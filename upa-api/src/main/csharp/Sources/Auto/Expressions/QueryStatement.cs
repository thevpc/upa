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
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 12:29 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface QueryStatement : Net.Vpc.Upa.Expressions.EntityStatement, Net.Vpc.Upa.Expressions.NameOrQuery {

         int CountFields();

         Net.Vpc.Upa.Expressions.QueryField GetField(int i);

         System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryField> GetFields();
    }
}
