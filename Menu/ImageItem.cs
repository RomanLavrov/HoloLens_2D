using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Menu
{
    class ImageItem
    {
        public BitmapImage Source { get; set; }
        public string Name { get; set; }

        public ImageItem()
        {

        }

        public ImageItem(IRandomAccessStream stream, string name)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(stream);
            Source = bmp;
            Name = name;
        }
    }
}
