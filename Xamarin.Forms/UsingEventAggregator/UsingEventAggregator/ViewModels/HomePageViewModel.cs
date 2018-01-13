using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using UsingEventAggregator.Models;
using UsingEventAggregator.Views;

namespace UsingEventAggregator.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator; 

        public HomePageViewModel (INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "Your Current Feedback (Read only)";

            _eventAggregator.GetEvent<IsFunChangedEvent>().Subscribe (IsFunChanged);
        }
        
        public void IsFunChanged (bool isFun)
        {
            IsFun = isFun;
        }
        
        #region Properties

        private bool _isFun;
        public bool IsFun
        {
            get => _isFun;
            set
            {
                SetProperty(ref _isFun, value);
                NotifyPropertyChanged(nameof(LovingItHatingIt));
            }
        }

        public string LovingItHatingIt => _isFun ? "Loving it!" : "Hating it!";

        #endregion

        #region Commands

        private DelegateCommand _entryCommand;
        public DelegateCommand EntryCommand => _entryCommand ?? (_entryCommand = new DelegateCommand (OnEntryCommandTapped));

        private void OnEntryCommandTapped ()
        {
            _navigationService.NavigateAsync(nameof(DataEntryPage), new NavigationParameters{{"isCurrentlyFun", _isFun}});
        }

        private DelegateCommand _goBackCommand;
        public DelegateCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new DelegateCommand (OnGoBackCommandTapped));

        private void OnGoBackCommandTapped ()
        {
            _navigationService.GoBackAsync ();
        }
        #endregion

        #region Overrides

        public override void Dispose ()
        {
            _eventAggregator.GetEvent<IsFunChangedEvent>().Unsubscribe (IsFunChanged);
        }

        #endregion
    }
}
