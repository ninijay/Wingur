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
        DataLayer.OAuthToken oat = new DataLayer.OAuthToken();
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
            if (oat.Authenticated)
            {
                //TODO: Display user profile info
            }
            else
            {
                //Authenticate application
                wvAuthenticate.Source = new Uri("https://api.imgur.com/oauth2/authorize?client_id="+Config.Config.client_id+"&response_type=token&state=Authorization");
                wvAuthenticate.Visibility = Visibility.Visible;
            }
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

        private void wvAuthenticate_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (wvAuthenticate.Source.ToString().Contains("https://imgur.com/?state=Authorization#"))
            {
                String url = wvAuthenticate.Source.ToString();
                //remove garbage
                url=url.Replace("https://imgur.com/?state=Authorization#","");
                if(url.Contains("access_token=") & url.Contains("refresh_token=") & url.Contains("expires_in") & url.Contains("account_username") & url.Contains("account_id="))
                {
                    BLImgurAPI bl = new BLImgurAPI();
                    DataLayer.ImgurUser usr;
                    String[] split = url.Split('&');
                    oat.Authenticated = true;
                    oat.Expires = DateTime.Now.AddSeconds(Double.Parse(split[1].Split('=')[1]));
                    oat.Token = split[0].Split('=')[1];
                    usr=bl.logIn(split[4].Split('=')[1],oat.Token);
                    oat.User = usr;
                    txtUsername.Text = "\n" + usr.Url;
                    wvAuthenticate.Visibility = Visibility.Collapsed;
                    wvAuthenticate.Source = new Uri("about:blank");
                }

            }
        }
    }
}
