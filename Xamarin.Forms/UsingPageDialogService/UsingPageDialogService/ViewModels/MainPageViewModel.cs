using System;
using Prism.Commands;
using Prism.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using CodeBrix.DeviceView;
using CodeBrix.Mvvm;
using CodeBrix.Services;
using Prism.Navigation;

namespace UsingPageDialogService.ViewModels
{
    public class MainPageViewModel : CodeBrixViewModelBase, IOrientationAware, INavigatedAware
    {
        //IMPORTANT - Please read:
        
        //Prism version 7 ships with the PageDialogService - a simple service for soliciting 
        // user feedback via Alerts and ActionSheets -
        // Alert - is a simple popup message with an OK button or OK/Cancel
        // ActionSheet - is similar to an Alert, but can have multiple options for the 
        //  for the user to choose from, plus "Cancel" and "Destroy" buttons - which could
        //  be labeled whatever you want.  On Android, the "Cancel" and "Destroy" buttons 
        //  appear the same; but on iOS, the "Cancel" button appears on the bottom - separated
        //  from other options, while "Destroy" appears at the top in a different color - as 
        //  if it is the "dangerous" option.
        private readonly IPageDialogService _pageDialogService;

        //CodeBrix also ships with the UserDialogService which wraps the excellent Acr.UserDialogs 
        // cross-platform Xamarin plug-in from Allan Ritchie. It has more options for user 
        // interaction and notification (e.g. Toasts - used below); 
        // read more about it and its features at:
        // https://github.com/aritchie/userdialogs
        private readonly IUserDialogService _userDialogService;

        public DelegateCommand DisplayAlertCommand { get; set; }
        public DelegateCommand DisplayActionSheetCommand { get; set; }

        public DelegateCommand DisplayActionSheetUsingActionSheetButtonsCommand { get; set; }

        public MainPageViewModel(IPageDialogService pageDialogService, IUserDialogService userDialogService)
        {
            RegisterForOrientationChange();

            _pageDialogService = pageDialogService;
            _userDialogService = userDialogService;

            DisplayAlertCommand = new DelegateCommand(DisplayAlert);

            DisplayActionSheetCommand = new DelegateCommand(DsiplayActionSheet);

            DisplayActionSheetUsingActionSheetButtonsCommand = new DelegateCommand(DisplayActionSheetUsingActionSheetButtons);
        }

        private async void DisplayAlert()
        {
            var result = await _pageDialogService.DisplayAlertAsync("Alert", "This is an alert from MainPageViewModel.", "Accept", "Cancel");
            Debug.WriteLine(result);
        }

        private async void DsiplayActionSheet()
        {
            var result = await _pageDialogService.DisplayActionSheetAsync("ActionSheet", "Cancel", "Destroy", "Option 1", "Option 2");
            Debug.WriteLine(result);
        }

        private void WriteResponse(string response)
        {
            Debug.WriteLine(response);
        }

        private async void DisplayActionSheetUsingActionSheetButtons()
        {
            IActionSheetButton option1Action = ActionSheetButton.CreateButton("Option 1", () =>
            {
                //Adding button with multi-line lambda Action
                int optionValue = 1;
                Debug.WriteLine($"Option {optionValue}");
            });
            IActionSheetButton option2Action = ActionSheetButton.CreateButton("Option 2", () => Debug.WriteLine("Option 2")); //Button with simple one-line lambda Action
            IActionSheetButton cancelAction = ActionSheetButton.CreateCancelButton("Cancel", WriteResponse, "Cancel"); //Using Action<string> to call a method

            await _pageDialogService.DisplayActionSheetAsync("ActionSheet with ActionSheetButtons", 
                option1Action, 
                option2Action, 
                cancelAction, 
                ActionSheetButton.CreateDestroyButton("Destroy", WriteResponse, "Destroy")); //Inline button creation
        }

        #region IOrientationAware implementation

        //RegisterForOrientationChange() should be called early in viewmodel initialization, e.g. constructor
        public void RegisterForOrientationChange()
        {
            SubscribeToOrientationChangeNotifications(this);
        }

        //UnregisterForOrientationChange() should be called when viewmodel is being disposed/destroyed -
        // so it won't be called in this single-view application (i.e. the view is never disposed)
        public void UnregisterForOrientationChange()
        {
            UnsubscribeFromOrientationChangeNotifications(this);
        }

        #endregion

        #region INavigatedAware implementation

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //Nothing to do here
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
            _userDialogService.Toast("UsingPageDialogService sample app created for Prism by Brian Lagunas.", TimeSpan.FromSeconds(3));
        }

        #endregion
    }
}
