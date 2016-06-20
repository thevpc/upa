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
package net.vpc.upa.filters;

import net.vpc.upa.AccessLevel;
import net.vpc.upa.FieldModifier;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.ManyToOneType;

import java.util.Collection;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class Fields extends AbstractFieldFilter {
    private static Fields DYNAMIC = as(new FieldDynamicFilter());
    private static Fields REGULAR = as(new FieldRegularFilter());
    private static Fields ANY = as(new FieldAnyFilter());
    private static Fields NONE = as(new FieldAnyFilter()).negate();
    private static Fields PRIMITIVE = as(new FieldPrimitiveFilter(null));

    private FieldFilter base;

    private Fields(FieldFilter base) {
        this.base = base;
    }

    public static Fields as(FieldFilter base) {
        if (base == null) {
            return any();
        }
        if (base instanceof Fields) {
            return (Fields) base;
        }
        return new Fields(base);
    }

    public static Fields any() {
        return ANY;
    }

    public static Fields regular() {
        return REGULAR;
    }

    public static Fields dynamic() {
        return DYNAMIC;
    }

    public static Fields none() {
        return NONE;
    }

    public static Fields primitive() {
        return PRIMITIVE;
    }

    public static Fields byInsertAccessLevel(AccessLevel... accepted) {
        return new Fields(FieldAccessLevelFilter.forPersist(accepted));
    }

    public static Fields byUpdateAccessLevel(AccessLevel... accepted) {
        return new Fields(FieldAccessLevelFilter.forUpdate(accepted));
    }

    public static Fields byReadAccessLevel(AccessLevel... accepted) {
        return new Fields(FieldAccessLevelFilter.forFind(accepted));
    }

    public static Fields byAllAccessLevel(AccessLevel... accepted) {
        return new Fields(FieldAccessLevelFilter.forAll(accepted));
    }

    public static Fields byModifiersAllOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isAllOf(accepted);
        return new Fields(fieldModifierFilter);
    }

    public static Fields byModifiersNotAllOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isNotAllOf(accepted);
        return new Fields(fieldModifierFilter);
    }

    public static Fields byModifiersNoneOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isNoneOf(accepted);
        return new Fields(fieldModifierFilter);
    }

    public static Fields byModifiersAnyOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isAnyOf(accepted);
        return new Fields(fieldModifierFilter);
    }

    public static Fields byName(String... acceptedFields) {
        return as(new FieldNameFilter(acceptedFields));
    }

    public static Fields byName(Collection<String> acceptedFields) {
        return as(new FieldNameFilter(acceptedFields));
    }

    public static Fields byList(Field... acceptedFields) {
        return as(new FieldListFilter(acceptedFields));
    }

    public static Fields byList(List<Field> acceptedFields) {
        return as(new FieldListFilter(acceptedFields));
    }

    public static Fields byImplType(Class<? extends Field> type) {
        return as(new FieldImplTypeFilter(type));
    }


    public static Fields byDataType(Class type) {
        return as(new FieldDataTypeFilter(type,true));
    }

    public static Fields byEntityType() {
        return byDataType(ManyToOneType.class);
    }

    public Fields byPrimitive() {
        return as(new FieldPrimitiveFilter(base));
    }

    public Fields and(FieldFilter other) {
        return as(FieldAndFilter.and(base, other));
    }

    public Fields andNot(FieldFilter other) {
        return and(new FieldReverseFilter(other));
    }

    public Fields or(FieldFilter other) {
        return new Fields(FieldOrFilter.or(base, other));
    }

    public Fields orNot(FieldFilter other) {
        return or(new FieldReverseFilter(other));
    }

    public Fields negate() {
        return new Fields(new FieldReverseFilter(base));
    }

    @Override
    public boolean acceptDynamic() throws UPAException {
        return base.acceptDynamic();
    }

    @Override
    public boolean accept(Field f) throws UPAException {
        return base.accept(f);
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 97 * hash + (this.base != null ? this.base.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Fields other = (Fields) obj;
        if (this.base != other.base && (this.base == null || !this.base.equals(other.base))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return String.valueOf(base);
    }

}
