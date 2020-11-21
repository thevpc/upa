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


    public class SingleEntityKeyList<K> : Net.TheVpc.Upa.Impl.Persistence.QueryResultLazyList<K> {

        private int columns;

        private Net.TheVpc.Upa.Entity entity;

        public SingleEntityKeyList(Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor, Net.TheVpc.Upa.Entity entity)  : base(queryExecutor){

            this.entity = entity;
            columns = queryExecutor.GetFields().Length;
        }


        public override K Parse(Net.TheVpc.Upa.Persistence.QueryResult result) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object[] keyObj = new object[columns];
            for (int i = 0; i < columns; i++) {
                keyObj[i] = result.Read<T>(i);
            }
            return (K) entity.CreateId(keyObj);
        }
    }
}
