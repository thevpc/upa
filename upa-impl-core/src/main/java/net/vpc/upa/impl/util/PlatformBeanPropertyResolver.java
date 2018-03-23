package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanProperty;
import net.vpc.upa.PropertyAccessType;

import java.lang.reflect.Field;
import java.lang.reflect.Method;

public class PlatformBeanPropertyResolver {
    public String property;
    public Class propertyType;

    public Field field;
    public Method getter;
    public Method setter;

    public PlatformBeanProperty mprop;
    public PlatformBeanProperty fprop;

    public PlatformBeanPropertyResolver(String property) {
        this.property = property;
    }

    public PlatformBeanProperty getPlatformBeanProperty(PropertyAccessType propertyAccessType){
        switch (propertyAccessType){
            case FIELD:{
                if(fprop==null){
                    fprop=new DefaultPlatformBeanProperty(property,propertyType,
                            field!=null?new PlatformBeanPropertyGetterByField(field):null,
                            field!=null && !PlatformUtils.isFinal(field)?new PlatformBeanPropertySetterByField(field):null
                            );
                }
                return fprop;
            }
            default:
                {
                if(mprop==null){
                    mprop=new DefaultPlatformBeanProperty(property,propertyType,
                            getter != null? new PlatformBeanPropertyGetterByMethod(getter) : field!=null? new PlatformBeanPropertyGetterByField(field):null,
                            setter != null? new PlatformBeanPropertySetterByMethod(setter) : field!=null? new PlatformBeanPropertySetterByField(field):null
                            );
                }
                return mprop;
            }
        }
    }
}
