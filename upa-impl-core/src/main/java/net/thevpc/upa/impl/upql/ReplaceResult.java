package net.thevpc.upa.impl.upql;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * Created by vpc on 6/28/17.
 */
public class ReplaceResult {
    public static final ReplaceResult NO_UPDATES_CONTINUE = new ReplaceResult(null, ReplaceResultType.NO_UPDATES, false,true);
    public static final ReplaceResult NO_UPDATES_STOP = new ReplaceResult(null, ReplaceResultType.NO_UPDATES, true,true);
    public static final ReplaceResult UPDATE_AND_CONTINUE_CLEAN = new ReplaceResult(null, ReplaceResultType.UPDATE, false,true);
//    public static final ReplaceResult UPDATE_AND_CONTINUE_DIRTY = new ReplaceResult(null, ReplaceResultType.UPDATE, false,false);
    public static final ReplaceResult UPDATE_AND_STOP = new ReplaceResult(null, ReplaceResultType.UPDATE, true,true);
//    public static final ReplaceResult REMOVE_AND_CONTINUE = new ReplaceResult(null, ReplaceResultType.REMOVE, false);
    public static final ReplaceResult REMOVE_AND_STOP = new ReplaceResult(null, ReplaceResultType.REMOVE, true,false);
    private final CompiledExpressionExt expression;
    private final ReplaceResultType replaceResultType;
    /**
     * if true do not process children
     */
    private final boolean stop;
    /**
     * if false force re process updating
     */
    private final boolean clean;

    private ReplaceResult(CompiledExpressionExt expression, ReplaceResultType type, boolean stop, boolean clean) {
        this.expression = expression;
        this.replaceResultType = type;
        this.stop = stop;
        this.clean = clean;
    }

    public boolean isClean() {
        return clean;
    }

    public boolean isDirty() {
        return !clean;
    }

//    public static ReplaceResult continueWithNewObj(CompiledExpressionExt expression) {
//        return new ReplaceResult(expression, ReplaceResultType.NEW_INSTANCE, false);
//    }
    public static ReplaceResult stopWithNewObj(CompiledExpressionExt expression) {
        return new ReplaceResult(expression, ReplaceResultType.NEW_INSTANCE, true,true);
    }

    public static ReplaceResult continueWithNewCleanObj(CompiledExpressionExt expression) {
        return new ReplaceResult(expression, ReplaceResultType.NEW_INSTANCE, false,true);
    }
    public static ReplaceResult continueWithNewDirtyObj(CompiledExpressionExt expression) {
        return new ReplaceResult(expression, ReplaceResultType.NEW_INSTANCE, false,false);
    }
    public static ReplaceResult stopWithNewCleanObj(CompiledExpressionExt expression) {
        return new ReplaceResult(expression, ReplaceResultType.NEW_INSTANCE, true,true);
    }
    public static ReplaceResult stopWithNewDirtyObj(CompiledExpressionExt expression) {
        return new ReplaceResult(expression, ReplaceResultType.NEW_INSTANCE, true,false);
    }


    public boolean isStop() {
        return stop;
    }

    public CompiledExpressionExt getExpression(CompiledExpressionExt old) {
        switch (replaceResultType){
            case NEW_INSTANCE:return expression;
        }
        return old;
    }

    public CompiledExpressionExt getExpression() {
        return expression;
    }

    public boolean isNewInstance() {
        return getReplaceResultType()==ReplaceResultType.NEW_INSTANCE;
    }

    public ReplaceResultType getReplaceResultType() {
        return replaceResultType;
    }

    public boolean isUpdateContent() {
        switch (replaceResultType) {
            case UPDATE: {
                return true;
            }
        }
        return false;
    }

    @Override
    public String toString() {
        switch (getReplaceResultType()){
            case NO_UPDATES:return "NO_UPDATES"+(stop?"!!STOP":"");
            case UPDATE:return "UPDATE"+(stop?"!!STOP":"");
            case REMOVE:return "REMOVE"+(stop?"!!STOP":"");
            case NEW_INSTANCE:return "NEW_INSTANCE("+expression+")"+(stop?"!!STOP":"");
        }
        return "ReplaceResult{" +
                "expression=" + expression +
                ", type=" + replaceResultType +
                ", stop=" + stop +
                '}';
    }
}
