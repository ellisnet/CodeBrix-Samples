using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Xaml;

using CodeBrix;

using UsingDependencyService.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UsingDependencyService
{
	public partial class App : CodeBrixApplication
	{
	    public App(IPlatformConfiguration config = null) : base(config) { }

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        NavigationService.NavigateAsync(nameof(MainPage));
	    }

	    protected override void RegisterTypes(ICodeBrixContainer container)
	    {
	        container.RegisterForNavigation<MainPage>();
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
