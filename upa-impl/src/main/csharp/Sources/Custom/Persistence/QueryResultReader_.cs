using System.Collections;

namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 6:34 AM
     * To change this template use File | Settings | File Templates.
     */
    public partial class QueryResultReader<T> /*: System.Collections.Generic.IEnumerator<T>*/ {

        public void Dispose()
        {
            queryResult.Close();
        }

        public bool MoveNext()
        {
            return queryResult.HasNext();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T Current
        {
            get { return queryResultParser.Parse(queryResult); }
        }
    }
}
