/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test;

import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author vpc
 */
public class UPASuiteTestConfigurationReset {

    @BeforeClass
    public static void setup() {
        PUUtils.drawBox("RESET TEST DATABASE");
        PUUtils.deleteTestPersistenceUnits();
    }

    @Test
    public void emptyTest() {
        //dummy nop test to force @BeforeClass call
    }

//    public static void main(String[] args) {
//        PUUtils.deleteTestPersistenceUnits();
//    }
}
