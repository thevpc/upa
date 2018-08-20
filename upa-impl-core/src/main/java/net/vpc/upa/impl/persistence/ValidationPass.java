package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;

import java.util.HashSet;
import java.util.Set;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/3/13 10:11 AM
*/
public class ValidationPass implements Comparable<Object> {

    private final Set<Field> fields = new HashSet<Field>();
    private final int pass;
    private final ValidationPassType validationPassType;

    public ValidationPass(int pass, ValidationPassType type) {
        this.validationPassType = type;
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
            return (validationPassType == oth.validationPassType) ? 0 : validationPassType.ordinal() > oth.validationPassType.ordinal() ? 1 : -1;
        }
    }

    public Set<Field> getFields() {
        return fields;
    }

    public int getPass() {
        return pass;
    }

    public ValidationPassType getValidationPassType() {
        return validationPassType;
    }
}
