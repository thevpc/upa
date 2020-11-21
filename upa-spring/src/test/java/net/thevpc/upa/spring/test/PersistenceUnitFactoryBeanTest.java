package net.thevpc.upa.spring.test;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.spring.SpringUPAConfig;
import net.thevpc.upa.spring.*;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;

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
    @ComponentScan("net.thevpc")
    public static class AppConfig extends SpringUPAConfig {

    }
}
