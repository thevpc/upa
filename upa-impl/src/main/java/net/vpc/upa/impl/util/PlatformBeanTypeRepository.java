package net.vpc.upa.impl.util;

import net.vpc.upa.BeanType;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by vpc on 6/11/16.
 */
public class PlatformBeanTypeRepository {
    private static PlatformBeanTypeRepository instance=new PlatformBeanTypeRepository();
    private final Map<Class,BeanType> classBeanTypeReflectorMap=new HashMap<Class, BeanType>();
    public static PlatformBeanTypeRepository getInstance() {
        return instance;
    }
    public BeanType getBeanType(Class cls){
        BeanType beanType = classBeanTypeReflectorMap.get(cls);
        if(beanType ==null){
            synchronized (classBeanTypeReflectorMap){
                beanType = classBeanTypeReflectorMap.get(cls);
                if(beanType ==null){
                    beanType =new DefaultBeanType(cls);
                    classBeanTypeReflectorMap.put(cls, beanType);
                }
            }
        }
        return beanType;
    }

}
