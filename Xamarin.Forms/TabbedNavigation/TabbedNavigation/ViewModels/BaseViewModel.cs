using CodeBrix.Mvvm;
using Prism.Navigation;

namespace TabbedNavigation.ViewModels
{
    public class BaseViewModel : CodeBrixViewModelBase, INavigatingAware, IDestructible
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public virtual void Destroy()
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
