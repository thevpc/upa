package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.util.PlatformUtils;

import java.util.*;

/**
 * Created by vpc on 1/4/14.
 */
class TypeInfo {

    boolean document;
    BindingId binding;
    boolean read;
    boolean identifiable;
//    List<Integer> indexesToRead =new ArrayList<Integer>();
    List<FieldInfo> nonIdFields = new ArrayList<FieldInfo>();
    List<FieldInfo> idFields = new ArrayList<FieldInfo>();
    Set<Relationship> manyToOneRelations = new HashSet<Relationship>();
    FieldInfo[] fieldsArray;
    FieldInfo leadPrimaryField;
    FieldInfo leadField;
    ResultObject currentResult;
    Entity entity;
    Class resultType;
    EntityBuilder builder;
    EntityBuilder entityConverter;
    Map<String, FieldInfo> fieldsMap = new HashMap<String, FieldInfo>();
    Map<String, FieldInfoSetter> setters = new HashMap<String, FieldInfoSetter>();
    TypeInfoSupParser parser;

    public TypeInfo(BindingId binding) {
        this.binding = binding;
    }

    public FieldInfoSetter setterFor(String name){
        FieldInfoSetter setter = setters.get(name);
        if(setter!=null){
            return setter;
        }

        if(document){
            setter= new DocumentFieldInfoSetter(name);
        }else if(entity!=null){
            setter= new EntityBuilderFieldInfoSetter(name, builder);
        }else {
            setter= new PlatformBeanFieldInfoSetter(PlatformUtils.findPlatformBeanProperty(name,resultType));
        }
        setters.put(name,setter);
        return setter;
    }

    public TypeInfo(BindingId binding, Entity entity) {
        this.binding = binding;
        this.entity = entity;
        if (entity != null) {
            builder = entity.getBuilder();
            entityConverter = entity.getBuilder();
            resultType = entity.getEntityType();
        }
    }

    public TypeInfo(BindingId binding, Class resultType) {
        this.binding = binding;
        this.resultType = resultType;
    }

    @Override
    public String toString() {
        return "TypeInfo{" +
                "binding="+(binding==null?"''":("'" + binding + '\'')) +
                ", entity=" + entity +
                '}';
    }

}
