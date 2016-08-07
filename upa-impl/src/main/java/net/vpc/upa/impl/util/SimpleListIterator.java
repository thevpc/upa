package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;

import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 10:18 PM
*/
@PortabilityHint(target = "C#",name = "ignore")
class SimpleListIterator<T> implements Iterator<T>, ListIterator<T> {

    /**
     * Index of element to be returned by subsequent call to next.
     */
    int cursor = 0;
    private List<T> iteratorList;

    SimpleListIterator(List<T> iteratorList, int cursor) {
        this.iteratorList = iteratorList;
        this.cursor = cursor;
    }

    public boolean hasNext() {
        return cursor < iteratorList.size();
    }

    public T next() {
        int i = cursor;
        T next = iteratorList.get(i);
        cursor = i + 1;
        return next;
    }

    public void remove() {
    }

    public boolean hasPrevious() {
        return cursor != 0;
    }

    public T previous() {
        int i = cursor - 1;
        T previous = iteratorList.get(i);
        cursor = i;
        return previous;
    }

    public int nextIndex() {
        return cursor;
    }

    public int previousIndex() {
        return cursor - 1;
    }

    public void set(T e) {
        iteratorList.set(cursor, e);
    }

    public void add(T e) {
        iteratorList.add(cursor, e);
    }
}
