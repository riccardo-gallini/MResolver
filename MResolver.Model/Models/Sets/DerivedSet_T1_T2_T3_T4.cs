using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class DerivedSet<X1,X2,X3,X4> : Set<TupleKey<X1,X2,X3,X4>>
    {
        public Set<X1> OverSet1 { get; }
        public Set<X2> OverSet2 { get; }
        public Set<X3> OverSet3 { get; }
        public Set<X4> OverSet4 { get; }


        public override IndexType IndexType
        {
            get
            {
                return IndexType.Undefined;
            }
        }

        public override SetType SetType
        {
            get
            {
                return SetType.Derived;
            }
        }

        public override int Arity
        {
            get
            {
                return 4;
            }
        }

        public override IEnumerable<IModelSet> OverSets
        {
            get
            {
                yield return OverSet1;
                yield return OverSet2;
                yield return OverSet3;
                yield return OverSet4;
            }
        }

        public bool Contains(X1 idx1, X2 idx2, X3 idx3, X4 idx4)
        {
            return _internal_data.Contains(TupleKey.Create(idx1, idx2, idx3, idx4));
        }

        public override bool Add(TupleKey<X1,X2,X3,X4> item)
        {
            //add single elements to base sets
            OverSet1.Add(item.Item1);
            OverSet2.Add(item.Item2);
            OverSet3.Add(item.Item3);
            OverSet4.Add(item.Item4);

            return base.Add(item);
        }

        internal DerivedSet(string name,
                            Model m,
                            Set<X1> overSet1,
                            Set<X2> overSet2,
                            Set<X3> overSet3,
                            Set<X4> overSet4)   : base(name, m)
        {
            if (SetUtility.IsBaseSetType(typeof(X1), typeof(X2), typeof(X3), typeof(X4)) == false)
            {
                throw new ArgumentException();
            }

            _internal_data = new HashSet<TupleKey<X1,X2,X3,X4>>();

            OverSet1 = overSet1;
            OverSet2 = overSet2;
            OverSet3 = overSet3;
            OverSet4 = overSet4;
        }

    }
}