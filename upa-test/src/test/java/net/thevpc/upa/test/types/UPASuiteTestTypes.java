/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.test.types;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;

/**
 *
 * @author vpc
 */
@RunWith(Suite.class)

@Suite.SuiteClasses({
    TypesEnumUC.class,
    TypesLobUC.class,
    TypesSecretUC.class,
    TypesTemporalUC.class,
    TypesTransformerUC.class,
    TypesPasswordUC.class,
})
public class UPASuiteTestTypes {
    
}
