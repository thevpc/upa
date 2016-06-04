package net.vpc.upa.impl.util;

import java.lang.reflect.InvocationTargetException;

/**
 * Created by vpc on 5/17/16.
 */
public class PlatformLenientType implements LenientType{
    private String typeName;
    private Class type;

    public PlatformLenientType(String typeName) {
        this.typeName = typeName;
    }

    public boolean isValid(){
        return getValidType()!=null;
    }

    public Class getValidTypeOrError(){
        Class c=getValidType();
        if(c==null){
            throw new RuntimeException("Invalid Type");
        }
        return c;
    }

    public Class getValidType(){
        if(type==null){
            try {
                type=Class.forName(typeName);
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
                type=Void.TYPE;
            }
        }
        if(Void.TYPE.equals(type)){
            return null;
        }
        return type;
    }

    public Object newInstance(){
        try {
            return getValidTypeOrError().newInstance();
        } catch (InstantiationException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        } catch (IllegalAccessException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        }
    }

    public Object invokeInstance(Object instance,String method,Class[] types,Object[] args){
        try {
            return getValidTypeOrError().getMethod(method, types).invoke(instance, args);
        } catch (NoSuchMethodException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        } catch (IllegalAccessException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        } catch (InvocationTargetException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        }
    }

    public Object invokeStatic(String method,Class[] types,Object[] args){
        try {
            return getValidTypeOrError().getMethod(method,types).invoke(null,args);
        } catch (NoSuchMethodException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        } catch (IllegalAccessException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        } catch (InvocationTargetException e) {
            Throwable c = e.getCause();
            if(c instanceof RuntimeException){
                throw (RuntimeException) c;
            }
            throw new RuntimeException(c);
        }
    }
}
