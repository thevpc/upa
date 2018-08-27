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
package net.vpc.upa.events;

import net.vpc.upa.*;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.IdEnumerationExpression;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.List;

/**
 * @author taha.bensalah@gmail.com
 */
public class UpdateEvent extends EntityEvent {

    private Document updatesDocument;
    private Object updatesObject;
    private Expression filterExpression;

    public UpdateEvent(Document updatesDocument, Expression filterExpression, EntityExecutionContext entityExecutionContext, EventPhase phase) {
        super(entityExecutionContext, phase);
        this.updatesDocument = updatesDocument;
        this.filterExpression = filterExpression;
    }

    public Document getUpdatesDocument() {
        return updatesDocument;
    }

    public Object getUpdatesObject() {
        if (updatesObject == null && updatesDocument != null) {
            EntityBuilder builder = getContext().getEntity().getBuilder();
            updatesObject = builder.documentToObject(updatesDocument);
            if(getFilterExpression() instanceof IdExpression){
                Object id = ((IdExpression) getFilterExpression()).getId();
                builder.setObjectId(updatesObject,id);
            }
        }
        return updatesObject;
    }

    public Expression getFilterExpression() {
        return filterExpression;
    }


    public void storeUpdatedIds() {
        List object = (List) this.getContext().getObject("updated_ids_" + this.getEntity().getName());
        if (object != null) {
            //already loaded
            return;
        }
        Expression expr = this.getFilterExpression();
        Entity entity = this.getEntity();
        if (expr instanceof IdEnumerationExpression) {
            IdEnumerationExpression k = (IdEnumerationExpression) expr;
            expr = new IdEnumerationExpression(k.getIds(), new Var("this"));
        }
        PersistenceUnit pu = this.getPersistenceUnit();
        List old = pu.createQueryBuilder(entity.getName()).byExpression(expr).getIdList();
        int sise=old.size();//force load!
        this.getContext().setObject("updated_ids_" + entity.getName(), old);
    }

    public <T> List<T> loadUpdatedIds() {
        List<T> object = (List<T>) this.getContext().<List<T>>getObject("updated_ids_" + this.getEntity().getName());
        if (object == null) {
            throw new net.vpc.upa.exceptions.IllegalUPAArgumentException("StoreUpdatedIdsRequiresPreUpdateToBeInvoked");
        }
        return object;
    }

}
