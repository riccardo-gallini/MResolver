using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public static class SetUtility
    {
       
        public readonly static IEnumerable<IModelSet> EmptyOverSets = Enumerable.Empty<IModelSet>();
              
        public readonly static AllKeys ALL_KEYS = AllKeys.singleton;

        internal static IndexType GetIndexType(Type type)
        {
            if (type == typeof(int))
                return IndexType.Numeric;

            else if (type == typeof(string))
                return IndexType.String;

            else if (type == typeof(DateTime))
                return IndexType.Time;

            else
                return IndexType.Undefined;

        }

        internal static bool IsBaseSetType(Type type)
        {
            if ((type == typeof(int)) || type == typeof(string) || type == typeof(DateTime))
                return true;
            else
                return false;
        }

        internal static bool IsBaseSetType(Type type1, Type type2)
        {
            return IsBaseSetType(type1) && IsBaseSetType(type2);
        }

        internal static bool IsBaseSetType(Type type1, Type type2, Type type3)
        {
            return IsBaseSetType(type1) && IsBaseSetType(type2) && IsBaseSetType(type3);
        }

        internal static bool IsBaseSetType(Type type1, Type type2, Type type3, Type type4)
        {
            return IsBaseSetType(type1) && IsBaseSetType(type2) && IsBaseSetType(type3) && IsBaseSetType(type4);
        }
    }
}
