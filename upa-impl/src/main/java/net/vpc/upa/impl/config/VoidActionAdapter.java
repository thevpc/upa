/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.Action;
import net.vpc.upa.VoidAction;

/**
 *
 * @author vpc
 */
public class VoidActionAdapter implements Action<Object>{
    private VoidAction action;

    public VoidActionAdapter(VoidAction action) {
        this.action = action;
    }

    @Override
    public Object run() {
        action.run();
        return null;
    }
    
}
