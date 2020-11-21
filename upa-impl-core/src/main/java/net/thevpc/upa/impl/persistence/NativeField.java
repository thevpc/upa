package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.upql.BindingId;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/24/12 5:43 PM
 */
public class NativeField {
    private int index;
    private boolean expanded;
    private BindingId bindingId;
    //    private String fullBinding;
//    private String exprString;
    private String name;
    private DataTypeTransform typeTransform;
    private Field field;
    private Entity parentBindingEntity;

    /**
     * true if this field a key part of a partial object that should be loaded out of this query
     * mainly because it is a "SELECT" fetch strategy
     */
    private boolean preferLoadLater;

    /**
     * true if the object is not to be load fully!! (for instance when loading only ids and names)
     */
    private boolean partialObject;

    public NativeField(String name, BindingId bindingId, int index, boolean expanded, Entity entity, Field field, DataTypeTransform typeChain, boolean preferLoadLater, boolean partialObject) {
        this.bindingId = bindingId;
        this.preferLoadLater = preferLoadLater;
        this.partialObject = partialObject;
        this.expanded = expanded;
        this.index = index;
        if (index < 0) {
            throw new IllegalUPAArgumentException("Invalid index < " + index);
        }
//        this.exprString = exprString;
        this.name = name;
//        if(StringUtils.isNullOrEmpty(bindingId)){
//            fullBinding=name;
//        }else{
//            fullBinding=bindingId+"."+name;
//        }
        this.field = field;
        this.parentBindingEntity = entity;
        this.typeTransform = typeChain;
        //REMOVE ME
        if (typeChain == null) {
            throw new IllegalUPAArgumentException("Null DataType");
        }
    }

    public boolean isPartialObject() {
        return partialObject;
    }

    public Entity getParentBindingEntity() {
        return parentBindingEntity;
    }

    public boolean isPreferLoadLater() {
        return preferLoadLater;
    }

    public int getIndex() {
        return index;
    }

//    public String getFullBinding() {
//        return fullBinding;
//    }

    public BindingId getBindingId() {
        return bindingId;
    }

    public Field getField() {
        return field;
    }

    public String getName() {
        return name;
    }

    public DataTypeTransform getTypeTransform() {
        return typeTransform;
    }

    @Override
    public String toString() {
        return "NativeField{" + "bindingId=" + bindingId + ", name=" + name + ", typeChain=" + typeTransform + ", field=" + field + '}';
    }

//    public String getExprString() {
//        return exprString;
//    }

    public boolean isExpanded() {
        return expanded;
    }
}
