using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.DataGrid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
            BindingContext = new MainViewModel();
		}


	}

    public class MainViewModel : INotifyPropertyChanged
    {

        #region fields
        private List<Team> teams;
        private List<Reservation> reservations;
        private Team selectedItem;
        private bool isRefreshing;
        #endregion

        #region Properties
        public List<Team> Teams
        {
            get { return teams; }
            set { teams = value; OnPropertyChanged(nameof(Teams)); }
        }

        public List<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; OnPropertyChanged(nameof(Reservations)); }
        }

        public Team SelectedTeam
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                System.Diagnostics.Debug.WriteLine("Team Selected : " + value?.Name);
            }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); }
        }

        public ICommand RefreshCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            List<Reservation> reservations = new List<Reservation>();
            reservations.Add(new Reservation() { Name = "L.A. Lakers", CantBebidas = 2, CantEntradas = 1, CantFondos =0, CantPostres = 1, TotalPayment = 54.6 });
            Reservations = reservations;


            //List<Team> teams = new List<Team>();
            //teams.Add(new Team() { Name = "L.A. Lakers, ", Win = 17, Loose = 65, Percentage = 0.255, Conf = "8-44", Div = "2-14", Home = "12-29", Road = "5-36", Last10 = "2-8", Streak = "W 1", Logo = "lakers.png" });
            //Teams = teams;

            RefreshCommand = new Command(CmdRefresh);
        }

        private async void CmdRefresh()
        {
            IsRefreshing = true;
            // wait 3 secs for demo
            await Task.Delay(3000);
            IsRefreshing = false;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}