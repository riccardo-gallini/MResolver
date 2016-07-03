using Gemini.Framework;
using MResolver.Engine;
using MResolver.Models;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace MResolver.UI.Designer
{
    [Export(typeof(IModule))]
    [Export(typeof(DesignerModule))]
    public class DesignerModule : ModuleBase
    {

        public Model CurrentModel { get; private set; }
        public ModelHost Engine { get; private set; }
        public ModelTreeViewModel TreeView { get; private set; }

        public override void Initialize()
        {
            //boh
            CurrentModel = MResolver.UI.Test.TestModel.TEST_MODEL();
            Engine = new ModelHost(CurrentModel);
            TreeView = new ModelTreeViewModel(CurrentModel);
        }

        public override void PostInitialize()
        {
            Shell.ShowTool(TreeView);

            

            Engine.EveryThing();

        }

        #region Commands

        public ICommand AddPrimitiveSet() { return new RelayCommand(AddPrimitiveSet_impl, CanAlterModel); }
        public ICommand AddDerivedSet() { return new RelayCommand(AddDerivedSet_impl, CanAlterModel); }
        public ICommand RemoveSet() { return new RelayCommand(RemoveSet_impl, CanAlterModel); }
        public ICommand AddVariable() { return new RelayCommand(AddVariable_impl, CanAlterModel); }
        public ICommand RemoveVariable() { return new RelayCommand(RemoveVariable_impl, CanAlterModel); }
        public ICommand AddFormula() { return new RelayCommand(AddFormula_impl, CanAlterModel); }
        public ICommand RemoveFormula() { return new RelayCommand(RemoveFormula_impl, CanAlterModel); }
        public ICommand AddScript() { return new RelayCommand(AddScript_impl, CanAlterModel); }
        public ICommand RemoveScript() { return new RelayCommand(RemoveScript_impl, CanAlterModel); }

        #endregion

        #region Commands implementation

        public void OpenEditWindow(NodeType modelElementType, IModelElement modelElement)
        {
 
            Document doc;
             
            switch (modelElementType)
            {
                case NodeType.Set:
                    doc = new SetViewModel((IModelSet)modelElement);
                    break;

                case NodeType.Variable:
                    doc = new VariableViewModel((IModelVariable)modelElement);
                    break;

                case NodeType.Formula:
                    doc = new FormulaViewModel((Formula)modelElement);
                    break;

                case NodeType.Script:
                    doc = new ScriptViewModel((Script)modelElement);
                    break;

                default:
                    doc = null;
                    break;
                }

                //open the window
                if (doc != null)
                {
                Shell.OpenDocument(doc);
                }
            }
        

        public void AddPrimitiveSet_impl()
        {

        }

        private void AddDerivedSet_impl()
        {
            throw new NotImplementedException();
        }

        private void RemoveSet_impl()
        {
            throw new NotImplementedException();
        }

        private void AddVariable_impl()
        {
            throw new NotImplementedException();
        }

        private void RemoveVariable_impl()
        {
            throw new NotImplementedException();
        }

        private void AddFormula_impl()
        {
            throw new NotImplementedException();
        }

        private void RemoveFormula_impl()
        {
            throw new NotImplementedException();
        }

        private void AddScript_impl()
        {
            throw new NotImplementedException();
        }

        private void RemoveScript_impl()
        {
            throw new NotImplementedException();
        }

        public bool CanAlterModel()
        {
            return true;
        }

        #endregion

    }

}

