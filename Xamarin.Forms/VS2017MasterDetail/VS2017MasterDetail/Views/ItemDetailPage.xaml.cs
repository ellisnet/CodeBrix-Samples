//CODEBRIX-CONVERSION-NOTE: A lot of usings no longer needed
//using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using VS2017MasterDetail.Models;
//using VS2017MasterDetail.ViewModels;

namespace VS2017MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        //CODEBRIX-CONVERSION-NOTE: No longer need to reference the viewmodel in our view
        //ItemDetailViewModel viewModel;

	    //CODEBRIX-CONVERSION-NOTE: No longer need this constructor - won't be passing in
	    // a viewmodel instance.
        //public ItemDetailPage(ItemDetailViewModel viewModel)
        //{
        //    InitializeComponent();

        //    BindingContext = this.viewModel = viewModel;
        //}

        public ItemDetailPage()
        {
            InitializeComponent();

            //CODEBRIX-CONVERSION-NOTE: Prism sets the BindingContext for us - 
            // and the new Item logic has been moved to the NewItemViewModel
            //var item = new Item
            //{
            //    Text = "Item 1",
            //    Description = "This is an item description."
            //};

            //viewModel = new ItemDetailViewModel(item);
            //BindingContext = viewModel;
        }
    }
}