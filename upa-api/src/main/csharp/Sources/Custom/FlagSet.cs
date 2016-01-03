using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;
namespace Net.Vpc.Upa{


    /**
    * This is a Read Only EnumSet implementation
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    */
    public sealed class FlagSet<E> : ICloneable, IEnumerable<E> {

        private readonly Type elementType;

        private readonly HashSet<E> enumSet;

        internal FlagSet(Type elementType, HashSet<E> enumSet)
        {
            this.elementType = elementType;
            this.enumSet = enumSet;
        }


        public ISet<E> AsSet() {
            return new HashSet<E>(enumSet);
        }

        public bool IsEmpty() {
            return enumSet.Count==0;
        }

        public int Size() {
            return enumSet.Count;
        }

        public bool Missing(E e) {
            return !enumSet.Contains(e);
        }

        public bool ContainsAll(FlagSet<E> c) {
            foreach (var flag in c)
            {
                if(!enumSet.Contains(flag))
                {
                    return false;
                }
            }
            return true;
        }

        public bool MissingAll(params E [] all) {
            return MissingAll(new List<E>(all));
        }

        public bool MissingAll(List<E> c) {
            foreach (E object_ in c) {
                if (enumSet.Contains(object_)) {
                    return false;
                }
            }
            return true;
        }

        public bool MissingAll(FlagSet<E> c) {
            return MissingAll(new List<E>(c.enumSet));
        }

        public bool Contains(E e) {
            return enumSet.Contains(e);
        }

        public bool ContainsAll(List<E> c) {
            foreach (E object_ in c)
            {
                if (!enumSet.Contains(object_))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ContainsAll(params E [] arr) {
            return ContainsAll(new List<E>(arr));
        }

        public FlagSet<E> Add(E e) {
            HashSet<E> c = new HashSet<E>(enumSet);
            c.Add(e);
            return new FlagSet<E>(elementType, c);
        }

        public FlagSet<E> AddAll(List<E> collection) {
            HashSet<E> c = new HashSet<E>(enumSet);
            foreach (var e in collection)
            {
                c.Add(e);
            }
            return new FlagSet<E>(elementType, c);
        }

        public FlagSet<E> AddAll(params E [] arr) {
            return AddAll(new List<E>(arr));
        }

        public FlagSet<E> AddAll(FlagSet<E> other) {
            return AddAll(new List<E>(other.enumSet));
        }

        public FlagSet<E> Remove(E e) {
            HashSet<E> c = new HashSet<E>(enumSet);
            c.Remove(e);
            return new FlagSet<E>(elementType, c);
        }

        public FlagSet<E> RemoveAll(List<E> collection) {
            HashSet<E> c = new HashSet<E>(enumSet);
            foreach (var e in collection)
            {
                c.Remove(e);
            }
            return new FlagSet<E>(elementType, c);
        }

        public FlagSet<E> RemoveAll(params E [] arr) {
            return RemoveAll(new List<E>(arr));
        }

        public FlagSet<E> RemoveAll(FlagSet<E> other) {
            return RemoveAll(new List<E>(other.enumSet));
        }

        public FlagSet<E> RetainAll(List<E> collection) {
            HashSet<E> c = new HashSet<E>(enumSet);
            foreach (var e in collection)
            {
                if (enumSet.Contains(e))
                {
                    c.Add(e);
                }
            }
            return new FlagSet<E>(elementType, c);
        }

        public FlagSet<E> RetainAll(params E [] arr) {
            return RetainAll(new List<E>(arr));
        }

        public FlagSet<E> RetainsAll(FlagSet<E> other) {
            return RetainAll(new List<E>(other.enumSet));
        }

        public IEnumerator<E> GetEnumerator()
        {
            return enumSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return new FlagSet<E>(elementType, enumSet);
        }

        override public String ToString() {
            StringBuilder sb = new StringBuilder("[");
            bool first = true;
            foreach (E e in this) {
                if (first) {
                    first = false;
                } else {
                    sb.Append(", ");
                }
                sb.Append(e);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
