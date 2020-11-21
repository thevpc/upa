/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.test;

import net.thevpc.upa.test.conf.UPASuiteTestConf;
import net.thevpc.upa.test.context.UPASuiteTestContext;
import net.thevpc.upa.test.crud.UPASuiteTestCrud;
import net.thevpc.upa.test.entitypatterns.UPASuiteTestPattern;
import net.thevpc.upa.test.formulas.UPASuiteTestFormula;
import net.thevpc.upa.test.importexport.UPASuiteTestImportExport;
import net.thevpc.upa.test.listeners.UPASuiteTestListeners;
import net.thevpc.upa.test.perf.UPASuiteTestPerf;
import net.thevpc.upa.test.relations.UPASuiteTestRelations;
import net.thevpc.upa.test.runtime.UPASuiteTestRuntime;
import net.thevpc.upa.test.structure.UPASuiteTestStructure;
import net.thevpc.upa.test.syntax.UPASuiteTestSyntax;
import net.thevpc.upa.test.types.UPASuiteTestTypes;
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
    UPASuiteTestRuntime.class,
    UPASuiteTestPerf.class,
})
public class UPASuiteTest {
    
}
