/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionFilter;
import net.vpc.upa.expressions.JoinCriteria;
import net.vpc.upa.expressions.Select;

/**
 * @author taha.bensalah@gmail.com
 */
class ComplexUpdateExpressionFilter implements ExpressionFilter {

    private final String entityName;
    private final boolean isUpdateComplexValuesStatementSupported;
    private final boolean isUpdateComplexValuesIncludingUpdatedTableSupported;

    public ComplexUpdateExpressionFilter(String entityName, boolean isUpdateComplexValuesStatementSupported, boolean isUpdateComplexValuesIncludingUpdatedTableSupported) {
        this.entityName = entityName;
        this.isUpdateComplexValuesStatementSupported = isUpdateComplexValuesStatementSupported;
        this.isUpdateComplexValuesIncludingUpdatedTableSupported = isUpdateComplexValuesIncludingUpdatedTableSupported;
    }

    @Override
    public boolean accept(Expression expression) {
        if (Select.class.isInstance(expression)) {
            Select ss = (Select) expression;
            if (!isUpdateComplexValuesStatementSupported) {
                return true;
            }
            if (!isUpdateComplexValuesIncludingUpdatedTableSupported) {
                if (ss.getEntity() != null) {
                    boolean meFound = false;
                    String ssentityName = ss.getEntityName();
                    if (ssentityName != null && ssentityName.equals(entityName)) {
                        meFound = true;
                    }
                    if (!meFound) {
                        for (JoinCriteria join : ss.getJoins()) {
                            String jentityName = join.getEntityName();
                            if (jentityName != null && jentityName.equals(entityName)) {
                                meFound = true;
                            }
                        }
                    }
                    if (meFound) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

}
