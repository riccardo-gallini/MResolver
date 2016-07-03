using Gemini.Framework;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.UI
{
    public class VariableViewModel : Document
    {
        public IModelVariable Variable;

        public VariableViewModel(IModelVariable innerVariable)
        {
            Variable = innerVariable;
            this.DisplayName = Variable.Name;
        }

    }
}
