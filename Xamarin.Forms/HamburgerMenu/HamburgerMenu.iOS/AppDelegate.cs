using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using CodeBrix;

namespace HamburgerMenu.iOS
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

        //This override is only necessary if you want to have pages that require specific orientations - 
        // i.e. if you want specific pages to be Portrait-only or Landscape-only
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application,
            UIWindow forWindow)
        {
            //Tweak this line to match what you want your application to have as its default allowed orientations
            // - i.e. for pages that don't specify Portrait-only or Landscape-only.
            // It would make sense for this to match what is in your app's Manifest - the default for iOS apps is
            // UIInterfaceOrientationMask.Portrait | UIInterfaceOrientationMask.Landscape
            // a.k.a. UIInterfaceOrientationMask.AllButUpsideDown
            UIInterfaceOrientationMask allowedOrientations = UIInterfaceOrientationMask.Portrait
                                                            | UIInterfaceOrientationMask.Landscape;
            return iOSPlatformConfigBase.GetSupportedInterfaceOrientations(this, allowedOrientations);
        }
    }

    public class iOSConfiguration : iOSPlatformConfigBase
    {
        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here
        }
    }
}
