using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{

    //A tuple that is good as a dictionary key

    public abstract class TupleKey
    {
        public static TupleKey<T1,T2> Create<T1,T2>(T1 item1, T2 item2)
        {
            return new TupleKey<T1,T2>(item1, item2);
        }

        public static TupleKey<T1,T2,T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new TupleKey<T1,T2,T3>(item1, item2, item3);
        }

        public static TupleKey<T1,T2,T3,T4> Create<T1,T2,T3,T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return new TupleKey<T1,T2,T3,T4>(item1, item2, item3, item4);
        }
        
    }
}
