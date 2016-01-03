/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import java.util.HashSet;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.JoinCriteria;
import net.vpc.upa.expressions.QueryField;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.CompiledJoinCriteria;
import net.vpc.upa.impl.uql.compiledexpression.CompiledNameOrSelect;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SelectExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public SelectExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileSelect((Select) o, declarations);
    }

    protected CompiledSelect compileSelect(Select v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledSelect s = new CompiledSelect();
        s.setDistinct(v.isDistinct());
        s.setTop(v.getTop());
        CompiledNameOrSelect nameOrSelect = (CompiledNameOrSelect) outer.compileAny(v.getEntity(), declarations);
        String entityAlias = v.getEntityAlias();
        HashSet<String> aliases = new HashSet<String>();
        if (entityAlias == null) {
            if (nameOrSelect instanceof CompiledEntityName) {
                entityAlias = ((CompiledEntityName) nameOrSelect).getName();
            } else {
                entityAlias = "ALIAS";
            }
            int i = 0;
            while (true) {
                String a2 = i == 0 ? entityAlias : (entityAlias + i);
                if (!aliases.contains(a2)) {
                    aliases.add(a2);
                    entityAlias = a2;
                    break;
                }
                i++;
            }
        }
        s.from(nameOrSelect, entityAlias);
        for (int i = 0; i < v.countJoins(); i++) {
            JoinCriteria c = v.getJoin(i);
            CompiledNameOrSelect jnameOrSelect = (CompiledNameOrSelect) outer.compileAny(c.getEntity(), declarations);
            entityAlias = c.getEntityAlias();
            if (entityAlias == null) {
                if (nameOrSelect instanceof CompiledEntityName) {
                    entityAlias = ((CompiledEntityName) nameOrSelect).getName();
                } else {
                    entityAlias = "ALIAS";
                }
                i = 0;
                while (true) {
                    String a2 = i == 0 ? entityAlias : (entityAlias + i);
                    if (!aliases.contains(a2)) {
                        aliases.add(a2);
                        entityAlias = a2;
                        break;
                    }
                    i++;
                }
            }
            CompiledJoinCriteria cc = new CompiledJoinCriteria(c.getJoinType(), jnameOrSelect, entityAlias, outer.compileAny(c.getCondition(), declarations));
            s.join(cc);
        }
        for (int i = 0; i < v.countFields(); i++) {
            QueryField field = v.getField(i);
            s.field(outer.compileAny(field.getExpression(), declarations), field.getAlias());
        }
        s.where(outer.compileAny(v.getWhere(), declarations));
        s.having(outer.compileAny(v.getHaving(), declarations));
        for (int i = 0; i < v.countGroupByItems(); i++) {
            Expression c = v.getGroupBy(i);
            s.groupBy(outer.compileAny(c, declarations));
        }
        for (int i = 0; i < v.countOrderByItems(); i++) {
            Expression c = v.getOrderBy(i);
            s.orderBy(outer.compileAny(c, declarations), v.isOrderAscending(i));
        }
        return s;
    }
    
}
