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

//CODEBRIX-CONVERSION-NOTE: Additional usings required for CodeBrix and the code added below -
using CodeBrix;

namespace VS2017MasterDetail.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            //CODEBRIX-CONVERSION-NOTE: The old LoadApplication() call was commented out (below) and
            // replaced with this new call because our App class (inherited from CodeBrixApplication)
            // needs to be passed in some configuration information about the device platform.
            LoadApplication(new VS2017MasterDetail.App(new UwpConfiguration()));

            //LoadApplication(new VS2017MasterDetail.App());
        }
    }

    //CODEBRIX-CONVERSION-NOTE: Each one of our platform-specific projects will need to have a platform-
    // specific configuration class (that implements IPlatformConfiguration via the base class) added.
    // This is how the CodeBrix libraries are able to pull in platform-specific functionality when needed.
    public class UwpConfiguration : UwpPlatformConfigBase
    {
        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here
        }
    }
}
