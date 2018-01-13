//CODEBRIX-CONVERSION-NOTE: A lot of usings no longer needed
//using System;
//using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using VS2017MasterDetail.Models;

namespace VS2017MasterDetail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        //CODEBRIX-CONVERSION-NOTE: Item-handling logic moved to viewmodel class
        //public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            //CODEBRIX-CONVERSION-NOTE: Item-handling logic moved to viewmodel class
            //Item = new Item
            //{
            //    Text = "Item name",
            //    Description = "This is an item description."
            //};

            //CODEBRIX-CONVERSION-NOTE: Prism sets the BindingContext for us - 
            //BindingContext = this;
        }

        //CODEBRIX-CONVERSION-NOTE: Item-handling logic moved to viewmodel class
        //async void Save_Clicked(object sender, EventArgs e)
        //{
        //    MessagingCenter.Send(this, "AddItem", Item);
        //    await Navigation.PopModalAsync();
        //}
    }
}