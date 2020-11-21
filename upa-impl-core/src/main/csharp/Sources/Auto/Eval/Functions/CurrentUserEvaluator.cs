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



namespace Net.TheVpc.Upa.Impl.Eval.Functions
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class CurrentUserEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.CurrentUserEvaluator();


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            Net.TheVpc.Upa.PersistenceUnit pu = evalContext.GetPersistenceUnit();
            if (pu == null) {
                pu = Net.TheVpc.Upa.UPA.GetPersistenceUnit();
            }
            Net.TheVpc.Upa.UserPrincipal user = pu.GetUserPrincipal();
            return user == null ? "anonymous" : user.GetName();
        }
    }
}
