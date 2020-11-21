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



namespace Net.TheVpc.Upa.Impl.Uql.Filters
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/10/13 11:22 PM*/
    public class ParamFilter : Net.TheVpc.Upa.Expressions.ExpressionFilter {

        private readonly string name;

        public ParamFilter(string name) {
            this.name = name;
        }


        public virtual bool Accept(Net.TheVpc.Upa.Expressions.Expression e) {
            return (e is Net.TheVpc.Upa.Expressions.Param) && name.Equals(((Net.TheVpc.Upa.Expressions.Param) e).GetName());
        }
    }
}
