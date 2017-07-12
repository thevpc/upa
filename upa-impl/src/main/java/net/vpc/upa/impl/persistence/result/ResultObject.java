package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Document;
import net.vpc.upa.Key;
import net.vpc.upa.ObjectFactory;

/**
 * Created by vpc on 7/1/17.
 */
public class ResultObject {
    Object entityObject;
    Object entityResult;
    Object entityUpdatable;
    Document entityDocument;

    public ResultObject() {
    }

    public static ResultObject forNull(){
        return new ResultObject();
    }

    public static ResultObject forObject(Object entityObject,Document entityDocument){
        ResultObject r=new ResultObject();
        r.entityObject = entityObject;
        r.entityDocument = entityDocument;
        r.entityResult = entityObject;
        return r;
    }

    public static ResultObject forDocument(Object entityObject,Document entityDocument){
        ResultObject r=new ResultObject();
        r.entityObject = entityObject;
        r.entityDocument = entityDocument;
        r.entityResult = entityDocument;
        return r;
    }
    public boolean isNull(){
        return entityDocument==null;
    }
}
