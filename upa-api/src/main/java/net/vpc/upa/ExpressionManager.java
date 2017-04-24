/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort 
 * to raise programming language frameworks managing relational data in 
 * applications using Java Platform, Standard Edition and Java Platform, 
 * Enterprise Edition and Dot Net Framework equally to the next level of 
 * handling ORM for mutable data structures. UPA is intended to provide 
 * a solid reflection mechanisms to the mapped data structures while 
 * affording to make changes at runtime of those data structures. 
 * Besides, UPA has learned considerably of the leading ORM 
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few) 
 * failures to satisfy very common even known to be trivial requirement in 
 * enterprise applications. 
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.types.DataType;

import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface ExpressionManager {

    ResultMetaData createMetaData(Expression baseExpression, FieldFilter fieldFilter) ;

    FunctionExpression createFunctionExpression(String name,Expression[] args);

    QLEvaluator createEvaluator() ;

    Expression parseExpression(String expression);

    /**
     * simplifies expression by evaluating all map vars in the expression.
     * simplifyExpression("a.id",{"a":{id:4,name:'example'}}) = Literal(4)
     * the expression it self may be modified while evaluation process.
     * Do copy ( expression.copy() ) the expression if one wants readonly acept
     * @param expression expression to simplify
     * @param vars map of available vars
     * @return simplified expression
     */
    Expression simplifyExpression(Expression expression, Map<String, Object> vars);

    Expression simplifyExpression(String expression, Map<String, Object> vars);

    /**
     * parse all UserExpressions withing this expression
     * @param expression any expression
     * @return expression where all UserExpressions are parsed
     */
    Expression parseExpression(Expression expression);

    CompiledExpression compileExpression(Expression expression, ExpressionCompilerConfig config);

    CompiledExpression compileExpression(CompiledExpression expression, ExpressionCompilerConfig config);

    FunctionDefinition addFunction(String name, DataType type, Function function);

    void removeFunction(String name);

    List<FunctionDefinition> getFunctions();

    Set<String> getFunctionNames();

    boolean containsFunction(String name);

    FunctionDefinition getFunction(String name);
}
