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



namespace Net.TheVpc.Upa.Impl.Uql
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultQLExpressionParser : Net.TheVpc.Upa.QLExpressionParser {

        public virtual Net.TheVpc.Upa.Expressions.Expression Parse(System.IO.TextReader text) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new Net.TheVpc.Upa.Impl.Uql.Parser.Syntax.UQLParser(text).Any();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression Parse(string reader) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return null;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression Parse(System.IO.Stream inputStream) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return null;
        }
    }
}
