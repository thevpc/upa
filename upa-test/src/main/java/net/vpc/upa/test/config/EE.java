/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.config;

import net.vpc.upa.UPA;
import net.vpc.upa.config.ConnectionConfig;

/**
 *
 * @author vpc
 */
@ConnectionConfig(
        connexionString = "derby:embedded://example",
        userName = "toto",
        password = "toto"
)
public class EE {

    public static void main(String[] args) {
        UPA.configure(EE.class);
        System.out.println(UPA.getPersistenceUnit());
    }
}
