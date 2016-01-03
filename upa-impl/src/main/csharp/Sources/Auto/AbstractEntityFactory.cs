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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 12:45 AM
     */
    public abstract class AbstractEntityFactory : Net.Vpc.Upa.Impl.EntityFactory {


        public virtual  Net.Vpc.Upa.Record GetRecord<R>(R entity) {
            return GetRecord<R>(entity, false);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Record GetRecord<R>(R arg1, bool arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object GetProperty(object arg1, string arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Record CreateRecord();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetProperty(object arg1, string arg2, object arg3);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R GetEntity<R>(Net.Vpc.Upa.Record arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R CreateObject<R>();
    }
}
