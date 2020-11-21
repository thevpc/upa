/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import java.util.HashSet;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.JoinCriteria;
import net.thevpc.upa.expressions.QueryField;
import net.thevpc.upa.expressions.Select;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.impl.upql.ext.expr.CompiledJoinCriteria;
import net.thevpc.upa.impl.upql.ext.expr.CompiledNameOrSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SelectExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileSelect((Select) o, manager,declarations);
    }

    protected CompiledSelect compileSelect(Select v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledSelect s = new CompiledSelect();
        s.setDistinct(v.isDistinct());
        s.setTop(v.getTop());
        CompiledNameOrSelect nameOrSelect = (CompiledNameOrSelect) manager.translateAny(v.getEntity(), declarations);
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
            CompiledNameOrSelect jnameOrSelect = (CompiledNameOrSelect) manager.translateAny(c.getEntity(), declarations);
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
            CompiledJoinCriteria cc = new CompiledJoinCriteria(c.getJoinType(), jnameOrSelect, entityAlias, manager.translateAny(c.getCondition(), declarations));
            s.join(cc);
        }
        for (int i = 0; i < v.countFields(); i++) {
            QueryField field = v.getField(i);
            s.field(manager.translateAny(field.getExpression(), declarations), field.getAlias());
            s.getField(i).setIndex(i);
        }


        s.where(manager.translateAny(v.getWhere(), declarations));
        s.having(manager.translateAny(v.getHaving(), declarations));
        for (int i = 0; i < v.countGroupByItems(); i++) {
            Expression c = v.getGroupBy(i);
            s.groupBy(manager.translateAny(c, declarations));
        }
        for (int i = 0; i < v.countOrderByItems(); i++) {
            Expression c = v.getOrderBy(i);
            s.orderBy(manager.translateAny(c, declarations), v.isOrderAscending(i));
        }
        return s;
    }
    
}
