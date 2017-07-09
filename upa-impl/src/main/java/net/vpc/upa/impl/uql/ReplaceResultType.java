package net.vpc.upa.impl.uql;

/**
 * Created by vpc on 6/28/17.
 */
public enum ReplaceResultType {
    NO_UPDATES,
    UPDATE,
    NEW_INSTANCE,
    REMOVE
    ;
    public static ReplaceResultType max(ReplaceResultType one,ReplaceResultType two){
        if(one.ordinal()>two.ordinal()){
            return one;
        }
        return two;
    }
    public static ReplaceResultType min(ReplaceResultType one,ReplaceResultType two){
        if(one.ordinal()<two.ordinal()){
            return one;
        }
        return two;
    }
}
