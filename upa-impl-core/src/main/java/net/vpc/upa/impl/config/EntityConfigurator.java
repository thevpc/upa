/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.Entity;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface EntityConfigurator {
    void install(Entity e);
    void uninstall(Entity e);
}
