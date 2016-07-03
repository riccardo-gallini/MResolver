using Gemini.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework.Services;
using MResolver.Models;

namespace MResolver.UI
{
    public class ModelTreeViewModel : Tool
    {

        public override PaneLocation PreferredLocation { get { return PaneLocation.Left; } }
        public override bool ShouldReopenOnStart
        {
            get
            {
                return false;
            }
        }

        public Model Model { get; }

        //Model tree's root nodes
        public ObservableCollection<NodeViewModel> RootNodes { get; }
                        
                
        public ModelTreeViewModel(Model model) 
        {
            //build model tree
            Model = model;

            RootNodes = new ObservableCollection<NodeViewModel>();
            RootNodes.Add(buildTree(Model));
            
            this.DisplayName = "Model Explorer";
        }
                

        private NodeViewModel buildTree(Model model)
        {
            var root = new NodeViewModel(this, NodeType.Model, model.Name ?? "Model");

            var sets_group = new NodeViewModel(this, NodeType.SetGroup, "Sets");
            root.Nodes.Add(sets_group);
            foreach (var set in model.Sets.Values)
            {
                sets_group.Nodes.Add(new NodeViewModel(this, NodeType.Set, set));
            }

            var variables_group = new NodeViewModel(this, NodeType.VariableGroup, "Variables");
            root.Nodes.Add(variables_group);
            foreach (var variable in model.Variables.Values)
            {
                variables_group.Nodes.Add(new NodeViewModel(this, NodeType.Variable, variable));
            }

            var formulas_group = new NodeViewModel(this, NodeType.FormulaGroup, "Formulas");
            root.Nodes.Add(formulas_group);
            foreach (var formula in model.Formulas.Values)
            {
                formulas_group.Nodes.Add(new NodeViewModel(this, NodeType.Formula, formula));
            }

            var scripts_group = new NodeViewModel(this, NodeType.ScriptGroup, "Scripts");
            root.Nodes.Add(scripts_group);
            foreach (var script in model.Scripts.Values)
            {
                scripts_group.Nodes.Add(new NodeViewModel(this, NodeType.Script, script));
            }

            return root;
        }
        
    }
}
