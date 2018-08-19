package net.vpc.upa.impl.upql.ext.expr;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 12:22 AM
*/
class SplitResult {
    private String value;
    private boolean delimiter;

    public SplitResult(String value, boolean delimiter) {
        this.value = value;
        this.delimiter = delimiter;
    }

    public String getValue() {
        return value;
    }

    public boolean isDelimiter() {
        return delimiter;
    }

    @Override
    public String toString() {
        return delimiter ? ("Delimiter{" + value + "}") : ("Value{" + value + "}");
    }
}
