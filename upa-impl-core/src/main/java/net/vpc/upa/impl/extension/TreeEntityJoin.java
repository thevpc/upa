package net.vpc.upa.impl.extension;

import net.vpc.upa.expressions.*;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/12/12
 * Time: 5:39 PM
 * To change this template use File | Settings | File Templates.
 */
public class TreeEntityJoin extends JoinCriteria {
    public TreeEntityJoin(String table, String var1, Expression expression) {
        this(new EntityName(table),var1,expression);
    }

    public TreeEntityJoin(NameOrQuery table, String var1, Expression expression) {
        this(table, var1,null,expression);
    }

    public TreeEntityJoin(NameOrQuery table, String var1, String var2, Expression expression) {
        super(JoinType.INNER_JOIN, table,var1,new TreeEntityJoinCondition(((EntityName)table).getName(),var1,var2==null?var2+"_ancestor":var2,expression));
    }
//    private static TreeEntityExtension getTreeSpecSupport(Entity entity){
//        List<TreeEntityExtension> tss = entity.getExtensions(TreeEntityExtension.class);
//        if(tss.size()!=1){
//            throw new RuntimeException("Unexpected");
//        }
//        return tss.get(0);
//    }

}
