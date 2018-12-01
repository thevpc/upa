package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Document;
import net.vpc.upa.EntityBuilder;

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

    public static ResultObject forObject(Object entityObject, EntityBuilder builder,boolean itemAsDocument){
        if(!itemAsDocument){
            return forObject(entityObject,builder);
        }else{
            ResultObject r=new ResultObject();
            r.entityObject = entityObject;
            r.entityDocument = builder.objectToDocument(r.entityObject,true);
            r.entityResult = r.entityDocument;
            return r;
        }
    }
    public static ResultObject forObject(Object entityObject, EntityBuilder builder){
        ResultObject r=new ResultObject();
        r.entityObject = entityObject;
        r.entityDocument = builder.objectToDocument(r.entityObject,true);
        r.entityResult = entityObject;
        return r;
    }

    public static ResultObject forDocument(Document entityDocument, EntityBuilder builder){
        ResultObject r=new ResultObject();
        r.entityDocument = entityDocument;
        r.entityResult = entityDocument;
        r.entityObject = builder.documentToObject(r.entityDocument);
        return r;
    }
    public boolean isNull(){
        return entityDocument==null;
    }

    public Object getEntityObject() {
        return entityObject;
    }
}
