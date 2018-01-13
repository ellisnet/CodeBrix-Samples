using CodeBrix.Mvvm;
using Prism.Navigation;

namespace UsingModules.SampleModule.ViewModels
{
    public class SamplePageViewModel : CodeBrixViewModelBase, INavigationAware, IDestructible
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated away from.
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            Title = "Sample Page from a Prism module";
            if (parameters.ContainsKey("par"))
            {
                Title += " - parameter: " + (string)parameters["par"];
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //Called before the implementor has been navigated to - but not called when using 
            // device hardware or software back buttons.
        }

        public void Destroy()
        {
            //Called when user navigates back to parent, and SamplePage is removed from the nav 
            // stack - IDisposable.Dispose()-type logic should be put here.
        }
    }
}
