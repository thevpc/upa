package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanType;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by vpc on 6/11/16.
 */
public class PlatformBeanTypeRepository {
    private static PlatformBeanTypeRepository instance=new PlatformBeanTypeRepository();
    private final Map<Class,PlatformBeanType> classBeanTypeReflectorMap=new HashMap<Class, PlatformBeanType>();
    public static PlatformBeanTypeRepository getInstance() {
        return instance;
    }
    public PlatformBeanType getBeanType(Class cls){
        PlatformBeanType platformBeanType = classBeanTypeReflectorMap.get(cls);
        if(platformBeanType ==null){
            synchronized (classBeanTypeReflectorMap){
                platformBeanType = classBeanTypeReflectorMap.get(cls);
                if(platformBeanType ==null){
                    platformBeanType =new DefaultPlatformBeanType(cls);
                    classBeanTypeReflectorMap.put(cls, platformBeanType);
                }
            }
        }
        return platformBeanType;
    }

}
