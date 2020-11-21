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
     * Created by vpc on 6/27/16.
     */
    public class DefaultResultField : Net.TheVpc.Upa.Persistence.ResultField {

        public Net.TheVpc.Upa.Expressions.Expression expression;

        public string alias;

        public Net.TheVpc.Upa.Types.DataType dataType;

        public Net.TheVpc.Upa.Field field;

        public Net.TheVpc.Upa.Entity entity;

        public DefaultResultField(Net.TheVpc.Upa.Expressions.Expression expression, string alias, Net.TheVpc.Upa.Types.DataType dataType, Net.TheVpc.Upa.Field field, Net.TheVpc.Upa.Entity entity) {
            this.expression = expression;
            if (alias == null) {
                if (expression is Net.TheVpc.Upa.Expressions.Var) {
                    alias = ((Net.TheVpc.Upa.Expressions.Var) expression).GetName();
                } else {
                    alias = expression.ToString();
                }
            }
            this.alias = alias;
            this.dataType = dataType;
            this.field = field;
            this.entity = entity;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public virtual string GetAlias() {
            return alias;
        }


        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }


        public virtual Net.TheVpc.Upa.Field GetField() {
            return field;
        }


        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
