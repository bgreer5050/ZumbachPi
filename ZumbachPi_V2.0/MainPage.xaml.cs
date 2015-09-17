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

        public MainPage()
        {
            this.InitializeComponent();
           
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
          
            Debug.WriteLine(this.Width.ToString());
            Debug.WriteLine(this.Height.ToString());
            LoadWebView();
            
        }


        private void LoadWebView()
        {
            StorageFile file;
            StringBuilder strB = new StringBuilder();


            Task x = Task.Run(() =>
            {
                try
                {
                    StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    file =  folder.GetFileAsync("MyWebPage.html").AsTask().Result; // GetItemsAsync().AsTask().Result;
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

            //        StringBuilder sb = new StringBuilder();
            //        sb.Append(@"<!DOCTYPE html>");
            //        sb.Append(@"<head>");
            //        sb.Append(@"<meta charset=""utf - 8"" />");
            //        sb.Append(@" <title></title>");



            //        sb.Append(@"<style>
            //          #mybody {
            //        -ms-zoom: 1.00;
            //        -moz-transform: scale(1.00);
            //        -moz-transform-origin: 0 0;
            //        -o-transform: scale(1.00);
            //        -o-transform-origin: 0 0;
            //        -webkit-transform: scale(1.00);
            //        -webkit-transform-origin: 0 0;
            //    }
            //</style>");

            //        sb.Append(@"<script>");
            //        sb.Append(@"window.scrollTo(0,500);");



            //        sb.Append(@"</script>");


            //        sb.Append(@"</head>");
            //        sb.Append(@"<body id=""mybody"" style=""margin: 0px; width: 1200px; height:800px; padding: 0px;"">");
            //        sb.Append(@" <iframe id=""myiframe"" src=""http://apollo.metal-matic.com/BedfordPark/Conversion/Downtime/Dashboard"" style=""width:1200; height:800px; overflow-X:auto; overflow-y:auto;""></iframe>");
            //        sb.Append(@"</body>");
            //        sb.Append(@"</html>");

            //        string mysource = sb.ToString();
            //        mysource = mysource.Replace("\r", string.Empty);
            //        mysource = mysource.Replace("\n", string.Empty);
            //        mysource = mysource.Replace(@"\", string.Empty);





            //        string currentDirectory = Directory.GetCurrentDirectory();
            //        Uri uri = new Uri("file://" + currentDirectory + @"/HTMLPage1.html",UriKind.Absolute);
            //        Uri uri2 = new Uri(@"C:/Users/DefaultAccount/AppData/Local/DevelopmentFiles/SparkPIVS.Debug_ARM.Bill/HTMLPage1.html");

            //        DirectoryInfo di = new DirectoryInfo(currentDirectory);


            //        mysource = File.ReadAllText("C:\\Users\\DefaultAccount\\AppData\\Local\\DevelopmentFiles\\SparkPIVS.Debug_ARM.Bill");

            //        //FileInfo[] files = di.GetFiles();
            //        //for(var x = 0; x < files.Length; x++)
            //        //{
            //        //    Debug.WriteLine(files[x].FullName);
            //        //    //if(files[x].FullName.Contains("HTMLPage"))
            //        //    //{
            //        //    //    FileStream fs = new FileStream()
            //        //    //    File.ReadAllText(files[x].) mysource = files[x].op
            //        //    //}

            //        //}

            //        //foreach (File f in di.GetFiles())
            //        //{

            //        //}
            //        //foreach(File f in currentDirectory)
            //        //File.ReadAllText()

            //        // webView2.Uri HTMLPage1.html

            //        webView2.Navigate(uri2);
            //        //NavigateToString(mysource);

            webView2.NavigateToString(strB.ToString());

          

            
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
            Debug.WriteLine(ZumbachOnline().ToString());
          //  LoadWebView(int.Parse(slider.Value.ToString()));
            Debug.WriteLine(slider.Value.ToString());
        //    if (webView1 != null)
        //        await webView1.InvokeScriptAsync("eval", new string[] { "ZoomFunction(" + e.NewValue.ToString() + ");" });
        }

        private bool ZumbachOnline()
        {
            var tokenSource = new CancellationTokenSource();
            System.Threading.CancellationToken token = tokenSource.Token;

            WebRequest request = WebRequest.Create("http://shopfloor/");

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
