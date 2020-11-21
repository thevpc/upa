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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/19/12
     * Time: 12:29 AM
     * To change this template use File | Settings | File Templates.
     */
    public interface CompiledQueryStatement : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement {

         int CountFields();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> GetFields();

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField GetField(int i);
    }
}
