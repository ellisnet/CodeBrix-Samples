using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBrix;
using UsingEventAggregator.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UsingEventAggregator
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
	        container.RegisterForNavigation<HomePage>();
	        container.RegisterForNavigation<DataEntryPage>();
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
