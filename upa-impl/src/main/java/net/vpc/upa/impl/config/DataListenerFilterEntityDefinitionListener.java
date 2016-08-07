///*
// * To change this template, choose Tools | Templates
// * and open the template in the editor.
// */
//package net.vpc.upa.impl.config;
//
//import net.vpc.upa.Entity;
//import net.vpc.upa.callback.EntityListener;
//import net.vpc.upa.callback.EntityDefinitionEvent;
//import net.vpc.upa.callback.EntityDefinitionListener;
//
///**
// *
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// */
//public class DataListenerFilterEntityDefinitionListener implements EntityDefinitionListener {
//
//    private EntityListener dataListener;
//    private String callbackFilter;
//
//    public DataListenerFilterEntityDefinitionListener(EntityListener dataInterceptor, String callbackFilter) {
//        this.dataListener = dataInterceptor;
//        this.callbackFilter = callbackFilter;
//    }
//
//    public void onCreateEntity(EntityDefinitionEvent event) {
//        if (event.isAfter()) {
//            Entity e = event.getEntity();
//            if (accept(e)) {
//                e.addEntityListener(dataListener);
//            }
//        }
//    }
//
//    public void onRemoveEntity(EntityDefinitionEvent event) {
//        if (event.isAfter()) {
//            Entity e = event.getEntity();
//            if (accept(e)) {
//                e.removeEntityListener(dataListener);
//            }
//        }
//    }
//
//    public void onMoveEntity(EntityDefinitionEvent event) {
//    }
//
//    private boolean accept(Entity e) {
//        String entityFilter = callbackFilter;
//        if (entityFilter == null || entityFilter.length() == 0) {
//            return true;
//        }
//        return entityFilter.matches(e.getName());
//    }
//}
