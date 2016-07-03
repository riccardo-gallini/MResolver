using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    
    public class PrimitiveSet<X1> : Set<X1>
    {
        public override IndexType IndexType
        {
            get
            {
                return SetUtility.GetIndexType(typeof(X1));
            }
        }

        public override int Arity
        {
            get
            {
                return 1;
            }
        }

        public override IEnumerable<IModelSet> OverSets
        {
            get
            {
                return SetUtility.EmptyOverSets;
            }
        }

        public override SetType SetType
        {
            get
            {
                return SetType.Primitive;
            }
        }

        internal PrimitiveSet(string name, Model m) : base(name, m)
        {
            var type = typeof(X1);

            if ( SetUtility.IsBaseSetType(type) == false )
            {
                throw new ArgumentException();
            }

            if (this.IndexType == IndexType.Time)
            {
                base._internal_data = new SortedSet<X1>();
                base._internal_data.Add((X1)(object)DateTime.MinValue); // the only boxing here!!!!
            }
            else
            {
                base._internal_data = new HashSet<X1>();
            }
            
        }

    }


}
