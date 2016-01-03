package net.vpc.upa.impl.util;

import java.util.Arrays;
import java.util.Comparator;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/17/12 7:18 PM
 */
public class CompareUtils {

    public static final <T> void sort(T[] array,final IndexedComparator<T> comparator){
        IndexedItem<T>[] x=new IndexedItem[array.length];
        for (int i = 0; i < x.length; i++) {
            x[i]=new IndexedItem<T>(array[i],i);

        }
        Comparator<IndexedItem<T>> comparator2= new IndexedItemComparator<T>(comparator);
        Arrays.sort(x,comparator2);

    }

}
