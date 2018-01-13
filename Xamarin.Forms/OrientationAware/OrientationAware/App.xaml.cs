using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeBrix;
using OrientationAware.ViewModels;
using OrientationAware.Views;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]

namespace OrientationAware
{
	public partial class App : CodeBrixApplication
	{
	    public App(IPlatformConfiguration config = null) : base(config) { }

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        NavigationService.NavigateAsync(nameof(MainPage));
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

	    protected override void RegisterTypes(ICodeBrixContainer container)
	    {
	        //Register the pages and custom types required by the application here
	        
	        // The main view on Android will be MainPageDroid; the main view on iOS will be MainPageiOS; all others will be MainPage
	        // (and all will use MainPageViewModel as the viewmodel) and all will be navigate-to-able via nameof(MainPage)
            container.RegisterForNavigationOnPlatform<MainPage, MainPageViewModel>(androidView: typeof(MainPageDroid), iOSView: typeof(MainPageiOS));
	    }
	}
}
