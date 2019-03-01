using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.XFDownloadManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentPage
    {
        IDownloader downloader = DependencyService.Get<IDownloader>();
        public DownloadPage()
        {
            InitializeComponent();
            downloader.OnFileDownloaded += OnFileDownloaded;
        }

        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("XF Downloader", "Se Descargo correctamente!", "Close");
            }
            else
            {
                DisplayAlert("XF Downloader", "No se pudo descargar el archivo!", "Close");
            }
        }

        private void DownloadClicked(object sender, EventArgs e)
        {
            downloader.DownloadFile("http://www.dada-data.net/uploads/image/hausmann_abcdddddddd.jpg", "Animetronix_Downloads");
        }
    }
}