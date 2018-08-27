package net.vpc.upa.impl.extension;

import net.vpc.upa.events.PersistenceUnitEvent;
import net.vpc.upa.events.PersistenceUnitListener;
import net.vpc.upa.events.PersistenceUnitListenerAdapter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 2:29 PM
 */
class UnionPersistenceUnitInterceptorAdapter extends PersistenceUnitListenerAdapter implements PersistenceUnitListener {
    private DefaultUnionEntityExtension defaultUnionEntityExtensionSupport;

    public UnionPersistenceUnitInterceptorAdapter(DefaultUnionEntityExtension defaultUnionEntityExtensionSupport) {
        this.defaultUnionEntityExtensionSupport = defaultUnionEntityExtensionSupport;
    }

    @Override
    public void onModelChanged(PersistenceUnitEvent event) {
        if (defaultUnionEntityExtensionSupport.viewQuery == null) {
            defaultUnionEntityExtensionSupport.viewQuery = defaultUnionEntityExtensionSupport.createViewQuery();
        }
    }
}
