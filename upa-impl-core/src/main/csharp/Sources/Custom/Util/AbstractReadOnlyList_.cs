using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.TheVpc.Upa.Impl.Util
{
    public abstract class AbstractReadOnlyList<R> : IList<R>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<R> GetEnumerator()
        {
            return new AbstractReadOnlyListEnum(this);
        }

        public void Add(R item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(R item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(R[] array, int arrayIndex)
        {
           new List<R>(this).CopyTo(array,arrayIndex);
        }

        public bool Remove(R item)
        {
            throw new NotImplementedException();
        }

        public abstract int Count { get; }


        public bool IsReadOnly
        {
            get { return true; }
        }

        public int IndexOf(R item)
        {
            int index = 0;
            foreach (var v in this)
            {
                if(v==null || (v!=null && v.Equals(item)))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public void Insert(int index, R item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public R this[int index]
        {
            get { return Get(index); }
            set { throw new NotImplementedException(); }
        }

        protected abstract R Get(int index);
        
        private class AbstractReadOnlyListEnum :IEnumerator<R>
        {
            private AbstractReadOnlyList<R> list;
            private int index = -1;

            public AbstractReadOnlyListEnum(AbstractReadOnlyList<R> list)
            {
                this.list = list;
            }

            public void Dispose()
            {
                //
            }

            public bool MoveNext()
            {
                if(index<list.Count)
                {
                    index++;
                    return true;
                }else
                {
                    return false;
                }
            }

            public void Reset()
            {
                index = 0;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public R Current
            {
                get { return list[index]; }
            }
        }
    }
}
