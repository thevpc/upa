package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;
import net.vpc.upa.EntityBuilder;
import net.vpc.upa.Record;
import net.vpc.upa.Relationship;

import java.util.*;

/**
 * Created by vpc on 1/4/14.
 */
class TypeInfo {

    boolean record;
    String parentBinding;
    String bindingName;
    String binding;
    boolean update;
    List<Integer> indexesToUpdate=new ArrayList<Integer>();
    List<FieldInfo> allFields = new ArrayList<FieldInfo>();
    Set<Relationship> manyToOneRelations = new HashSet<Relationship>();
    FieldInfo[] infosArray;
    FieldInfo leadPrimaryField;
    FieldInfo leadField;
    Object entityObject;
    Object entityResult;
    Object entityUpdatable;
    Record entityRecord;
    Entity entity;
    Class entityType;
    EntityBuilder entityFactory;
    EntityBuilder entityConverter;
    Map<String, FieldInfo> fields = new HashMap<String, FieldInfo>();

    public TypeInfo(String binding, Entity entity) {
        this.binding = binding;
        int dotPos = binding == null ? -1 : binding.lastIndexOf('.');
        if (dotPos > 0) {
            this.parentBinding = binding.substring(0, dotPos);
            this.bindingName = binding.substring(dotPos + 1);
        }
        this.entity = entity;
        if (entity != null) {
            entityFactory = entity.getBuilder();
            entityConverter = entity.getBuilder();
            entityType = entity.getEntityType();
        }
    }

    @Override
    public String toString() {
        return "TypeInfo{" +
                "binding='" + binding + '\'' +
                ", entity=" + entity +
                '}';
    }
}
