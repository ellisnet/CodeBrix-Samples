using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using Xamarin.Forms; - no longer used

using VS2017MasterDetail.Models;
using VS2017MasterDetail.Services;

//CODEBRIX-CONVERSION-NOTE: Additional usings required for CodeBrix and the changes made below -
using CodeBrix.Mvvm;

namespace VS2017MasterDetail.ViewModels
{

    //CODEBRIX-CONVERSION-NOTE: With Prism, we want all of our viewmodels to inherit from BindableBase;
    // with CodeBrix, we have CodeBrixViewModelBase with additional properties and functionality -
    // but which also inherits from BindableBase.  So, to make things easy - since we already have a common
    // BaseViewModel that the other ViewModels inherit from - we will just set this BaseViewModel to inherit
    // from CodeBrixViewModelBase
    public class BaseViewModel : CodeBrixViewModelBase
    {
        //CODEBRIX-CONVERSION-NOTE: We will now be getting the DataStore in our individual viewmodels (where
        // needed) via constructor injection - as that is the Prism Way(TM)
        //public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            //CODEBRIX-CONVERSION-NOTE: Swiched to NotifyPropertyChanged because OnPropertyChanged is obsolete in Prism
            NotifyPropertyChanged(propertyName);
            //OnPropertyChanged(propertyName);
            return true;
        }

        //CODEBRIX-CONVERSION-NOTE: CodeBrixViewModelBase already has an implementation of INotifyPropertyChanged
        // - so, we can comment out this implementation
        //#region INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    var changed = PropertyChanged;
        //    if (changed == null)
        //        return;

        //    changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //#endregion
    }

    //CODEBRIX-CONVERSION-NOTE: This is sort of extra-credit... just a nice-to-have for ReSharper (and other
    //  Visual Studio plug-in tools?) when editing XAML files that work with Prism-based ViewModels...
    //  This special class will allow us to have IntelliSense while we are editing our XAML view files in Visual
    //  Studio with ReSharper.  I.e. it is for design-time only, and does nothing at compile-time or run-time.
    //  For more info, check these pages -
    //  https://github.com/PrismLibrary/Prism/issues/986
    //  https://gist.github.com/nuitsjp/7478bfc7eba0f2a25b866fa2e7e9221d
    //  https://blog.nuits.jp/enable-intellisense-for-viewmodel-members-with-prism-for-xamarin-forms-2f274e7c6fb6
    public static class DesignTimeViewModelLocator
    {
        public static AboutViewModel AboutPage => null;
        public static ItemDetailViewModel ItemDetailPage => null;
        public static ItemsViewModel ItemsPage => null;
        public static NewItemViewModel NewItemPage => null;
    }
}
