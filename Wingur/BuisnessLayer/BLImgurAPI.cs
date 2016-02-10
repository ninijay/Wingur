using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Wingur
{
    class BLImgurAPI
    {
        String BaseURL = "https://api.imgur.com/3/";

        public string GetGallery(String section,String sort, Boolean Viral, Int32 Page)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Client-ID", Config.Config.client_id);
            client.Timeout = System.TimeSpan.FromSeconds(60);
            
            var str = client.GetStringAsync(BaseURL +"gallery/"+ section + "/" + sort + "/" + Page + ".json").Result;
            return str;
           // throw new Exception("Method not implemented yet");
        }

        public Object GetSubRedditGallery(String Subreddit,String Sort,Int32 Page)
        {
            throw new Exception("Method not implemented yet");
        }
    }
}
