using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    /// <summary>
    /// Represents a formula for the model
    /// </summary>
    public class Formula : IModelElement
    {

        /// <summary>
        /// 
        /// </summary>
        public Model Model { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        public Formula(string name, Model m)
        {
            Name = name;
            Model = m;
            Breakpoints = new List<Breakpoint>();
        }

        public IList<Breakpoint> Breakpoints {get;}

        //after compilation 
        public bool IsCompiled { get; set; }
        public Dictionary<string, IModelVariable> AssignedVariables;
        public Dictionary<string, IModelVariable> SourceVariables;



    }
}


/*
Public Class Formula

    
    Dim _prefixName As String

    
    

    Friend Sub New(name_prefix As String, m As Model, impl As Action)
        _model = m
        _impl = impl
        _prefixName = name_prefix
        _name = BuildName()
    End Sub

    Private Function BuildName() As String
        Dim name = PrefixName
        Dim i = _model._setNestedLoops.Count - 1
        While i >= 0
            name &= "_" & _model._setNestedLoops(i).Index
            i -= 1
        End While
        If _model.Formulas.ContainsKey(name) Then
            name &= "_" & (_model.Formulas.Count - 1)
        End If
        Return name
    End Function

    Friend Sub Execute()
        _impl()
    End Sub

    Public Overrides Function ToString() As String
        Return _name
    End Function
End Class*/
