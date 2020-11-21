package net.thevpc.upa.spring;

import net.thevpc.upa.config.ScanFilter;
import net.thevpc.upa.persistence.ConnectionConfig;
import net.thevpc.upa.persistence.PersistenceGroupConfig;
import net.thevpc.upa.persistence.PersistenceUnitConfig;
import net.thevpc.upa.persistence.UPAContextConfig;
import org.springframework.context.annotation.Bean;
import org.springframework.transaction.PlatformTransactionManager;
import org.springframework.transaction.annotation.EnableTransactionManagement;

@EnableTransactionManagement
public abstract class SpringUPAConfig {

    @Bean
    public PlatformTransactionManager transactionManager(){
        return new SpringUPATransactionManager();
    }

    /**
     * <pre>
     *   SpringUPAPersistenceUnitFactoryBean e = new SpringUPAPersistenceUnitFactoryBean();
     *   e.setConfig(new UPAContextConfig()
     *        .addFilter(new ScanFilter().setLibs("**").setTypes("**"))
     *        .addPersistenceGroups(
     *             new PersistenceGroupConfig("example")
     *                  .addPersistenceUnit(
     *                       new PersistenceUnitConfig("myCnx")
     *                            .addConnectionConfig(
     *                                 new ConnectionConfig()
     *                                      .setConnectionString("derby:embedded://mydb;structure=create;userName=me;password=metoo")
     *   ))));
     *
     * </pre>
     * @return
     */
    @Bean
    public SpringUPAPersistenceUnitFactoryBean getPersistenceUnitFactoryBean() {
        SpringUPAPersistenceUnitFactoryBean e = new SpringUPAPersistenceUnitFactoryBean();
        e.setConfig(new UPAContextConfig()
                .addFilter(new ScanFilter().setLibs("**").setTypes("**"))
                .addPersistenceGroups(
                        new PersistenceGroupConfig("example")
                                .addPersistenceUnit(
                                        new PersistenceUnitConfig("myCnx")
                                                .addConnectionConfig(
                                                        new ConnectionConfig()
                                                                .setConnectionString("derby:embedded://mydb;structure=create;userName=me;password=metoo")
                                                )
                                )
                ));
        return e;
    }
}
