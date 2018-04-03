package net.vpc.upa.spring.test;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPA;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.PersistenceGroupConfig;
import net.vpc.upa.persistence.PersistenceUnitConfig;
import net.vpc.upa.persistence.UPAContextConfig;
import net.vpc.upa.spring.*;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.transaction.PlatformTransactionManager;
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
        PersistenceUnit pu = UPA.getPersistenceUnit();
    }

    @Configuration
    @ComponentScan("net.vpc")
    public static class AppConfig extends SpringUPAConfig{

    }
}
