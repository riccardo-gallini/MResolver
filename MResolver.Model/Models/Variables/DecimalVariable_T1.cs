using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class DecimalVariable<X1> : Variable <X1, Decimal>
    {

        ////Indexer
        //public Decimal this[X1 idx]
        //{
        //    get
        //    {
        //        return _getInternalData(idx);
        //    }
        //    set
        //    {
        //        _setInternalData(idx, value);
        //    }
        //}

        public override int Arity
        {
            get
            {
                return 1;
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

        internal DecimalVariable(string name, Model m, Set<X1> overSet) : base(name, m) 
        {
            if ( SetUtility.IsBaseSetType(typeof(X1)) )
            {
                this.OverSet = overSet;
                this._internal_data = new Dictionary<X1, Decimal>();
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
    }
}
