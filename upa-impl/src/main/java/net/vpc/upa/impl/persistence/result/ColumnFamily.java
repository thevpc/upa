package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.util.PlatformUtils;

import java.util.*;

/**
 * Created by vpc on 1/4/14.
 */
class ColumnFamily {

    boolean initialized;
    boolean documentType;
    BindingId binding;
    boolean read;
    boolean identifiable;
//    List<Integer> indexesToRead =new ArrayList<Integer>();
    List<FieldInfo> nonIdFields = new ArrayList<FieldInfo>();
    List<FieldInfo> idFields = new ArrayList<FieldInfo>();
    FieldInfo[] fieldsArray;
    Entity entity;
    Class resultType;
    EntityBuilder builder;
    EntityBuilder entityConverter;
    Map<String, FieldInfo> fieldsMap = new HashMap<String, FieldInfo>();
    Map<String, FieldInfoSetter> setters = new HashMap<String, FieldInfoSetter>();
    ColumnFamilyParser parser;
    boolean partialObject;
    ObjectFactory ofactory;

    public ColumnFamily(BindingId binding, ObjectFactory ofactory) {
        this(binding,(Entity) null,null,ofactory);
    }

    public ColumnFamily(BindingId binding, Entity entity, ObjectFactory ofactory) {
        this(binding,entity,null,ofactory);
    }

    public ColumnFamily(BindingId binding, Class resultType, ObjectFactory ofactory) {
        this(binding,null,resultType,ofactory);
    }

    private ColumnFamily(BindingId binding, Entity entity, Class resultType, ObjectFactory ofactory) {
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
        return "ColumnFamily{" +
                "binding="+(binding==null?"''":("'" + binding + '\'')) +
                ", entity=" + entity +
                '}';
    }

    public ResultObject createResultObject(){
        ColumnFamily columnFamily =this;
        ResultObject result=new ResultObject();
        if (columnFamily.documentType) {
            Object entityObject = null;
            Document entityDocument = columnFamily.builder == null ? ofactory.createObject(Document.class) : columnFamily.builder.createDocument();
            result.entityObject = entityObject;
            result.entityDocument = entityDocument;
            result.entityResult = entityDocument;
        } else {
            Object entityObject = columnFamily.builder.createObject();
            Document entityDocument = columnFamily.entityConverter.objectToDocument(entityObject, true);
            result.entityObject = entityObject;
            result.entityDocument = entityDocument;
            result.entityResult = entityObject;
        }
        return result;
    }
    public static ResultObject createResultObject(Entity entity,boolean documentType){
        ResultObject result=new ResultObject();
        if (documentType) {
            Object entityObject = null;
            Document entityDocument = entity.getBuilder().createDocument();
            result.entityObject = entityObject;
            result.entityDocument = entityDocument;
            result.entityResult = entityDocument;
        } else {
            Object entityObject = entity.getBuilder().createObject();
            Document entityDocument = entity.getBuilder().objectToDocument(entityObject, true);
            result.entityObject = entityObject;
            result.entityDocument = entityDocument;
            result.entityResult = entityObject;
        }
        return result;
    }
}
