/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.ExpressionFormula;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author vpc
 */
public class RebuildExpressionInfo {
    DefaultCompiledExpression compiledExpression;
    ExpressionFormula initialFormula;
    ExpressionFormula rebuiltFormula;
    Expression expression;
}
