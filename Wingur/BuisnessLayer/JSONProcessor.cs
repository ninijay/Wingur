using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Wingur.BuisnessLayer
{
    class JSONProcessor
    {
        public DataLayer.ImgurUser jsonToUser(Windows.Data.Json.JsonObject json)
        {
            DataLayer.ImgurUser _usr;
            //----------------------------
            
            _usr = new DataLayer.ImgurUser();
            JsonObject data = json.GetNamedObject("data", null);
            JsonValue jsonV;
            _usr.Id = (int)(data.GetNamedNumber("id"));
            _usr.Url = data.GetNamedString("url");
            //null value causes JSON object to crash
            jsonV=data.GetNamedValue("bio");
            if(jsonV.ValueType.ToString() == "Null")
            {
              _usr.Bio = "";
            }
            else
            {
              _usr.Bio = jsonV.ToString();
            }
            _usr.Rep = (float) data.GetNamedNumber("reputation");
            _usr.Created = (int)data.GetNamedNumber("created");
            //may be boolean or int: false = not a pro user, number if is a pro user
            jsonV = data.GetNamedValue("pro_expiration");
            if (jsonV.ValueType.ToString() == "Boolean")
            {
                _usr.Pro = -1;
            }
            else
            {
                _usr.Pro = (int)jsonV.GetNumber();
            }

            // return user
            return _usr;
        }
    }
}
