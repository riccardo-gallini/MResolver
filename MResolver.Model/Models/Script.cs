using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    public abstract class Script : Formula
    {
        public Script(string name, Model m) : base(name,m)
        {

        }

    }
}
