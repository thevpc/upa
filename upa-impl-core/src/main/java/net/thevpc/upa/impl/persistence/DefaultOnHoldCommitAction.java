package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.types.I18NString;
import net.thevpc.upa.PersistenceState;
import net.thevpc.upa.UPAObject;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.OnHoldCommitAction;
import net.thevpc.upa.impl.OnHoldCommitActionType;
import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.persistence.PersistenceStore;

import java.util.Set;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/20/12 9:54 PM
 */
public class DefaultOnHoldCommitAction implements OnHoldCommitAction {

    private UPAObject object;
    private OnHoldCommitActionType actionType;
    private UPAObject old;
    private int order;
    private Set<String> updates;

//    public DefaultOnHoldCommitAction(UPAObject object, OnHoldCommitActionType type, int order, UPAObject old, Set<String> updates) {
//        this(object, type, order);
//        this.old = old;
//        this.updates = updates;
//    }

    public DefaultOnHoldCommitAction(UPAObject object, OnHoldCommitActionType type, int order) {
        this.object = object;
        this.actionType = type;
        this.order = order;
    }

    @Override
    public int getOrder() {
        return order;
    }

    @Override
    public void commitModel() throws UPAException {
        new DefaultBeanAdapter(object).setProperty("persistenceState", PersistenceState.TRANSIENT);
    }

    @Override
    public void commitStorage(EntityExecutionContext context) throws UPAException {
        PersistenceStore persistenceStore = context.getPersistenceStore();
        //should verify if not yet stored
        switch (object.getPersistenceState()) {
            case VALID: {
                //do nothing
                break;
            }
            case TRANSIENT: {
                switch (actionType) {
                    case CREATE: {
                        persistenceStore.alterPersistenceUnitAddObject(object);
                        break;
                    }
                    case REMOVE: {
                        persistenceStore.alterPersistenceUnitRemoveObject(object);
                        break;
                    }
                    case UPDATE: {
                        persistenceStore.alterPersistenceUnitUpdateObject(old, object, updates);
                        break;
                    }
                }
                new DefaultBeanAdapter(object).setProperty("persistenceState", PersistenceState.VALID);
                break;
            }
            default: {
                throw new UPAException(new I18NString("Unexpected"));
            }
        }
    }

    public UPAObject getObject() {
        return object;
    }

    
    @Override
    public String toString() {
        switch (actionType) {
            case CREATE: {
                return "Create(" + object + ", impl=" + object.getClass().getSimpleName() + ", order=" + order + ")";
            }
        }
        return "CommitAction{" + "object=" + object + ", type=" + actionType + ", old=" + old + ", order=" + order + ", updates=" + updates + '}';
    }

    public int compareTo(OnHoldCommitAction o) {
        int i1 = getOrder();
        int i2 = o.getOrder();
        int i = i1 - i2;
        if (i != 0) {
            return i;
        }
        if (this == o) {
            return 0;
        }
        return i;
    }

}
