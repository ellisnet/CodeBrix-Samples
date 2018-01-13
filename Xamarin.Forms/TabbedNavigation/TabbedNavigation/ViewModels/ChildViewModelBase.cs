using Prism;
using Prism.Events;
using Prism.Navigation;
using TabbedNavigation.Events;
using System;

namespace TabbedNavigation.ViewModels
{
    public class ChildViewModelBase : BaseViewModel, IActiveAware
    {
        private readonly IEventAggregator _eventAggregator;

        public ChildViewModelBase( IEventAggregator eventAggregator )
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<InitializeTabbedChildrenEvent>().Subscribe(OnInitializationEventFired);
            IsActiveChanged += (sender, e) => System.Diagnostics.Debug.WriteLine($"{Title} IsActive: {IsActive}");
        }

        public event EventHandler IsActiveChanged;

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set { SetProperty(ref _isActive, value, () => System.Diagnostics.Debug.WriteLine($"{Title} IsActive Changed: {value}")); }
        }

        //TODO: Currently having a problem where the viewmodel OnNavigatingTo() method is being called twice when the 
        // 'Show Dynamic Tabbed Page' button is clicked.  First *with* the correct NavigationParameters collection;
        // and then second with a Null collection.
        // So, using this _savedMessage field to save the 'message' parameter value from the first call.
        private string _savedMessage;

        void OnInitializationEventFired(NavigationParameters parameters)
        {
            var message = parameters.GetValue<string>("message");
            System.Diagnostics.Debug.WriteLine($"{Title} Detected an initialization event, with 'message' parameter value: {message}");
            Message = $"{Title} Initialized by Event: {message}";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            var message = parameters.GetValue<string>("message");
            //See note about _savedMessage above
            _savedMessage = _savedMessage ?? message;
            System.Diagnostics.Debug.WriteLine($"{Title} is executing OnNavigatingTo, with 'message' parameter value: {message}");
            Message = $"{Title} Initialized by OnNavigatingTo: {_savedMessage}";
        }

        public override void Destroy()
        {
            System.Diagnostics.Debug.WriteLine($"{Title} is being Destroyed!");
            _eventAggregator.GetEvent<InitializeTabbedChildrenEvent>().Unsubscribe(OnInitializationEventFired);
        }
    }
}
