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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section">hot | top | user     - defaults to hot</param>
        /// <param name="sort">viral | top | time | rising (only available with user section)      - defaults to viral</param>
        /// <param name="Viral">true | false     - Show or hide viral images from the 'user' section. Defaults to true</param>
        /// <param name="Page">integer - the data paging number</param>
        /// <param name="OAuth">OAuth Token - For user authentication</param>
        /// <returns></returns>
        public string GetGallery(String section,String sort, Boolean Viral, Int32 Page, String OAuth =null )
        {
            HttpClient client = GetHttpClient(OAuth);
            
            string URI = BaseURL;
            URI += "gallery/" + section + "/" + sort + "/" + Page + ".json";
            if (section == "user")
            {
                    URI += "showViral=" + Viral.ToString();
            }
  
            
            var jsonStr = client.GetStringAsync(URI).Result;
            return jsonStr;
           // throw new Exception("Method not implemented yet");
        }

        public Object GetSubRedditGallery(String Subreddit,String Sort,Int32 Page)
        {
            throw new Exception("Method not implemented yet");
        }

        //Configures HttpClient with proper headers
        private HttpClient GetHttpClient(String OAuth= null)
        {
            HttpClient client = new HttpClient();
            //Must send client ID to access API
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Client-ID", Config.Config.client_id);
            client.Timeout = System.TimeSpan.FromSeconds(60);
            if(OAuth!=null)
            {
                client.DefaultRequestHeaders.Add("Bearer", OAuth); //Add OAuth Token to http Headers
            }
            return client;
        }
    }
}
