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



namespace Net.Vpc.Upa.Expressions
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/29/12 5:50 PM
     */
    public class VarVal {

        private Net.Vpc.Upa.Expressions.Var var;

        private Net.Vpc.Upa.Expressions.Expression val;

        public VarVal(Net.Vpc.Upa.Expressions.Var var, Net.Vpc.Upa.Expressions.Expression val) {
            this.SetVar(var);
            this.SetVal(val);
        }

        public virtual Net.Vpc.Upa.Expressions.Var GetVar() {
            return var;
        }

        public virtual void SetVar(Net.Vpc.Upa.Expressions.Var var) {
            this.var = var;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetVal() {
            return val;
        }

        public virtual void SetVal(Net.Vpc.Upa.Expressions.Expression val) {
            this.val = val;
        }


        public override string ToString() {
            return var + "=" + val;
        }
    }
}
