/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.Entity;
import net.vpc.upa.EntitySecurityManager;

/**
 *
 * @author vpc
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
