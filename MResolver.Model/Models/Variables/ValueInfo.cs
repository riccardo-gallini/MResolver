using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{

    /// <summary>
    /// Used in predecessors / successors analysis for individual variable values.
    /// </summary>
    public class ValueInfo
    {
        public IModelVariable Variable { get; }
        public object Index { get; }
        public Formula ThroughFormula { get; }

        public ValueInfo(IModelVariable variable, object index, Formula throughFormula)
        {
            Variable = variable;
            Index = index;
            ThroughFormula = throughFormula;
        }
    }

}
