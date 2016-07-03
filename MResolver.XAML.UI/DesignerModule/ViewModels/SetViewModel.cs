using Gemini.Framework;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.UI
{
    public class SetViewModel : Document
    {
        public IModelSet Set { get; }

        public SetViewModel(IModelSet innerSet)
        {
            Set = innerSet;
            this.DisplayName = Set.Name;
            
        }


    }
}
