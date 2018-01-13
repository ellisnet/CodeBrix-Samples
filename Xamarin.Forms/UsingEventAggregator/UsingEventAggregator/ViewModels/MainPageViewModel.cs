using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using CodeBrix.Services;
using Prism.Events;
using UsingEventAggregator.Views;
using UsingEventAggregator.Models;

namespace UsingEventAggregator.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IUserDialogService _dialogService;

        private static bool showedSampleMessage;

        public MainPageViewModel (INavigationService navigationService, IEventAggregator eventAggregator, IUserDialogService dialogService)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;

            Title = "Prism.Forms EventAggregator";
        }

        #region Commands

        private DelegateCommand _localCommand;
        public DelegateCommand LocalCommand => _localCommand ?? (_localCommand = new DelegateCommand (OnLocalCommandTapped));

        private void OnLocalCommandTapped ()
        {
            _navigationService.NavigateAsync (nameof (HomePage));
        }

        private DelegateCommand _nativeCommand;
        public DelegateCommand NativeCommand => _nativeCommand ?? (_nativeCommand = new DelegateCommand (OnNativeCommandTapped));

        private void OnNativeCommandTapped ()
        {
            _eventAggregator.GetEvent<NativeEvent>().Publish(new NativeEventArgs("Xamarin.Forms"));
        }

        #endregion

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (!showedSampleMessage)
            {
                await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
                _dialogService.Toast("UsingEventAggregator sample app created for Prism by Hussain Abbasi.", TimeSpan.FromSeconds(3));
                showedSampleMessage = true;
            }
        }
    }
}
