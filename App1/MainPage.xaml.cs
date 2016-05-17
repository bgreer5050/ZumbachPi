using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            Random rnd = new Random();
            System.Threading.Timer timer = new System.Threading.Timer(UpdateUI, null, 1000, 60000);

            this.InitializeComponent();

            Uri uri = new Uri("http://apollo.metal-matic.com/BedfordPark/Conversion/Downtime/Dashboard?x=" + rnd.NextDouble());
            
            webView1.Navigate(uri);

            //Uri uri2 = new Uri("http://apollo.metal-matic.com/BedfordPark/Fabrication/Downtime/Dashboard");
            //webView2.Navigate(uri2);
        }

        private async void UpdateUI(object state)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {

                Uri uri = new Uri("http://apollo.metal-matic.com/BedfordPark/Conversion/Downtime/Dashboard");

                webView1.Navigate(uri);
                //webView1.Refresh();
            });
        }

        private void webView1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            
        }

        private void RichTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
