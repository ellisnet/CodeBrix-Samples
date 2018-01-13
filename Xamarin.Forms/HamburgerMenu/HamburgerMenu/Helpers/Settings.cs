// Helpers/Settings.cs
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HamburgerMenu.Helpers
{
    public class Settings : INotifyPropertyChanged
    {
        private static Lazy<Settings> SettingsInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Current => SettingsInstance.Value;

        private Settings()
        {
        }

        private static ISettings AppSettings => CrossSettings.Current;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if(!string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // ReSharper disable once UnusedMethodReturnValue.Local
        bool SetProperty(string value, string defaultValue = null, [CallerMemberName] string propertyName = null)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
            {
                return false;
            }

            if(Equals(AppSettings.GetValueOrDefault(propertyName, defaultValue), value))
            {
                return false;
            }

            AppSettings.AddOrUpdateValue(propertyName, value);
            RaisePropertyChanged(propertyName);

            return true;
        }

        #endregion INotifyPropertyChanged

        string GetProperty(string defaultValue = null, [CallerMemberName]string propertyName = null)
        {
            if(string.IsNullOrWhiteSpace(propertyName))
            {
                return defaultValue;
            }

            return AppSettings.GetValueOrDefault(propertyName, defaultValue);
        }

        public string UserName
        {
            get => GetProperty();
            set => SetProperty(value);
        }
    }
}