//package net.vpc.upa.impl;
//
//import net.vpc.upa.EntityPart;
//import net.vpc.upa.Section;
//
//import java.beans.PropertyChangeEvent;
//import java.beans.PropertyChangeListener;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 1/4/13 12:05 AM
// */
//public class DefaultEntityPrivateBeforeAddListener implements PropertyChangeListener{
//        private DefaultEntity e;
//
//    public DefaultEntityPrivateBeforeAddListener(DefaultEntity e) {
//        this.e = e;
//    }
//
//    @Override
//        public void propertyChange(PropertyChangeEvent evt) {
//            Section section = (Section) evt.getSource();
//            Object[] val = (Object[]) evt.getNewValue();
//            e.beforePartAdded(section, (EntityPart) val[0], (Integer) val[1]);
//        }
//
//}
