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
public class FieldFilters  {
    private static final RichFieldFilter DYNAMIC = as(new FieldDynamicFilter());
    private static final RichFieldFilter REGULAR = as(new FieldRegularFilter());
    private static final RichFieldFilter ALL = as(new FieldAnyFilter());
    private static final RichFieldFilter NONE = as(new FieldAnyFilter()).negate();
    private static final RichFieldFilter PRIMITIVE = as(new FieldPrimitiveFilter(null));
    private static final RichFieldFilter ID = FieldFilters.regular().and(FieldFilters.byModifiersAnyOf(FieldModifier.ID));


    public static RichFieldFilter as(FieldFilter base) {
        if (base == null) {
            return all();
        }
        if (base instanceof FieldFilters) {
            return (RichFieldFilter) base;
        }
        return new CustomFieldFilter(base);
    }

    public static RichFieldFilter all() {
        return ALL;
    }
    public static RichFieldFilter id() {
        return ID;
    }

    public static RichFieldFilter regular() {
        return REGULAR;
    }

    public static RichFieldFilter dynamic() {
        return DYNAMIC;
    }

    public static RichFieldFilter none() {
        return NONE;
    }

    public static RichFieldFilter primitive() {
        return PRIMITIVE;
    }

    public static RichFieldFilter byInsertAccessLevel(AccessLevel... accepted) {
        return new CustomFieldFilter(FieldAccessLevelFilter.forPersist(accepted));
    }

    public static RichFieldFilter byUpdateAccessLevel(AccessLevel... accepted) {
        return new CustomFieldFilter(FieldAccessLevelFilter.forUpdate(accepted));
    }

    public static RichFieldFilter byReadAccessLevel(AccessLevel... accepted) {
        return new CustomFieldFilter(FieldAccessLevelFilter.forFind(accepted));
    }

    public static RichFieldFilter byAllAccessLevel(AccessLevel... accepted) {
        return new CustomFieldFilter(FieldAccessLevelFilter.forAll(accepted));
    }

    public static RichFieldFilter byModifiersAllOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isAllOf(accepted);
        return new CustomFieldFilter(fieldModifierFilter);
    }

    public static RichFieldFilter byModifiersNotAllOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isNotAllOf(accepted);
        return new CustomFieldFilter(fieldModifierFilter);
    }

    public static RichFieldFilter byModifiersNoneOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isNoneOf(accepted);
        return new CustomFieldFilter(fieldModifierFilter);
    }

    public static RichFieldFilter byModifiersAnyOf(FieldModifier... accepted) {
        FieldModifierFilter fieldModifierFilter = new FieldModifierFilter();
        fieldModifierFilter = fieldModifierFilter.isAnyOf(accepted);
        return new CustomFieldFilter(fieldModifierFilter);
    }

    public static RichFieldFilter byName(String... acceptedFields) {
        return as(new FieldNameFilter(acceptedFields));
    }

    public static RichFieldFilter byName(Collection<String> acceptedFields) {
        return as(new FieldNameFilter(acceptedFields));
    }

    public static RichFieldFilter byList(Field... acceptedFields) {
        return as(new FieldListFilter(acceptedFields));
    }

    public static RichFieldFilter byList(List<Field> acceptedFields) {
        return as(new FieldListFilter(acceptedFields));
    }

    public static RichFieldFilter byImplType(Class<? extends Field> type) {
        return as(new FieldImplTypeFilter(type));
    }


    public static RichFieldFilter byDataType(Class type) {
        return as(new FieldDataTypeFilter(type, true));
    }

    public static RichFieldFilter byEntityType() {
        return byDataType(ManyToOneType.class);
    }
}
