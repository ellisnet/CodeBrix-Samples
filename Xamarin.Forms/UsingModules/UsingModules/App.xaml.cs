using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBrix;
using UsingModules.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UsingModules.SampleModule;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UsingModules
{
	public partial class App : CodeBrixApplication
	{
	    public App(IPlatformConfiguration config = null) : base(config) { }

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        NavigationService.NavigateWithNavigationPageAsync($"{nameof(MainPage)}?title=Hello%20from%20Xamarin.Forms");
	    }

	    protected override void RegisterTypes(ICodeBrixContainer container)
        {
	        container.RegisterForNavigation<MainPage>();
	    }

	    protected override void RegisterModules(ICodeBrixContainer container)
	    {
            //Since the sample module has a default InitializationMode of OnDemand, this will cause the module
            // to have its types registered, and to be initialized, on the first LoadModule() request.
            container.RegisterModule(new SampleModuleInfo());

            //If we wanted its types to be registered, and for it to be initialized, during initial
            // application load; we can change that by modifying the RegisterModule() call like this:
            //container.RegisterModule(new SampleModuleInfo{ InitializationMode = InitializationMode.WhenAvailable});
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
