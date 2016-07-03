using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MResolver.Models
{

    public abstract class Set<X> : ISet<X>, IModelSet
    {

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
        public abstract SetType SetType { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract IndexType IndexType { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract IEnumerable<IModelSet> OverSets { get; }
     
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }


        // ISet<T> abstract implementation delegated to base classes

        protected ISet<X> _internal_data;
               

        protected Set(string name, Model m)
        {
            this.Name = name;
            this.Model = m;
        }

        public int Count
        {
            get
            { 
                return _internal_data.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }


        public virtual bool Add(X item)
        {
            if (_internal_data.Contains(item) == false)
            {
                _internal_data.Add(item);
                return true;
            }
            return false;
        }
        
        public void UnionWith(IEnumerable<X> other)
        {
            _internal_data.UnionWith(other);
        }

        public void IntersectWith(IEnumerable<X> other)
        {
            _internal_data.IntersectWith(other);
        }

        public void ExceptWith(IEnumerable<X> other)
        {
            _internal_data.ExceptWith(other);
        }

        public void SymmetricExceptWith(IEnumerable<X> other)
        {
            _internal_data.SymmetricExceptWith(other);
        }

        public bool IsSubsetOf(IEnumerable<X> other)
        {
            return _internal_data.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<X> other)
        {
            return _internal_data.IsSupersetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<X> other)
        {
            return _internal_data.IsProperSupersetOf(other);
        }

        public bool IsProperSubsetOf(IEnumerable<X> other)
        {
            return _internal_data.IsProperSubsetOf(other);
        }

        public bool Overlaps(IEnumerable<X> other)
        {
            return _internal_data.Overlaps(other);
        }

        public bool SetEquals(IEnumerable<X> other)
        {
            return _internal_data.SetEquals(other); //TODO: Remove items?
        }

        void ICollection<X>.Add(X item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            _internal_data.Clear(); //TODO: Remove items?
        }

        public bool Contains(X item)
        {
            return _internal_data.Contains(item);
        }

        public void CopyTo(X[] array, int arrayIndex)
        {
            _internal_data.CopyTo(array, arrayIndex);
        }

        public bool Remove(X item)
        {
            return _internal_data.Remove(item);
        }

        public IEnumerator<X> GetEnumerator()
        {
            return _internal_data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _internal_data.GetEnumerator();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
