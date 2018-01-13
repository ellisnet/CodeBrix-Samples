using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CodeBrix;
using ContosoCookbook.Services;
using ContosoCookbook.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace ContosoCookbook
{
    public partial class App : CodeBrixApplication
    {
        public App(IPlatformConfiguration platformConfig) : base(platformConfig) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateWithNavigationPageAsync(nameof(MainPage));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(ICodeBrixContainer container)
        {
            container.RegisterForNavigation<MainPage>();
            container.RegisterForNavigation<RecipePage>();

            container.RegisterLazySingleton(() => new RecipeService(), typeof(IRecipeService));
        }
    }
}
