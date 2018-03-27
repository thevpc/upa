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



namespace Net.Vpc.Upa.Impl.Eval.Functions
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class CurrentUserEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.CurrentUserEvaluator();


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            Net.Vpc.Upa.PersistenceUnit pu = evalContext.GetPersistenceUnit();
            if (pu == null) {
                pu = Net.Vpc.Upa.UPA.GetPersistenceUnit();
            }
            Net.Vpc.Upa.UserPrincipal user = pu.GetUserPrincipal();
            return user == null ? "anonymous" : user.GetName();
        }
    }
}
