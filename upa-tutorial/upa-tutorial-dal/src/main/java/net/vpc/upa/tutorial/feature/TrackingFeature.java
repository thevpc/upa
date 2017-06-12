/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.feature;

import net.vpc.upa.DefaultFieldBuilder;
import net.vpc.upa.Entity;
import net.vpc.upa.Section;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.config.Callback;
import net.vpc.upa.config.OnCreate;
import net.vpc.upa.types.LongType;
import net.vpc.upa.types.StringType;
import net.vpc.upa.types.TimestampType;

/**
 * Simple Trace Callback that will add automatically fields
 * creationDate,creationUser,modificationDate,modificationUser
 * and revision
 * to all declared Entities
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Callback
public class TrackingFeature {

    @OnCreate
    public void entityAdded(EntityEvent event) {
        Entity entity = event.getEntity();
        Section tracking = entity.addSection("Tracking");

        tracking.addField(new DefaultFieldBuilder().setName("creationDate").setDataType(TimestampType.DEFAULT).setPersistFormula("currentTimestamp()"));
        tracking.addField(new DefaultFieldBuilder().setName("creationUser").setDataType(StringType.DEFAULT).setPersistFormula("currentUser()"));

        tracking.addField(new DefaultFieldBuilder().setName("modificationDate").setDataType(TimestampType.DEFAULT).setFormula("currentTimestamp()"));
        tracking.addField(new DefaultFieldBuilder().setName("modificationUser").setDataType(StringType.DEFAULT).setFormula("currentUser()"));

        tracking.addField(new DefaultFieldBuilder().setName("revision").setDefaultObject(0L).setDataType(LongType.DEFAULT).setUpdateFormula("revision+1"));
    }
}
