/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.tutorial.feature;

import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.events.FieldEvent;
import net.thevpc.upa.config.Callback;
import net.thevpc.upa.config.OnCreate;
import net.thevpc.upa.config.OnDrop;

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
