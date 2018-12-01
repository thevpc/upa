package net.vpc.upa.impl.cache;

import net.vpc.upa.Document;
import net.vpc.upa.Key;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.events.*;

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
                invalidateById(context.getEntity().getName(),k);
            }

            @Override
            public void afterRemove(EntityTriggerContext context, Object id) {
                Key k = context.getEntity().getBuilder().idToKey(id);
                invalidateById(context.getEntity().getName(),k);
            }

            @Override
            public void afterUpdateFormulas(EntityTriggerContext context, Object id, Document document) {
                Key k = context.getEntity().getBuilder().idToKey(id);
                invalidateById(context.getEntity().getName(),k);
            }
        }, null,true);
    }

}
