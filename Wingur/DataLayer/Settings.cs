using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;


namespace Wingur.DataLayer
{
    class Settings
    {
        public void StoreOAuth(OAuthToken OAuth)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["Authenticated"] = OAuth.Authenticated;
            localSettings.Values["Expires"] = OAuth.Expires.ToBinary();
            localSettings.Values["RefreshToken"] = OAuth.RefreshToken;
            localSettings.Values["Token"] = OAuth.Token;
            localSettings.Values["User_Bio"] = OAuth.User.Bio;
            localSettings.Values["User_Created"] = OAuth.User.Created;
            localSettings.Values["User_Id"] = OAuth.User.Id;
            localSettings.Values["User_Pro"] = OAuth.User.Pro;
            localSettings.Values["User_Rep"] = OAuth.User.Rep;
            localSettings.Values["User_Url"] = OAuth.User.Url;
            

        }

        public OAuthToken GetOAuth()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            OAuthToken o = new OAuthToken();
            ImgurUser u = new ImgurUser();

            try {
                u.Bio = (string)localSettings.Values["User_Bio"];
                u.Created = (int)localSettings.Values["User_Created"];
                u.Id = (int)localSettings.Values["User_Id"];
                u.Pro = (int)localSettings.Values["User_Pro"];
                u.Rep = (float)localSettings.Values["User_Rep"];
                u.Url = (string)localSettings.Values["User_Url"];
                o.Authenticated = (bool)localSettings.Values["Authenticated"];
                o.Expires = DateTime.FromBinary((long)localSettings.Values["Expires"]);
                o.RefreshToken = (string)localSettings.Values["RefreshToken"];
                o.Token = (string)localSettings.Values["Token"];
                o.User = u;

                BuisnessLayer.BLImgurAPI bl = new BuisnessLayer.BLImgurAPI();
                u = bl.logIn(u.Url, o.Token);
                o.User = u;
            }
            catch
            {
                o = new OAuthToken();
                u = new ImgurUser();
                o.User = u;
            }

            return o;
        }

        public void ClearOAuth()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("Authenticated");
            localSettings.Values.Remove("Expires");
            localSettings.Values.Remove("RefreshToken");
            localSettings.Values.Remove("Token");
            localSettings.Values.Remove("User_Bio");
            localSettings.Values.Remove("User_Created");
            localSettings.Values.Remove("User_Id");
            localSettings.Values.Remove("User_Pro");
            localSettings.Values.Remove("User_Rep");
            localSettings.Values.Remove("User_Url");
        }
    }
}
