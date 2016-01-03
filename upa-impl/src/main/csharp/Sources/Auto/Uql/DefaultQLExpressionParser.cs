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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author vpc
     */
    public class DefaultQLExpressionParser : Net.Vpc.Upa.QLExpressionParser {

        public virtual Net.Vpc.Upa.Expressions.Expression Parse(System.IO.TextReader text) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParser(text).Any();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression Parse(string reader) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParser(new System.IO.StringReader(reader)).Any();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression Parse(System.IO.Stream inputStream) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParser(inputStream).Any();
        }
    }
}
