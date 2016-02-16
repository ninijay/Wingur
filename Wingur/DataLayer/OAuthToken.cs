using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingur.DataLayer
{
    class OAuthToken
    {
        String _token;
        String _refreshtoken;
        DateTime _expires;
        Boolean _authenticated=false;
        DataLayer.ImgurUser _user;
        

        public String Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public String RefreshToken
        {
            get { return _refreshtoken; }
            set { _refreshtoken = value; }
        }
        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        public Boolean Authenticated
        {
            get { return _authenticated; }
            set { _authenticated = value; }
        }
        public DataLayer.ImgurUser User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
