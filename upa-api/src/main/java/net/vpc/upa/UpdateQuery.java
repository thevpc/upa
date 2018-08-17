/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
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
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;

import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * Created by vpc on 6/12/16.
 */
public interface UpdateQuery {
    UpdateQuery setNone();

    UpdateQuery setValues(Object object);

    UpdateQuery setValues(Document document);

    Object getValues();

    UpdateQuery byField(String name,Object expr);

    UpdateQuery byId(Object expr);

    UpdateQuery byIdList(List<Object> expr);

    UpdateQuery byKey(Key expr);

//    UpdateQuery byObject(Object expr);

    UpdateQuery byPrototype(Object expr);

    UpdateQuery byDocumentPrototype(Document expr);

    UpdateQuery byKeyList(List<Key> expr);

    UpdateQuery byExpressionList(List<Expression> expr);

    UpdateQuery byExpression(Expression expr);

//    UpdateQuery byAll();

//    ConditionType getUpdateConditionType();

    Expression getUpdateExpression();

    Map<String, Object> getHints();

    Map<String, Object> getHints(boolean autoCreate);

    UpdateQuery setHints(Map<String, Object> hints);

    UpdateQuery setHint(String name, Object value);


    UpdateQuery addUpdatableField(String name);

    UpdateQuery removeUpdatableField(String name);

    UpdateQuery addUpdatableFields(String... names);

    UpdateQuery removeUpdatableFields(String... names);

    UpdateQuery addUpdatableFields(Collection<String> names);

    UpdateQuery removeUpdatableFields(Collection<String> names);

    UpdateQuery updateAll();

    Set<String> getUpdatedFields();

    UpdateQuery setUpdatedFields(Collection<String> partialUpdateFields);

    UpdateQuery update(Collection<String> partialUpdateFields);

    UpdateQuery update(String... partialUpdateFields);

    UpdateQuery update(String partialUpdateFields);

    UpdateQuery removeUpdatedFields(Collection<String> partialUpdateFields);

    FieldFilter getFormulaFields();

    UpdateQuery validate(String formulaField);

    UpdateQuery validate(String... formulaFields);

    UpdateQuery validate(Collection<String> formulaFields);

    UpdateQuery validate(FieldFilter formulaFields);

    UpdateQuery validateAll();

    UpdateQuery validateNone();

    boolean isIgnoreUnspecified();

    UpdateQuery setIgnoreUnspecified(boolean ignoreUnspecified);

    long execute();
}
