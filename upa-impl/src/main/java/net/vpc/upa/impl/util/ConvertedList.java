package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;

import java.util.AbstractList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/26/12 4:41 PM
 */
@PortabilityHint(target = "C#",name = "ignore")
public class ConvertedList<K,V> extends AbstractList<V>{
    private Converter<K,V> converter;
    private List<K> base;

    public ConvertedList(List<K> base, Converter<K, V> converter) {
        this.base = base;
        this.converter = converter;
    }

    @Override
    public V get(int index) {
        return converter.convert(base.get(index));
    }

    @Override
    public int size() {
        return base.size();
    }
}
