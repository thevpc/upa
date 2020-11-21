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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 5:38 PM
     * To change this template use File | Settings | File Templates.
     */
    public abstract class DefaultTypeMarshaller : Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller {

        private Net.TheVpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        public virtual void SetMarshallManager(Net.TheVpc.Upa.Impl.Persistence.MarshallManager marshallManager) {
            this.marshallManager = marshallManager;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager() {
            return marshallManager;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string ToSQLLiteral(object arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Types.DataType GetPersistentDataType(Net.TheVpc.Upa.Types.DataType arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object Read(int arg1, System.Data.IDataReader arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Write(object arg1, int arg2, System.Data.IDbCommand arg3);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Write(object arg1, int arg2, System.Data.IDataReader arg3);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool IsLiteralSupported();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int GetSize();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetName(string arg1, int arg2);
    }
}
