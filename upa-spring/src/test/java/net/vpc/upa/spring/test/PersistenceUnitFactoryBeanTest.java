package net.vpc.upa.spring.test;

import net.vpc.upa.*;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.PersistenceGroupConfig;
import net.vpc.upa.persistence.PersistenceUnitConfig;
import net.vpc.upa.persistence.UPAContextConfig;
import net.vpc.upa.spring.PersistenceUnitFactoryBean;
import net.vpc.upa.spring.SpringPersistenceGroupProvider;
import net.vpc.upa.spring.SpringPersistenceUnitProvider;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.stereotype.Repository;

@Repository
public class PersistenceUnitFactoryBeanTest {

    @Autowired
    PersistenceUnit pu;

    public static void main(String[] args) {
        LogUtils.prepare();
        AnnotationConfigApplicationContext ctx = new AnnotationConfigApplicationContext(AppConfig.class);
        PersistenceUnitFactoryBeanTest t = ctx.getBean(PersistenceUnitFactoryBeanTest.class);
        t.run();
    }

    private void run() {
        System.out.println(pu.getName());
    }

    @Configuration
    @ComponentScan("net.vpc")
    public static class AppConfig {

        @Bean
        public PersistenceGroupProvider getPersistenceGroupProvider() {
            return new SpringPersistenceGroupProvider();
        }

        @Bean
        public PersistenceUnitProvider getPersistenceUnitProvider() {
            return new SpringPersistenceUnitProvider();
        }

        @Bean
        public PersistenceUnitFactoryBean getPersistenceUnitFactoryBean() {
            PersistenceUnitFactoryBean e = new PersistenceUnitFactoryBean();
            e.setConfig(new UPAContextConfig()
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
            e.setPersistenceGroupProvider(getPersistenceGroupProvider());
            e.setPersistenceUnitProvider(getPersistenceUnitProvider());
            return e;
        }
    }
}
