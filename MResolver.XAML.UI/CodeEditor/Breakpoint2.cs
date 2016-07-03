using ICSharpCode.SharpDevelop.Bookmarks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpDevelop;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;

namespace MResolver.UI
{
    class Breakpoint2 : BookmarkBase
    {

        public Breakpoint2(int _line, IBookmarkMargin _manager) : base(new TextLocation(_line, 1))
        {
            Manager = _manager;
        }

        

        public override ImageSource Image
        {
            get
            {
                return ResourceImage.Get("../../Icons/Bookmarks/Breakpoint.png");
            }
        }

        public IBookmarkMargin Manager { get; }
           

       
    }
}
