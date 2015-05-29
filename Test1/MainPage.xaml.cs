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

namespace ZumbachPi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool blnZumbachDisplayed;
        private Uri targetUri = new Uri(@"http://10.0.200.155/screen.htm");

        public MainPage()
        {
            this.InitializeComponent();
            blnZumbachDisplayed = false;
            btnConnect.Visibility = Visibility.Collapsed;
            tbOff.Visibility = Visibility.Collapsed;
            tbTime.Visibility = Visibility.Collapsed;

            System.Threading.Timer timerCheckZumbach = new System.Threading.Timer(CheckIfZumbachIsRunning, null, 1000, 60000);


          
        }

        private void View1_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            blnZumbachDisplayed = false;
            tbTime.Visibility = Visibility.Visible;
            view1.Visibility = Visibility.Collapsed;
            tbTime.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private async  void CheckIfZumbachIsRunning(object state)
        {
            if(blnZumbachDisplayed==false)
            {
                blnZumbachDisplayed = true;

               await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {

        view1.Navigate(targetUri);
        tbTime.Visibility = Visibility.Collapsed;
        view1.NavigationFailed += View1_NavigationFailed;
    });
            }

        }

        private void DisplayZumbach()
        {
           


            view1.Navigate(targetUri);
            view1.NavigationFailed += View1_NavigationFailed;
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            blnZumbachDisplayed = false;
            targetUri = new Uri(@"http://10.0.200.155/screen.htm");
            CheckIfZumbachIsRunning(null);
        }
    }
}
