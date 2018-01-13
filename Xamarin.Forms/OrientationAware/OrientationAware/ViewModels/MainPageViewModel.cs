using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CodeBrix.DeviceView;
using CodeBrix.Mvvm;
using CodeBrix.Services;
using Prism.Navigation;

namespace OrientationAware.ViewModels
{
    public class MainPageViewModel : CodeBrixViewModelBase, IOrientationAware, IDestructible, INavigatedAware
    {
        private readonly IUserDialogService _dialogService;

        public string OrientationText => $"Rendering this view in {(IsPortraitOrientation ? "Portrait" : "Landscape")} mode.";

        public string DeviceText => $"Rocking the {DeviceModel}, eh? Awesome!";

        //A bit of Android weirdness, explained below
        public bool AndroidLandscapeLeftOrientation => IsLandscapeLeftOrientation 
            || (IsPortraitUpsideDownOrientation 
                && PreviousOrientation == DeviceViewOrientation.LandscapeLeft);
        public bool AndroidLandscapeRightOrientation => IsLandscapeRightOrientation
            || (IsPortraitUpsideDownOrientation
                && PreviousOrientation == DeviceViewOrientation.LandscapeRight);
        public bool AndroidLandscapeOrientation => AndroidLandscapeLeftOrientation || AndroidLandscapeRightOrientation;
        public bool AndroidPortraitOrientation => IsPortraitNormalOrientation 
            || (IsPortraitUpsideDownOrientation && PreviousOrientation == DeviceViewOrientation.PortraitNormal);

        public string UpArrowPath => "Images/arrow_up.svg";
        public string DownArrowPath => "Images/arrow_down.svg";
        public string LeftArrowPath => "Images/arrow_left.svg";
        public string RightArrowPath => "Images/arrow_right.svg";

        public MainPageViewModel(IUserDialogService dialogService)
        {
            _dialogService = dialogService;
            RegisterForOrientationChange();
        }

        //We want to make sure that our UI knows that the OrientationText has changed when the orientation changes
        // - so we are overriding OnOrientationChanged() and adding a NotifyPropertyChanged() call for that.
        // It is not necessary to call base.OnOrientationChanged()
        public override void OnOrientationChanged()
        {
            NotifyPropertyChanged(nameof(OrientationText));

            //On Android, the app UI will not render in an upside-down orientation.  It will be whatever it was last.
            // But the soft button may (and a hard button *will*) move to the top. And the orientation will
            // switch to IsPortraitUpsideDownOrientation=true. So, for this demo, I want that to be called 
            // PortraitNormal, LandscapeLeft or LandscapeRight - based on what orientation the UI is stuck in.
            // Hence the special Android  properties.
            NotifyPropertyChanged(nameof(AndroidLandscapeLeftOrientation));
            NotifyPropertyChanged(nameof(AndroidLandscapeRightOrientation));
            NotifyPropertyChanged(nameof(AndroidLandscapeOrientation));
            NotifyPropertyChanged(nameof(AndroidPortraitOrientation));

            #region Throw up some console messages about the screen orientation, just for fun
            //TODO: So far, UWP only reports PortraitNormal or LandscapeLeft
            string currentOrientation =
                IsPortraitNormalOrientation
                    ? "Portrait - Normal"
                    : IsPortraitUpsideDownOrientation
                        ? " Portrait - Updside-Down"
                        : IsLandscapeLeftOrientation
                            ? "Landscape - with device bottom on right"
                            : IsLandscapeRightOrientation
                                ? "Landscape - with device bottom on left"
                                : IsPortraitOrientation
                                    ? "Portrait"
                                    : IsLandscapeOrientation
                                        ? "Landscape"
                                        : "Unknown";
            Debug.WriteLine($"Current orientation: {currentOrientation}");
            if (HasDisplayNotch) //For iPhone X (and simulator) only - so far
            {
                string notchPosition =
                    HasTopDisplayNotch
                        ? "Top"
                        : HasBottomDisplayNotch
                            ? "Bottom"
                            : HasRightDisplayNotch
                                ? "Right"
                                : HasLeftDisplayNotch
                                    ? "Left"
                                    : "";
                Debug.WriteLine($"Has the display notch on the {notchPosition}");
            }
            #endregion
        }

        //This will allow our ViewModel to start getting updated about device orientation changes
        // - RegisterForOrientationChange() should be called early in ViewModel setup (e.g. constructor)
        public void RegisterForOrientationChange()
        {
            SubscribeToOrientationChangeNotifications(this);
        }

        //This will allow our ViewModel to stop getting updated about device orientation changes
        // - UnregisterForOrientationChange() should be called when our ViewModel is being gotten rid of
        // - e.g. implement IDestructible and then call it in Destroy()
        public void UnregisterForOrientationChange()
        {
            UnsubscribeFromOrientationChangeNotifications(this);
        }

        //Implementation of IDestructible - will be called when our View and ViewModel are no longer needed.
        public void Destroy()
        {
            UnregisterForOrientationChange();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //Nothing to do here
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
            _dialogService.Toast("OrientationAware sample app created for CodeBrix by Jeremy Ellis.",
                TimeSpan.FromSeconds(3));
        }
    }
}
