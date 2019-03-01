using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LottieDemoPage : ContentPage
    {
        public LottieDemoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()

        {

            base.OnAppearing();



            MessagingCenter.Subscribe<LottieDemoPage>(this, AppSettings.PlayMessage, (sender) =>

            {

                LottieView.Play();

            });



            MessagingCenter.Subscribe<LottieDemoPage>(this, AppSettings.PauseMessage, (sender) =>

            {

                LottieView.Pause();

            });

        }



        protected override void OnDisappearing()

        {

            base.OnDisappearing();



            MessagingCenter.Unsubscribe<LottieDemoPage>(this, AppSettings.PlayMessage);

            MessagingCenter.Unsubscribe<LottieDemoPage>(this, AppSettings.PauseMessage);

        }
    }
}