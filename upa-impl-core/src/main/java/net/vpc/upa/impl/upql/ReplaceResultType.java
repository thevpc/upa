package net.vpc.upa.impl.upql;

/**
 * Created by vpc on 6/28/17.
 */
public enum ReplaceResultType {
    /**
     * Undefined value, treated as null
     */
    DEFAULT,
    NO_UPDATES,
    UPDATE,
    NEW_INSTANCE,
    REMOVE
    ;
}
