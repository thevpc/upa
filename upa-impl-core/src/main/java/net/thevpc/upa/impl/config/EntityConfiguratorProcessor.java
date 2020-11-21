/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Entity;
import net.thevpc.upa.events.DefinitionListenerAdapter;
import net.thevpc.upa.events.EntityDefinitionListener;
import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.filters.EntityFilter;

import java.util.HashSet;
import java.util.List;

/**
 * @author taha.bensalah@gmail.com
 */
public final class EntityConfiguratorProcessor
        extends DefinitionListenerAdapter
        implements EntityDefinitionListener {

    private EntityFilter filter;
    private EntityConfigurator configurator;
    private boolean oneShot;
    private PersistenceUnit u;
    private HashSet<String> added = new HashSet<String>();

    public static void configureTracker(PersistenceUnit u, EntityFilter filter, EntityConfigurator configurator) {
        new EntityConfiguratorProcessor(false).process(u, filter, configurator);
    }

    public static void configureOneShot(PersistenceUnit u, EntityFilter filter, EntityConfigurator configurator) {
        new EntityConfiguratorProcessor(true).process(u, filter, configurator);
    }

    private EntityConfiguratorProcessor(boolean onShot) {
        this.oneShot = onShot;
    }

    private void process(PersistenceUnit u, EntityFilter filter, EntityConfigurator configurator) {
        this.filter = filter;
        this.configurator = configurator;
        List<Entity> f = u.getEntities(filter);
        for (Entity f1 : f) {
            configurator.install(f1);
        }
        u.addDefinitionListener(this);
    }

    public void onCreateEntity(EntityEvent event) {
        Entity e = event.getEntity();
        if (filter.accept(e)) {
            if (!added.contains(e.getName())) {
                added.add(e.getName());
                configurator.install(e);
            }
        }
    }

    public void onDropEntity(EntityEvent event) {
        Entity e = event.getEntity();
        if (filter.accept(e)) {
            added.add(e.getName());
            configurator.uninstall(event.getEntity());
            if (oneShot && added.size() == 0) {
                u.removeDefinitionListener(this);
            }
        }
    }

    public void onMoveEntity(EntityEvent event) {
    }

}
