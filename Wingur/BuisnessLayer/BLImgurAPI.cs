using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingur
{
    class BLImgurAPI
    {
        String BaseURL = "https://api.imgur.com/3/";

        public Object GetGallery(String section,String sort, Boolean Viral, Int32 Page)
        {
            throw new Exception("Method not implemented yet");
        }

        public Object GetSubRedditGallery(String Subreddit,String Sort,Int32 Page)
        {
            throw new Exception("Method not implemented yet");
        }
    }
}
