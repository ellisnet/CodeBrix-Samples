using System;
//using System.Windows.Input; - no longer used

//using Xamarin.Forms; - no longer used

//CODEBRIX-CONVERSION-NOTE: Additional usings for CodeBrix (which is built on Prism)
using Prism.Commands;

namespace VS2017MasterDetail.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            //CODEBRIX-CONVERSION-NOTE: There is no major advantage to using a Prism DelegateCommand vs. 
            // Xamarin.Forms.Command but in CodeBrix, we try not to reference items in the Xamarin.Forms 
            // namespace in our viewmodels, for improved testability and portability to other 
            // (non-Xamarin.Forms) platforms
            OpenWebCommand = new DelegateCommand(() => OpenUri("https://xamarin.com/platform"));

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public DelegateCommand OpenWebCommand { get; }
    }
}