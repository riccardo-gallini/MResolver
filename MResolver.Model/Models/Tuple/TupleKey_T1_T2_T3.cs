using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public class TupleKey<T1,T2,T3> : TupleKey, IEquatable<TupleKey<T1,T2,T3>>
    {
        public T1 Item1 { get; }
        public T2 Item2 { get; }
        public T3 Item3 { get; }
              
        public TupleKey(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public bool Equals(TupleKey<T1,T2,T3> other)
        {
            var comparer1 = EqualityComparer<T1>.Default;
            if (comparer1.Equals(this.Item1, other.Item1))
            {
                var comparer2 = EqualityComparer<T2>.Default;
                if (comparer2.Equals(this.Item2, other.Item2))
                {
                    var comparer3 = EqualityComparer<T3>.Default;
                    if (comparer3.Equals(this.Item3, other.Item3))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 486187739 + Item1.GetHashCode();
                hash = hash * 486187739 + Item2.GetHashCode();
                hash = hash * 486187739 + Item3.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(TupleKey<T1,T2,T3>))
                return false;
            else
                return this.Equals((TupleKey<T1,T2,T3>)obj);
        }

        public override string ToString()
        {
            return Item1.ToString() + "_" + Item2.ToString() + "_" + Item3.ToString();
        }
    }
}
