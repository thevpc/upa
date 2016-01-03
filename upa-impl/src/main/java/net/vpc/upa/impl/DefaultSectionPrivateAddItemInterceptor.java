package net.vpc.upa.impl;

import net.vpc.upa.EntityPart;
import net.vpc.upa.Section;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 2:27 PM
*/
class DefaultSectionPrivateAddItemInterceptor implements ItemInterceptor<EntityPart> {
    private DefaultSection defaultSection;

    public DefaultSectionPrivateAddItemInterceptor(DefaultSection defaultSection) {
        this.defaultSection = defaultSection;
    }

    @Override
    public void before(EntityPart child, int index) {
        EntityPart oldParent = child.getParent();
        if (oldParent != null && oldParent != defaultSection) {
            if (oldParent instanceof Section) {
                Section x = (Section) oldParent;
                x.removePartAt(x.indexOfPart(child));
            }
        }
        DefaultBeanAdapter adapter = new DefaultBeanAdapter(child);
        if (oldParent != defaultSection) {
            adapter.setProperty("parent", defaultSection);
        }
        adapter.setProperty("entity", defaultSection.getEntity());
    }

    @Override
    public void after(EntityPart entityItem, int index) {
    }
}
