
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.Permissions;
using Plugin.FacebookClient;
using Android.Content;
using Android.Views;

namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

         
            base.OnCreate(savedInstanceState);
            FacebookClientManager.Initialize(this);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);                     
            //Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            //Xamarin.FormsMaps.Init(this, savedInstanceState);
            //XFGloss.Droid.Library.Init(this, savedInstanceState);


            //var pixelWidth = (int)Resources.DisplayMetrics.WidthPixels;
            //var pixelHeight = (int)Resources.DisplayMetrics.HeightPixels;
            //var screenPixelDensity = (double)Resources.DisplayMetrics.Density;
            //App.ScreenHeight = (double)((pixelHeight - 0.5f) / screenPixelDensity);
            //App.ScreenWidth = (double)((pixelWidth - 0.5f) / screenPixelDensity);
            //StatusBarHelper.DecorView = this.Window.DecorView;

            //LoadApplication(new App());

            LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(
            this,
            new UXDivers.Gorilla.Config("Good Gorilla")
              // Register Grial Shared assembly
              .RegisterAssemblyFromType<App1.Cards.SumaryOrden>()
            ));

        }

        //public override void OnWindowAttributesChanged(WindowManagerLayoutParams @params)
        //{
        //    base.OnWindowAttributesChanged(@params);
        //}

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            FacebookClientManager.OnActivityResult(requestCode, resultCode, intent);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //public override void OnBackPressed()
        //{
        //    //if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
        //    //{
               
        //    //}
        //    //else
        //    //{
               
        //    //}
        //}
    }
}