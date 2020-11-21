/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.tutorial.model;

import net.thevpc.upa.config.Singleton;
import net.thevpc.upa.config.*;

/**
 * This is a Singleton Entity.
 * Singleton entities provides simple way to 'one row' tables
 * such as Configuration Tables.
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Singleton
public class Config {

    private String emailServer;
    private String emailAddress;

    public String getEmailServer() {
        return emailServer;
    }

    public void setEmailServer(String emailServer) {
        this.emailServer = emailServer;
    }

    public String getEmailAddress() {
        return emailAddress;
    }

    public void setEmailAddress(String emailAddress) {
        this.emailAddress = emailAddress;
    }

}
