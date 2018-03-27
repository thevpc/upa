/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultQueryResult : Net.Vpc.Upa.Persistence.QueryResult {

        private System.Data.IDataReader resultSet;

        private System.Data.IDbCommand statement;

        private Net.Vpc.Upa.Impl.Persistence.TypeMarshaller[] marshallers;

        private Net.Vpc.Upa.Types.DataTypeTransform[] types;

        private bool closed;

        private int[] nativePos;

        private System.Collections.Generic.IDictionary<int? , object> updates = new System.Collections.Generic.Dictionary<int? , object>();

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultQueryResult)).FullName);

        public DefaultQueryResult(System.Data.IDataReader resultSet, System.Data.IDbCommand statement, Net.Vpc.Upa.Impl.Persistence.TypeMarshaller[] marshallers, Net.Vpc.Upa.Types.DataTypeTransform[] types) {
            this.resultSet = resultSet;
            this.statement = statement;
            this.marshallers = marshallers;
            this.types = types;
            this.nativePos = new int[marshallers.Length];
            int lastNativePos = 1;
            int np = 0;
            foreach (Net.Vpc.Upa.Impl.Persistence.TypeMarshaller marshaller in marshallers) {
                nativePos[np] = lastNativePos;
                lastNativePos += marshaller.GetSize();
                np++;
            }
        }


        public virtual int GetFieldsCount() {
            return marshallers.Length;
        }


        public virtual  T Read<T>(int index) {
            try {
                object read = marshallers[index].Read(nativePos[index], resultSet);
                //            read = types[index].reverseTransformValue(read);
                return (T) read;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("ReadQueryResultColumnFailed"), index, nativePos[index]);
            }
        }


        public virtual  void Write<T>(int index, T @value) {
            updates[index]=@value;
        }


        public virtual bool HasNext() {
            try {
                if (closed || (resultSet).IsClosed) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("ResultSet closed, unable to retrieve next record",null));
                }
                updates.Clear();
                return resultSet.NextResult();
            } catch (System.Exception e) {
                bool alreadyClosed = false;
                try {
                    alreadyClosed = (resultSet).IsClosed;
                } catch (System.Exception e2) {
                }
                //ignore
                if (alreadyClosed) {
                    return false;
                }
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("ReadQueryHasNextFailed"));
            }
        }

        public virtual void Close() {
            try {
                closed = true;
                if (!(resultSet).IsClosed) {
                    if (!(resultSet).IsClosed) {
                        resultSet.Close();
                    }
                }
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("CloseFailed"));
            }
        }

        public virtual void UpdateCurrent() {
            int? index = null;
            try {
                foreach (System.Collections.Generic.KeyValuePair<int? , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<int?,object>>(updates)) {
                    index = (entry).Key;
                    marshallers[index].Write((entry).Value, nativePos[index], resultSet);
                }
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("ReadQueryResultColumnFailed"), index, index == null ? null : nativePos[index]);
            }
        }
    }
}
