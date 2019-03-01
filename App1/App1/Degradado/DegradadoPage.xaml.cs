using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFGloss;

namespace App1.Degradado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DegradadoPage : ContentPage
    {
        public DegradadoPage()
        {
            InitializeComponent();

            //var cell = new Button();
            //cell.Text = "Red";
            //cell.TextColor = Color.White;

            //CellGloss.SetBackgroundGradient(cell, new Gradient(Color.Red, Color.Maroon));
            //ContentPageGloss.SetBackgroundGradient(demo, new Gradient(Color.Red, Color.Maroon));
            //demo.Children.Add(cell);
        }
    }
}