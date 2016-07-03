using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MResolver.UI
{
    /// <summary>
    /// Interaction logic for ModelTree.xaml
    /// </summary>
    public partial class ModelTreeView : UserControl
    {

        public ModelTreeView()
        {
            InitializeComponent();
        }
                
        private void TreeViewItemMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var node = (sender as FrameworkElement).Tag as NodeViewModel;
                if (!node.HasChildItems)
                {
                    node.Open.Execute(node);
                }
            }

        }
                
    }
}
