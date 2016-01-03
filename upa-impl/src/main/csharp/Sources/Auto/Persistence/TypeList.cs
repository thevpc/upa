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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Persistence
{


    public class TypeList<T> : Net.Vpc.Upa.Impl.Persistence.QueryResultIteratorList<T> {

        private int columns;

        private Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter beanAdapter;

        private string[] fields;

        private string[] fieldsByExpression;

        public TypeList(Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL, System.Type entity, string[] fields)  : base(nativeSQL){

            Net.Vpc.Upa.Impl.Persistence.NativeField[] expressions = nativeSQL.GetFields();
            this.fields = fields;
            beanAdapter = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(entity);
            if (fields == null || fields.Length == 0) {
                System.Collections.Generic.IList<string> fieldNames = beanAdapter.GetFieldNames();
                this.fields = fieldNames.ToArray();
            }
            fieldsByExpression = new string[expressions.Length];
            for (int i = 0; i < fieldsByExpression.Length; i++) {
                Net.Vpc.Upa.Impl.Persistence.NativeField e = expressions[i];
                string name = e.GetName();
                foreach (string field in this.fields) {
                    if (name.Equals(field)) {
                        fieldsByExpression[i] = field;
                        break;
                    }
                }
            }
            columns = expressions.Length;
        }


        public override T Parse(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            T instance = (T) beanAdapter.NewInstance();
            for (int i = 0; i < columns; i++) {
                object v = result.Read<object>(i);
                if (fieldsByExpression[i] != null) {
                    beanAdapter.SetProperty<object>(instance, fieldsByExpression[i], v);
                }
            }
            return instance;
        }
    }
}
