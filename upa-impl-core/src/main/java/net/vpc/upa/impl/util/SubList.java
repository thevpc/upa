/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.AbstractList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class SubList<E> extends AbstractList<E> implements List<E> {

    private final List<E> parent;
    private final int parentOffset;
    private final int offset;
    private int size;

    public SubList(List<E> parent,
            int offset, int fromIndex, int toIndex) {
        this.parent = parent;
        this.parentOffset = fromIndex;
        this.offset = offset + fromIndex;
        this.size = toIndex - fromIndex;
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public E set(int index, E e) {
        rangeCheck(index);
        checkForCoModification();
        return parent.set(offset + index, e);
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public E get(int index) {
        rangeCheck(index);
        checkForCoModification();
        return parent.get(offset + index);
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public int size() {
        checkForCoModification();
        return this.size;
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public void add(int index, E e) {
        rangeCheckForAdd(index);
        checkForCoModification();
        parent.add(parentOffset + index, e);
        this.size++;
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public E remove(int index) {
        rangeCheck(index);
        checkForCoModification();
        E result = parent.remove(parentOffset + index);
        this.size--;
        return result;
    }

//    protected void removeRange(int fromIndex, int toIndex) {
//        checkForComodification();
//        parent.removeRange(parentOffset + fromIndex,
//                parentOffset + toIndex);
//        this.modCount = parent.modCount;
//        this.size -= toIndex - fromIndex;
//    }
    @PortabilityHint(target = "C#", name = "suppress")
    public boolean addAll(Collection<? extends E> c) {
        return addAll(this.size, c);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public boolean addAll(int index, Collection<? extends E> c) {
        rangeCheckForAdd(index);
        int cSize = c.size();
        if (cSize == 0) {
            return false;
        }

        checkForCoModification();
        parent.addAll(parentOffset + index, c);
//        this.modCount = parent.modCount;
        this.size += cSize;
        return true;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public Iterator<E> iterator() {
        return listIterator();
    }

    @PortabilityHint(target = "C#", name = "suppress")
    public ListIterator<E> listIterator(int index) {
        checkForCoModification();
        rangeCheckForAdd(index);
        return new SimpleListIterator(this, index);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public List<E> subList(int fromIndex, int toIndex) {
        subListRangeCheck(fromIndex, toIndex, size);
        return new SubList(this, offset, fromIndex, toIndex);
    }

    private void rangeCheck(int index) {
        if (index < 0 || index >= this.size) {
            throw new IndexOutOfBoundsException(outOfBoundsMsg(index));
        }
    }

    private void rangeCheckForAdd(int index) {
        if (index < 0 || index > this.size) {
            throw new IndexOutOfBoundsException(outOfBoundsMsg(index));
        }
    }

    private String outOfBoundsMsg(int index) {
        return "Index: " + index + ", Size: " + this.size;
    }

    private void checkForCoModification() {
        //
    }

    static void subListRangeCheck(int fromIndex, int toIndex, int size) {
        if (fromIndex < 0) {
            throw new IndexOutOfBoundsException("fromIndex = " + fromIndex);
        }
        if (toIndex > size) {
            throw new IndexOutOfBoundsException("toIndex = " + toIndex);
        }
        if (fromIndex > toIndex) {
            throw new IllegalUPAArgumentException("fromIndex(" + fromIndex
                    + ") > toIndex(" + toIndex + ")");
        }
    }
}
