package net.vpc.upa.impl;

import net.vpc.upa.CompoundField;
import net.vpc.upa.EntityPart;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.Section;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 2:25 PM
*/
class DefaultEntityPrivateAddItemInterceptor implements ItemInterceptor<EntityPart> {
    private EntityExt defaultEntity;

    public DefaultEntityPrivateAddItemInterceptor(EntityExt defaultEntity) {
        this.defaultEntity = defaultEntity;
    }

    @Override
    public void before(EntityPart item, int index) {
        EntityPart oldParent = item.getParent();
        if (oldParent != null) {
            if (!(oldParent instanceof Section) && !(oldParent instanceof CompoundField)) {
                throw new UPAIllegalArgumentException(
                        "Field Parent is neither a Field Section nor a Field");
            }
        }

        defaultEntity.beforePartAdded(null, item, index);
        if (oldParent != null) {
            if (oldParent instanceof Section) {
                Section x = (Section) oldParent;
                x.removePartAt(x.indexOfPart(item));
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
    public void after(EntityPart item, int index) {
        defaultEntity.afterPartAdded(null, item, index);
    }
}
