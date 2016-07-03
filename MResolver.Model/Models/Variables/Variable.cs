using IronPython.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{
    



    public abstract class Variable<X, V> : IModelVariable
    {

        protected IDictionary<X, V> _internal_data;

        //after recalc: used to keep track of predecessors / successors for individual values
        protected IDictionary<X, IList<ValueInfo>> _internal_predecessors;
        protected IDictionary<X, IList<ValueInfo>> _internal_successors;

        #region INDEXERS - for accessing variables 
        
        //Generic Indexer (by tuple or single value)
        public V this[X key]
        {
            get
            {
                return _getInternalData(key);
            }
            set
            {
                _setInternalData(key, value);
            }
        }

        //Generic object Indexed (by python tuple)
        public V this[PythonTuple key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //Generic object Indexed (by python tuple)
        public V this[Slice key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //Generic object Indexed (by slice - by int as date)
        public V this[object key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Model Model { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract int Arity { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public Set<X> OverSet { get; protected set; }

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
        public abstract VariableType VariableType { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public abstract V DefaultValue { get;  }

        protected Variable(string name, Model m)
        {
            this.Name = name;
            this.Model = m;
        }

        protected V _getInternalData(X idx) {

            if (_internal_data.ContainsKey(idx) == false)
            {
                var dft = this.DefaultValue;
                _internal_data.Add(idx, dft);
                OverSet.Add(idx);
                return dft;
            }
            else
            {
                return _internal_data[idx];
            }
        }

        protected void _setInternalData(X idx, V value)
        {
            if (_internal_data.ContainsKey(idx) == false)
            {
                _internal_data.Add(idx, value);
                OverSet.Add(idx);
            }
            else
            {
                _internal_data[idx] = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
