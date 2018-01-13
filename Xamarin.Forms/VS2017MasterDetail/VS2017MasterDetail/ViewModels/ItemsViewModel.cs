using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

//using Xamarin.Forms; - no longer used

using VS2017MasterDetail.Models;
using VS2017MasterDetail.Views;

//CODEBRIX-CONVERSION-NOTE: Additional usings for CodeBrix (which is built on Prism)
using CodeBrix.Services;
using Prism.Commands;
using Prism.Navigation;
using VS2017MasterDetail.Services;

namespace VS2017MasterDetail.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        //CODEBRIX-CONVERSION-NOTE: We will now be passing in services that we need in the viewmodel via 
        // constructor parameters - which is the Prism Way(TM)
        // In this ViewModel, we need the NavigationService, our DataStore (service), and the
        // MessagingService
        private readonly INavigationService _navigationService;
        private readonly IDataStore<Item> _dataStore;
        private readonly IMessagingService _messagingService;

        //CODEBRIX-CONVERSION-NOTE: We will be identifying which item was selected from the list using this
        //  SelectedItem property. When an item is selected (unless it is null) we will navigate to the
        //  ItemDetailPage, providing the selected item to the new page via the NavigationParameters collection.
        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                if (value != null)
                {
                    Task.Run(async () => {
                        //When the user returns to the Items list, the most recently visited item
                        //  will no longer be selected.
                        await Task.Delay(500);
                        this.SelectedItem = null;
                    });
                    _navigationService.NavigateAsync(nameof(ItemDetailPage), new NavigationParameters { { "item", value } });
                }
            }
        }

        //CODEBRIX-CONVERSION-NOTE: Changed the LoadItemsCommand to be a Prism DelegateCommand and added an 
        //  AddItemCommand to be bound to the view's Add Item toolbar button.
        public DelegateCommand LoadItemsCommand { get; set; }
        public DelegateCommand AddItemCommand { get; set; }

        //CODEBRIX-CONVERSION-NOTE: Now using Prism dependency injection for the INavigationService, IDataStore
        // and IMessagingService instances - note that in Prism, the name of the NavigationService parameter is
        // picky - it must be named "navigationService"
        public ItemsViewModel(INavigationService navigationService, IDataStore<Item> dataStore, IMessagingService messagingService)
        {
            //CODEBRIX-CONVERSION-NOTE: Five more changes to this constructor -

            //  1. Store our injected instances in our fields that we created above
            _navigationService = navigationService;
            _dataStore = dataStore;
            _messagingService = messagingService;

            Title = "Browse";
            Items = new ObservableCollection<Item>();

            //  2. LoadItemsCommand is a Prism DelegateCommand now, as mentioned above
            LoadItemsCommand = new DelegateCommand(async () => await ExecuteLoadItemsCommand());

            //  3. The object that will send the "AddItem" message will now be the NewItemViewModel instead of the 
            //       NewItemPage, so our MessagingCenter.Subscribe<> Type parameter needed to be changed.
            //       Also, in CodeBrix, we try to avoid referencing Xamarin.Forms-namespace items directly in our
            //       viewmodels; this will make them more testable - e.g. for Continuous Integration tests.
            //       So, using our IMessagingService instance (which uses MessageCenter behind the scenes) to subscribe, 
            //       instead of accessing MessagingCenter directly.
            _messagingService.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await _dataStore.AddItemAsync(_item);
            });

            //  4. Implement our new AddItemCommand for navigating to the NewItemPage when user taps "Add Item"
            AddItemCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync(nameof(NewItemPage)));

            //  5. Call our LoadItemsCommand to perform the initial load of items
            LoadItemsCommand.Execute();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}