using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Model : INamedElement
    {
        /// <summary>
        /// 
        /// </summary>
        public ModelElementDictionary<IModelSet> Sets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ModelElementDictionary<IModelVariable> Variables { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ModelElementDictionary<Formula> Formulas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ModelElementDictionary<Script> Scripts { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsSet(string name) { return this.Sets.ContainsKey(name); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public bool ContainsSet(IModelSet set) { return this.Sets.Contains(set); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsVariable(string name) { return this.Variables.ContainsKey(name); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public bool ContainsVariable(IModelVariable variable) { return this.Variables.Contains(variable); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsFormula(string name) { return this.Formulas.ContainsKey(name); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public bool ContainsFormula(Formula formula) { return this.Formulas.Contains(formula); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsScript(string name) { return this.Scripts.ContainsKey(name); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public bool ContainsScript(Script script) { return this.Scripts.Contains(script); }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Model()
        {
            Sets = new ModelElementDictionary<IModelSet>();
            Variables = new ModelElementDictionary<IModelVariable>();
            Formulas = new ModelElementDictionary<Formula>();
            Scripts = new ModelElementDictionary<Script>();
        }

        #region Set/Variable/Formula building fluent interface

        public SetBuilder Set(string setName)
        {
            return new SetBuilder(setName, this);
        }

        public DecimalVariableBuilder DecimalVariable(string variableName)
        {
            return new DecimalVariableBuilder(variableName, this);
        }

        public Formula Formula(string formulaName, string formulaText = null)
        {
            var new_formula = new Formula(formulaName, this);
            new_formula.Text = formulaText;
            this.Formulas.Add(new_formula);
            return new_formula;
        }

        #endregion

    }
}
