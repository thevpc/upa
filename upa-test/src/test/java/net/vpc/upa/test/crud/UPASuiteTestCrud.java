/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.crud;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;

/**
 *
 * @author vpc
 */
@RunWith(Suite.class)

@Suite.SuiteClasses({
   CrudUC.class,
   CrudUC2.class,
   CrudSelectUC.class,
   CrudUnstructuredUC.class,
   CrudUserInClientUC.class,
})
public class UPASuiteTestCrud {
    
}
