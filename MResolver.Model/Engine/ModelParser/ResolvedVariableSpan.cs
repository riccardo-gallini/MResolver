using Microsoft.Scripting;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Engine.ModelParser
{
    /// <summary>
    /// Contains the span of a variable inside a formula.
    /// </summary>
    public class ResolvedVariableSpan
    {

        public IModelVariable Variable { get; }
        public SourceSpan Location { get; }

        public ResolvedVariableSpan(IModelVariable variable, SourceSpan location)
        {
            Variable = variable;
            Location = location;
        }
    }
}
