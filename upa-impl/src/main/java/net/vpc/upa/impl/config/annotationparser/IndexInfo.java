/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.annotationparser;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.IndexDescriptor;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IndexInfo implements IndexDescriptor{
    private String name;
    private List<String> fieldsNames=new ArrayList<String>();
    private OverriddenValue<Boolean> unique=new OverriddenValue<Boolean>();

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<String> getFieldsNames() {
        return fieldsNames;
    }

    public void setFieldsNames(List<String> fieldsNames) {
        this.fieldsNames = fieldsNames;
    }

    OverriddenValue<Boolean> getUnique() {
        return unique;
    }

    void setUnique(OverriddenValue<Boolean> unique) {
        this.unique = unique;
    }

    public String[] getFieldNames() {
        return fieldsNames.toArray(new String[fieldsNames.size()]);
    }

    public boolean isUnique() {
        return (Boolean)unique.getValue(Boolean.TRUE);
    }
    
}
