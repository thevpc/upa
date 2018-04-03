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
     */
    public class Star : Net.Vpc.Upa.Expressions.Var {

        public Star()  : base("*"){

        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Star o = new Net.Vpc.Upa.Expressions.Star();
            return o;
        }


        public override string ToString() {
            return "*";
        }
    }
}
