/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.Entity;
import net.thevpc.upa.EntityUsage;
import net.thevpc.upa.Relationship;

/**
 *
 * @author vpc
 */
public class DefaultEntityUsage implements EntityUsage {
    private final Entity usageEntity;
    private final Object usageId;
    private final Relationship usageContext;

    public DefaultEntityUsage(Entity usageEntity, Object usageId, Relationship usageContext) {
        this.usageEntity = usageEntity;
        this.usageId = usageId;
        this.usageContext = usageContext;
    }

    public Entity getUsageEntity() {
        return usageEntity;
    }

    public Object getUsageId() {
        return usageId;
    }

    public Relationship getUsageContext() {
        return usageContext;
    }
    
}
