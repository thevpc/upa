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



namespace Net.TheVpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface QLEvaluator {

         Net.TheVpc.Upa.Expressions.Expression EvalString(string expression, object context);

         Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression expression, object context);

         Net.TheVpc.Upa.QLEvaluatorRegistry GetRegistry();
    }
}
