package net.vpc.upa.spring.test;

import net.vpc.upa.*;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.PersistenceGroupConfig;
import net.vpc.upa.persistence.PersistenceUnitConfig;
import net.vpc.upa.persistence.UPAContextConfig;
import net.vpc.upa.spring.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.EnableTransactionManagement;
import java.util.List;

public class PersistenceUnitFactoryBeanTest {
    public static void main(String[] args) {
        LogUtils.prepare();
        AnnotationConfigApplicationContext ctx = new AnnotationConfigApplicationContext(AppConfig.class);
        Repo t = ctx.getBean(Repo.class);
        List<Category> all0 = t.findAll();

        Category c=new Category();
        c.setName("hi ");
        t.save(c);
        List all = t.findAll();
        System.out.println(all);
    }
    @Configuration
    @ComponentScan("net.vpc")
    @EnableTransactionManagement
    public static class AppConfig {

        @Bean
        public UPATransactionManager transactionManager(){
            UPATransactionManager upaTransactionManager=new UPATransactionManager();
            return  upaTransactionManager;
        }

        @Bean
        public PersistenceUnitFactoryBean getPersistenceUnitFactoryBean() {
            PersistenceUnitFactoryBean e = new PersistenceUnitFactoryBean();
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
}
