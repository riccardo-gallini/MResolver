using IronPython;
using IronPython.Compiler;
using IronPython.Compiler.Ast;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;
using Microsoft.Scripting.Runtime;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Engine.ModelParser
{
    /// <summary>
    /// Entry point for Formula parser
    /// receives: > Formula to be analyzed
    /// returns:  > FormulaParseInfo with
    ///             - errors
    ///             - complete python ast
    ///             - variable dependecies from formula
    /// </summary>
    public class FormulaParser
    {
        ModelHost model_host;

        public FormulaParser(ModelHost modelEngine)
        {
            model_host = modelEngine;
        }

        //spawns the python compiler and analyzes a formula
        // outputs: FormulaParseInfo class containing:
        //          errors
        //          python ast
        //          analysis of formula dependencies from python ast
        public FormulaParseInfo Parse(Formula f)
        {
            var parseErrorSink = new FormulaErrorSink();
            var ScriptEngine = model_host.ScriptEngine;

            ScriptSource script_source = ScriptEngine.CreateScriptSourceFromString(f.Text, SourceCodeKind.Statements);
            var source_unit = HostingHelpers.GetSourceUnit(script_source);

            var language_context = HostingHelpers.GetLanguageContext(model_host.ScriptEngine);
            Parser parser = Parser.CreateParser(
                    new CompilerContext(source_unit, language_context.GetCompilerOptions(), parseErrorSink),
                    (PythonOptions)language_context.Options);
            
            var python_ast = parser.ParseFile(false);
            

            var info = new FormulaParseInfo(f, parseErrorSink.Errors, python_ast);

            var formula_walker = new FormulaAstWalker(info);
            python_ast.Walk(formula_walker);

            return info;

        }

    }

   
}
