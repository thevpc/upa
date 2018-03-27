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



namespace Net.Vpc.Upa.Impl.Uql.Filters
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/10/13 11:22 PM*/
    public class ParamFilter : Net.Vpc.Upa.Expressions.ExpressionFilter {

        private readonly string name;

        public ParamFilter(string name) {
            this.name = name;
        }


        public virtual bool Accept(Net.Vpc.Upa.Expressions.Expression e) {
            return (e is Net.Vpc.Upa.Expressions.Param) && name.Equals(((Net.Vpc.Upa.Expressions.Param) e).GetName());
        }
    }
}
