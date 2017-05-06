using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Forms;
using System.IO;
using XLabs.Platform.Device;
using XLabs.Forms.Services;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Services.Email;
using XLabs.Serialization;
using XLabs.Platform.Services;

namespace Awesomekit.Droid
{
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            App.OnContainerSet += OnContainerSet;

            LoadApplication(new App());
        }

        private void OnContainerSet(XLabs.Ioc.IDependencyContainer container)
        {
            container.Register<IDevice>(t => AndroidDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                .Register<IMediaPicker, MediaPicker>();
        }
    }
}