package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;

import java.util.Iterator;
import java.util.ListIterator;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 10:18 PM
*/
@PortabilityHint(target = "C#",name = "ignore")
class IteratorListIterator<T> implements Iterator<T>, ListIterator<T> {

    /**
     * Index of element to be returned by subsequent call to next.
     */
    int cursor = -1;
    private LazyList<T> lazyList;

    IteratorListIterator(LazyList<T> lazyList) {
        this(lazyList, -1);
    }
    
    IteratorListIterator(LazyList<T> lazyList, int cursor) {
        this.lazyList = lazyList;
        this.cursor = cursor;
    }

    public boolean hasNext() {
        lazyList.ensureLoadTo(cursor+1);

        return !lazyList.end || (cursor+1) < lazyList.size();
    }

    public T next() {
        int i = cursor+1;
        T next = lazyList.get(i);
        cursor = i;
        return next;
    }

    public void remove() {
        lazyList.remove(cursor);
    }

    public boolean hasPrevious() {
        return cursor > 0;
    }

    public T previous() {
        int i = cursor - 1;
        T previous = lazyList.get(i);
        cursor = i;
        return previous;
    }

    public int nextIndex() {
        return cursor+1;
    }

    public int previousIndex() {
        return cursor - 1;
    }

    public void set(T e) {
        lazyList.set(cursor, e);
    }

    public void add(T e) {
        lazyList.add(e);
    }
}
