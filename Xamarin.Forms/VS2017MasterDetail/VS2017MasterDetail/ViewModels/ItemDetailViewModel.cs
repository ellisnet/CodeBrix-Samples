using System;
using VS2017MasterDetail.Models;

//CODEBRIX-CONVERSION-NOTE: Additional usings for CodeBrix (which is built on Prism)
using CodeBrix.Mvvm;
using Prism.Navigation;

namespace VS2017MasterDetail.ViewModels
{
    //CODEBRIX-CONVERSION-NOTE: The viewmodel now implements INavigationAware with OnNavigatingTo(), OnNavigatedTo() 
    //  and OnNavigatedFrom() methods. The item (to show detail for) is being provided via a navigation parameter
    //  instead of as a constructor parameter - see below.

    //  Also, this ViewModel class is going to be created everytime a user browses to an item in our list of items
    //  - so we want to 'Destroy' each viewmodel instance to clean up after it (similar to the IDisposable interface).
    //  Prism gives us an interface to implement that should cause our Destroy() method to be called automatically -
    //  IDestructible - but this does not work correctly with Master/Detail interfaces under certain circumstances.
    //  So instead we are calling the more pro-active CodeBrix version: IDestructibleWithAssist
    //  Note that this may result in our Destroy() method below being called more than once.
    public class ItemDetailViewModel : BaseViewModel, INavigationAware, IDestructibleWithAssist
    {
        //CODEBRIX-CONVERSION-NOTE: Updated Item to be a notification-generating property -
        //  was previously: public Item Item { get; set; }
        private Item _item;
        public Item Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        //CODEBRIX-CONVERSION-NOTE: This is the old constructor that allows the Item to be viewed to be passed in
        //  via a parameter; in Prism we usually pass these objects as NavigationParameters members, and look for
        //  them in the OnNavigatedTo() method (below) -
        //public ItemDetailViewModel(Item item = null)
        //{
        //    Title = item?.Text;
        //    Item = item;
        //}

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //Called before the implementor has been navigated to - but not called when using 
            // device hardware or software back buttons.

            //Assignment of values to UI-element-bound-properties less visible to users (than OnNavigatedTo())

            //CODEBRIX-CONVERSION-NOTE: Now getting our item as a NavigationParameters member, instead of via 
            //  constructor injection.
            if (parameters?["item"] is Item item)
            {
                Title = item.Text;
                Item = item;
            }
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            // Updating UI-element-bound-properties here may cause the change from 
            // not-assigned -> assigned to be visible to the user
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated away from.
        }

        public void Destroy()
        {
            //Free up resources that are used by the ViewModel here
            _item = null;

            //Note that since we have implemented IDestructibleWithAssist we should be prepared for this method
            // to be called more than once - which is fine, because the above code can executed multiple times.
        }
    }
}
