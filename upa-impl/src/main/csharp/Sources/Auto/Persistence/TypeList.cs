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


    public class TypeList<T> : Net.Vpc.Upa.Impl.Persistence.QueryResultLazyList<T> {

        private int columns;

        private Net.Vpc.Upa.BeanType beanType;

        private string[] fields;

        private string[] fieldsByExpression;

        public TypeList(Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor, System.Type entity, string[] fields)  : base(queryExecutor){

            Net.Vpc.Upa.Impl.Persistence.NativeField[] expressions = queryExecutor.GetFields();
            this.fields = fields;
            beanType = Net.Vpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(entity);
            if (fields == null || fields.Length == 0) {
                System.Collections.Generic.ISet<string> fieldNames = beanType.GetPropertyNames();
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
            T instance = (T) beanType.NewInstance();
            for (int i = 0; i < columns; i++) {
                object v = result.Read<T>(i);
                if (fieldsByExpression[i] != null) {
                    beanType.SetProperty(instance, fieldsByExpression[i], v);
                }
            }
            return instance;
        }
    }
}
