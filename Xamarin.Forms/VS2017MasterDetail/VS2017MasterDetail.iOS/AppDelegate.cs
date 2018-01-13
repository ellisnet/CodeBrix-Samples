using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

//CODEBRIX-CONVERSION-NOTE: Additional usings required for CodeBrix and the code added below -
using CodeBrix;

namespace VS2017MasterDetail.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //CODEBRIX-CONVERSION-NOTE: The old LoadApplication() call was commented out (below) and
            // replaced with this new call because our App class (inherited from CodeBrixApplication)
            // needs to be passed in some configuration information about the device platform.
            LoadApplication(new App(new iOSConfiguration()));

            //LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }

    //CODEBRIX-CONVERSION-NOTE: Each one of our platform-specific projects will need to have a platform-
    // specific configuration class (that implements IPlatformConfiguration via the base class) added.
    // This is how the CodeBrix libraries are able to pull in platform-specific functionality when needed.
    public class iOSConfiguration : iOSPlatformConfigBase
    {
        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here
        }
    }
}
