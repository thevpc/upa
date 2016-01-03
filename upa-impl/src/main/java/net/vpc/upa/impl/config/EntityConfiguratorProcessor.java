/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.callbacks.DefinitionListenerAdapter;
import net.vpc.upa.callbacks.EntityDefinitionListener;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.filters.EntityFilter;

import java.util.HashSet;
import java.util.List;

/**
 * @author vpc
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
