/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.NativeTransientPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultTransientDefinition implements NativeTransientPersistenceDefinition {
    public static DefaultTransientDefinition INSTANCE=new DefaultTransientDefinition();
    private DefaultTransientDefinition(){
        
    }
}
