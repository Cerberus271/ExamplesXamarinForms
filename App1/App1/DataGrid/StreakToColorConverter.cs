﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace App1.DataGrid
{
    public class StreakToColorConverter : IValueConverter
    {
        //public static string[] WinStreakColors = new string[] { "#CEF6CE", "#A9F5A9", "#81F781", "#58FA58", "#2EFE2E", "#00FF00", "#01DF01" };
        //public static string[] LooseStreakColors = new string[] { "#F5A9A9", "#F78181", "#FA5858", "#FE2E2E", "#FF0000", "#DF0101", "8A0808" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.Transparent;

            //string val = value.ToString();


            //if (val.Contains("Payment"))
            //    return Color.LightGreen;
            //else
            //    return Color.White;

            return Color.LightGreen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
