
using Android.App;
using Android.Views;

namespace App1.Droid
{
    public static class StatusBarHelper
    {
        public static View DecorView
        {
            get;
            set;
        }
        public static ActionBar AppActionBar
        {
            get;
            set;
        }
    }
}