using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public interface IModelSet : IModelElement
    {

        /// <summary>
        /// 
        /// </summary>
        SetType SetType { get; }

        /// <summary>
        /// 
        /// </summary>
        IndexType IndexType { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IModelSet> OverSets { get; }

    }
}
