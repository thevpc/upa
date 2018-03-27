package net.vpc.upa.impl.util;

import java.util.Comparator;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 10:10 PM
*/
class IndexedItemComparator<T> implements Comparator<IndexedItem<T>> {
    private final IndexedComparator<T> comparator;

    public IndexedItemComparator(IndexedComparator<T> comparator) {
        this.comparator = comparator;
    }

    @Override
    public int compare(IndexedItem<T> o1, IndexedItem<T> o2) {
        return comparator.compare(o1.getItem(), o2.getItem(), o1.getIndex(), o2.getIndex());
    }
}
