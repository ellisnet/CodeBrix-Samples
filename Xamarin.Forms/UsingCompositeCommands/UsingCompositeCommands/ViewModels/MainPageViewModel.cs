using System;
using System.Threading.Tasks;
using CodeBrix.Mvvm;
using CodeBrix.Services;
using Prism.Navigation;

namespace UsingCompositeCommands.ViewModels
{
    public class MainPageViewModel : CodeBrixViewModelBase, INavigatedAware
    {
        private readonly IUserDialogService _dialogService;

        private IApplicationCommands _applicationCommand;
        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommand;
            set => SetProperty(ref _applicationCommand, value);
        }

        public MainPageViewModel(IApplicationCommands applicationCommands, IUserDialogService dialogService)
        {
            ApplicationCommands = applicationCommands;
            _dialogService = dialogService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //Nothing to do here
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
            _dialogService.Toast("UsingCompositeCommands sample app created for Prism by Brian Lagunas.", TimeSpan.FromSeconds(3));
        }
    }
}
