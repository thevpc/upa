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
package net.vpc.upa.filters;

import net.vpc.upa.Field;
import net.vpc.upa.FieldModifier;
import net.vpc.upa.FlagSet;
import net.vpc.upa.FlagSets;
import net.vpc.upa.exceptions.UPAException;

public class FieldModifierFilter extends AbstractFieldFilter {

    private FlagSet<FieldModifier>[] accepted;
    private FlagSet<FieldModifier>[] rejected;
    private boolean acceptDynamic;

    public FieldModifierFilter() {
        accepted = new FlagSet[0];
        rejected = new FlagSet[0];
    }

    private FieldModifierFilter(FlagSet<FieldModifier>[] accepted, FlagSet<FieldModifier>[] rejected, boolean acceptDynamic) {
        this.accepted = accepted;
        this.rejected = rejected;
        this.acceptDynamic = acceptDynamic;
    }

    @Override
    public boolean acceptDynamic() {
        return acceptDynamic;
    }

    public boolean isAcceptDynamic() {
        return acceptDynamic;
    }

    public FieldModifierFilter setAcceptDynamic(boolean acceptDynamic) {
        if (this.acceptDynamic == acceptDynamic) {
            return this;
        }
        return new FieldModifierFilter(accepted, rejected, acceptDynamic);
    }

    public boolean accept(FlagSet<FieldModifier> modifiersValue) throws UPAException {
        for (int i = 0; i < accepted.length; i++) {
            if (accept(modifiersValue, i)) {
                return true;
            }
        }
        return false;
    }

    private boolean accept(FlagSet<FieldModifier> modifiersValue, int i) throws UPAException {
        FlagSet<FieldModifier> a = accepted[i];
        FlagSet<FieldModifier> r = rejected[i];
        for (FieldModifier m : a) {
            if (!modifiersValue.contains(m)) {
                return false;
            }
        }
        for (FieldModifier m : r) {
            if (modifiersValue.contains(m)) {
                return false;
            }
        }
        return true;
    }

    public boolean accept(Field f) throws UPAException {
        FlagSet<FieldModifier> modifiersValue = f.getModifiers();
        return accept(modifiersValue);
    }

    private FieldModifierFilter or(FieldModifier[] modifierYes, FieldModifier[] modifierNo) {
        FlagSet<FieldModifier> y = modifierYes == null ? FlagSets.noneOf(FieldModifier.class) : FlagSets.noneOf(FieldModifier.class).addAll(modifierYes);
        FlagSet<FieldModifier> n = modifierNo == null ? FlagSets.noneOf(FieldModifier.class) : FlagSets.noneOf(FieldModifier.class).addAll(modifierNo);
        for (int i = 0; i < accepted.length; i++) {
            if (accepted[i].equals(y) && rejected[i].equals(n)) {
                return this;
            }
        }
        FlagSet<FieldModifier>[] na = new FlagSet[accepted.length + 1];
        FlagSet<FieldModifier>[] nr = new FlagSet[rejected.length + 1];
        System.arraycopy(accepted, 0, na, 0, accepted.length);
        System.arraycopy(rejected, 0, nr, 0, rejected.length);
        na[na.length - 1] = y;
        nr[nr.length - 1] = n;
        return new FieldModifierFilter(na, nr, acceptDynamic);
    }

    public FieldModifierFilter isAllOfFirstsAndNoneOfSeconds(FieldModifier[] modifierYes, FieldModifier[] modifierNo) {
        if (accepted.length != 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use orIsAllOfFirstsAndNoneOfSeconds instead");
        }
        return or(modifierYes, modifierNo);
    }

    public FieldModifierFilter orIsAllOfFirstsAndNoneOfSeconds(FieldModifier[] modifierYes, FieldModifier[] modifierNo) {
        if (accepted.length == 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use isAllOfFirstsAndNoneOfSeconds instead");
        }
        return or(modifierYes, modifierNo);
    }

    public FieldModifierFilter isOneOfFirstsAndNoneOfSeconds(FieldModifier[] modifierYes, FieldModifier[] modifierNo) {
        if (accepted.length != 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use orIsAllOfFirstsAndNoneOfSeconds instead");
        }
        FieldModifierFilter x = this;
        for (int i = 0; i < modifierYes.length; i++) {
            x = or(new FieldModifier[]{modifierYes[i]}, modifierNo);
        }
        return x;
    }

    public FieldModifierFilter orIsOneOfFirstsAndNoneOfSeconds(FieldModifier[] modifierYes, FieldModifier[] modifierNo) {
        if (accepted.length == 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use isAllOfFirstsAndNoneOfSeconds instead");
        }
        FieldModifierFilter x = this;
        for (int i = 0; i < modifierYes.length; i++) {
            x = or(new FieldModifier[]{modifierYes[i]}, modifierNo);
        }
        return x;
    }

    public FieldModifierFilter isAllOf(FieldModifier... modifiers) {
        if (accepted.length != 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use orIsAllOf instead");
        }
        return or(modifiers);
    }

    public FieldModifierFilter isAnyOf(FieldModifier... modifiers) {
        if (accepted.length != 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use orIsOneOf instead");
        }
        FieldModifierFilter x = this;
        for (FieldModifier m : modifiers) {
            x = x.or(new FieldModifier[]{m});
        }
        return x;
    }

    public FieldModifierFilter orIsOneOf(FieldModifier... modifiers) {
        if (accepted.length == 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use isOneOf instead");
        }
        FieldModifierFilter x = this;
        for (FieldModifier m : modifiers) {
            x = or(new FieldModifier[]{m});
        }
        return x;
    }

    public FieldModifierFilter isNotAllOf(FieldModifier... modifiers) {
        if (accepted.length != 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use orIsNotOneOf instead");
        }
        FieldModifierFilter x = this;
        for (FieldModifier m : modifiers) {
            x = orNot(new FieldModifier[]{m});
        }
        return x;
    }

    public FieldModifierFilter orIsNotAllOf(FieldModifier... modifiers) {
        if (accepted.length == 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use isNotOneOf instead");
        }
        FieldModifierFilter x = this;
        for (FieldModifier m : modifiers) {
            x = orNot(new FieldModifier[]{m});
        }
        return x;
    }

    public FieldModifierFilter isNoneOf(FieldModifier... modifiers) {
        if (accepted.length != 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use orIsNoneOf instead");
        }
        return orNot(modifiers);
    }

    public FieldModifierFilter orIsAllOf(FieldModifier... modifiers) {
        if (accepted.length == 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use isAllOf instead");
        }
        return or(modifiers);
    }

    public FieldModifierFilter orIsNoneOf(FieldModifier... modifiers) {
        if (accepted.length == 0) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException("use isNoneOf instead");
        }
        return orNot(modifiers);
    }

    private FieldModifierFilter or(FieldModifier[] modifiers) {
        return or(modifiers, null);
    }

    private FieldModifierFilter orNot(FieldModifier[] modifiers) {
        return or(null, modifiers);
    }

    //    public FieldFilter or(Field fields[]) {
//        checkLock();
//        acceptedFields.add(Arrays.asList(fields));
//        return this;
//    }
//
//    public FieldFilter orNot(Field fields[]) {
//        checkLock();
//        nonAcceptedFields.add(Arrays.asList(fields));
//        return this;
//    }
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("EffectiveModifiers(");
        for (int i = 0; i < accepted.length; i++) {
            if (i > 0) {
                sb.append(") or (");
            }
            boolean first = true;
            for (FieldModifier e : accepted[i]) {
                if (first) {
                    first = false;
                } else {
                    sb.append(" and ");
                }
                sb.append(e);
            }
            for (FieldModifier e : rejected[i]) {
                if (first) {
                    sb.append("not ");
                    first = false;
                } else {
                    sb.append(" and not ");
                }
                sb.append(e);
            }
        }

        sb.append(")");
//        sb.append(acceptedFields);
//        sb.append(" !");
//        sb.append(nonAcceptedFields);
        return sb.toString();
    }

    @Override
    public boolean equals(Object other) {
        if (this == other) {
            return true;
        }
        if (other == null || !(other instanceof FieldModifierFilter)) {
            return false;
        }
        FieldModifierFilter m = (FieldModifierFilter) other;
        if (m.accepted.length != accepted.length) {
            return false;
        }
        for (int i = 0; i < m.accepted.length; i++) {
            boolean found = false;
            for (int j = 0; j < accepted.length; j++) {
                if ((m.accepted[i].equals(accepted[j])) && (m.rejected[i] == rejected[j])) {
                    found = true;
                    break;
                }
            }
            if (!found) {
                return false;
            }
        }
        for (int i = 0; i < accepted.length; i++) {
            boolean found = false;
            for (int j = 0; j < m.accepted.length; j++) {
                if ((accepted[i].equals(m.accepted[j])) && (rejected[i] == m.rejected[j])) {
                    found = true;
                    break;
                }
            }
            if (!found) {
                return false;
            }
        }
        return true;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + arrayHash(this.accepted);
        hash = 97 * hash + arrayHash(this.rejected);
        hash = 97 * hash + (this.acceptDynamic ? 1 : 0);
        return hash;
    }

    /**
     * Arrays.deepHashCode not used because java sepcific
     *
     * @param arr
     * @return
     */
    private int arrayHash(Object[] arr) {
        int x = 0;
        if (arr != null) {
            for (Object o : arr) {
                if (o != null) {
                    x += 31 * o.hashCode();
                }
            }
        }
        return x;
    }
}
