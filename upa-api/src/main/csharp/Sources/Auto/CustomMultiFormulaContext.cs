/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * Called once per pass to evaluate and <b>store</b> formula values for all the given fields
     * @param fields fields to update
     * @param expression entities (rows) filter
     * @param executionContext executionContext
     */
    public interface CustomMultiFormulaContext : Net.Vpc.Upa.BaseFormulaContext {

         System.Collections.Generic.ISet<Net.Vpc.Upa.Field> GetFields();

         Net.Vpc.Upa.Expressions.Expression GetFilter();
    }
}
