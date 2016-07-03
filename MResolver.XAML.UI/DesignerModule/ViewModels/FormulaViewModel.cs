using Gemini.Framework;
using ICSharpCode.AvalonEdit.Document;
using MResolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.UI
{
    public class FormulaViewModel : Document
    {
        public Formula Formula { get; } 

        public FormulaViewModel(Formula innerFormula)
        {
            Formula = innerFormula;
            this.DisplayName = Formula.Name;
            FormulaText = new TextDocument();
            FormulaText.Changed += FormulaTextChanged;
        }

        private void FormulaTextChanged(object sender, DocumentChangeEventArgs e)
        {
            
        }

        public TextDocument FormulaText { get; set; }
        
    }
}
