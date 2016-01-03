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


    public class SingleEntityKeyList<K> : Net.Vpc.Upa.Impl.Persistence.QueryResultIteratorList<K> {

        private int columns;

        private Net.Vpc.Upa.Entity entity;

        public SingleEntityKeyList(Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL, Net.Vpc.Upa.Entity entity)  : base(nativeSQL){

            this.entity = entity;
            columns = nativeSQL.GetFields().Length;
        }


        public override K Parse(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object[] keyObj = new object[columns];
            for (int i = 0; i < columns; i++) {
                keyObj[i] = result.Read<object>(i);
            }
            return (K) entity.CreateId(keyObj);
        }
    }
}
