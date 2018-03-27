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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/12/12
     * Time: 5:39 PM
     * To change this template use File | Settings | File Templates.
     */
    public class TreeEntityJoin : Net.Vpc.Upa.Expressions.JoinCriteria {

        public TreeEntityJoin(string table, string var1, Net.Vpc.Upa.Expressions.Expression expression)  : this(new Net.Vpc.Upa.Expressions.EntityName(table), var1, expression){

        }

        public TreeEntityJoin(Net.Vpc.Upa.Expressions.NameOrQuery table, string var1, Net.Vpc.Upa.Expressions.Expression expression)  : this(table, var1, null, expression){

        }

        public TreeEntityJoin(Net.Vpc.Upa.Expressions.NameOrQuery table, string var1, string var2, Net.Vpc.Upa.Expressions.Expression expression)  : base(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, table, var1, new Net.Vpc.Upa.Impl.Extension.TreeEntityJoinCondition(((Net.Vpc.Upa.Expressions.EntityName) table).GetName(), var1, var2 == null ? var2 + "_ancestor" : var2, expression)){

        }
    }
}
