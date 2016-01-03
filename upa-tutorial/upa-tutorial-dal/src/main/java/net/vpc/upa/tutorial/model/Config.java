/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.model;

import net.vpc.upa.FieldModifier;

import net.vpc.upa.config.*;

/**
 *
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
