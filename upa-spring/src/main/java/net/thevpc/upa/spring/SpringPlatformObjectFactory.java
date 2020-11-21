package net.thevpc.upa.spring;

import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.PlatformObjectFactory;
import org.springframework.context.ApplicationContext;

public class SpringPlatformObjectFactory implements PlatformObjectFactory {
    private static ApplicationContext globalApplicationContext;
    private ApplicationContext localApplicationContext;

    public ApplicationContext getApplicationContext() {
        if(localApplicationContext!=null){
            return localApplicationContext;
        }
        if(globalApplicationContext!=null){
            return globalApplicationContext;
        }
        throw new RuntimeException("Missing globalApplicationContext");
    }
    public static ApplicationContext getGlobalApplicationContext() {
        return globalApplicationContext;
    }

    public static void setGlobalApplicationContext(ApplicationContext globalApplicationContext) {
        SpringPlatformObjectFactory.globalApplicationContext = globalApplicationContext;
    }

    public SpringPlatformObjectFactory(ApplicationContext localApplicationContext) {
        this.localApplicationContext = localApplicationContext;
    }

    public SpringPlatformObjectFactory() {
    }

    @Override
    public <T> T createObject(Class<T> type, String name) {
        ApplicationContext ac=getApplicationContext();
        if(name!=null) {
            if (ac.containsBean(name)) {
                return (T) ac.getBean(name);
            }
        }
        String[] beanNamesForType = ac.getBeanNamesForType(type);
        if(beanNamesForType.length>0){
            return (T) ac.getBean(beanNamesForType[0]);
        }
        //how to get Application context here?
        return (T) PlatformUtils.newInstance(type);
    }
}
