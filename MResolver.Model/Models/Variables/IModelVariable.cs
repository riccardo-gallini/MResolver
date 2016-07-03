using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public interface IModelVariable : IModelElement
    {

        /// <summary>
        /// 
        /// </summary>
        VariableType VariableType { get; }

    }
}

