using Prism.Navigation;
using Prism.Mvvm;

using Xamarin.Forms;

using CodeBrix;

namespace TabbedNavigation.Views
{
    public partial class DynamicTabbedPage : TabbedPage, INavigatingAware
    {
        private readonly ICodeBrixContainer _container;

        public DynamicTabbedPage(ICodeBrixContainer container)
        {
            InitializeComponent();
            _container = container;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{Title} OnNavigatingTo");
            var tabs = parameters.GetValues<string>("addTab");
            foreach(var name in tabs)
            {
                AddChild(name, new NavigationParameters {{ "message", "Hello from DynamicTabbedPage" }});
            }
        }

        private void AddChild(string name, NavigationParameters parameters)
        {
            var page = _container.Resolve<Page>(name);

            if (ViewModelLocator.GetAutowireViewModel(page) == null)
            {
                ViewModelLocator.SetAutowireViewModel(page, true);
            }

            (page as INavigatingAware)?.OnNavigatingTo(parameters);
            (page?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);

            Children.Add(page);
        }
    }
}
