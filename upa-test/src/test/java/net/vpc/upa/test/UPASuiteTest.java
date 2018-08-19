/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test;

import net.vpc.upa.test.conf.UPASuiteTestConf;
import net.vpc.upa.test.context.UPASuiteTestContext;
import net.vpc.upa.test.crud.UPASuiteTestCrud;
import net.vpc.upa.test.entitypatterns.UPASuiteTestPattern;
import net.vpc.upa.test.formulas.UPASuiteTestFormula;
import net.vpc.upa.test.importexport.UPASuiteTestImportExport;
import net.vpc.upa.test.listeners.UPASuiteTestListeners;
import net.vpc.upa.test.perf.UPASuiteTestPerf;
import net.vpc.upa.test.relations.UPASuiteTestRelations;
import net.vpc.upa.test.structure.UPASuiteTestStructure;
import net.vpc.upa.test.syntax.UPASuiteTestSyntax;
import net.vpc.upa.test.types.UPASuiteTestTypes;
import org.junit.runner.RunWith;
import org.junit.runners.Suite;

/**
 *
 * @author vpc
 */
@RunWith(Suite.class)

@Suite.SuiteClasses({
   UPASuiteTestConfigurationReset.class,
   UPASuiteTestCrud.class,
   UPASuiteTestStructure.class,
   UPASuiteTestContext.class,
    UPASuiteTestConf.class,
    UPASuiteTestFormula.class,
    UPASuiteTestImportExport.class,
    UPASuiteTestListeners.class,
    UPASuiteTestRelations.class,
    UPASuiteTestPattern.class,
    UPASuiteTestSyntax.class,
    UPASuiteTestTypes.class,
    UPASuiteTestPerf.class,
})
public class UPASuiteTest {
    
}
