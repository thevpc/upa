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
     *
     * @author taha.bensalah@gmail.com
     */
    public interface QLEvaluatorRegistry {

         void RegisterTypeEvaluator(System.Type type, Net.Vpc.Upa.QLTypeEvaluator t);

         void RegisterFunctionEvaluator(string name, Net.Vpc.Upa.QLTypeEvaluator t);

         void RegisterFunctionEvaluator(string name, Net.Vpc.Upa.Function t);

         void UnregisterFunctionEvaluator(string name);

         void UnregisterTypeEvaluator(System.Type type);

         Net.Vpc.Upa.QLTypeEvaluator GetTypeEvaluator(System.Type type);
    }
}
