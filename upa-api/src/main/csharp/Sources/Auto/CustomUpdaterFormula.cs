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



namespace Net.Vpc.Upa
{


    /**
     * CustomUpdaterFormula is guaranteed to be invoked once per pass even if equal instances are passed to multiple fields,
     * only one instance will be invoked for all fields (for the same pass).
     * The same CustomUpdaterFormula instance may be invoked multiple times in distinct passes
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface CustomUpdaterFormula : Net.Vpc.Upa.Formula {

        /**
             * Called once per pass to evaluate and <b>store</b> formula values for all the given fields
             * @param fields fields to update
             * @param expression entities (rows) filter
             * @param executionContext executionContext
             */
         void UpdateFormula(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);
    }
}
