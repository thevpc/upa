package net.vpc.upa.impl.upql;

/**
 * Created by vpc on 7/1/17.
 */
public class BindingId {
    private String name;
    private BindingId parent;

    public BindingId(String name) {
        this.name = name;
    }

    public BindingId(String name,BindingId parent) {
        this.name = name;
        this.parent = parent;
    }

    public static BindingId createChild(BindingId parent,String name){
        return new BindingId(name,parent);
    }

    public static BindingId create(String name){
        return new BindingId(name);
    }

    public BindingId createChild(String name){
        return new BindingId(name,this);
    }

    public BindingId getParent() {
        return parent;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        BindingId bindingId = (BindingId) o;

        if (name != null ? !name.equals(bindingId.name) : bindingId.name != null) return false;
        return parent != null ? parent.equals(bindingId.parent) : bindingId.parent == null;
    }

    @Override
    public int hashCode() {
        int result = name != null ? name.hashCode() : 0;
        result = 31 * result + (parent != null ? parent.hashCode() : 0);
        return result;
    }

    @Override
    public String toString() {
        if(parent==null){
            return name;
        }
        return parent.toString()+"."+name;
    }

    public String getName() {
        return name;
    }
}
