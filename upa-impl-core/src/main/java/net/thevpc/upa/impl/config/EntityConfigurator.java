/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import net.thevpc.upa.Entity;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface EntityConfigurator {
    void install(Entity e);
    void uninstall(Entity e);
}
