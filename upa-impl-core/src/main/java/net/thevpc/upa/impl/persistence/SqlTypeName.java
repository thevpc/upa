/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

/**
 *
 * @author vpc
 */
public class SqlTypeName {

    private final String name;
    private final int size;
    private final int scale;
    private final String fullName;

    public SqlTypeName(String name, int size, int scale, String fullName) {
        this.name = name;
        this.size = size;
        this.scale = scale;
        this.fullName = fullName;
    }

    public SqlTypeName(String name) {
        this(name, -1, -1);
    }

    public SqlTypeName(String name, int size) {
        this(name, size, -1);
    }

    public SqlTypeName(String name, int size, int scale) {
        this.name = name;
        this.size = size;
        this.scale = scale;
        if (size != -1 && scale != -1) {
            this.fullName = name + "(" + size + "," + scale + ")";
        } else if (size != -1) {
            this.fullName = name + "(" + size + ")";
        } else {
            this.fullName = name;
        }
    }

    public String getName() {
        return name;
    }

    public int getSize() {
        return size;
    }

    public int getScale() {
        return scale;
    }

    public String getFullName() {
        return fullName;
    }

}
