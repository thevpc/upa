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



namespace Net.TheVpc.Upa.Expressions
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 12:29 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface QueryStatement : Net.TheVpc.Upa.Expressions.EntityStatement, Net.TheVpc.Upa.Expressions.NameOrQuery {

         int CountFields();

         Net.TheVpc.Upa.Expressions.QueryField GetField(int i);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryField> GetFields();
    }
}
