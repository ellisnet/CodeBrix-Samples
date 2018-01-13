using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CodeBrix;

using HamburgerMenu.Services;
using HamburgerMenu.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace HamburgerMenu
{
	public partial class App : CodeBrixApplication
	{
	    public App(IPlatformConfiguration platformConfig) : base(platformConfig)
	    { }

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        NavigationService.NavigateWithNavigationPageAsync(nameof(LoginPage));
	    }

	    protected override void RegisterTypes(ICodeBrixContainer container)
	    {
	        container.RegisterForNavigation<MainPage>();
	        container.RegisterForNavigation<LoginPage>();
	        container.RegisterForNavigation<ViewA>();
	        container.RegisterForNavigation<ViewB>();
	        container.RegisterForNavigation<ViewC>();

	        container.RegisterLazySingleton(typeof(IAuthenticationService), typeof(AuthenticationService));
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

	    protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
