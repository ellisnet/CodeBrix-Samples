using CodeBrix;
using TabbedNavigation.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TabbedNavigation
{
	public partial class App : CodeBrixApplication
	{
	    public App(IPlatformConfiguration config = null) : base(config) { }

	    protected override void OnInitialized()
	    {
	        InitializeComponent();
	        NavigationService.NavigateWithNavigationPageAsync(nameof(MainPage));
	    }

	    protected override void RegisterTypes(ICodeBrixContainer container)
	    {
	        container.RegisterForNavigation<MainPage>();
	        container.RegisterForNavigation<NavigatingAwareTabbedPage>();
	        container.RegisterForNavigation<EventInitializingTabbedPage>();
	        container.RegisterForNavigation<DynamicTabbedPage>(() => new DynamicTabbedPage(container));
	        container.RegisterForNavigation<ViewA>();
	        container.RegisterForNavigation<ViewB>();
	        container.RegisterForNavigation<ViewC>();
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
