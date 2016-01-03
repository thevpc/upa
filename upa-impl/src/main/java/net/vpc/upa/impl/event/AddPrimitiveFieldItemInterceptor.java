package net.vpc.upa.impl.event;

import net.vpc.upa.CompoundField;
import net.vpc.upa.EntityPart;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.Section;
import net.vpc.upa.impl.DefaultCompoundField;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

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
        EntityPart oldParent = child.getParent();
        if (oldParent != null && oldParent != defaultCompoundField) {
            if (oldParent instanceof Section) {
                Section x = (Section) oldParent;
                x.removePartAt(x.indexOfPart(child));
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
