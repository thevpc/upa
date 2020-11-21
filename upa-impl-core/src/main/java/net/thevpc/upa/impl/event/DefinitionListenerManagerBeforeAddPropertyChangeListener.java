//package net.thevpc.upa.impl;
//
//import net.thevpc.upa.EventPhase;
//import net.thevpc.upa.UPAObject;
//import net.thevpc.upa.impl.event.PersistenceUnitListenerManager;
//
//import java.beans.PropertyChangeEvent;
//import java.beans.PropertyChangeListener;
//
///**
//* @author Taha BEN SALAH <taha.bensalah@gmail.com>
//* @creationdate 1/7/13 2:39 PM
//*/
//class DefinitionListenerManagerBeforeAddPropertyChangeListener implements PropertyChangeListener {
//    private PersistenceUnitListenerManager persistenceUnitListenerManager;
//
//    public DefinitionListenerManagerBeforeAddPropertyChangeListener(PersistenceUnitListenerManager persistenceUnitListenerManager) {
//        this.persistenceUnitListenerManager = persistenceUnitListenerManager;
//    }
//
//    @Override
//    public void propertyChange(PropertyChangeEvent evt) {
//        Object[] newValue = (Object[]) evt.getNewValue();
//        UPAObject o = (UPAObject) newValue[0];
//        UPAObject parent = (UPAObject) newValue[2];
//        persistenceUnitListenerManager.itemAdded(o, (Integer) newValue[1], parent, EventPhase.BEFORE);
//    }
//}
