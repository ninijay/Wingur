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
using System.Threading.Tasks;
using Windows.Data.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Wingur
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Testing Functions
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MenuAnimationOpen.Begin();
        }

        private void txtUsername_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //TODO: Sign in method or if already signed in, bring up user profile
        }

        private void txtViral_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //TODO: Get Viral Gallery
            BLImgurAPI bl = new BLImgurAPI();
            JsonObject json = bl.GetGallery("hot", "time", true, 1);

            //TODO: Process JSON
            //TODO: Display Content
        }

        private void txtUserSub_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //TODO: Get User sub Gallery
            BLImgurAPI bl = new BLImgurAPI();
            JsonObject json = bl.GetGallery("user", "time", true, 1);
            //TODO: Process JSON
            //TODO: Display Content
        }


    }
}
