using ContosoCookbook.Business;
using ContosoCookbook.ViewModels;
using Xamarin.Forms;

namespace ContosoCookbook.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((MainPageViewModel)BindingContext).SelectRecipeCommand.Execute((Recipe)args.Item);
        }
    }
}
