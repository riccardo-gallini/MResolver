using IronPython.Compiler.Ast;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Engine.ModelParser
{

    /// <summary>
    /// Walker class used to analyze a formula's python AST
    /// </summary>
    public class FormulaAstWalker : PythonWalker
    {
        public FormulaParseInfo Info { get; }
        public Model ParsedModel { get; }
        public Formula ParsedFormula { get; }
        
        public FormulaAstWalker(FormulaParseInfo formulaParseInfo)
        {
            Info = formulaParseInfo;
            ParsedFormula = Info.Formula;
            ParsedModel = ParsedFormula.Model;
        }

        #region Assignment parsing

        enum AssignmentSide
        {
            None,
            LHS,
            RHS
        }

        AssignmentSide assignment_location = AssignmentSide.None;

        public override bool Walk(AssignmentStatement node)
        {
            assignment_location = AssignmentSide.LHS;
            foreach (var n in node.Left) { n.Walk(this); }

            assignment_location = AssignmentSide.RHS;
            node.Right.Walk(this);

            assignment_location = AssignmentSide.None;
            return true;
        }

        public override bool Walk(NameExpression node)
        {
            //is it a variable?
            if (ParsedModel.ContainsVariable(node.Name))
            {
                IModelVariable variable = ParsedModel.Variables[node.Name];
                this.WalkVariable(variable, node);
            }
            return base.Walk(node); 
        }
        
        public void WalkVariable(IModelVariable variable, NameExpression node)
        {
            //if we find a variable inside an assignment, it can be useful...
            if (assignment_location == AssignmentSide.LHS)
            {
                //if we are in the LHS, then it's the assigned variable 
                Info.AssignedVariable = variable;
                Info.ResolvedVariableSpans.Add(new ResolvedVariableSpan(variable, node.Span));
            }

            else if (assignment_location == AssignmentSide.RHS)
            {
                //if we are in the RHS then it's one of the source variables for the formula
                if (!Info.SourceVariables.ContainsKey(variable.Name))
                {
                    Info.SourceVariables.Add(variable);
                }
                Info.ResolvedVariableSpans.Add(new ResolvedVariableSpan(variable, node.Span));
            }
        }
        
        #endregion

    }
}
