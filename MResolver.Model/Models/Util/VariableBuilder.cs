using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class DecimalVariableBuilder
    {
        internal string VariableName { get; }
        internal Model Model { get; }

        internal DecimalVariableBuilder(string variableName, Model model)
        {
            VariableName = variableName;
            Model = model;
        }

        public DecimalVariable<X1> Over<X1>(PrimitiveSet<X1> set)
        {
            var new_variable = new DecimalVariable<X1>(VariableName, Model, set);
            Model.Variables.Add(VariableName, new_variable);
            return new_variable;
       
        }

        public DecimalVariable<X1,X2> Over<X1,X2>(Set<TupleKey<X1,X2>> set)
        {
            var new_variable = new DecimalVariable<X1,X2>(VariableName, Model, set);
            Model.Variables.Add(VariableName, new_variable);
            return new_variable;
        }

        public DecimalVariable<X1,X2,X3> Over<X1,X2,X3>(Set<TupleKey<X1,X2,X3>> set)
        {
            var new_variable = new DecimalVariable<X1,X2,X3>(VariableName, Model, set);
            Model.Variables.Add(VariableName, new_variable);
            return new_variable;
        }

        public DecimalVariable<X1,X2,X3,X4> Over<X1,X2,X3,X4>(Set<TupleKey<X1,X2,X3,X4>> set)
        {
            var new_variable = new DecimalVariable<X1,X2,X3,X4>(VariableName, Model, set);
            Model.Variables.Add(VariableName, new_variable);
            return new_variable;
        }



    }
}
