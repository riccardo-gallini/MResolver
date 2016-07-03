using IronPython.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class DecimalVariable<X1,X2,X3> : Variable<TupleKey<X1,X2,X3>, Decimal>
    {

        //Fast Indexer
        public Decimal this[X1 idx1, X2 idx2, X3 idx3]
        {
            get
            {
                return _getInternalData(TupleKey.Create(idx1, idx2, idx3));
            }
            set
            {
                _setInternalData(TupleKey.Create(idx1, idx2, idx3), value);
            }
        }

        //Generic Indexer (for slicing & for dates as integers)
        //public Decimal this[object idx1, object idx2, object idx3]
        //{
        //    get
        //    {
        //        return _getInternalData(TupleKey.Create(idx1, idx2, idx3));
        //    }
        //    set
        //    {
        //        _setInternalData(TupleKey.Create(idx1, idx2, idx3), value);
        //    }
        //}

        public override int Arity
        {
            get
            {
                return 3;
            }
        }

        public override decimal DefaultValue
        {
            get
            {
                return 0.0m;
            }
        }

        public override VariableType VariableType
        {
            get
            {
                return VariableType.Decimal;
            }
        }


        internal DecimalVariable(string name, Model m, Set<TupleKey<X1, X2, X3>> overSet) : base(name, m)
        {
            if (SetUtility.IsBaseSetType(typeof(X1), typeof(X2), typeof(X3)) )
            {
                this.OverSet = overSet;
                this._internal_data = new Dictionary<TupleKey<X1, X2, X3>, Decimal>();
            }
            else
            {
                throw new ArgumentException();
            }

        }
    }
}
