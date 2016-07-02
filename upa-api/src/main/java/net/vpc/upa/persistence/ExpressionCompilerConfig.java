/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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
/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.persistence;

import net.vpc.upa.filters.FieldFilter;

import java.util.HashMap;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExpressionCompilerConfig {

    private Map<String, String> aliasToEntityContext;
    private Map<String, Object> hints;
    private boolean validate = true;
    private boolean expandFields = true;
    private FieldFilter expandFieldFilter;
    private boolean expandEntityFilter = true;
    private String thisAlias = null;

    public ExpressionCompilerConfig() {
    }

    public Map<String, String> getAliasToEntityContext() {
        return aliasToEntityContext;
    }

    public ExpressionCompilerConfig bindAliastoEntity(String alias, String entityName) {
        if (aliasToEntityContext == null) {
            aliasToEntityContext = new HashMap<String, String>();
        }
        if(entityName==null){
            aliasToEntityContext.remove(alias);
        }else{
            aliasToEntityContext.put(alias, entityName);
        }
        return this;
    }

    public ExpressionCompilerConfig setAliasToEntityContext(Map<String, String> aliasToEntityContext) {
        this.aliasToEntityContext = aliasToEntityContext;
        return this;
    }

    public boolean isExpandFields() {
        return expandFields;
    }

    public ExpressionCompilerConfig setExpandFields(boolean expandFields) {
        this.expandFields = expandFields;
        return this;
    }

    public FieldFilter getExpandFieldFilter() {
        return expandFieldFilter;
    }

    public ExpressionCompilerConfig setExpandFieldFilter(FieldFilter expandFieldFilter) {
        this.expandFieldFilter = expandFieldFilter;
        return this;
    }

    public boolean isExpandEntityFilter() {
        return expandEntityFilter;
    }

    public ExpressionCompilerConfig setExpandEntityFilter(boolean expandEntityFilter) {
        this.expandEntityFilter = expandEntityFilter;
        return this;
    }

    public boolean isValidate() {
        return validate;
    }

    public ExpressionCompilerConfig setValidate(boolean validate) {
        this.validate = validate;
        return this;
    }

    public String getThisAlias() {
        return thisAlias;
    }

    public ExpressionCompilerConfig setThisAlias(String thisAlias) {
        this.thisAlias = thisAlias;
        return this;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    public Object getHint(String hintName) {
        return hints==null?null:hints.get(hintName);
    }

    public Object getHint(String hintName,Object defaultValue) {
        Object c = hints == null ? null : hints.get(hintName);
        return c==null?defaultValue:c;
    }

    public ExpressionCompilerConfig setHints(Map<String, Object> hints) {
        this.hints = hints;
        return this;
    }

    @Override
    public String toString() {
        return "ExpressionCompilerConfig{" + "aliasToEntityContext=" + aliasToEntityContext + ", validate=" + validate + ", expandFields=" + expandFields + ", expandFieldFilter=" + expandFieldFilter + ", expandEntityFilter=" + expandEntityFilter + ", thisAlias=" + thisAlias + '}';
    }
}
