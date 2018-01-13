using System;
using System.Threading.Tasks;
using CodeBrix.Services;
using HamburgerMenu.Services;
using Prism.Commands;
using Prism.Navigation;

namespace HamburgerMenu.ViewModels
{
    public class LoginPageViewModel : BaseViewModel, INavigatedAware
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserDialogService _dialogService;

        public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IUserDialogService dialogService)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
            _dialogService = dialogService;

            Title = "Login";

            LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password);
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand LoginCommand { get; }

        private async void OnLoginCommandExecuted()
        {
            IsBusy = true;
            if(_authenticationService.Login(UserName, Password))
            {
                await _navigationService.NavigateAsync($"/MainPage/NavigationPage/ViewA?message=Glad%20you%20read%20the%20code");
            }
            else
            {
                await _dialogService.AlertAsync("Don't you know Prism Rocks? Cuz that's the password, no spaces, and it doesn't matter about caps...", "Seriously???", "I didn't read the code...");
            }
            IsBusy = false;
        }

        private bool LoginCommandCanExecute() =>
            !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && IsNotBusy;

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast

            _dialogService.Toast("HamburgerMenu sample app created for Prism by Dan Siegel.",
                TimeSpan.FromSeconds(3));
        }
    }
}
