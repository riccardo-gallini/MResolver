using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Engine
{
    public class BreakpointEventArgs : EventArgs
    {
        Model Model { get; }
        Formula Formula { get; }
        int LineNumber { get; }

        public BreakpointEventArgs(Model model, Formula formula, int lineNumber)
        {
            Model = model;
            Formula = formula;
            LineNumber = lineNumber;
        }

    }
}
