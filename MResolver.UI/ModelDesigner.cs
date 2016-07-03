using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MResolver.UI
{
    public partial class ModelDesigner : Form
    {
        public ModelDesigner()
        {
            InitializeComponent();
        }



        private void BuildTree()
        {
            var root = treeView1.Nodes.Add("Model");
            root.Nodes.Add("Variables");
            root.Nodes.Add("Sets");
            root.Nodes.Add("Formulas");
            root.Nodes.Add("Scripts");
        }

        private void ModelDesigner_Load(object sender, EventArgs e)
        {
            BuildTree();
        }
    }
}
