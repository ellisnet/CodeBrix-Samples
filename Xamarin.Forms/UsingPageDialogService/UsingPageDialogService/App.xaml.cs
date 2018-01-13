using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBrix;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UsingPageDialogService.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UsingPageDialogService
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
