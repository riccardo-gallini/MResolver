//using ICSharpCode.SharpDevelop.Bookmarks;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ICSharpCode.SharpDevelop;
//using System.Windows.Input;
//using System.Windows.Media;

//namespace MResolver.UI
//{
//    class Breakpoint : IBookmark
//    {

//        public Breakpoint(int _line, IBookmarkMargin _manager) 
//        {
//            LineNumber = _line;
//            Manager = _manager;
//        }

//        public bool CanDragDrop
//        {
//            get
//            {
//                return true;
//            }
//        }

//        public ImageSource Image
//        {
//            get
//            {
//                return ResourceImage.Get("../../Icons/Bookmarks/Breakpoint.png");
//            }
//        }

//        public IBookmarkMargin Manager { get; }
//        public int LineNumber { get; }
        
//        public int ZOrder
//        {
//            get
//            {
//                return 1;
//            }
//        }

//        public void Drop(int lineNumber)
//        {
//            var p = 0;
//        }

//        public void MouseDown(MouseButtonEventArgs e)
//        {
            
//        }

//        public void MouseUp(MouseButtonEventArgs e)
//        {
//            if (e.ChangedButton == MouseButton.Left)
//            {
//                Manager.Bookmarks.Remove(this);
//                e.Handled = true;
//            }
            
//        }
//    }
//}
