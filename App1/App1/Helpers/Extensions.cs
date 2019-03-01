using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FreeAnimeMusic.Helpers
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            var col = new ObservableCollection<T>();
            foreach (var cur in enumerable)
            {
                col.Add(cur);
            }
            return col;
        }

        public static string ClearTitle(this string stringValue)
        {
            string[] splitString = stringValue.Split('.');

            if (splitString.Length == 1)
                return stringValue;
            else if (splitString.Length == 2)
                return splitString[1].Trim();
            else
                return stringValue;
        }
    }
}
