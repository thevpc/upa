package net.thevpc.upa.impl.config.annotationparser;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/15/12 11:50 AM
*/
class OverriddenValue<T> {

    boolean specified;
    int order = Integer.MIN_VALUE;
    T value;

    public OverriddenValue() {
    }

    public void setValue(T newValue) {
        specified = true;
        value = newValue;
    }

    public void setBetterValue(T newValue, int order) {
        if (order >= this.order) {
            setValue(newValue);
        }
    }

    public T getValue(T unspecifiedValue) {
        if(!specified){
            return unspecifiedValue;
        }
        return value;
    }
}
