/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 8 nov. 02
 * Time: 21:57:02
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.event;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Key;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.expressions.IdCollectionExpression;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Collection;
import java.util.List;
import net.vpc.upa.callbacks.EntityListenerAdapter;
import net.vpc.upa.callbacks.PersistEvent;
import net.vpc.upa.callbacks.RemoveEvent;
import net.vpc.upa.callbacks.UpdateEvent;

public abstract class ExpressionHelperInterceptorSupport extends EntityListenerAdapter {
    //    private boolean attach;
//    Entity table;

    public ExpressionHelperInterceptorSupport() {
    }

    public abstract Expression translateExpression(Expression e) throws UPAException;

    public abstract void afterDeleteHelper(RemoveEvent event, Expression updatedExpression) throws UPAException;

    public abstract void afterUpdateHelper(UpdateEvent event, Expression updatedExpression) throws UPAException;

    public abstract void afterPersistHelper(PersistEvent event, Expression translatedExpression) throws UPAException;

    public boolean acceptDeleteTableHelper(RemoveEvent event) throws UPAException {
        return true;
    }

    public boolean acceptUpdateTableHelper(UpdateEvent event) throws UPAException {
        return true;
    }

    public boolean acceptUpdateTableOlderValuesHelper(UpdateEvent event) throws UPAException {
        return false;
    }

    /**
     *
     * @param event
     * @return
     * @throws UPAException
     */
    public boolean acceptPersistDocumentHelper(PersistEvent event) throws UPAException {
        return true;
    }

    @Override
    public final void onPreRemove(RemoveEvent event)
            throws UPAException {
        EntityExecutionContext executionContext = event.getContext();
        if (acceptDeleteTableHelper(event)) {
            executionContext.setObject(event.getTrigger().getName() + ":toDelete", createUpdatedCollection(event.getEntity(), event.getFilterExpression()));
        }
    }

    @Override
    public final void onRemove(RemoveEvent event)
            throws UPAException {
        EntityExecutionContext executionContext = event.getContext();
        String name = event.getTrigger().getName();
        Collection<Key> collection = (Collection<Key>) executionContext.getObject(name + ":toDelete");
        if (collection == null) {
            return;
        }
        executionContext.remove(name + ":toDelete");
        if (!collection.isEmpty()) {
            afterDeleteHelper(event, createInCollection(event.getEntity(), collection));
        }
    }

    @Override
    public final void onPreUpdate(UpdateEvent event)
            throws UPAException {
        String name = event.getTrigger().getName();
        EntityExecutionContext executioncontext = event.getContext();
        if (acceptUpdateTableHelper(event)) {
            Collection<Key> v = createUpdatedCollection(event.getEntity(), event.getFilterExpression());
            if (!v.isEmpty()) {
                executioncontext.setObject(name + ":toUpdate", v);
            }
        }
    }

    @Override
    public final void onUpdate(UpdateEvent event)
            throws UPAException {
        // validate old references
        EntityExecutionContext executioncontext = event.getContext();
        String name = event.getTrigger().getName();
        Collection<Key> collection = executioncontext.getObject(name + ":toUpdate");
        if (collection == null) {
            return;
        }
        executioncontext.remove(name + ":toUpdate");
        IdCollectionExpression inColl = null;
        if (!collection.isEmpty()) {
            inColl = createInCollection(event.getEntity(), collection);
            afterUpdateHelper(event, inColl);
        }

        // validate old references
        if (acceptUpdateTableOlderValuesHelper(event)) {
            Expression newUpdates = null;
            if (inColl != null) {
                Expression translated = translateExpression(event.getFilterExpression());
                if (translated != null) {
                    newUpdates = new And(
                            new Not(inColl), translated);
                } else {
                    newUpdates = new Not(inColl);
                }
            } else {
                newUpdates = translateExpression(event.getFilterExpression());
            }
            afterUpdateHelper(event, newUpdates);
        }
    }

    private Collection<Key> createUpdatedCollection(Entity entity, Expression expression) throws UPAException {
        return entity.createQueryBuilder().byExpression(translateExpression(expression)).getKeyList();
    }

    private IdCollectionExpression createInCollection(Entity entity, Collection<Key> collection) throws UPAException {
        List<Field> pfs = entity.getIdFields();
        Var[] v = new Var[pfs.size()];
        for (int i = 0; i < pfs.size(); i++) {
            v[i] = new Var(new Var(pfs.get(i).getEntity().getName()), pfs.get(i).getName());
        }
        if (pfs.size() == 1) {
            IdCollectionExpression inColl = new IdCollectionExpression(v[0]);
            //inColl.setClientProperty(DefaultEntity.EXPRESSION_SURELY_EXISTS, true);
            for (Key k : collection) {
                inColl.add(new Literal(k.getObject(), pfs.get(0).getDataType()));
            }
            return inColl;
        } else {
            IdCollectionExpression inColl = new IdCollectionExpression(v);
            //inColl.setClientProperty(DefaultEntity.EXPRESSION_SURELY_EXISTS, true);
            for (Key k : collection) {
                Literal[] l = new Literal[pfs.size()];
                for (int j = 0; j < pfs.size(); j++) {
                    l[j] = new Literal(k.getObjectAt(j), pfs.get(j).getDataType());
                }
                inColl.add(l);
            }
            return inColl;
        }
    }

    @Override
    public final void onPersist(PersistEvent event)
            throws UPAException {
        if (acceptPersistDocumentHelper(event)) {
            afterPersistHelper(event, translateExpression(event.getEntity().getBuilder().idToExpression(event.getPersistedId(), UQLUtils.THIS)));
        }
    }

}
