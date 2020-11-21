package net.thevpc.upa.impl.util;

/**
 * @author taha.bensalah@gmail.com on 7/24/16.
 */
public class Ref<T> {
    private T value;

    public Ref(T value) {
        this.value = value;
    }

    public Ref() {
    }

    public T get(){
        return value;
    }
    public void set(T val){
        this.value=val;
    }

    @Override
    public String toString() {
        return "Ref(" +
                value +
                ')';
    }
}
