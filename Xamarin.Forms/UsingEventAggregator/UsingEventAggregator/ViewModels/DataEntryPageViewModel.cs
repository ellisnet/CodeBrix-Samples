using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using UsingEventAggregator.Models;

namespace UsingEventAggregator.ViewModels
{
    public class DataEntryPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public DataEntryPageViewModel (INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "So what do you think?";
        }

        private bool _isFun;
        public bool IsFun
        {
            get => _isFun;
            set
            { 
                SetProperty (ref _isFun, value);
                NotifyPropertyChanged(nameof(LovingItHatingIt));
                _eventAggregator.GetEvent<IsFunChangedEvent>().Publish(value);
            }
        }

        public string LovingItHatingIt => _isFun ? "Loving it!" : "Hating it!";

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand => _submitCommand ?? (_submitCommand = new DelegateCommand (OnSubmitTapped));

        private void OnSubmitTapped()
        {
            _navigationService.GoBackAsync ();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            IsFun = parameters.GetValue<bool>("isCurrentlyFun");
        }
    }
}
