using CodeBrix.Services;
using Prism.Commands;
using Prism.Navigation;
using VS2017MasterDetail.Models;

//CODEBRIX-CONVERSION-NOTE: This new NewItemViewModel class was created so that logic could be removed from the 
//  NewItemPage.xaml.cs code-behind file. When using CodeBrix, our XAML page code-behind files should be as empty
//  as possible.

namespace VS2017MasterDetail.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IMessagingService _messagingService;

        public Item Item { get; set; }

        public DelegateCommand SaveItemCommand { get; set; }

        public NewItemViewModel(INavigationService navigationService, IMessagingService messagingService)
        {
            _navigationService = navigationService;
            _messagingService = messagingService;

            Item = new Item
            {
                Text = "Item name",
                Description = "This is a nice description"
            };

            SaveItemCommand = new DelegateCommand(async () => {
                _messagingService.Send(this, "AddItem", Item);
                await _navigationService.GoBackAsync();
            });
        }
    }
}
