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
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
     * this template use File | Settings | File Templates.
     */
    public abstract class AbstractQuery : Net.Vpc.Upa.Query {

        private bool updatable = false;


        public virtual Net.Vpc.Upa.Types.Temporal GetDate() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (Net.Vpc.Upa.Types.Temporal) GetSingleValue();
        }


        public virtual string GetString() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (string) GetSingleValue();
        }


        public virtual object GetNumber() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (object) GetSingleValue();
        }


        public virtual object GetSingleValue() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetSingleValue(null);
        }


        public virtual object GetSingleValue(object defaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record mergedRecord = GetRecord();
            if (mergedRecord == null) {
                return defaultValue;
            }
            return mergedRecord.GetSingleResult<object>();
        }


        public virtual Net.Vpc.Upa.MultiRecord GetMultiRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.MultiRecord> multiRecordList = null;
            try {
                multiRecordList = GetMultiRecordList();
                if (!(multiRecordList.Count==0)) {
                    return multiRecordList[0];
                }
                return null;
            } finally {
                Net.Vpc.Upa.Impl.Util.UPAUtils.Close(multiRecordList);
            }
        }


        public virtual Net.Vpc.Upa.Record GetRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Record> multiRecordList = null;
            try {
                multiRecordList = GetRecordList();
                bool empty = (multiRecordList.Count==0);
                if (!empty) {
                    return multiRecordList[0];
                }
                return null;
            } finally {
                Net.Vpc.Upa.Impl.Util.UPAUtils.Close(multiRecordList);
            }
        }


        public virtual  R GetEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<R> r = null;
            try {
                r = GetEntityList<R>();
                if (!(r.Count==0)) {
                    return r[0];
                }
                return default(R);
            } finally {
                Net.Vpc.Upa.Impl.Util.UPAUtils.Close(r);
            }
        }

        public virtual  R GetSingleEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<R> entityList = null;
            try {
                entityList = GetEntityList<R>();
                if ((entityList.Count==0)) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("Not found");
                }
                int x = 0;
                foreach (object @object in entityList) {
                    x++;
                    if (x > 1) {
                        throw new Net.Vpc.Upa.Exceptions.UPAException("Ambiguity");
                    }
                }
                return entityList[0];
            } finally {
                Net.Vpc.Upa.Impl.Util.UPAUtils.Close(entityList);
            }
        }

        public virtual  R GetSingleEntityOrNull<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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
                        throw new Net.Vpc.Upa.Exceptions.UPAException("Ambiguity");
                    }
                }
                return entityList[0];
            } finally {
                Net.Vpc.Upa.Impl.Util.UPAUtils.Close(entityList);
            }
        }

        public virtual bool IsUpdatable() {
            return updatable;
        }

        public virtual void SetUpdatable(bool forUpdate) {
            this.updatable = forUpdate;
        }

        public abstract Net.Vpc.Upa.Entity GetDefaultEntity();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<K> GetIdList<K>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetTypeList<T>(System.Type arg1, string[] arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Query SetParameter(string arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool IsEmpty();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.Vpc.Upa.MultiRecord> GetMultiRecordList();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetValueList<T>(string arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Query SetLazyListLoadingEnabled(bool arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool IsLazyListLoadingEnabled();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<T> GetValueList<T>(int arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.Vpc.Upa.Key> GetKeyList();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<R> GetEntityList<R>();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.Vpc.Upa.Record> GetRecordList();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int ExecuteNonQuery();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Query SetParameter(int arg1, object arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void UpdateCurrent();
    }
}
