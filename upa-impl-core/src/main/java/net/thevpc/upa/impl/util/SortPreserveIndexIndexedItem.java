package net.thevpc.upa.impl.util;

import java.util.Comparator;

/**
 * Created by vpc on 7/8/17.
 */
public class SortPreserveIndexIndexedItem<T> implements Comparable<SortPreserveIndexIndexedItem<T>>{
    T item;
    int index;
    Comparator<T> comp;

    public SortPreserveIndexIndexedItem(T item, int index,Comparator<T> comp) {
        this.item = item;
        this.index = index;
        this.comp = comp;
    }

    @Override
    public int compareTo(SortPreserveIndexIndexedItem<T> o2) {
        int i = comp.compare(this.item, o2.item);
        if (i == 0) {
            i = this.index - o2.index;
        }
        return i;
    }

    public T getItem() {
        return item;
    }

    public int getIndex() {
        return index;
    }
}
