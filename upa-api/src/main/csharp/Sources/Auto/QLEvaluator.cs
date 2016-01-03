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
     * @author vpc
     */
    public interface QLEvaluator {

         object EvalString(string expression, object context);

         object EvalObject(Net.Vpc.Upa.Expressions.Expression expression, object context);

         void RegisterTypeEvaluator(System.Type type, Net.Vpc.Upa.QLTypeEvaluator t);

         Net.Vpc.Upa.QLTypeEvaluator GetTypeEvaluator(System.Type type);
    }
}
