using System;

using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using CodeBrix;

namespace ContosoCookbook.Droid
{
    [Activity(Label = "ContosoCookbook", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidConfiguration(this, bundle)));
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            AndroidPlatformConfigBase.OnConfigurationChanged(newConfig);
        }
    }

    public class AndroidConfiguration : AndroidPlatformConfigBase
    {
        public AndroidConfiguration(Activity mainActivity, Bundle bundle) : base(mainActivity, bundle) { }

        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Register any platform-specific types here
        }
    }
}
