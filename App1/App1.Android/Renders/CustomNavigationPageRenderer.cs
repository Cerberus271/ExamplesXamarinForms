using Android.Support.V7.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using AView = Android.Views.View;
using Android.App;
using Android.Content;
using Android.Widget;
using App1.CustomControls;
using App1.Droid.Renders;
using Android.Views;
using System.Reflection;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace App1.Droid.Renders
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        public CustomNavigationPageRenderer(Context context) : base(context)
        {

        }

        IPageController PageController => Element as IPageController;
        CustomNavigationPage CustomNavigationPage => Element as CustomNavigationPage;
        Android.Support.V7.Widget.Toolbar _toolbar;

        //protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        //{
        //    base.OnElementChanged(e);

        //    var memberInfo = typeof(CustomNavigationPageRenderer).BaseType;
        //    if (memberInfo != null)
        //    {
        //        var field = memberInfo.GetField(nameof(_toolbar), BindingFlags.Instance | BindingFlags.NonPublic);
        //        _toolbar = field.GetValue(this) as Android.Support.V7.Widget.Toolbar;
        //        _toolbar.SetBackgroundColor(Color.Transparent.ToAndroid());

        //        Activity context = Context as Activity;
        //      //  _toolbar.NavigationIcon = Android.Support.V4.Content.ContextCompat.GetDrawable(context, Resource.Drawable.abc_ic_arrow_drop_right_black_24dp);



        //        var window = context.Window;
        //        window.AddFlags(WindowManagerFlags.TranslucentStatus);
        //        context.Window.ClearFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);



        //    }
        //}

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            //base.OnLayout(changed, l, t, r, b);

            //Android.Support.V7.Widget.Toolbar bar = _toolbar;
            //bar.BringToFront();

            CustomNavigationPage.IgnoreLayoutChange = true;
            base.OnLayout(changed, l, t, r, b);
            CustomNavigationPage.IgnoreLayoutChange = false;

            var containerHeight = b - t;

            PageController.ContainerArea = new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));


            //for (var i = 0; i < ChildCount; i++)
            //{
            //    AView child = GetChildAt(i);

            //    var pageContainer = child.GetType().GetProperty("Child")?.GetValue(child) as IVisualElementRenderer;
            //    Page childPage = pageContainer?.Element as Page;

            //    if (childPage == null)
            //        return;

            //    bool childHasNavBar = NavigationPage.GetHasNavigationBar(childPage);

            //    if (childHasNavBar)
            //    {
            //        child.Layout(0, 0, r, b);
            //    }
            //}

            for (var i = 0; i < ChildCount; i++)
            {
                var child = GetChildAt(i);

                if (child is Android.Support.V7.Widget.Toolbar)
                {
                    continue;
                }

                child.Layout(0, 0, r, b);
            }
        }
    }
}