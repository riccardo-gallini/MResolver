using ICSharpCode.SharpDevelop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MResolver.UI
{
    public class ResourceImage : IImage
    {

        public string Name { get; }

        public ResourceImage(string _name)
        {
            Name = _name;
        }

        public Bitmap Bitmap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Icon Icon
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ImageSource ImageSource
        {
            get
            {
                return new BitmapImage(new Uri(Name, UriKind.Relative));
            }
        }
    }
}
