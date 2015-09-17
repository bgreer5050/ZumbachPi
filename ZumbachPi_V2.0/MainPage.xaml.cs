using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
            intSliderValue = 1;
           
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
          
            Debug.WriteLine(this.Width.ToString());
            Debug.WriteLine(this.Height.ToString());

            
        }


        private void LoadWebView(int _zoom)
        {
           

            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE html>");
            sb.Append(@"<head>");
            sb.Append(@"<meta charset=""utf - 8"" />");
            sb.Append(@" <title></title>");


            switch(intSliderValue)
            {
                case 1:
                    sb.Append(@"<style>
                              #mybody {
                            -ms-zoom: 0.75;
                            -moz-transform: scale(0.75);
                            -moz-transform-origin: 0 0;
                            -o-transform: scale(0.75);
                            -o-transform-origin: 0 0;
                            -webkit-transform: scale(0.75);
                            -webkit-transform-origin: 0 0;
                        }
                    </style>");
                    break;

                case 2:
                    sb.Append(@"<style>
                              #mybody {
                            -ms-zoom: 1.00;
                            -moz-transform: scale(1.00);
                            -moz-transform-origin: 0 0;
                            -o-transform: scale(1.00);
                            -o-transform-origin: 0 0;
                            -webkit-transform: scale(1.00);
                            -webkit-transform-origin: 0 0;
                        }
                    </style>");
                    break;

                case 3:
                    sb.Append(@"<style>
                              #mybody {
                            -ms-zoom: 1.50;
                            -moz-transform: scale(1.50);
                            -moz-transform-origin: 0 0;
                            -o-transform: scale(1.50);
                            -o-transform-origin: 0 0;
                            -webkit-transform: scale(1.50);
                            -webkit-transform-origin: 0 0;
                        }
                    </style>");
                    break;

                case 4:
                    sb.Append(@"<style>
                              #mybody {
                            -ms-zoom: 2.00;
                            -moz-transform: scale(2.00);
                            -moz-transform-origin: 0 0;
                            -o-transform: scale(2.00);
                            -o-transform-origin: 0 0;
                            -webkit-transform: scale(2.00);
                            -webkit-transform-origin: 0 0;
                        }
                    </style>");
                    break;

                default:
                    sb.Append(@"<style>
                                #mybody {
                              -ms-zoom: 1.00;
                              -moz-transform: scale(1.00);
                              -moz-transform-origin: 0 0;
                              -o-transform: scale(1.00);
                              -o-transform-origin: 0 0;
                              -webkit-transform: scale(1.00);
                              -webkit-transform-origin: 0 0;
                          }
                      </style>");
                    break;
            }

            //        sb.Append(@"<style>
            //          #mybody {
            //        -ms-zoom: 1.50;
            //        -moz-transform: scale(1.50);
            //        -moz-transform-origin: 0 0;
            //        -o-transform: scale(1.50);
            //        -o-transform-origin: 0 0;
            //        -webkit-transform: scale(1.50);
            //        -webkit-transform-origin: 0 0;
            //    }
            //</style>");

            sb.Append(@"<style>
              #mybody {
            -ms-zoom: 1.00;
            -moz-transform: scale(1.00);
            -moz-transform-origin: 0 0;
            -o-transform: scale(1.00);
            -o-transform-origin: 0 0;
            -webkit-transform: scale(1.00);
            -webkit-transform-origin: 0 0;
        }
    </style>");

            sb.Append(@"<script>");
            sb.Append(@"window.scrollTo(0,500);");
            sb.Append(@"</script>");


            sb.Append(@"</head>");
            sb.Append(@"<body id=""mybody"" style=""margin: 0px; padding: 0px; overflow: hidden; "">");
            sb.Append(@" <iframe id=""myiframe"" src=""http://apollo.metal-matic.com/BedfordPark/Conversion/Downtime/Dashboard"" style=""width:1200px; height:1000px; overflow-X:auto; overflow-y:auto;""></iframe>");
            sb.Append(@"</body>");
            sb.Append(@"</html>");

            string mysource = sb.ToString();
            webView2.NavigateToString(mysource);

            
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

            LoadWebView(int.Parse(slider.Value.ToString()));
            Debug.WriteLine(slider.Value.ToString());
        //    if (webView1 != null)
        //        await webView1.InvokeScriptAsync("eval", new string[] { "ZoomFunction(" + e.NewValue.ToString() + ");" });
        }
    }
}
