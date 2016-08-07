//package net.vpc.upa.impl;
//
//import net.vpc.upa.EventPhase;
//import net.vpc.upa.UPAObject;
//import net.vpc.upa.impl.event.PersistenceUnitListenerManager;
//
//import java.beans.PropertyChangeEvent;
//import java.beans.PropertyChangeListener;
//
///**
//* @author Taha BEN SALAH <taha.bensalah@gmail.com>
//* @creationdate 1/7/13 2:38 PM
//*/
//class DefinitionListenerManagerAfterMovePropertyChangeListener implements PropertyChangeListener {
//    private PersistenceUnitListenerManager persistenceUnitListenerManager;
//
//    public DefinitionListenerManagerAfterMovePropertyChangeListener(PersistenceUnitListenerManager persistenceUnitListenerManager) {
//        this.persistenceUnitListenerManager = persistenceUnitListenerManager;
//    }
//
//    @Override
//    public void propertyChange(PropertyChangeEvent evt) {
//        Object[] newValue = (Object[]) evt.getNewValue();
//        UPAObject o = (UPAObject) newValue[0];
//        persistenceUnitListenerManager.itemMoved(o, (Integer) newValue[1], (Integer) newValue[2], EventPhase.AFTER);
//    }
//}
