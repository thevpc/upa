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
package net.vpc.upa.expressions;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by IntelliJ IDEA. User: root Date: 10 juin 2003 Time: 16:29:33 To
 * change this template use Options | File Templates.
 */
public class Uplet extends DefaultExpression {

    private static final long serialVersionUID = 1L;
    private Expression[] expressions;

    public Uplet(Expression[] expressions) {
        super();
        this.expressions = expressions;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> all = new ArrayList<TaggedExpression>();
        for (int i = 0; i < expressions.length; i++) {
            all.add(new TaggedExpression(expressions[i], new IndexedTag("#", i)));
        }
        return all;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        expressions[((IndexedTag) tag).getIndex()] = e;
    }

//    public String toSQL(boolean flag, PersistenceUnit database) {
//        Expression sql;
//        if(expressions.length>1){
//            Concat concat=new Concat();
//            for(int i=0;i<expressions.length;i++){
//                if(i>0){
//                    concat.add(new Literal('~'));
//                }
//                concat.add(expressions[i]);
//            }
//            sql=concat;
//        }else{
//            sql=expressions[0];
//        }
//        return sql.toSQL(flag, database);
//    }
    public Expression[] getExpressions() {
        return expressions;
    }

    @Override
    public Expression copy() {
        Expression[] expressions2 = new Expression[expressions.length];
        for (int i = 0; i < expressions2.length; i++) {
            expressions2[i] = expressions[i].copy();
        }
        Uplet o = new Uplet(expressions2);
        return o;
    }
}
