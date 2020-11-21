/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import net.thevpc.upa.Action;
import net.thevpc.upa.VoidAction;

/**
 *
 * @author taha.bensalah@gmail.com
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
