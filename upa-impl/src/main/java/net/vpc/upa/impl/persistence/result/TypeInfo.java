package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.util.PlatformUtils;

import java.util.*;

/**
 * Created by vpc on 1/4/14.
 */
class TypeInfo {

    boolean initialized;
    boolean documentType;
    BindingId binding;
    boolean read;
    boolean identifiable;
//    List<Integer> indexesToRead =new ArrayList<Integer>();
    List<FieldInfo> nonIdFields = new ArrayList<FieldInfo>();
    List<FieldInfo> idFields = new ArrayList<FieldInfo>();
    FieldInfo[] fieldsArray;
    ResultObject currentResult;
    Entity entity;
    Class resultType;
    EntityBuilder builder;
    EntityBuilder entityConverter;
    Map<String, FieldInfo> fieldsMap = new HashMap<String, FieldInfo>();
    Map<String, FieldInfoSetter> setters = new HashMap<String, FieldInfoSetter>();
    TypeInfoSupParser parser;
    boolean partialObject;
    ObjectFactory ofactory;

    public TypeInfo(BindingId binding,ObjectFactory ofactory) {
        this(binding,(Entity) null,null,ofactory);
    }

    public TypeInfo(BindingId binding, Entity entity,ObjectFactory ofactory) {
        this(binding,entity,null,ofactory);
    }

    public TypeInfo(BindingId binding, Class resultType,ObjectFactory ofactory) {
        this(binding,null,resultType,ofactory);
    }

    private TypeInfo(BindingId binding, Entity entity,Class resultType,ObjectFactory ofactory) {
        this.binding = binding;
        this.ofactory = ofactory;
        this.entity = entity;
        if (entity != null) {
            this.builder = entity.getBuilder();
            this.entityConverter = entity.getBuilder();
            this.resultType = entity.getEntityType();
        }
        if(resultType!=null){
            this.resultType=resultType;
        }
    }

    public FieldInfoSetter setterFor(String name){
        FieldInfoSetter setter = setters.get(name);
        if(setter!=null){
            return setter;
        }

        if(documentType){
            setter= new DocumentFieldInfoSetter(name);
        }else if(entity!=null){
            setter= new EntityBuilderFieldInfoSetter(name, builder);
        }else {
            setter= new PlatformBeanFieldInfoSetter(PlatformUtils.findPlatformBeanProperty(name,resultType));
        }
        setters.put(name,setter);
        return setter;
    }


    @Override
    public String toString() {
        return "TypeInfo{" +
                "binding="+(binding==null?"''":("'" + binding + '\'')) +
                ", entity=" + entity +
                '}';
    }

    public ResultObject createResultObject(){
        TypeInfo typeInfo=this;
        ResultObject result=new ResultObject();
        if (typeInfo.documentType) {
            Object entityObject = null;
            Document entityDocument = typeInfo.builder == null ? ofactory.createObject(Document.class) : typeInfo.builder.createDocument();
            result.entityObject = entityObject;
            result.entityDocument = entityDocument;
            result.entityResult = entityDocument;
        } else {
            Object entityObject = typeInfo.builder.createObject();
            Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
            result.entityObject = entityObject;
            result.entityDocument = entityDocument;
            result.entityResult = entityObject;
        }
        return result;
    }
}
