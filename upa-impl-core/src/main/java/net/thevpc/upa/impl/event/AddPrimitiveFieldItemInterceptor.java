package net.thevpc.upa.impl.event;

import net.thevpc.upa.CompoundField;
import net.thevpc.upa.PrimitiveField;
import net.thevpc.upa.Section;
import net.thevpc.upa.impl.DefaultCompoundField;
import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.impl.util.ItemInterceptor;
import net.thevpc.upa.EntityItem;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/4/13 12:17 AM
*/
public class AddPrimitiveFieldItemInterceptor implements ItemInterceptor<PrimitiveField> {
    private DefaultCompoundField defaultCompoundField;

    public AddPrimitiveFieldItemInterceptor(DefaultCompoundField defaultCompoundField) {
        this.defaultCompoundField = defaultCompoundField;
    }

    @Override
    public void before(PrimitiveField primitiveField, int index) {
    }

    @Override
    public void after(PrimitiveField child, int index) {
        EntityItem oldParent = child.getParent();
        if (oldParent != null && oldParent != defaultCompoundField) {
            if (oldParent instanceof Section) {
                Section x = (Section) oldParent;
                x.removeItemAt(x.indexOfItem(child));
            } else if (oldParent instanceof CompoundField) {
                CompoundField x = (CompoundField) oldParent;
                ((DefaultCompoundField)x).dropFieldAt(x.indexOfField(child));
            }
        }
        if (oldParent != defaultCompoundField) {
            DefaultBeanAdapter adapter=new DefaultBeanAdapter(child);
            adapter.setProperty("parent", defaultCompoundField);
        }
    }
}
