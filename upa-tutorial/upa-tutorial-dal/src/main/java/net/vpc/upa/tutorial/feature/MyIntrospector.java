/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.feature;

import net.vpc.upa.callbacks.DefinitionListenerAdapter;
import net.vpc.upa.callbacks.EntityDefinitionListener;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.callbacks.FieldDefinitionListener;
import net.vpc.upa.callbacks.FieldEvent;
import net.vpc.upa.config.Callback;
import net.vpc.upa.config.OnCreate;
import net.vpc.upa.config.OnDrop;

/**
 *
 * @author vpc
 */
@Callback
public class MyIntrospector extends DefinitionListenerAdapter {

    @OnCreate
    public void entityAdded(EntityEvent event) {
        // ...
    }

    @OnDrop
    public void fieldRemoved(FieldEvent event) {
        // ...
    }

}
