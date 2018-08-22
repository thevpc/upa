/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.conf;

import net.vpc.upa.UPA;
import net.vpc.upa.config.BoolEnum;
import net.vpc.upa.config.ConnectionConfig;
import net.vpc.upa.config.PersistenceUnitConfig;
import net.vpc.upa.config.ScanConfig;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

/**
 *
 * @author vpc
 */
@ConnectionConfig(
        connexionString = "derby:embedded://db-embedded/example",
        userName = "toto",
        password = "toto"
)
@PersistenceUnitConfig(
                    scan = {
                        @ScanConfig(types = "never.**")
                    },
                    inheritScanFilters = BoolEnum.FALSE
            )
public class StaticConfigureUC3 {

    @Test
    public void testMe() {
        PUUtils.reset();
        UPA.configure(StaticConfigureUC3.class);
        System.out.println(UPA.getPersistenceUnit());
    }
}
