package net.vpc.upa.impl.persistence;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 11:14 PM
 */
public class FieldTracking {
    private String name;
    private String setterMethodName;
    private int index;

    public FieldTracking(String name, String setterMethodName, int index) {
        this.name = name;
        this.setterMethodName = setterMethodName;
        this.index = index;
    }

    public String getName() {
        return name;
    }

    public String getSetterMethodName() {
        return setterMethodName;
    }

    public int getIndex() {
        return index;
    }
}
