using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Cards
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabPage : ContentPage
	{
		public TabPage ()
		{
			InitializeComponent ();

            ChangeTabs(TypeTab.Home);
        }

        private void Tab1Clicked(object sender, EventArgs e)
        {
            ChangeTabs(TypeTab.Home);
        }

        private void Tab2Clicked(object sender, EventArgs e)
        {
            ChangeTabs(TypeTab.Artist);
        }

        private void ChangeTabs(TypeTab tab)
        {
            if (tab == TypeTab.Home)
            {
                vHombe.BackgroundColor = Color.White;
                vArtist.BackgroundColor = Color.Transparent;

                stkTab1.IsVisible = true;
                stkTab2.IsVisible = false;             

            }
            else if (tab == TypeTab.Artist)
            {
                vHombe.BackgroundColor = Color.Transparent;
                vArtist.BackgroundColor = Color.White;

                stkTab1.IsVisible = false;
                stkTab2.IsVisible = true;            

            }           

        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:

                    if (stkTab1.IsVisible == true)
                    {
                        ChangeTabs(TypeTab.Artist);
                    }                  

                    break;

                case SwipeDirection.Right:

                     if (stkTab2.IsVisible == true)
                    {
                        ChangeTabs(TypeTab.Home);
                    }

                    break;               
            }
        }
    }

    public enum TypeTab
    {
        Home,
        Artist,       
    }
}