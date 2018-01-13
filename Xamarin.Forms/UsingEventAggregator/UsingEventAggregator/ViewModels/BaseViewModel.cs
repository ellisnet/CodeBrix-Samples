using System;
using CodeBrix.Mvvm;
using Prism.Navigation;

namespace UsingEventAggregator.ViewModels
{
    public class BaseViewModel : CodeBrixViewModelBase, INavigationAware, IDisposable
    {
        #region Properties

        private string _title;
        public string Title
        {
        	get => _title;
            set => SetProperty (ref _title, value);
        }

        #endregion

        #region INavigationAware

        public virtual void OnNavigatedFrom (NavigationParameters parameters) { }

        public virtual void OnNavigatedTo (NavigationParameters parameters) { }

        public virtual void OnNavigatingTo (NavigationParameters parameters) { }

        #endregion

        #region IDisposable

        public virtual void Dispose() { }
        
        #endregion
    }
}
