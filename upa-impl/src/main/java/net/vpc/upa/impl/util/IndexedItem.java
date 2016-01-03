package net.vpc.upa.impl.util;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 10:03 PM
*/
class IndexedItem<G>{
    private G item;
    private int index;

    IndexedItem(G item, int index) {
        this.setItem(item);
        this.setIndex(index);
    }

    public G getItem() {
        return item;
    }

    public void setItem(G item) {
        this.item = item;
    }

    public int getIndex() {
        return index;
    }

    public void setIndex(int index) {
        this.index = index;
    }
}
