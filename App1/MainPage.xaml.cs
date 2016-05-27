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
        System.Threading.Timer timer;
        int x = 0;

        public MainPage()
        {
            Random rnd = new Random();
            timer = new System.Threading.Timer(UpdateUI, null,TimeSpan.FromSeconds(1.0d),TimeSpan.FromSeconds(120.0d));
            
            

            this.InitializeComponent();

            //Uri uri = new Uri("http://apollo.metal-matic.com/BedfordPark/Fabrication/Downtime/Dashboard");

            Uri uri = new Uri("http://apollo.metal-matic.com/BedfordPark/Conversion/Downtime/Dashboard");
            
            webView1.Navigate(uri);
            webView1.NavigationFailed += WebView1_NavigationFailed;

            //Uri uri2 = new Uri("http://apollo.metal-matic.com/BedfordPark/Fabrication/Downtime/Dashboard");
            //webView2.Navigate(uri2);
        }

        private void WebView1_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            webView1.NavigateToString(@"<br /><br /><center><h1>Apollo Dashboard Offline</h1></center>");
        }

        private async void UpdateUI(object state)
        {
           
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {

                    Uri uri = new Uri("http://apollo.metal-matic.com/BedfordPark/Fabrication/Downtime/Dashboard");

                    // Uri uri = new Uri("http://apollo.metal-matic.com/BedfordPark/Conversion/Downtime/Dashboard");
                    // Uri uri = new Uri("http://yahoo.com");

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
