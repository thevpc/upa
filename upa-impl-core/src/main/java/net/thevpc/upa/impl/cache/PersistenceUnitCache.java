package net.thevpc.upa.impl.cache;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Document;
import net.thevpc.upa.Key;
import net.thevpc.upa.events.EntityTriggerContext;
import net.thevpc.upa.events.PersistenceUnitEvent;
import net.thevpc.upa.events.PersistenceUnitListenerAdapter;
import net.thevpc.upa.events.SingleDataInterceptorAdapter;
import net.thevpc.upa.events.*;

public class PersistenceUnitCache extends DefaultEntityCollectionCache {
    private PersistenceUnit pu;

    public PersistenceUnitCache(int defaultEntitySize, PersistenceUnit pu) {
        super(defaultEntitySize);
        this.pu = pu;
        pu.addPersistenceUnitListener(new PersistenceUnitListenerAdapter() {
            @Override
            public void onPreModelChanged(PersistenceUnitEvent event) {
                invalidate();
            }

            @Override
            public void onPreStart(PersistenceUnitEvent event) {
                invalidate();
            }

            @Override
            public void onPreClose(PersistenceUnitEvent event) {
                invalidate();
            }

            @Override
            public void onPreStorageChanged(PersistenceUnitEvent event) {
                invalidate();
            }

            @Override
            public void onPreClear(PersistenceUnitEvent event) {
                invalidate();
            }

            @Override
            public void onPreReset(PersistenceUnitEvent event) {
                invalidate();
            }

            @Override
            public void onPreUpdateFormulas(PersistenceUnitEvent event) {
                invalidate();
            }
        });
        pu.addTrigger("PersistenceUnitCache", new SingleDataInterceptorAdapter() {

            @Override
            public void afterUpdate(EntityTriggerContext context, Object id, Document document) {
                Key k = context.getEntity().getBuilder().idToKey(id);
                invalidateByKey(context.getEntity().getName(),k);
            }

            @Override
            public void afterRemove(EntityTriggerContext context, Object id) {
                Key k = context.getEntity().getBuilder().idToKey(id);
                invalidateByKey(context.getEntity().getName(),k);
            }

            @Override
            public void afterUpdateFormulas(EntityTriggerContext context, Object id, Document document) {
                Key k = context.getEntity().getBuilder().idToKey(id);
                invalidateByKey(context.getEntity().getName(),k);
            }
        }, null,true);
    }

}
