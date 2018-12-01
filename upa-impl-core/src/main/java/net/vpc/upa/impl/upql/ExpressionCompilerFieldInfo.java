package net.vpc.upa.impl.upql;

import net.vpc.upa.Field;

public class ExpressionCompilerFieldInfo {
    public Field field;
    public boolean preferLoadLater;
    public boolean partialObject;

    public ExpressionCompilerFieldInfo(Field field, boolean preferLoadLater,boolean partialObject) {
        this.field = field;
        this.preferLoadLater = preferLoadLater;
        this.partialObject = partialObject;
    }
}
