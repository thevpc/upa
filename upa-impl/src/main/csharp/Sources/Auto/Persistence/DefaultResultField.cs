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
     * Created by vpc on 6/27/16.
     */
    public class DefaultResultField : Net.Vpc.Upa.Persistence.ResultField {

        public Net.Vpc.Upa.Expressions.Expression expression;

        public string alias;

        public Net.Vpc.Upa.Types.DataType dataType;

        public Net.Vpc.Upa.Field field;

        public Net.Vpc.Upa.Entity entity;

        public DefaultResultField(Net.Vpc.Upa.Expressions.Expression expression, string alias, Net.Vpc.Upa.Types.DataType dataType, Net.Vpc.Upa.Field field, Net.Vpc.Upa.Entity entity) {
            this.expression = expression;
            if (alias == null) {
                if (expression is Net.Vpc.Upa.Expressions.Var) {
                    alias = ((Net.Vpc.Upa.Expressions.Var) expression).GetName();
                } else {
                    alias = expression.ToString();
                }
            }
            this.alias = alias;
            this.dataType = dataType;
            this.field = field;
            this.entity = entity;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public virtual string GetAlias() {
            return alias;
        }


        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }


        public virtual Net.Vpc.Upa.Field GetField() {
            return field;
        }


        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
