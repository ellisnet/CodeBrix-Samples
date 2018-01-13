using HamburgerMenu.Services;
using Prism.Commands;
using Prism.Navigation;

namespace HamburgerMenu.ViewModels
{
    public class ViewAViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public ViewAViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "View A";
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
