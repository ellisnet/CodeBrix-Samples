using Prism.Commands;
using System;
using System.Globalization;
using CodeBrix.Mvvm;

namespace UsingCompositeCommands.ViewModels
{
    public class TabViewModel : CodeBrixViewModelBase
    {
        private string _lastSaved;
        public string LastSaved
        {
            get => _lastSaved;
            set => SetProperty(ref _lastSaved, value);
        }

        public DelegateCommand SaveCommand => new DelegateCommand(Save);
        public DelegateCommand ResetCommand => new DelegateCommand(Reset);

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            applicationCommands.SaveCommand.RegisterCommand(SaveCommand);
            applicationCommands.ResetCommand.RegisterCommand(ResetCommand);
        }

        private void Save()
        {
            LastSaved = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }

        private void Reset()
        {
            LastSaved = "Reset - no value";
        }
    }
}
