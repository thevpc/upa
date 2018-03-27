package net.vpc.upa.spring.test;

import net.vpc.upa.*;
import net.vpc.upa.persistence.ConnectionConfig;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.stereotype.Repository;

@Repository
public class PersistenceUnitFactoryBeanTest {

    @Autowired PersistenceUnit pu;

    public static void main(String[] args) {
        AnnotationConfigApplicationContext ctx = new AnnotationConfigApplicationContext(AppConfig.class);
        PersistenceUnitFactoryBeanTest t = ctx.getBean(PersistenceUnitFactoryBeanTest.class);
        t.run();
    }

    private void run() {
        System.out.println(pu.getName());
    }

    @Configuration
    @ComponentScan("net.vpc")
    public static class AppConfig{

        @Bean
        public PersistenceGroupProvider getPersistenceGroupProvider(){
            return new SpringPersistenceGroupProvider();
        }

        @Bean
        public PersistenceUnitProvider getPersistenceUnitProvider(){
            return new SpringPersistenceUnitProvider();
        }

        @Bean
        public PersistenceUnitFactoryBean getPersistenceUnitFactoryBean(){
            PersistenceUnitFactoryBean e = new PersistenceUnitFactoryBean();
            e.setPersistenceGroupName("example");
            e.setPersistenceUnitName("myCnx");
            ConnectionConfig connectionConfig = new ConnectionConfig();
            connectionConfig.setConnectionString("derby:embedded://mydb?structure=create;username=me;password=metoo");
            e.setConnectionConfig(connectionConfig);
            e.setPersistenceGroupProvider(getPersistenceGroupProvider());
            e.setPersistenceUnitProvider(getPersistenceUnitProvider());
            return e;
        }
    }
}
