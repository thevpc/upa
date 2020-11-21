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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/12/12
     * Time: 5:39 PM
     * To change this template use File | Settings | File Templates.
     */
    public class TreeEntityJoin : Net.TheVpc.Upa.Expressions.JoinCriteria {

        public TreeEntityJoin(string table, string var1, Net.TheVpc.Upa.Expressions.Expression expression)  : this(new Net.TheVpc.Upa.Expressions.EntityName(table), var1, expression){

        }

        public TreeEntityJoin(Net.TheVpc.Upa.Expressions.NameOrQuery table, string var1, Net.TheVpc.Upa.Expressions.Expression expression)  : this(table, var1, null, expression){

        }

        public TreeEntityJoin(Net.TheVpc.Upa.Expressions.NameOrQuery table, string var1, string var2, Net.TheVpc.Upa.Expressions.Expression expression)  : base(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, table, var1, new Net.TheVpc.Upa.Impl.Extension.TreeEntityJoinCondition(((Net.TheVpc.Upa.Expressions.EntityName) table).GetName(), var1, var2 == null ? var2 + "_ancestor" : var2, expression)){

        }
    }
}
