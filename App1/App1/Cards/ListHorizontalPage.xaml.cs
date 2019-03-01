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
    public partial class ListHorizontalPage : ContentPage
    {
        public ListHorizontalPage()
        {
            InitializeComponent();

            List<Images> list = new List<Images>()
            {

                new Images(){ Source = "Breakfast0.png", Name = "Image 1" },
                new Images(){ Source = "Breakfast1.png", Name = "Image 2"  },
                new Images(){ Source = "Breakfast2.png", Name = "Image 3"  },
                new Images(){ Source = "Breakfast3.png", Name = "Image 4"  },
                new Images(){ Source = "Breakfast0.png", Name = "Image 5"  },
                new Images(){ Source = "Breakfast1.png", Name = "Image 6"  },
                new Images(){ Source = "Breakfast2.png" , Name = "Image 7" },
                new Images(){ Source = "Breakfast3.png", Name = "Image 8"  }
            };

            MessagesListView.ItemsSource = list;
        }
    }

    public class Images
    {
        public string Source { get; set; }
        public string Name { get; set; }
    }
}