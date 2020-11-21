using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:13 AM To change
     * this template use File | Settings | File Templates.
     */
    public class LazyList<T> : System.Collections.Generic.IList<T>, Net.TheVpc.Upa.Closeable {

        protected internal System.Collections.Generic.IEnumerator<T> @base;

        private System.Collections.Generic.IList<T> loaded = new System.Collections.Generic.List<T>();

        private int actualSize = 0;

        internal bool end = false;

        private int startIndex = 0;

		public LazyList(System.Collections.Generic.IEnumerator<T> @base) {
            this.@base = @base;
        }


        public override System.String ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append("[");
            bool v = false;
            if (startIndex > 0) {
                s.Append("<").Append(startIndex).Append(" items ignored> ...");
                v = true;
            }
            foreach (T t in loaded) {
                if (v) {
                    s.Append(", ");
                } else {
                    v = true;
                }
                s.Append(t);
            }
            if (!end) {
                if (v) {
                    s.Append(", ");
                }
                s.Append("... <lazy loadable items>");
            }
            s.Append("]");
            return s.ToString();
        }


        public virtual bool IsEmpty() {
            if (actualSize > 0) {
                return false;
            }
            if (!end) {
                LoadNext();
            }
            return actualSize <= 0;
        }


        internal virtual void Load(int index) {
            if (index < startIndex) {
                throw new System.Exception(index + " < Window = " + startIndex);
            }
            while (!end && index >= actualSize) {
                LoadNext();
            }
        }


        public virtual T Get(int index) {
            Load(index);
            return loaded[index - startIndex];
        }


        protected internal virtual void EnsureLoadAll() {
            while (LoadNext()) {
            }
        }

        private bool LoadNext() {
            if (!end) {
                if (@base.MoveNext()) {
                    loaded.Add(@base.Current);
                    actualSize++;
                    return true;
                }
                Close();
            }
            return false;
        }

        public virtual void Close() {
            end = true;
            LoadingFinished();
        }

        protected internal virtual void LoadingFinished() {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LazyListIterator<T>(this, 0);
        }

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            foreach (var e in this)
            {
                if ((e==null && item==null) ||(e!=null && e.Equals(item)))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            new List<T>(this).CopyTo(array,arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get
            {
                EnsureLoadAll();
                return actualSize;
            }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public int IndexOf(T item)
        {
            int pos = 0;
            foreach (var e in this)
            {
                if ((e == null && item == null) || (e != null && e.Equals(item)))
                {
                    return pos;
                }
                pos++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get { return Get(index); }
            set { throw new System.NotImplementedException(); }
        }
    }
}
