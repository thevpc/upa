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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 12/20/12 2:49 AM*/
    public class ClassDelegateMarshaller : Net.TheVpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        private Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller @delegate;

        private System.Type delegateType;

        public ClassDelegateMarshaller(System.Type delegateType) {
            this.delegateType = delegateType;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetDelegate() {
            return @delegate = GetMarshallManager().GetTypeMarshaller(delegateType);
        }

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            return GetDelegate().Read(index, resultSet);
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
            GetDelegate().Write(@object, i, updatableResultSet);
        }

        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            return GetDelegate().ToSQLLiteral(@object);
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            
        }

        public override bool IsLiteralSupported() {
            return GetDelegate().IsLiteralSupported();
        }
    }
}
