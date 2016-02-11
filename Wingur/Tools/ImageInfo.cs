using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Wingur.Tools
{
    class ImageInfo
    {
        private Int32 _width;
        private Int32 _height;
        private Int32 _upvotes;
        private Int32 _downvotes;
        private Int32 _views;
        private String _title;
        private String _description;
        private BitmapImage _image;

        public Int32 Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public Int32 Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public Int32 UpVotes
        {
            get { return _upvotes; }
            set { _upvotes = value; }
        }
        public Int32 DownVotes
        {
            get { return _downvotes; }
            set { _downvotes = value; }
        }
        public Int32 Views
        {
            get { return _views; }
            set { _views = value; }
        }
        public BitmapImage Image
        {
            get { return _image;  }
            set { _image = value; }
        }
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
