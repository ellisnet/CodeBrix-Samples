using Prism.Events;
using TabbedNavigation.Events;

namespace TabbedNavigation.ViewModels
{
    public class EventInitializingTabbedPageViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        public EventInitializingTabbedPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Title = "Event Initialized";
        }

        public override void OnNavigatingTo(Prism.Navigation.NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{Title} OnNavigatingTo");
            _eventAggregator.GetEvent<InitializeTabbedChildrenEvent>().Publish(parameters);
        }
    }
}
