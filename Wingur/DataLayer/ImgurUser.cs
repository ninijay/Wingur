using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingur.DataLayer
{
    /*
     *  Imgur User Class
     *  See https://api.imgur.com/models/account for more details
     */
    class ImgurUser
    {
        private int id;
        private string url;
        private string bio;
        private float rep;
        private int created;
        private int pro;

        public System.Int32 Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public System.String Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public System.String Bio
        {
            get
            {
                return bio;
            }

            set
            {
                bio = value;
            }
        }

        public System.Single Rep
        {
            get
            {
                return rep;
            }

            set
            {
                rep = value;
            }
        }

        public System.Int32 Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public System.Int32 Pro
        {
            get
            {
                return pro;
            }

            set
            {
                pro = value;
            }
        }
    }
}
