using FreeAnimeMusic.Helpers;
using FreeAnimeMusic.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Card3 : ContentPage
    {
        private int repeat = 0;
        public Card3()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            Card3ViewModel _viewModel = new Card3ViewModel();
            _viewModel.onPanelAnimation += _viewModel_onPanelAnimation;
            BindingContext = _viewModel;
            pickerTip.SelectedIndex = 0;

            lst_Days.ItemSelected += (sender, e) =>
            {
                var itemSelected = e.SelectedItem as HourOpen;
                if (itemSelected != null)
                {
                    _viewModel.SelectedDay = itemSelected;
                }

              ((ListView)sender).SelectedItem = null;
            };

            lst_Hours.ItemSelected += (sender, e) =>
            {
                var itemSelected = e.SelectedItem as HourOpen;
                if (itemSelected != null)
                {
                    _viewModel.SelectedHour = itemSelected;
                }

           ((ListView)sender).SelectedItem = null;
            };
        }

        private void _viewModel_onPanelAnimation(int index_panel)
        {
            if (repeat == index_panel)
                return;

            repeat = index_panel;
            FlipAnimation fade = new FlipAnimation();
            fade.Duration = "150";

            if (index_panel == 2)
            {
                panel_detail_happybirthday.Animate(fade);
            }
            if (index_panel == 3)
            {
                panel_invites.Animate(fade);
            }
            if (index_panel == 1)
            {
                panel_detail_event.Animate(fade);
            }
        }
    }

    public class Card3ViewModel : BaseViewModel
    {
        public ICommand _CommandBack { get; private set; }
        public ICommand _CommandNext { get; private set; }
        public Command CommandSelectedEvent { get; set; }

        public delegate void delegateAnimation(int index_panel);
        public event delegateAnimation onPanelAnimation;

        public Card3ViewModel()
        {
            IsVisible_panel_detail_event = true;
            IsVisible_panel_detail_happybirthday = false;
            IsVisible_panel_invites = false;
            Global.IndexPanel = 1;

            CommandSelectedEvent = new Command(ExecuteCommandSelectedEvent);

            All_Events = new ObservableCollection<Images>();

            List<Images> list = new List<Images>()
            {

                new Images(){ Source = "Breakfast0.png", Name = "Cumpleaños" },
                new Images(){ Source = "Breakfast1.png", Name = "Reencuentro"  },
                new Images(){ Source = "Breakfast2.png", Name = "Primera Cita"  },
                new Images(){ Source = "Breakfast3.png", Name = "Aniversario"  },
                new Images(){ Source = "Breakfast0.png", Name = "Noche loca"  },
                new Images(){ Source = "Breakfast0.png", Name = "Despues del cine" },
                new Images(){ Source = "Breakfast0.png", Name = "Otro" }
            };

            All_Events = list.ToObservableCollection();
            TextEvent = "Celebraremos: ";


            List_Days = new ObservableCollection<HourOpen>();
            List_Hours = new ObservableCollection<HourOpen>();


            List<HourOpen> list2 = new List<HourOpen>();
            List<HourOpen> list3 = new List<HourOpen>();
            DateTime init = DateTime.Now;


            for (int i = 0; i < 15; i++)
            {
                HourOpen obj = new HourOpen();
                obj.Day = init.AddDays(i);
                list2.Add(obj);
            }


            int h = 9;
            int final = 24 - h;
            for (int i = 0; i < final; i++)
            {

                HourOpen obj = new HourOpen();
                HourOpen obj2 = new HourOpen();

                obj.Hour = new TimeSpan(h + i, 0, 0);
                obj2.Hour = new TimeSpan(h + i, 30, 0);

                list3.Add(obj);
                list3.Add(obj2);
            }

            List_Hours = list3.ToObservableCollection();
            List_Days = list2.ToObservableCollection();
        }



        private async Task ExecuteCommandNext()
        {
            if (Global.IndexPanel == 1)
            {
                IsVisible_panel_detail_event = false;
                IsVisible_panel_detail_happybirthday = true;
                IsVisible_panel_invites = false;
                Global.IndexPanel = 2;
               
            }
            else if (Global.IndexPanel == 2)
            {
                IsVisible_panel_detail_event = false;
                IsVisible_panel_detail_happybirthday = false;
                IsVisible_panel_invites = true;
                Global.IndexPanel = 3;
            }

            onPanelAnimation?.Invoke(Global.IndexPanel);
        }

        private async Task ExecuteCommandBack()
        {
            if (Global.IndexPanel == 3)
            {
                IsVisible_panel_detail_event = false;
                IsVisible_panel_detail_happybirthday = true;
                IsVisible_panel_invites = false;
                Global.IndexPanel = 2;
            }
            else if (Global.IndexPanel == 2)
            {
                IsVisible_panel_detail_event = true;
                IsVisible_panel_detail_happybirthday = false;
                IsVisible_panel_invites = false;
                Global.IndexPanel = 1;               
            }

            onPanelAnimation?.Invoke(Global.IndexPanel);
        }

        void ExecuteCommandSelectedEvent(object parameter)
        {
            Images obj = parameter as Images;
            TextEvent = "Celebraremos: " + obj.Name;
        }



        public ICommand CommandNext
        {
            get { return _CommandNext = _CommandNext ?? new Command(async () => await ExecuteCommandNext()); }
        }

        public ICommand CommandBack
        {
            get { return _CommandBack = _CommandBack ?? new Command(async () => await ExecuteCommandBack()); }
        }



        private string textEvent = string.Empty;
        public string TextEvent
        {
            get { return textEvent; }
            set { SetProperty(ref textEvent, value); }
        }

        private ObservableCollection<Images> all_Events = null;
        public ObservableCollection<Images> All_Events
        {
            get { return all_Events; }
            set { SetProperty(ref all_Events, value); }
        }

        // Visibility Panels
        private bool isVisible_panel_detail_event;
        public bool IsVisible_panel_detail_event
        {
            get { return isVisible_panel_detail_event; }
            set { SetProperty(ref isVisible_panel_detail_event, value); }
        }

        private bool isVisible_panel_detail_happybirthday;
        public bool IsVisible_panel_detail_happybirthday
        {
            get { return isVisible_panel_detail_happybirthday; }
            set { SetProperty(ref isVisible_panel_detail_happybirthday, value); }
        }

        private bool isVisible_panel_invites;
        public bool IsVisible_panel_invites
        {
            get { return isVisible_panel_invites; }
            set { SetProperty(ref isVisible_panel_invites, value); }
        }

        //

        private ObservableCollection<HourOpen> list_Days = null;
        public ObservableCollection<HourOpen> List_Days
        {
            get { return list_Days; }
            set { SetProperty(ref list_Days, value); }
        }

        private ObservableCollection<HourOpen> list_Hours = null;
        public ObservableCollection<HourOpen> List_Hours
        {
            get { return list_Hours; }
            set { SetProperty(ref list_Hours, value); }
        }

        private string textTip = string.Empty;
        public string TextTip
        {
            get { return textTip; }
            set { SetProperty(ref textTip, value); }
        }

        private string selectedTip = string.Empty;
        public string SelectedTip
        {
            get { return selectedTip; }
            set
            {
                SetProperty(ref selectedTip, value);

                if (!string.IsNullOrEmpty(selectedTip))
                    TextTip = selectedTip;

            }
        }

        private string textDayAndHour = string.Empty;
        public string TextDayAndHour
        {
            get { return textDayAndHour; }
            set { SetProperty(ref textDayAndHour, value); }
        }

        private HourOpen selectedDay;
        public HourOpen SelectedDay
        {
            get { return selectedDay; }
            set
            {
                SetProperty(ref selectedDay, value);

                if (selectedDay != null)
                {
                    if (selectedHour != null)
                    {
                        textDayAndHour = selectedDay.Day.ToString("d") + " " + selectedHour.Hour.ToString(@"hh\:mm");
                    }
                    else
                    {
                        textDayAndHour = selectedDay.Day.ToString("d");
                    }

                }
            }
        }

        private HourOpen selectedHour;
        public HourOpen SelectedHour
        {
            get { return selectedHour; }
            set
            {
                SetProperty(ref selectedHour, value);

                if (selectedHour != null)
                {
                    if (selectedDay != null)
                    {
                        textDayAndHour = selectedDay.Day.ToString("d") + " " + selectedHour.Hour.ToString(@"hh\:mm");
                    }
                    else
                    {
                        textDayAndHour = selectedHour.Hour.ToString(@"hh\:mm");
                    }

                }
            }
        }

    }

    public class HourOpen
    {
        public DateTime Day { get; set; }
        public TimeSpan Hour { get; set; }
    }

    public class Global
    {
        public static int IndexPanel { get; set; }
    }
}