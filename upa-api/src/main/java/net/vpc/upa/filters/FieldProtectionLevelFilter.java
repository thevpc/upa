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
import net.vpc.upa.ProtectionLevel;
import net.vpc.upa.exceptions.UPAException;

import java.util.Arrays;
import java.util.EnumSet;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class FieldProtectionLevelFilter extends AbstractFieldFilter {

    private boolean dynamic;
    private boolean checkPersist;
    private boolean checkUpdate;
    private boolean checkSelect;
    private EnumSet<ProtectionLevel> accepted;

    public static FieldProtectionLevelFilter forAll(ProtectionLevel... accepted) {
        EnumSet<ProtectionLevel> all = EnumSet.noneOf(ProtectionLevel.class);
        all.addAll(Arrays.asList(accepted));
        return new FieldProtectionLevelFilter(true, true, true, all, false);
    }

    public static FieldProtectionLevelFilter forPersist(ProtectionLevel... accepted) {
        EnumSet<ProtectionLevel> all = EnumSet.noneOf(ProtectionLevel.class);
        all.addAll(Arrays.asList(accepted));
        return new FieldProtectionLevelFilter(true, false, false, all, false);
    }

    public static FieldProtectionLevelFilter forUpdate(ProtectionLevel... accepted) {
        EnumSet<ProtectionLevel> all = EnumSet.noneOf(ProtectionLevel.class);
        all.addAll(Arrays.asList(accepted));
        return new FieldProtectionLevelFilter(false, true, false, all, false);
    }

    public static FieldProtectionLevelFilter forFind(ProtectionLevel... accepted) {
        EnumSet<ProtectionLevel> all = EnumSet.noneOf(ProtectionLevel.class);
        all.addAll(Arrays.asList(accepted));
        return new FieldProtectionLevelFilter(false, false, true, all, false);
    }

    public FieldProtectionLevelFilter(boolean checkPersist, boolean checkUpdate, boolean checkSelect, Set<ProtectionLevel> accepted, boolean dynamic) {
        this.checkPersist = checkPersist;
        this.checkUpdate = checkUpdate;
        this.checkSelect = checkSelect;
        this.dynamic = dynamic;
        this.accepted = EnumSet.noneOf(ProtectionLevel.class);
        if (accepted != null) {
            this.accepted.addAll(accepted);
        }
    }

    @Override
    public boolean acceptDynamic() {
        return dynamic;
    }

    @Override
    public boolean accept(Field f)  {
        if (checkPersist) {
            if (!accepted.contains(f.getPersistProtectionLevel())) {
                return false;
            }
        }
        if (checkUpdate) {
            if (!accepted.contains(f.getUpdateProtectionLevel())) {
                return false;
            }
        }
        if (checkSelect) {
            if (!accepted.contains(f.getReadProtectionLevel())) {
                return false;
            }
        }
        return true;
    }

    @Override
    public String toString() {
        StringBuilder b = new StringBuilder();
        if (checkPersist && checkUpdate && checkSelect) {
            b.append("AnyProtectionLevel").append(accepted);
        } else if (!checkPersist && !checkUpdate && !checkSelect) {
            b.append("true");
        } else {
            if (checkSelect) {
                b.append("Persist");
            }
            if (checkUpdate) {
                b.append("Update");
            }
            if (checkSelect) {
                b.append("Find");
            }
            b.append("ProtectionLevel").append(accepted);
        }
        return b.toString();
    }
}
