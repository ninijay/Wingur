using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingur.BuisnessLayer
{
    class JSONProcessor
    {
        public DataLayer.ImgurUser jsonToUser(Windows.Data.Json.JsonObject json)
        {
            DataLayer.ImgurUser _usr;
            //----------------------------

            _usr = new DataLayer.ImgurUser();
            _usr.Id = (int)(json.GetNamedArray("data").GetNumberAt (0));
            _usr.Url = json.GetNamedArray("data").GetStringAt(1);
            _usr.Bio = json.GetNamedArray("data").GetStringAt(2);
            _usr.Rep = (float) json.GetNamedArray("data").GetNumberAt(3);
            _usr.Created = (int)json.GetNamedArray("data").GetNumberAt(4);
            _usr.Pro = (int)json.GetNamedArray("data").GetNumberAt(5);


            // return user
            return _usr;
        }
    }
}
