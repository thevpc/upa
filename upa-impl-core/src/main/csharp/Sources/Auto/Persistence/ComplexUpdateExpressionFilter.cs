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
     *
     * @author taha.bensalah@gmail.com
     */
    internal class ComplexUpdateExpressionFilter : Net.Vpc.Upa.Expressions.ExpressionFilter {

        private readonly string entityName;

        private readonly bool isUpdateComplexValuesStatementSupported;

        public ComplexUpdateExpressionFilter(string entityName, bool isUpdateComplexValuesStatementSupported) {
            this.entityName = entityName;
            this.isUpdateComplexValuesStatementSupported = isUpdateComplexValuesStatementSupported;
        }


        public virtual bool Accept(Net.Vpc.Upa.Expressions.Expression expression) {
            if (typeof(Net.Vpc.Upa.Expressions.Select).IsInstanceOfType(expression)) {
                Net.Vpc.Upa.Expressions.Select ss = (Net.Vpc.Upa.Expressions.Select) expression;
                if (isUpdateComplexValuesStatementSupported) {
                    if (ss.GetEntity() != null) {
                        bool meFound = false;
                        string ssentityName = ss.GetEntityName();
                        if (ssentityName != null && ssentityName.Equals(entityName)) {
                            meFound = true;
                        }
                        if (!meFound) {
                            foreach (Net.Vpc.Upa.Expressions.JoinCriteria join in ss.GetJoins()) {
                                string jentityName = join.GetEntityName();
                                if (jentityName != null && jentityName.Equals(entityName)) {
                                    meFound = true;
                                }
                            }
                        }
                        if (meFound) {
                            return true;
                        }
                    }
                } else {
                    return true;
                }
            }
            return false;
        }
    }
}
