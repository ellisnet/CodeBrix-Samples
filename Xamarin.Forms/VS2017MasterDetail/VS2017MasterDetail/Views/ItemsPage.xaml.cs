//CODEBRIX-CONVERSION-NOTE: A lot of usings no longer needed
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using VS2017MasterDetail.Models;
//using VS2017MasterDetail.Views;
//using VS2017MasterDetail.ViewModels;

namespace VS2017MasterDetail.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
	    //CODEBRIX-CONVERSION-NOTE: No longer need to reference the viewmodel in our view
        //ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            //CODEBRIX-CONVERSION-NOTE: Prism sets the BindingContext for us - 
            //BindingContext = viewModel = new ItemsViewModel();
        }

	    //CODEBRIX-CONVERSION-NOTE: All of the following logic has been moved to the ItemsViewModel class -

        //async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var item = args.SelectedItem as Item;
        //    if (item == null)
        //        return;

        //    await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

        //    // Manually deselect item.
        //    ItemsListView.SelectedItem = null;
        //}

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (viewModel.Items.Count == 0)
        //        viewModel.LoadItemsCommand.Execute(null);
        //}
    }
}