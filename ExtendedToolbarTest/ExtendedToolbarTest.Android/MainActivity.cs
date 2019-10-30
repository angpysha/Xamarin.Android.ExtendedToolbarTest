using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using ExtendedToolbarTest.Droid.Services;
using ExtendedToolbarTest.Services;
using FFImageLoading.Forms.Platform;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;

namespace ExtendedToolbarTest.Droid
{
    [Activity(Label = "ExtendedToolbarTest", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this,bundle);
            CachedImageRenderer.Init(true);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            var layout = FindViewById<LinearLayout>(Resource.Id.toolbar_button_layout);

            var button = new Button(this);
            var layoutParams =
                new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            button.LayoutParameters = layoutParams;

         //   layout.AddView(button);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<IImageToolbarService, ImageToolbarService>();
        }
    }
}

