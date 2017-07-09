/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;

import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DataTypeTransformList implements DataTypeTransform, Iterable<DataTypeTransform> {

    private DataTypeTransform[] items;

    public DataTypeTransformList(DataTypeTransform[] others) {
        ArrayList<DataTypeTransform> all = new ArrayList<DataTypeTransform>();
        DataType src = null;
        for (DataTypeTransform i : others) {
            if (i != null) {
                if (src != null) {
                    if(!i.getSourceType().isAssignableFrom(src)){
                        throw new IllegalArgumentException("Invalid "+src+" expected "+i.getSourceType());
                    }
                }
                src = i.getTargetType();
                if (i instanceof DataTypeTransformList) {
                    all.addAll(Arrays.asList(((DataTypeTransformList) i).items));
                } else {
                    all.add(i);
                }
            }
        }
        this.items = all.toArray(new DataTypeTransform[all.size()]);
    }

    public DataTypeTransform get(int i) {
        return items[i];
    }

    public int size() {
        return items.length;
    }

    public Object transformValue(Object value) {
        Object v = value;
        for (DataTypeTransform n : items) {
            v = n.transformValue(v);
        }
        return v;
    }

    public Object reverseTransformValue(Object value) {
        Object v = value;
        for (int i = items.length - 1; i >= 0; i--) {
            DataTypeTransform n = items[i];
            v = n.reverseTransformValue(v);
        }
        return v;
    }

    public DataType getSourceType() {
        return items[0].getSourceType();
    }

    public DataType getTargetType() {
        return items[items.length - 1].getTargetType();
    }

    public DataTypeTransform chain(DataTypeTransform other) {
        if (other == null) {
            return this;
        }
        return new DataTypeTransformList(new DataTypeTransform[]{this, other});
    }

    public static DataTypeTransform chain(DataTypeTransform a, DataTypeTransform b) {
        if (a == null) {
            if (b == null) {
                return null;
            } else {
                return b;
            }
        } else if (b == null) {
            return a;
        } else {
            return new DataTypeTransformList(new DataTypeTransform[]{a, b});
        }
    }

    public Iterator<DataTypeTransform> iterator() {
        return Arrays.asList(items).iterator();
    }

    /**
     *  @PortabilityHint(target = "C#", name = "inline")
     *  public System.Collections.Generic.IEnumerator<T> GetEnumerator (){
     *    return ((System.Collections.Generic.IEnumerable<Net.Vpc.Upa.Types.DataTypeTransform>)items).GetEnumerator ();
     *  }
     *
     */

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        DataTypeTransformList that = (DataTypeTransformList) o;

        // Probably incorrect - comparing Object[] arrays with Arrays.equals
        return Arrays.equals(items, that.items);
    }

    @Override
    public int hashCode() {
        return Arrays.hashCode(items);
    }
}
