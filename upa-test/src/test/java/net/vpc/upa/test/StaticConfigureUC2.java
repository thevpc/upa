/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test;

import net.vpc.upa.UPA;
import net.vpc.upa.config.BoolEnum;
import net.vpc.upa.config.Config;
import net.vpc.upa.config.ConnectionConfig;
import net.vpc.upa.config.PersistenceGroupConfig;
import net.vpc.upa.config.PersistenceUnitConfig;
import net.vpc.upa.config.ScanConfig;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

/**
 *
 * @author vpc
 */
@ConnectionConfig(
        connexionString = "derby:embedded://example",
        userName = "toto",
        password = "toto"
)
@Config(
        persistenceUnits = {
            @PersistenceUnitConfig(
                    scan = {
                        @ScanConfig(types = "never.**")
                    },
                    inheritScanFilters = BoolEnum.FALSE
            )
        }
)
public class StaticConfigureUC2 {

    @Test
    public void testMe() {
        UPAImplDefaults.PRODUCTION_MODE = false;
        PUUtils.drawBox("Test");
        UPA.configure(StaticConfigureUC2.class);
        System.out.println(UPA.getPersistenceUnit());
    }
}
