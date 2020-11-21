package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.DefaultBeanAdapter;
import net.thevpc.upa.impl.util.ItemInterceptor;
import net.thevpc.upa.PrimitiveField;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/4/13 12:18 AM
*/
class DropPrimitiveFieldItemInterceptor implements ItemInterceptor<PrimitiveField> {
    @Override
    public void before(PrimitiveField primitiveField, int index) {
    }

    @Override
    public void after(PrimitiveField primitiveField, int index) {
        DefaultBeanAdapter adapter = new DefaultBeanAdapter(primitiveField);
        adapter.injectNull("parent");
    }
}
