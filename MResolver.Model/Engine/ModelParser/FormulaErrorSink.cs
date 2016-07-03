using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Engine.ModelParser
{

    /// <summary>
    /// Supresses exceptions thrown by the PythonParser when it finds a parsing error.
    /// Errors are stored in Errors collection.
    /// </summary>
    public class FormulaErrorSink : ErrorSink
    {
        public List<FormulaError> Errors { get; } 

        public FormulaErrorSink()
        {
            Errors = new List<FormulaError>();
            Listener = new ErrorSinkProxyListener(this);
        }

        public ErrorListener Listener { get; }
        
        public override void Add(SourceUnit source, string message, SourceSpan span, int errorCode, Severity severity)
        {
            int line = GetLine(span.Start.Line);
            Errors.Add(new FormulaError(source.Path, message, source.GetCodeLine(line), span, errorCode, severity));
        }
                
        /// <summary>
        /// Ensure the line number is valid.
        /// </summary>
        static int GetLine(int line)
        {
            if (line > 0)
            {
                return line;
            }
            return 1;
        }
    }
}
