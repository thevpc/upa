/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import net.thevpc.upa.Entity;
import net.thevpc.upa.EntitySecurityManager;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class SecurityManagerEntityConfigurator implements EntityConfigurator {

    private EntitySecurityManager s;

    public SecurityManagerEntityConfigurator(EntitySecurityManager s) {
        this.s = s;
    }

    public void install(Entity e) {
        e.setEntitySecurityManager(s);
    }

    public void uninstall(Entity e) {
    }

}
