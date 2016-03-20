package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.EntityBuilder;
import net.vpc.upa.Record;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 1/4/14.
 */
class TypeInfo {

    String parentBinding;
    String bindingName;
    String binding;
    List<FieldInfo> infos = new ArrayList<FieldInfo>();
    FieldInfo[] infosArray;
    FieldInfo leadPrimaryField;
    FieldInfo leadField;
    Object entityObject;
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
}
