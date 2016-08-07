using System.Collections;

namespace Net.Vpc.Upa.Impl.Util
{


    /**
    * @author Taha BEN Salah
    * @creationdate 1/5/13 10:18 PM*/
    internal class LazyListIterator<T> : System.Collections.Generic.IEnumerator<T> {

        /**
             * Index of element to be returned by subsequent call to next.
             */
        internal int cursor = 0;

        private Net.Vpc.Upa.Impl.Util.LazyList<T> iteratorList;

        internal LazyListIterator(Net.Vpc.Upa.Impl.Util.LazyList<T> iteratorList, int cursor) {
            this.iteratorList = iteratorList;
            this.cursor = cursor;
        }


        public void Dispose()
        {
            //
        }

        public bool MoveNext()
        {
            iteratorList.Load(cursor);
            bool r = !iteratorList.end || cursor < iteratorList.Count;
            if(r)
            {
                cursor++;
            }
            return r;
        }

        public void Reset()
        {
            cursor = 0;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T Current
        {
            get { return iteratorList[cursor-1]; }
        }
    }
}
