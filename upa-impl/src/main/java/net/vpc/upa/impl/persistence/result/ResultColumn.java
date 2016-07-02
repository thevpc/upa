package net.vpc.upa.impl.persistence.result;

/**
 * Created by vpc on 6/29/16.
 */
public class ResultColumn {
    private Object value;
    private String label;

    public ResultColumn() {
    }

    public Object getValue() {
        return value;
    }

    public void setValue(Object value) {
        this.value = value;
    }

    public String getLabel() {
        return label;
    }

    public void setLabel(String label) {
        this.label = label;
    }
}
