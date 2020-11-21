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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
     * this template use File | Settings | File Templates.
     */
    public abstract class AbstractQuery : Net.TheVpc.Upa.Query {

        private bool updatable = false;


        public virtual Net.TheVpc.Upa.Types.Temporal GetDate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (Net.TheVpc.Upa.Types.Temporal) GetSingleValue();
        }


        public virtual bool? GetBoolean() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (bool?) GetSingleValue();
        }


        public virtual int? GetInteger() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object n = (object) GetSingleValue();
            return n == null ? null : System.Convert.ToInt32(n);
        }


        public virtual long? GetLong() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object n = (object) GetSingleValue();
            return n == null ? null : System.Convert.ToInt32(n);
        }


        public virtual double? GetDouble() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object n = (object) GetSingleValue();
            return n == null ? null : System.Convert.ToDouble(n);
        }


        public virtual string GetString() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (string) GetSingleValue();
        }


        public virtual object GetNumber() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (object) GetSingleValue();
        }


        public virtual object GetSingleValue() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetSingleValue(null);
        }


        public virtual object GetSingleValue(object defaultValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Record mergedRecord = GetRecord();
            if (mergedRecord == null) {
                return defaultValue;
            }
            return mergedRecord.GetSingleResult<T>();
        }


        public virtual Net.TheVpc.Upa.MultiRecord GetMultiRecord() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.MultiRecord> multiRecordList = null;
            try {
                multiRecordList = GetMultiRecordList();
                if (!(multiRecordList.Count==0)) {
                    return multiRecordList[0];
                }
                return null;
            } finally {
                Net.TheVpc.Upa.Impl.Util.UPAUtils.Close(multiRecordList);
            }
        }


        public virtual Net.TheVpc.Upa.Record GetRecord() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Record> multiRecordList = null;
            try {
                multiRecordList = GetRecordList();
                bool empty = (multiRecordList.Count==0);
                if (!empty) {
                    return multiRecordList[0];
                }
                return null;
            } finally {
                Net.TheVpc.Upa.Impl.Util.UPAUtils.Close(multiRecordList);
            }
        }


        public virtual  R GetEntity<R>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<R> r = null;
            try {
                r = GetEntityList<R>();
                if (!(r.Count==0)) {
                    return r[0];
                }
                return default(R);
            } finally {
                Net.TheVpc.Upa.Impl.Util.UPAUtils.Close(r);
            }
        }

        public virtual  R GetSingleEntity<R>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<R> entityList = null;
            try {
                entityList = GetEntityList<R>();
                if ((entityList.Count==0)) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Not found");
                }
                int x = 0;
                foreach (object @object in entityList) {
                    x++;
                    if (x > 1) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAException("Ambiguity");
                    }
                }
                return entityList[0];
            } finally {
                Net.TheVpc.Upa.Impl.Util.UPAUtils.Close(entityList);
            }
        }

        public virtual  R GetSingleEntityOrNull<R>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<R> entityList = null;
            try {
                entityList = GetEntityList<R>();
                if ((entityList.Count==0)) {
                    return default(R);
                }
                int x = 0;
                foreach (object @object in entityList) {
                    x++;
                    if (x > 1) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAException("Ambiguity");
                    }
                }
                return entityList[0];
            } finally {
                Net.TheVpc.Upa.Impl.Util.UPAUtils.Close(entityList);
            }
        }

        public virtual bool IsUpdatable() {
            return updatable;
        }

        public virtual void SetUpdatable(bool forUpdate) {
            this.updatable = forUpdate;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query SetHint(string arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<K> GetIdList<K>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object GetHint(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query SetHints(System.Collections.Generic.IDictionary<string , object> arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object GetHint(string arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetTypeList<T>(System.Type arg1, string[] arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IDictionary<string , object> GetHints();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<T> GetValueSet<T>(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query SetParameter(string arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetResultList<T>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool IsEmpty();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.TheVpc.Upa.MultiRecord> GetMultiRecordList();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Persistence.ResultMetaData GetMetaData();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query RemoveParameter(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetValueList<T>(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query SetLazyListLoadingEnabled(bool arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool IsLazyListLoadingEnabled();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<T> GetTypeSet<T>(System.Type arg1, string[] arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetValueList<T>(int arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<K> GetIdSet<K>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<Net.TheVpc.Upa.Key> GetKeySet();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<T> GetResultSet<T>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.ISet<T> GetValueSet<T>(int arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<R> GetEntityList<R>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.TheVpc.Upa.Key> GetKeyList();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.TheVpc.Upa.Record> GetRecordList();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int ExecuteNonQuery();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query SetParameter(int arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void UpdateCurrent();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Query RemoveParameter(int arg1);
    }
}
