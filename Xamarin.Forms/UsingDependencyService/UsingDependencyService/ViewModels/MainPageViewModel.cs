using System;
using System.Threading.Tasks;
using CodeBrix.Mvvm;
using CodeBrix.Services;
using Prism.Commands;
using Prism.Navigation;
using UsingDependencyService.Services;

namespace UsingDependencyService.ViewModels
{
    public class MainPageViewModel : CodeBrixViewModelBase, INavigatedAware
    {
        private readonly ITextToSpeech _textToSpeech;
        private readonly IUserDialogService _dialogService;

        private string _textToSay = "Hello from CodeBrix and Prism.";
        public string TextToSay
        {
            get => _textToSay;
            set => SetProperty(ref _textToSay, value);
        }

        public DelegateCommand SpeakCommand { get; set; }

        //The ITextToSpeech dependency is provided by the Xamarin.Forms.DependencyService
        public MainPageViewModel(ITextToSpeech textToSpeech, IUserDialogService dialogService)
        {
            _textToSpeech = textToSpeech;
            _dialogService = dialogService;
            SpeakCommand = new DelegateCommand(Speak);
        }

        private void Speak()
        {
            _textToSpeech.Speak(TextToSay);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //Nothing to do here
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast
            _dialogService.Toast("UsingDependencyService sample app created for Prism by Brian Lagunas.", TimeSpan.FromSeconds(3));
        }
    }
}
