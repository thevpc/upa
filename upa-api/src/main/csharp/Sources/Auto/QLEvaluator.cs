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
     *
     * @author taha.bensalah@gmail.com
     */
    public interface QLEvaluator {

         Net.Vpc.Upa.Expressions.Expression EvalString(string expression, object context);

         Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression expression, object context);

         Net.Vpc.Upa.QLEvaluatorRegistry GetRegistry();
    }
}
