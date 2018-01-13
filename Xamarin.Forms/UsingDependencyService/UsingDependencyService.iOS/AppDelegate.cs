using System;
using System.Collections.Generic;
using System.Linq;
using CodeBrix;
using Foundation;
using UIKit;

namespace UsingDependencyService.iOS
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
            LoadApplication(new App(new iOSConfiguration()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSConfiguration : iOSPlatformConfigBase
    {
        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here

            //This sample application demonstrates that there is no need to register an interface implementation
            // (in this case: ITextToSpeech -> TextToSpeech_iOS) if that implementation is already registered 
            // via the Xamarin.Forms.DependencyService.
            // So a separate registration like this is not needed:
            //container.Register(typeof(ITextToSpeech), typeof(TextToSpeech_iOS));
        }
    }
}
