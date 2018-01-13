using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeBrix.Services;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using Module = UsingModules.SampleModule.SampleModule; 
using UsingModules.SampleModule.Views;

namespace UsingModules.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IModuleManager _moduleManager;
        private readonly INavigationService _navigationService;
        private readonly IUserDialogService _dialogService;

        private bool _showedSampleInfo;

        public MainPageViewModel(IModuleManager moduleManager, INavigationService navigationService, IUserDialogService dialogService)
        {
            _moduleManager = moduleManager;
            _navigationService = navigationService;
            _dialogService = dialogService;

            LoadSampleModuleCommand = new DelegateCommand(LoadSampleModule, ()=>!IsSampleModuleRegistered)
                .ObservesProperty(()=>IsSampleModuleRegistered);
            NavigateToSamplePageCommand = new DelegateCommand(NavigateToSamplePage, ()=>IsSampleModuleRegistered)
                .ObservesProperty(()=>IsSampleModuleRegistered);
        }

        private bool _isSampleModuleRegistered;
        public bool IsSampleModuleRegistered
        {
            get => _isSampleModuleRegistered;
            set => SetProperty(ref _isSampleModuleRegistered, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand LoadSampleModuleCommand { get; set; }

        public ICommand NavigateToSamplePageCommand { get; set; }

        private void NavigateToSamplePage()
        {
            _navigationService.NavigateAsync($"{nameof(SamplePage)}?par=test");
        }

        private void LoadSampleModule()
        {
            _moduleManager.LoadModule(Module.ModuleName);
            IsSampleModuleRegistered = true;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated away from.
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            if (parameters.ContainsKey("title"))
            {
                Title = (string)parameters["title"] + " and Prism";
            }

            if (!_showedSampleInfo)
            {
                await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
                _dialogService.Toast("UsingModules sample app created for Prism by Davide Zordan.", TimeSpan.FromSeconds(3));
                _showedSampleInfo = true;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //Called before the implementor has been navigated to - but not called when using 
            // device hardware or software back buttons.
        }
    }
}
