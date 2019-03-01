using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Intro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        Timer timer = null;
        int positionIndex = 0;

        public List<CarouselData> MyDataSource { get; set; }
        private int _position;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        public IntroPage()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            logoLayout.BackgroundColor = new Color(0, 0, 0, 0.7);

            MyDataSource = new List<CarouselData>() { new CarouselData() { Title = "Bienvenido", Detail="No necesitas llamar a un restaurante para asegurar tu mesa. Reservalope te ayuda con tus eventos!" },
                                                        new CarouselData() { Title = "1 - Reserva", Detail="Busca fácil y rápido. Asegura tu mesa" },
                                                        new CarouselData() { Title = "2 - Ordena", Detail="Elige tu plato favorito para tu evento" }};

            BindingContext = this;

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            positionIndex++;

            if (positionIndex%2==0)
            {
                carouselCtrl.Position = positionIndex/2;
            
            }

            if (positionIndex >= 6)
            {
                positionIndex = -1;
            }

        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            if (width > height)
            {
                videoPlayer.WidthRequest = App.ScreenWidth;
                videoPlayer.HeightRequest = App.ScreenHeight;
            }
            else if (width < height)
            {
                videoPlayer.WidthRequest = App.ScreenWidth / 2;
                videoPlayer.HeightRequest = App.ScreenHeight / 2;
            }

            base.LayoutChildren(x, y, width, height);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            carouselCtrl.Position = 2;
        }
    }
}