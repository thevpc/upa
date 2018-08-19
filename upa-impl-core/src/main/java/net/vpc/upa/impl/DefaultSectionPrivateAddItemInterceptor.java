package net.vpc.upa.impl;

import net.vpc.upa.Section;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;
import net.vpc.upa.EntityItem;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 2:27 PM
 */
class DefaultSectionPrivateAddItemInterceptor implements ItemInterceptor<EntityItem> {

    private DefaultSection defaultSection;

    public DefaultSectionPrivateAddItemInterceptor(DefaultSection defaultSection) {
        this.defaultSection = defaultSection;
    }

    @Override
    public void before(EntityItem child, int index) {
        EntityItem oldParent = child.getParent();
//        ((DefaultEntity) defaultSection.getEntity()).beforePartAdded(defaultSection, child, index);
        if (oldParent != null && oldParent != defaultSection) {
            if (oldParent instanceof Section) {
                Section x = (Section) oldParent;
                x.removeItemAt(x.indexOfItem(child));
            }
        }
        DefaultBeanAdapter adapter = new DefaultBeanAdapter(child);
        if (oldParent != defaultSection) {
            adapter.setProperty("parent", defaultSection);
        }
        adapter.setProperty("entity", defaultSection.getEntity());
    }

    @Override
    public void after(EntityItem entityItem, int index) {
//        ((DefaultEntity) defaultSection.getEntity()).afterPartAdded(defaultSection, entityItem, index);
    }
}
