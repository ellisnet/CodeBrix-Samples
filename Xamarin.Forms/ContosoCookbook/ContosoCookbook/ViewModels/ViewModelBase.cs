using System.Diagnostics;
using CodeBrix.Mvvm;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
    public class ViewModelBase : CodeBrixViewModelBase, INavigationAware, IDestructible
    {
        public ViewModelBase()
        {

        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public void Destroy()
        {
            Debug.WriteLine("Destroy called");
        }
    }
}
