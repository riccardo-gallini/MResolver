using Caliburn.Micro;
using MResolver.Models;
using MResolver.UI.Designer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MResolver.UI
{

    public enum NodeType
    {
        Model,
        SetGroup,
        Set,
        VariableGroup,
        Variable,
        FormulaGroup,
        Formula,
        ScriptGroup,
        Script
    }

    public class NodeViewModel : BaseViewModel
    {
        public NodeType NodeType { get; }
        public IModelElement ModelElement { get; }

        public ObservableCollection<NodeViewModel> Nodes { get; }
        public NodeViewModel ParentNode { get; private set; }
        public ModelTreeViewModel TreeView { get; }

        public bool IsSelected { get; set; }
        public bool HasChildItems { get { return Nodes.Count > 0; } }
        public bool IsExpanded { get; set; }

        public int HierarchicalLevel
        {
            get
            {
                var level = 0;
                NodeViewModel node = this;
                while ((node = node.ParentNode) != null)
                {
                    level++;
                }
                return level;
            }
        }

        public string Name { get; }
        public string Description { get; }

        private NodeViewModel(ModelTreeViewModel tree, NodeType nodeType)
        {
            NodeType = nodeType;
            Nodes = new ObservableCollection<NodeViewModel>();
            TreeView = tree;
            Nodes.CollectionChanged += Nodes_CollectionChanged;
        }

        private void Nodes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems!=null) { 
                foreach (NodeViewModel new_node in e.NewItems)
                {
                    new_node.ParentNode = this;
                }
            }

            if (e.OldItems!=null) { 
                foreach (NodeViewModel old_node in e.OldItems)
                {
                    old_node.ParentNode = null;
                }
            }
        }

        public NodeViewModel(ModelTreeViewModel tree, NodeType nodeType, string name, string description="") : this(tree, nodeType)
        {
            Name = name;
            Description = description;
        }

        public NodeViewModel(ModelTreeViewModel tree, NodeType nodeType, IModelElement innerModelElement) : this(tree, nodeType)
        {
            ModelElement = innerModelElement;
            Name = ModelElement.Name;
            Description = ModelElement.Description;
        }
        
        #region Node Styles

        public ImageSource Icon
        {
            get
            {
                switch (this.NodeType)
                {
                    case NodeType.Set:
                        return ResourceImage.Get("../../Icons/Designer/Set.png");

                    case NodeType.Variable:
                        return ResourceImage.Get("../../Icons/Designer/Variable_16x16.png");

                    case NodeType.Formula:
                        return ResourceImage.Get("../../Icons/Designer/Formula.png");

                    case NodeType.Script:
                        return ResourceImage.Get("../../Icons/Designer/Script.png");

                    default:
                        if (IsExpanded)
                        { return ResourceImage.Get("../../Icons/Designer/OpenDoc_16x16.png"); }
                        else { return ResourceImage.Get("../../Icons/Designer/OpenDoc_16x16.png"); }
                }
            }
        }

        public string FontWeight
        {
            get
            {
                switch (this.NodeType)
                {
                    case NodeType.Model:
                        return "DemiBold";
                        
                    default:
                        return "Regular";
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _Open;

        public ICommand Open
        {
            get
            {
                if (ModelElement != null)
                {
                    if (_Open==null)
                    {
                        var designer = IoC.Get<DesignerModule>();
                        _Open = new RelayCommand(() => designer.OpenEditWindow(NodeType, ModelElement));
                    }
                    return _Open;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

    }
}
