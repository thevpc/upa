/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.feature;

import net.vpc.upa.events.EntityEvent;
import net.vpc.upa.events.FieldEvent;
import net.vpc.upa.config.Callback;
import net.vpc.upa.config.OnCreate;
import net.vpc.upa.config.OnDrop;

/**
 * This is a Simple model changed listener
 * @author taha.bensalah@gmail.com
 */
@Callback
public class MyIntrospector {

    @OnCreate
    public void entityAdded(EntityEvent event) {
        // ...
    }

    @OnDrop
    public void fieldRemoved(FieldEvent event) {
        // ...
    }

}
