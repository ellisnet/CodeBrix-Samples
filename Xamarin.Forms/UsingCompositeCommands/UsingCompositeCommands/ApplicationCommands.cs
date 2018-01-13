using Prism.Commands;

namespace UsingCompositeCommands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
        CompositeCommand ResetCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        readonly CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand => _saveCommand;

        readonly CompositeCommand _resetCommand = new CompositeCommand();
        public CompositeCommand ResetCommand => _resetCommand;
    }
}
