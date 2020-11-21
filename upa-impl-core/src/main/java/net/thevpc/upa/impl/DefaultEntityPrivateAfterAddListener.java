//package net.thevpc.upa.impl;
//
//import net.thevpc.upa.EntityPart;
//import net.thevpc.upa.Section;
//
//import java.beans.PropertyChangeEvent;
//import java.beans.PropertyChangeListener;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 1/4/13 12:05 AM
// */
//public class DefaultEntityPrivateAfterAddListener implements PropertyChangeListener {
//    private DefaultEntity e;
//
//    public DefaultEntityPrivateAfterAddListener(DefaultEntity e) {
//        this.e = e;
//    }
//
//    @Override
//    public void propertyChange(PropertyChangeEvent evt) {
//        Section section = (Section) evt.getSource();
//        Object[] val = (Object[]) evt.getNewValue();
//        e.afterPartAdded(section, (EntityPart) val[0], (Integer) val[1]);
//    }
//
//}
