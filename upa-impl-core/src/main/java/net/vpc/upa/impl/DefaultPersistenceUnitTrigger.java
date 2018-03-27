//package net.vpc.upa.impl;
//
//import net.vpc.upa.callback.PersistenceUnitInterceptor;
//import net.vpc.upa.callback.PersistenceUnitTrigger;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 9/9/12 4:33 PM
// */
//public class DefaultPersistenceUnitTrigger extends AbstractUPAObject implements PersistenceUnitTrigger {
//    private PersistenceUnitInterceptor interceptor;
//    public DefaultPersistenceUnitTrigger() {
//    }
//
//    @Override
//    public PersistenceUnitInterceptor getInterceptor() {
//        return interceptor;
//    }
//
//    public void setInterceptor(PersistenceUnitInterceptor interceptor) {
//        this.interceptor = interceptor;
//    }
//
//    @Override
//    public String getAbsoluteName() {
//        return getName();
//    }
//}
