/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.tutorial.feature;

import net.thevpc.upa.DefaultFieldBuilder;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Section;
import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.config.Callback;
import net.thevpc.upa.config.OnCreate;
import net.thevpc.upa.types.LongType;
import net.thevpc.upa.types.StringType;
import net.thevpc.upa.types.TimestampType;

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
