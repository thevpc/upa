package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.impl.upql.BindingId;
import net.vpc.upa.impl.util.PlatformUtils;

import java.util.*;

/**
 * Created by vpc on 1/4/14.
 */
class ResultFieldFamily {
    boolean documentType;
    BindingId binding;
    boolean read;
    boolean identifiable;
    List<ResultFieldParseData> nonIdFields = new ArrayList<ResultFieldParseData>();
    List<ResultFieldParseData> idFields = new ArrayList<ResultFieldParseData>();
    ResultFieldParseData[] fieldsArray;
    Entity entity;
    Class resultType;
    EntityBuilder builder;
    Map<String, ResultFieldParseData> fieldsMap = new HashMap<String, ResultFieldParseData>();
    Map<String, ResultFieldParseDataSetter> setters = new HashMap<String, ResultFieldParseDataSetter>();
    ResultFieldFamilyParser parser;
    boolean partialObject;
    ObjectFactory ofactory;
    ResultObject currentResult;

    public ResultFieldFamily(BindingId binding, ObjectFactory ofactory) {
        this(binding,(Entity) null,null,ofactory);
    }

    public ResultFieldFamily(BindingId binding, Entity entity, ObjectFactory ofactory) {
        this(binding,entity,null,ofactory);
    }

    public ResultFieldFamily(BindingId binding, Class resultType, ObjectFactory ofactory) {
        this(binding,null,resultType,ofactory);
    }

    private ResultFieldFamily(BindingId binding, Entity entity, Class resultType, ObjectFactory ofactory) {
        this.binding = binding;
        this.ofactory = ofactory;
        this.entity = entity;
        if (entity != null) {
            this.builder = entity.getBuilder();
            this.resultType = entity.getEntityType();
        }
        if(resultType!=null){
            this.resultType=resultType;
        }
    }

    public ResultFieldParseDataSetter setterFor(String name){
        ResultFieldParseDataSetter setter = setters.get(name);
        if(setter!=null){
            return setter;
        }

        if(documentType){
            setter= new DocumentFieldInfoSetter(name);
        }else if(entity!=null){
            setter= new EntityBuilderFieldInfoSetter(name, builder);
        }else {
            setter= new PlatformBeanFieldInfoSetter(name,PlatformUtils.getBeanType(resultType));
        }
        setters.put(name,setter);
        return setter;
    }


    @Override
    public String toString() {
        return "ResultFieldFamily{" +
                "binding="+(binding==null?"''":("'" + binding + '\'')) +
                ", entity=" + entity +
                '}';
    }

    public ResultObject createResultObject(){
        ResultFieldFamily columnFamily =this;
        if (columnFamily.documentType) {
            return ResultObject.forDocument(null,columnFamily.builder == null ? ofactory.createObject(Document.class) : columnFamily.builder.createDocument());
        } else {
            Object entityObject = columnFamily.builder.createObject();
            return ResultObject.forObject(entityObject,columnFamily.builder.objectToDocument(entityObject, true));
        }
    }
}
