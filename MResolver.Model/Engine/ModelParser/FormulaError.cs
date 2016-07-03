using Microsoft.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Engine.ModelParser
{
    /// <summary>
	/// Saves information about a parser error reported by the FormulaErrorSink.
	/// </summary>
	public class FormulaError
    {
        string Path { get; } 
        string Message { get; }
        string LineText { get; }
        SourceSpan Location { get; }
        int ErrorCode { get; }
        Severity Severity { get; }

        public FormulaError(string path, string message, string lineText, SourceSpan location, int errorCode, Severity severity)
        {
            this.Path = path;
            this.Message = message;
            this.LineText = lineText;
            this.Location = location;
            this.ErrorCode = errorCode;
            this.Severity = severity;
        }

        public override string ToString()
        {
            return String.Concat("[", ErrorCode, "][Sev:", Severity.ToString(), "]", Message, "\r\nLine: ", Location.Start.Line, LineText, "\r\n", Path, "\r\n");
        }
    }
}
