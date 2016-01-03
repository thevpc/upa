package net.vpc.upa.impl;

import net.vpc.upa.Field;

import java.util.HashSet;
import java.util.Set;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/3/13 10:11 AM
*/
public class ValidationPass implements Comparable<Object> {

    Set<Field> fields = new HashSet<Field>();
    int pass;
    ValidationPassType type;

    public ValidationPass(int pass, ValidationPassType type) {
        this.type = type;
        this.pass = pass;
    }

    public int compareTo(Object o) {
        if (o == null) {
            return 1;
        }
        if (o == this) {
            return 0;
        }
        ValidationPass oth = (ValidationPass) o;
        if (pass > oth.pass) {
            return 1;
        } else if (pass < oth.pass) {
            return -1;
        } else {
            return (type == oth.type) ? 0 : type.ordinal() > oth.type.ordinal() ? 1 : -1;
        }
    }
}
