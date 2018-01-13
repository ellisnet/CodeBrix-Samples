using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CodeBrix;

namespace UsingDependencyService.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new UsingDependencyService.App(new UwpConfiguration()));
        }
    }

    public class UwpConfiguration : UwpPlatformConfigBase
    {
        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here

            //This sample application demonstrates that there is no need to register an interface implementation
            // (in this case: ITextToSpeech -> TextToSpeech_UWP) if that implementation is already registered 
            // via the Xamarin.Forms.DependencyService.
            // So a separate registration like this is not needed:
            //container.Register(typeof(ITextToSpeech), typeof(TextToSpeech_UWP));
        }
    }
}
