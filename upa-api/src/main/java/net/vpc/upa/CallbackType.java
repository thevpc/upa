package net.vpc.upa;

/**
 * Created by vpc on 7/25/15.
 */
public enum CallbackType {
    /**
     * unspecified value
     */
    DEFAULT,
    ON_PRE_PERSIST,
    ON_PERSIST,
    ON_UPDATE,
    ON_PRE_UPDATE,
    ON_REMOVE,
    ON_PRE_REMOVE,
    ON_RESET,
    ON_PRE_RESET,
    ON_CLEAR,
    ON_PRE_CLEAR,
    ON_INITIALIZE,
    ON_PRE_INITIALIZE,
    ON_CREATE,
    ON_PRE_CREATE,
    ON_DROP,
    ON_PRE_DROP,
    ON_MOVE,
    ON_PRE_MOVE,
    ON_ALTER,
    ON_PRE_ALTER,
    ON_START,
    ON_PRE_START,
    ON_UPDATE_FORMULAS,
    ON_PRE_UPDATE_FORMULAS,
    ON_CLOSE,
    ON_PRE_CLOSE,
    //Persistence Unit Events
    ON_MODEL_CHANGED,
    ON_PRE_MODEL_CHANGED,
    ON_STORAGE_CHANGED,
    ON_PRE_STORAGE_CHANGED,
    //Function Eval Events
    ON_EVAL

}
