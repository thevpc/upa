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
     * @creationdate 12/17/12 12:23 AM
     */
    public class ExpressionFieldPersister : Net.Vpc.Upa.Persistence.FieldPersister {

        private string field;

        private Net.Vpc.Upa.Expressions.Expression expression;

        public ExpressionFieldPersister(string field, Net.Vpc.Upa.Expressions.Expression expression) {
            this.field = field;
            this.expression = expression;
        }


        public virtual void BeforePersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            record.SetObject(field, expression);
        }


        public virtual void AfterPersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.Vpc.Upa.Impl.Persistence.ExpressionFieldPersister that = (Net.Vpc.Upa.Impl.Persistence.ExpressionFieldPersister) o;
            if (expression != null ? !expression.Equals(that.expression) : that.expression != null) return false;
            if (field != null ? !field.Equals(that.field) : that.field != null) return false;
            return true;
        }


        public override int GetHashCode() {
            int result = field != null ? field.GetHashCode() : 0;
            result = 31 * result + (expression != null ? expression.GetHashCode() : 0);
            return result;
        }
    }
}
