using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;
using MResolver.Models;
using Microsoft.Scripting;

namespace MResolver.Engine.ModelParser
{
    /// <summary>
    /// Contains info obtained by the parser the formula text
    /// Info:  - errors from parser
    ///        - the complete python ast
    ///        - variable dependecies from formula extracted from python ast
    /// </summary>
    public class FormulaParseInfo
    {
        public IList<FormulaError> Errors { get; }
        public Formula Formula { get; }
        public PythonAst Ast { get; }

        public bool IsValid { get; }

        public IModelVariable AssignedVariable { get; internal set; }
        public ModelElementDictionary<IModelVariable> SourceVariables { get; }
        public IList<ResolvedVariableSpan> ResolvedVariableSpans { get; }

        public FormulaParseInfo(Formula f, List<FormulaError> errors, PythonAst python_ast)
        {
            this.Formula = f;
            this.Errors = errors;
            this.Ast = python_ast;
            this.SourceVariables = new ModelElementDictionary<IModelVariable>();
            this.ResolvedVariableSpans = new List<ResolvedVariableSpan>();

            if (errors.Count==0) { this.IsValid = true; }
        }

    }
}
