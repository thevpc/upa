package net.vpc.upa.impl.util;

import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.Relationship;

class BeanForDocumentPlatformMethodProxy implements PlatformMethodProxy {
    private final Document document;
    private final Entity entity;

    public BeanForDocumentPlatformMethodProxy(Document document, Entity entity) {
        this.document = document;
        this.entity = entity;
    }

    @Override
    public Object intercept(PlatformMethodProxyEvent event) throws Throwable {
        String methodName = event.getMethodName();
        if (methodName.equals("$document")) {
            return document;
        }
        int length = methodName.length();
        Object object = event.getObject();
        if (length > 2) {
            Object[] args = event.getArguments();
            if (args.length==0 && methodName.startsWith(PlatformUtils.METHOD_IS_PREFIX) && Character.isUpperCase(methodName.charAt(2))) {
                String n = PlatformUtils.adjustVarFirstChar(methodName.substring(2));
                return document.get(n);
            }
            if (length > 3) {
                if (args.length==0 && methodName.startsWith(PlatformUtils.METHOD_GET_PREFIX) && Character.isUpperCase(methodName.charAt(3))) {
                    String n = PlatformUtils.adjustVarFirstChar(methodName.substring(3));
                    Object o = document.get(n);
                    if(o instanceof Document){
                        if(o == document){
                            //do nothing
                            o=object;
                        }else {
                            if(entity!=null) {
                                net.vpc.upa.Field f = entity.findField(n);
                                Relationship manyToOneRelationship = f.getManyToOneRelationship();
                                if (manyToOneRelationship != null) {
                                    Entity oe = manyToOneRelationship.getTargetEntity();
                                    o = oe.getBuilder().documentToObject((Document) o);
                                }
                            }
                        }
                    }
                    return o;
                }
                if (args.length==1 && methodName.startsWith(PlatformUtils.METHOD_SET_PREFIX) && Character.isUpperCase(methodName.charAt(3))) {
                    String n = PlatformUtils.adjustVarFirstChar(methodName.substring(3));
                    document.set(n, args[0]);
//                                    if(true){
                        return event.invokeSuper(object,event.getArguments());
//                                    }
//                                    Class<?> r = event.getMethod().getReturnType();
//                                    if(r.equals(Void.class) || r.equals(Void.TYPE)){
//                                        return null;
//                                    }
//                                    if(r.isAssignableFrom(type)){
//                                        return object;
//                                    }
//                                    throw new IllegalUPAArgumentException("Unsupported");
                }
            }
        }
        return event.invokeSuper(object,event.getArguments());
    }
}
