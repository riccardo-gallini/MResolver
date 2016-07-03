using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MResolver.Models;
using MResolver.Engine.ModelParser;
using IronPython;
using IronPython.Hosting;
using IronPython.Compiler;
using IronPython.Compiler.Ast;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;
using Microsoft.Scripting.Runtime;




namespace MResolver.Engine
{    
    /// <summary>
    /// Hosts a model and oversees its parsing, compilation and execution 
    /// </summary>
    public class ModelHost : IModelEngine
    {
        public Model RunningModel { get; }
        internal  ScriptEngine ScriptEngine { get; }

        private ScriptScope scriptScope = null;
        private FormulaErrorSink executionErrorSink;

        public ModelHost(Model model)
        {
            RunningModel = model;
            ScriptEngine = Python.CreateEngine();
            
            scriptScope = ScriptEngine.CreateScope();
            executionErrorSink = new FormulaErrorSink();
        }

        public event EventHandler<BreakpointEventArgs> BreakpointReached;
        //public event EventHandler<ExecEventArgs> ExecError;


        public void EveryThing()
        {
            //add every variable / set / formula to the scope
            foreach(var _set in RunningModel.Sets.Values)
            {
                scriptScope.SetVariable(_set.Name, _set);
            }

            foreach (var _variable in RunningModel.Variables.Values)
            {
                scriptScope.SetVariable(_variable.Name, _variable);
            }

            var opts = new CompilerOptions();
            


            foreach (var _formula in RunningModel.Formulas.Values)
            {
                //clear errors
                //executionErrorSink.Errors.Clear();

                ////SCRIPT HOSTING <Microsoft.Scripting.Hosting>
                //ScriptSource script_source = ScriptEngine.CreateScriptSourceFromString(_formula.Text, SourceCodeKind.Statements);
                //CompiledCode compiled_code = script_source.Compile(executionErrorSink.Listener);
                //SourceUnit s;
                //var cc = s.Compile();

                

                //compiled_code.Execute(scriptScope); // <-------

                ////SCRIPT <Microsoft.Scripting>

                var fp = new FormulaParser(this);
                var pi = fp.Parse(_formula);

            }

            
        }


    }

}
