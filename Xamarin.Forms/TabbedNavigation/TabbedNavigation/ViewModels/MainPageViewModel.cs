using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBrix.Services;
using TabbedNavigation.Views;

namespace TabbedNavigation.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogService _dialogService;

        private static bool showedDemoMessage;

        public MainPageViewModel(INavigationService navigationService, IUserDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
            LaunchDynamicTabbedPageCommand = new DelegateCommand(OnLaunchDynamicTabbedPageCommandExecuted);
        }

        private bool _showViewA;
        public bool ShowViewA
        {
            get => _showViewA;
            set => SetProperty(ref _showViewA, value);
        }

        private bool _showViewB;
        public bool ShowViewB
        {
            get => _showViewB;
            set => SetProperty(ref _showViewB, value);
        }

        private bool _showViewC;
        public bool ShowViewC
        {
            get => _showViewC;
            set => SetProperty(ref _showViewC, value );
        }

        public DelegateCommand<string> NavigateCommand { get; }

        public DelegateCommand LaunchDynamicTabbedPageCommand { get; }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (!showedDemoMessage)
            {
                await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
                _dialogService.Toast("TabbedNavigation sample app created for Prism by Dan Siegel.", TimeSpan.FromSeconds(3));
                showedDemoMessage = true;
            }
        }

        private void OnNavigateCommandExecuted(string path) =>
            _navigationService.NavigateAsync(path);

        private void OnLaunchDynamicTabbedPageCommandExecuted()
        {
            string path = nameof(DynamicTabbedPage);
            var children = new List<string>();
            if (ShowViewA)
            {
                children.Add("addTab=ViewA");
            }

            if (ShowViewB)
            {
                children.Add("addTab=ViewB");
            }

            if (ShowViewC)
            {
                children.Add("addTab=ViewC");
            }

            if (children.Count > 0)
            {
                path += "?" + string.Join("&", children);
            }

            _navigationService.NavigateAsync(path);
        }
    }
}
