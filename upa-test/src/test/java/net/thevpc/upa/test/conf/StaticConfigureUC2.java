/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.test.conf;

import net.thevpc.upa.test.util.PUUtils;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.BoolEnum;
import net.thevpc.upa.config.Config;
import net.thevpc.upa.config.ConnectionConfig;
import net.thevpc.upa.config.PersistenceUnitConfig;
import net.thevpc.upa.config.ScanConfig;
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
        PUUtils.reset();
        UPA.configure(StaticConfigureUC2.class);
        System.out.println(UPA.getPersistenceUnit());
    }
}
