package net.vpc.upa;

public interface PrimitiveId {
    Object getValue(int index);
    Object getValue();
    int size() ;
    Field getField(int index);
}
