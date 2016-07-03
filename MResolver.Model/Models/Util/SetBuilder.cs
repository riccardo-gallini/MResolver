using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class SetBuilder
    {
        internal string SetName { get; }
        internal Model Model { get; }

        internal SetBuilder(string setName, Model model)
        {
            SetName = setName;
            Model = model;
        }

        public PrimitiveSet<int> OverIntegers
        {
            get
            {
                var new_set = new PrimitiveSet<int>(SetName, Model);
                Model.Sets.Add(new_set);
                return new_set;
            }
        }

        public PrimitiveSet<string> OverStrings
        {
            get
            {
                var new_set = new PrimitiveSet<string>(SetName, Model);
                Model.Sets.Add(new_set);
                return new_set;
            }
        }

        public PrimitiveSet<DateTime> OverTime
        {
            get
            {
                var new_set = new PrimitiveSet<DateTime>(SetName, Model);
                Model.Sets.Add(new_set);
                return new_set;
            }
        }

        public DerivedSet<X1,X2> Over<X1,X2>(Set<X1> set1, Set<X2> set2)
        {
            var new_set = new DerivedSet<X1, X2>(SetName, Model, set1, set2);
            Model.Sets.Add(new_set);
            return new_set;
        }

        public DerivedSet<X1,X2,X3> Over<X1,X2,X3>(Set<X1> set1, Set<X2> set2, Set<X3> set3)
        {
            var new_set = new DerivedSet<X1, X2, X3>(SetName, Model, set1, set2, set3);
            Model.Sets.Add(new_set);
            return new_set;
        }

        public DerivedSet<X1,X2,X3,X4> Over<X1,X2,X3,X4>(Set<X1> set1, Set<X2> set2, Set<X3> set3, Set<X4> set4)
        {
            var new_set = new DerivedSet<X1,X2,X3,X4>(SetName, Model, set1, set2, set3, set4);
            Model.Sets.Add(new_set);
            return new_set;
        }

    }
}
