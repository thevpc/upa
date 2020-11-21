package net.thevpc.upa.impl;

import net.thevpc.upa.impl.ext.EntityExt;
import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.impl.util.ItemInterceptor;
import net.thevpc.upa.CompoundField;
import net.thevpc.upa.PrimitiveField;
import net.thevpc.upa.Section;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.EntityItem;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 2:25 PM
*/
class DefaultEntityPrivateAddItemInterceptor implements ItemInterceptor<EntityItem> {
    private EntityExt defaultEntity;

    public DefaultEntityPrivateAddItemInterceptor(EntityExt defaultEntity) {
        this.defaultEntity = defaultEntity;
    }

    @Override
    public void before(EntityItem item, int index) {
        EntityItem oldParent = item.getParent();
        if (oldParent != null) {
            if (!(oldParent instanceof Section) && !(oldParent instanceof CompoundField)) {
                throw new IllegalUPAArgumentException(
                        "Field Parent is neither a Field Section nor a Field");
            }
        }

        defaultEntity.beforeItemAdded(null, item, index);
        if (oldParent != null) {
            if (oldParent instanceof Section) {
                Section x = (Section) oldParent;
                x.removeItemAt(x.indexOfItem(item));
            } else if (oldParent instanceof CompoundField) {
                CompoundField x = (CompoundField) oldParent;
                ((DefaultCompoundField)x).dropFieldAt(x.indexOfField((PrimitiveField) item));
                //
            }
        }

        DefaultBeanAdapter a = new DefaultBeanAdapter(item);
        if (oldParent != null) {
            a.injectNull("parent");
        }
        a.setProperty("entity", defaultEntity);
    }

    @Override
    public void after(EntityItem item, int index) {
        defaultEntity.afterItemAdded(null, item, index);
    }
}
