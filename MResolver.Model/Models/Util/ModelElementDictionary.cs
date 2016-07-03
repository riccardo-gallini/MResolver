using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{

    /// <summary>
    /// A dictionary-based collection for named model elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelElementDictionary<T> : Dictionary<string, T> where T : INamedElement
    {
        
        public ModelElementDictionary(IDictionary<string,T> dict) : base(dict)
        {
        }

        public ModelElementDictionary(IEnumerable<T> list) : base()
        {
            foreach(var element in list)
            {
                this.Add(element);
            }
        }

        public ModelElementDictionary() : base()
        {
        }

        /// <summary>
        /// Add a model element to the collection.
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            this.Add(element.Name, element);
        }

        /// <summary>
        /// Checks wheter the element is contained in the collection. 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            return this.ContainsKey(element.Name);
        }


    }
}
