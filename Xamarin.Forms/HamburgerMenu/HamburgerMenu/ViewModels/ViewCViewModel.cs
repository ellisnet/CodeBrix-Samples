using HamburgerMenu.Services;
using Prism.Commands;
using Prism.Navigation;

namespace HamburgerMenu.ViewModels
{
    public class ViewCViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public ViewCViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "View C";
            _authenticationService = authenticationService;
            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand LogoutCommand { get; }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        public void OnLogoutCommandExecuted() =>
            _authenticationService.Logout();
    }
}
