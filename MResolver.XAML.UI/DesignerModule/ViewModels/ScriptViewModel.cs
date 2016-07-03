using Gemini.Framework;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.UI
{
    public class ScriptViewModel : Document
    {
        public Script Script { get; }

        public ScriptViewModel(Script innerScript) 
        {
            Script = innerScript;
            this.DisplayName = Script.Name;
        }

    }
}
