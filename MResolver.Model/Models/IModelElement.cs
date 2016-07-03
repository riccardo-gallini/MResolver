using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public interface IModelElement : INamedElement
    {
        /// <summary>
        /// 
        /// </summary>
        Model Model { get; }

    }

    public interface INamedElement
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        string Description { get; set; }
    }

    
}
