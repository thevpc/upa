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

import net.vpc.upa.Entity;
import net.vpc.upa.EntityShield;
import net.vpc.upa.exceptions.UPAException;

import java.util.HashSet;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultEntityFilter extends AbstractRichEntityFilter {
    private int acceptCloneable = 0;
    private int acceptValidatable = 0;
    private int acceptUpdatable = 0;
    private int acceptTransient = 0;
    private int acceptSystem = 0;
    private int acceptPrivate = 0;
    private int acceptDeletable = 0;
    private int acceptEmpty = 0;
    private int acceptPersistable = 0;
    private int acceptNavigatable = 0;
    //    private int acceptPrintable=0;
    private int acceptKeyGeneratable = 0;
    private int acceptKeyEditable = 0;
    private int acceptRenamable = 0;
    private int acceptClear = 0;
    private Class rootClass;
    private Set<String> acceptedNames;
    private Set<String> rejectedNames;

    public DefaultEntityFilter() {
    }

    public DefaultEntityFilter setAcceptName(String name){
        if(acceptedNames==null){
            acceptedNames=new HashSet<>();
        }
        acceptedNames.add(name);
        return this;
    }

    public DefaultEntityFilter unsetAcceptName(String name){
        if(acceptedNames!=null){
            acceptedNames.remove(name);
        }
        return this;
    }

    public DefaultEntityFilter setRejectName(String name){
        if(rejectedNames==null){
            rejectedNames=new HashSet<>();
        }
        rejectedNames.add(name);
        return this;
    }

    public DefaultEntityFilter unsetRejectName(String name){
        if(rejectedNames!=null){
            rejectedNames.remove(name);
        }
        return this;
    }

    public Class getRootTableClass() {
        return rootClass;
    }

    public DefaultEntityFilter setAcceptRootEntityClass(Class entity) {
        rootClass = entity;
        return this;
    }

    public boolean isAcceptCloneable() {
        return acceptCloneable == 1;
    }

    public DefaultEntityFilter setAcceptCloneable(boolean acceptCloneable) {
        this.acceptCloneable = acceptCloneable ? 1 : -1;
        return this;
    }

    public boolean isRejectCloneable() {
        return acceptCloneable == -1;
    }

    public boolean isAcceptValidatable() {
        return acceptValidatable == 1;
    }

    public DefaultEntityFilter setAcceptValidatable(boolean acceptValidatable) {
        this.acceptValidatable = acceptValidatable ? 1 : -1;
        return this;
    }

    public boolean isRejectValidatable() {
        return acceptValidatable == -1;
    }

    public boolean isAcceptUpdatable() {
        return acceptUpdatable == 1;
    }

    public DefaultEntityFilter setAcceptUpdatable(boolean acceptUpdatable) {
        this.acceptUpdatable = acceptUpdatable ? 1 : -1;
        return this;
    }

    public boolean isRejectUpdatable() {
        return acceptUpdatable == -1;
    }

    public boolean isAcceptTransient() {
        return acceptTransient == 1;
    }

    public DefaultEntityFilter setAcceptTransient(boolean acceptTransient) {
        this.acceptTransient = acceptTransient ? 1 : -1;
        return this;
    }

    public boolean isRejectTransient() {
        return acceptTransient == -1;
    }

    public boolean isAcceptSystem() {
        return acceptSystem == 1;
    }

    public DefaultEntityFilter setAcceptSystem(boolean acceptSystem) {
        this.acceptSystem = acceptSystem ? 1 : -1;
        return this;
    }

    public boolean isRejectSystem() {
        return acceptSystem == -1;
    }

    public boolean isAcceptPrivate() {
        return acceptPrivate == 1;
    }

    public DefaultEntityFilter setAcceptPrivate(boolean acceptPrivate) {
        this.acceptPrivate = acceptPrivate ? 1 : -1;
        return this;
    }

    public boolean isRejectPrivate() {
        return acceptPrivate == -1;
    }

    public boolean isAcceptDeletable() {
        return acceptDeletable == 1;
    }

    public DefaultEntityFilter setAcceptDeletable(boolean acceptDeletable) {
        this.acceptDeletable = acceptDeletable ? 1 : -1;
        return this;
    }

    public boolean isRejectDeletable() {
        return acceptDeletable == -1;
    }

    public boolean isAcceptEmpty() {
        return acceptEmpty == 1;
    }

    public DefaultEntityFilter setAcceptEmpty(boolean acceptEmpty) {
        this.acceptEmpty = acceptEmpty ? 1 : -1;
        return this;
    }

    public boolean isRejectEmpty() {
        return acceptEmpty == -1;
    }

    public boolean isAcceptPersistable() {
        return acceptPersistable == 1;
    }

    public DefaultEntityFilter setAcceptPersistable(boolean acceptPersistable) {
        this.acceptPersistable = acceptPersistable ? 1 : -1;
        return this;
    }

    public boolean isRejectPersistable() {
        return acceptPersistable == -1;
    }

    public boolean isAcceptNavigatable() {
        return acceptNavigatable == 1;
    }

    public DefaultEntityFilter setAcceptNavigatable(boolean acceptNavigatable) {
        this.acceptNavigatable = acceptNavigatable ? 1 : -1;
        return this;
    }

    public boolean isRejectNavigatable() {
        return acceptNavigatable == -1;
    }

//    public boolean isAcceptPrintable() {
//        return acceptPrintable==1;
//    }
//    public boolean isRejectPrintable() {
//        return acceptPrintable==-1;
//    }
//
//    public DefaultEntityFilter setAcceptPrintable(boolean acceptPrintable) {
//        this.acceptPrintable = acceptPrintable ? 1 :-1;
//        return this;
//    }

    public boolean isAcceptKeyGeneratable() {
        return acceptKeyGeneratable == 1;
    }

    public DefaultEntityFilter setAcceptKeyGeneratable(boolean acceptKeyGeneratable) {
        this.acceptKeyGeneratable = acceptKeyGeneratable ? 1 : -1;
        return this;
    }

    public boolean isRejectKeyGeneratable() {
        return acceptKeyGeneratable == -1;
    }

    public boolean isAcceptKeyEditable() {
        return acceptKeyEditable == 1;
    }

    public DefaultEntityFilter setAcceptKeyEditable(boolean acceptKeyEditable) {
        this.acceptKeyEditable = acceptKeyEditable ? 1 : -1;
        return this;
    }

    public boolean isRejectKeyEditable() {
        return acceptKeyEditable == -1;
    }

    public boolean isAcceptRenamable() {
        return acceptRenamable == 1;
    }

    public DefaultEntityFilter setAcceptRenamable(boolean acceptRenamable) {
        this.acceptRenamable = acceptRenamable ? 1 : -1;
        return this;
    }

    public boolean isRejectRenamable() {
        return acceptRenamable == -1;
    }

    public boolean isAcceptClear() {
        return acceptClear == 1;
    }

    public DefaultEntityFilter setAcceptClear(boolean acceptClear) {
        this.acceptClear = acceptClear ? 1 : -1;
        return this;
    }

    public boolean isRejectClear() {
        return acceptClear == -1;
    }

    public boolean accept(Entity entity) throws UPAException {
        Object source = entity.getEntityDescriptor().getSource();
        if (rootClass != null && (source == null || !rootClass.isAssignableFrom(source.getClass()))) {
            return false;
        }
        if(acceptedNames!=null && acceptedNames.size()>0  && !acceptedNames.contains(entity.getName())){
            return false;
        }
        if(rejectedNames!=null && rejectedNames.size()>0  && rejectedNames.contains(entity.getName())){
            return false;
        }
        EntityShield v = entity.getShield();
        if (isAcceptCloneable() && !v.isCloneSupported()) {
            return false;
        }
        if (isRejectCloneable() && v.isCloneSupported()) {
            return false;
        }
        if (isAcceptKeyEditable() && !v.isKeyEditionSupported()) {
            return false;
        }
        if (isRejectKeyEditable() && v.isKeyEditionSupported()) {
            return false;
        }

        if (isAcceptRenamable() && !v.isRenameSupported()) {
            return false;
        }
        if (isRejectRenamable() && v.isRenameSupported()) {
            return false;
        }

        if (isAcceptClear() && !v.isClearSupported()) {
            return false;
        }
        if (isRejectClear() && v.isClearSupported()) {
            return false;
        }

        if (isAcceptDeletable() && !v.isDeleteSupported()) {
            return false;
        }
        if (isRejectDeletable() && v.isDeleteSupported()) {
            return false;
        }

        try {
            if (isAcceptEmpty() && !entity.isEmpty()) {
                return false;
            }
        } catch (UPAException e) {
            return false;
        }
        try {
            if (isRejectEmpty() && entity.isEmpty()) {
                return false;
            }
        } catch (UPAException e) {
            return false;
        }
        if (isAcceptPersistable() && !v.isPersistSupported()) {
            return false;
        }
        if (isRejectPersistable() && v.isPersistSupported()) {
            return false;
        }
        if (isAcceptNavigatable() && !v.isNavigateSupported()) {
            return false;
        }
        if (isRejectNavigatable() && v.isNavigateSupported()) {
            return false;
        }

//        if(isAcceptPrintable() && !v.isPrintSupported()){
//            return false;
//        }
//        if(isRejectPrintable() && v.isPrintSupported()){
//            return false;
//        }
        if (isAcceptKeyGeneratable() && !v.isGeneratedId()) {
            return false;
        }
        if (isRejectKeyGeneratable() && v.isGeneratedId()) {
            return false;
        }
        if (isAcceptSystem() && !v.isSystem()) {
            return false;
        }
        if (isRejectSystem() && v.isSystem()) {
            return false;
        }
        if (isAcceptPrivate() && !v.isPrivate()) {
            return false;
        }
        if (isRejectPrivate() && v.isPrivate()) {
            return false;
        }

        if (isAcceptTransient() && !v.isTransient()) {
            return false;
        }
        if (isRejectTransient() && v.isTransient()) {
            return false;
        }

        if (isAcceptUpdatable() && !v.isUpdateSupported()) {
            return false;
        }

        if (isRejectUpdatable() && v.isUpdateSupported()) {
            return false;
        }

        if (isAcceptValidatable() && !v.isUpdateFormulaSupported()) {
            return false;
        }
        if (isRejectValidatable() && v.isUpdateFormulaSupported()) {
            return false;
        }
        return true;
    }
}
