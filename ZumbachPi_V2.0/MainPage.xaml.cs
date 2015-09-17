using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZumbachPi_V2._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int intSliderValue;
        public string strZoomLevel;

        public bool blnZumbachOn = false;

        private System.Threading.Timer timer;
        private Timer timerCheckEveryTenSeconds;
        private Timer timerCheckEveryFiveMinutes;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(this.Width.ToString());
            Debug.WriteLine(this.Height.ToString());
            timerCheckEveryTenSeconds = new Timer(LoadWebView, null, 5000, 5000);
            timerCheckEveryFiveMinutes = new Timer(LoadWebView, new object(), 10000, 30000);
        }


        private void LoadWebView(object obj)
        {
            if (obj == null && blnZumbachOn == false)
            {
                Debug.WriteLine("Checking");

                StorageFile file;
                StringBuilder strB = new StringBuilder();

                if (ZumbachOnline() == true)
                {

                    Task x = Task.Run(() =>
                    {
                        try
                        {
                            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                            file = folder.GetFileAsync("MyWebPage.html").AsTask().Result; // GetItemsAsync().AsTask().Result;
                        Stream stream = file.OpenStreamForReadAsync().Result;
                            StreamReader reader = new StreamReader(stream);
                            strB.Append(reader.ReadToEndAsync().Result);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    });

                    x.Wait();
                }

                else
                {
                    Task x = Task.Run(() =>
                    {
                        try
                        {
                            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                            file = folder.GetFileAsync("ZumbachOff.html").AsTask().Result; // GetItemsAsync().AsTask().Result;
                        Stream stream = file.OpenStreamForReadAsync().Result;
                            StreamReader reader = new StreamReader(stream);
                            strB.Append(reader.ReadToEndAsync().Result);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    });

                    x.Wait();

                }

                webView2.NavigateToString(strB.ToString());
            }
            else
            {
                Debug.WriteLine("NOT Checking");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //grid.Height = this.Height;
            //grid.Width = this.Width;
            //webView1.Height = this.Height;
            //webView1.Width = this.Width;
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
          
          //  LoadWebView(int.Parse(slider.Value.ToString()));
            Debug.WriteLine(slider.Value.ToString());
        //    if (webView1 != null)
        //        await webView1.InvokeScriptAsync("eval", new string[] { "ZoomFunction(" + e.NewValue.ToString() + ");" });
        }

        private bool ZumbachOnline()
        {
            var tokenSource = new CancellationTokenSource();
            System.Threading.CancellationToken token = tokenSource.Token;

            WebRequest request = WebRequest.Create("http://10.0.200.155/screen.htm");

            try
            {
                WebResponse response = request.GetResponseAsync().Result;
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
