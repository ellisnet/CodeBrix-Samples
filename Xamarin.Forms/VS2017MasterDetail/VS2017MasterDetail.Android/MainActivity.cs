using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

//CODEBRIX-CONVERSION-NOTE: Additional usings required for CodeBrix and the code added below -
using Android.Content.Res;
using CodeBrix;

namespace VS2017MasterDetail.Droid
{
    [Activity(Label = "VS2017MasterDetail", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //CODEBRIX-CONVERSION-NOTE: The old LoadApplication() call was commented out (below) and
            // replaced with this new call because our App class (inherited from CodeBrixApplication)
            // needs to be passed in some configuration information about the device platform.
            LoadApplication(new App(new AndroidConfiguration(this, bundle)));

            //LoadApplication(new App());
        }

        //CODEBRIX-CONVERSION-NOTE: Because of some uniqueness with the Android platform, the base class
        // for our platform configuration class needs to be updated when the configuration changes.
        // So we need to override OnConfigurationChanged() and pass the newConfig parameter to 
        // AndroidPlatformConfigBase.
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            AndroidPlatformConfigBase.OnConfigurationChanged(newConfig);
        }
    }

    //CODEBRIX-CONVERSION-NOTE: Each one of our platform-specific projects will need to have a platform-
    // specific configuration class (that implements IPlatformConfiguration via the base class) added.
    // This is how the CodeBrix libraries are able to pull in platform-specific functionality when needed.
    public class AndroidConfiguration : AndroidPlatformConfigBase
    {
        public AndroidConfiguration(Activity mainActivity, Bundle bundle) : base(mainActivity, bundle) { }

        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here
        }
    }
}

