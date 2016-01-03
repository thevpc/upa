package net.vpc.upa;

/**
 * Created by vpc on 7/25/15.
 */
public enum CallbackType {
    /**
     * unspecified value
     */
    DEFAULT,
    
    ON_PERSIST,
    ON_UPDATE,
    ON_REMOVE,
    ON_RESET,
    ON_CLEAR,
    ON_INITIALIZE,
    ON_CREATE,
    ON_DROP,
    ON_MOVE,
    ON_ALTER,
    ON_START,
    ON_CLOSE,

    //Persistence Unit Events
    ON_MODEL_CHANGED,
    ON_STORAGE_CHANGED,
    
    //Function Eval Events
    ON_EVAL,

}
