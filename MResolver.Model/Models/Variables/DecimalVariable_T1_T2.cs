using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class DecimalVariable<X1,X2> : Variable<TupleKey<X1,X2>, Decimal>
    {

        //Indexer by single key
        public Decimal this[X1 idx1, X2 idx2]
        {
            get
            {
                return _getInternalData(TupleKey.Create(idx1, idx2));
            }
            set
            {
                _setInternalData(TupleKey.Create(idx1, idx2), value);
            }
        }
        
        public override int Arity
        {
            get
            {
                return 2;
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


        internal DecimalVariable(string name, Model m, Set<TupleKey<X1,X2>> overSet) : base(name, m)
        {
            if (SetUtility.IsBaseSetType(typeof(X1), typeof(X2)) )
            {
                this.OverSet = overSet;
                this._internal_data = new Dictionary<TupleKey<X1,X2>, Decimal>();
            }
            else
            {
                throw new ArgumentException();
            }

        }
    }
}
