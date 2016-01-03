package net.vpc.upa.impl;

import net.vpc.upa.PrimitiveField;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.impl.util.ItemInterceptor;

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
