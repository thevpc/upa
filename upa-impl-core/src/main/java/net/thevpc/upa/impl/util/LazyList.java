package net.thevpc.upa.impl.util;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.Closeable;

import java.util.*;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:13 AM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "ignore")
public abstract class LazyList<T> implements List<T>, Closeable {

//    protected Iterator<T> base;
    private List<T> loaded = new ArrayList<T>();
    private int actualSize = 0;
    boolean end = false;
    private int startIndex = 0;

    public LazyList(Iterator<T> base) {
//        this.base = base;
    }

    @Override
    public int size() {
        ensureLoadAll();
        return actualSize;
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder();
        s.append("[");
        boolean v = false;
        if (startIndex > 0) {
            s.append("<").append(startIndex).append(" items ignored> ...");
            v = true;
        }
        for (T t : loaded) {
            if (v) {
                s.append(", ");
            } else {
                v = true;
            }
            s.append(t);
        }
        if (!end) {
            if (v) {
                s.append(", ");
            }
            s.append("... <lazy loadable items>");
        }
        s.append("]");
        return s.toString();
    }

    @Override
    public boolean isEmpty() {
        if (actualSize > 0) {
            return false;
        }
        if (!end) {
            checkLoadNext();
        }
        return actualSize <= 0;
    }

    @Override
    public boolean contains(Object o) {
        ensureLoadAll();
        return loaded.contains(o);
    }

    @Override
    public Iterator<T> iterator() {
        return new LazyListIterator(this);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public Object[] toArray() {
        ensureLoadAll();
        return loaded.toArray();
    }

    @Override
    public <T> T[] toArray(T[] a) {
        ensureLoadAll();
        return loaded.toArray(a);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public boolean add(T t) {
        ensureLoadAll();
        boolean v = loaded.add(t);
        actualSize=loaded.size();
        return v;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public boolean remove(Object o) {
        ensureLoadAll();
        boolean v = loaded.remove(o);
        actualSize=loaded.size();
        return v;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public boolean containsAll(Collection<?> c) {
        ensureLoadAll();
        return loaded.containsAll(c);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public boolean addAll(Collection<? extends T> c) {
        ensureLoadAll();
        boolean v = loaded.addAll(c);
        actualSize=loaded.size();
        return v;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public boolean addAll(int index, Collection<? extends T> c) {
        ensureLoadAll();
        boolean v = loaded.addAll(index - startIndex, c);
        actualSize=loaded.size();
        return v;
    }

    @Override
    public boolean removeAll(Collection<?> c) {
        ensureLoadAll();
        boolean v = loaded.removeAll(c);
        actualSize=loaded.size();
        return v;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public boolean retainAll(Collection<?> c) {
        ensureLoadAll();
        boolean v = loaded.retainAll(c);
        actualSize=loaded.size();
        return v;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void clear() {
        close();
        loaded.clear();
        actualSize=loaded.size();
    }

    void ensureLoadTo(int index) {
        if (index < startIndex) {
            throw new IllegalStateException(index + " < Window = " + startIndex);
        }
        while (!end && index >= actualSize) {
            checkLoadNext();
        }
    }

    @Override
    public T get(int index) {
        ensureLoadTo(index);
        return loaded.get(index - startIndex);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public T set(int index, T element) {
        ensureLoadTo(index);
        return loaded.set(index - startIndex, element);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void add(int index, T element) {
        ensureLoadTo(index);
        loaded.add(index,element);
        actualSize=loaded.size();
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public T remove(int index) {
        ensureLoadTo(index);
        T v = loaded.remove(index);
        actualSize=loaded.size();
        return v;
    }

    @Override
    public int indexOf(Object o) {
        ensureLoadAll();
        return loaded.indexOf(o);
    }

    @Override
    public int lastIndexOf(Object o) {
        ensureLoadAll();
        return loaded.lastIndexOf(o);
    }

    @Override
    public ListIterator<T> listIterator() {
        return listIterator(0);
    }

    @Override
    public ListIterator<T> listIterator(int index) {
        return new LazyListIterator(this);
    }

    @Override
    public List<T> subList(int fromIndex, int toIndex) {
        ensureLoadTo(toIndex);
        return new SubList(this, 0, fromIndex, toIndex);
    }

    public void ensureLoadAll() {
        while (checkLoadNext()) {
            //do nothing
        }
    }

    protected abstract boolean checkHasNext();
    protected abstract T loadNext();

    private boolean checkLoadNext() {
        if (!end) {
            if (checkHasNext()) {
                loaded.add(loadNext());
                actualSize++;
                return true;
            }
            close();
        }
        return false;
    }

    public void close() {
        end = true;
        loadingFinished();
    }

    protected void loadingFinished() {
    }

    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof List))
            return false;

        ListIterator<T> e1 = listIterator();
        ListIterator<?> e2 = ((List<?>) o).listIterator();
        while (e1.hasNext() && e2.hasNext()) {
            T o1 = e1.next();
            Object o2 = e2.next();
            if (!(o1==null ? o2==null : o1.equals(o2))) {
                return false;
            }
        }
        return !(e1.hasNext() || e2.hasNext());

    }

    @Override
    public int hashCode() {
        int hashCode = 1;
        for (T e : this) {
            hashCode = 31 * hashCode + (e == null ? 0 : e.hashCode());
        }
        return hashCode;
    }
}
