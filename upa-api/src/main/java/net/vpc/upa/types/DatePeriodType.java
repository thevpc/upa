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
package net.vpc.upa.types;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.Date;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 29 avr. 2003
 * Time: 10:38:06
 * 
 */
public class DatePeriodType extends DefaultDataType implements CompoundDataType {
    private String countName;
    private String periodTypeName;
    private NumberType countDataType;
    private EnumType periodTypeDataType;

    public DatePeriodType(String name, String countName, String periodTypeName, boolean nullable) {
        this(name, countName, periodTypeName, new IntType("PERIOD", 0, null, nullable, false));
    }

    public DatePeriodType(String name, String countName, String periodTypeName, NumberType countDataType) {
        super(name, DatePeriod.class, countDataType.isNullable());
        this.countName = countName;
        this.periodTypeName = periodTypeName;
        this.countDataType = countDataType;
        this.periodTypeDataType = new EnumType(PeriodOption.class, countDataType.isNullable());

        if (this.countName == null) {
            this.countName = "count";
        }
        if (this.periodTypeName == null) {
            this.periodTypeName = "type";
        }
        reevaluateCachedValues();
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
//        Integer defaultNonNullValue = (Integer) countDataType.getDefaultValue();
        if(!defaultValueUserDefined && !isNullable()) {
//            defaultValue=(new DatePeriod(defaultNonNullValue == null ? 0 : defaultNonNullValue.intValue(), PeriodOption.DAY));
            defaultValue=(new DatePeriod(0, PeriodOption.DAY));
        }
    }

    public String getCountName() {
        return countName;
    }

    public String getPeriodTypeName() {
        return periodTypeName;
    }

    public EnumType getPeriodTypeDataType() {
        return periodTypeDataType;
    }

    public NumberType getCountDataType() {
        return countDataType;
    }

    @Override
    public FieldDescriptor[] getComposingFields(FieldDescriptor fieldDescriptor) {
        String[] names = new String[]{
                fieldDescriptor.getName() +
                        Character.toUpperCase(countName.charAt(0)) + countName.substring(1)
                ,
                fieldDescriptor.getName() +
                        Character.toUpperCase(periodTypeName.charAt(0)) + periodTypeName.substring(1)
        };
        if (fieldDescriptor.getPersistFormula() != null) {
            throw new IllegalUPAArgumentException("Unsupported composing Persist Formula");
        }
        if (fieldDescriptor.getUpdateFormula() != null) {
            throw new IllegalUPAArgumentException("Unsupported composing Update Formula");
        }
        if (fieldDescriptor.getSelectFormula() != null) {
            throw new IllegalUPAArgumentException("Unsupported composing Select Formula");
        }
        FieldDescriptor[] fieldDescriptors = new FieldDescriptor[names.length];
        Object[] def = getPrimitiveValues(fieldDescriptor.getDefaultObject());
        Object[] uns = getPrimitiveValues(fieldDescriptor.getUnspecifiedObject());
        for (int i = 0; i < fieldDescriptors.length; i++) {
            DefaultFieldDescriptor d = new DefaultFieldDescriptor();
            d.setReadProtectionLevel(ProtectionLevel.PRIVATE);
            d.setDataType(i == 0 ? TypesFactory.INT : TypesFactory.INT);
            d.setDefaultObject(def == null ? null : def[i]);
            d.setUnspecifiedObject(uns == null ? null : uns[i]);
            d.setPersistAccessLevel(fieldDescriptor.getPersistAccessLevel());
            d.setModifiers(FlagSets.of(UserFieldModifier.SYSTEM));
            d.setUpdateAccessLevel(fieldDescriptor.getPersistAccessLevel());
            fieldDescriptors[i] = d;
        }
        return fieldDescriptors;
    }

    public Object[] getPrimitiveValues(Object object) {
        if (object == null) {
            return null;
        }
        DatePeriod datePeriod = (DatePeriod) object;
        return new Object[]{datePeriod.getCount(), datePeriod.getPeriodType().ordinal()};
    }

    public Object getCompoundValue(Object[] values) {
        if (values != null && values[0] != null && values[1] != null) {
            int c = ((Integer) values[0]).intValue();
            int p = ((Integer) values[1]).intValue();
            return new DatePeriod(c, PeriodOption.values()[p]);
        }
        return null;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        DatePeriodType that = (DatePeriodType) o;

        if (countName != null ? !countName.equals(that.countName) : that.countName != null) return false;
        if (periodTypeName != null ? !periodTypeName.equals(that.periodTypeName) : that.periodTypeName != null)
            return false;
        if (countDataType != null ? !countDataType.equals(that.countDataType) : that.countDataType != null)
            return false;
        return periodTypeDataType != null ? periodTypeDataType.equals(that.periodTypeDataType) : that.periodTypeDataType == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (countName != null ? countName.hashCode() : 0);
        result = 31 * result + (periodTypeName != null ? periodTypeName.hashCode() : 0);
        result = 31 * result + (countDataType != null ? countDataType.hashCode() : 0);
        result = 31 * result + (periodTypeDataType != null ? periodTypeDataType.hashCode() : 0);
        return result;
    }
}
