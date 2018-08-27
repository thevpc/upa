package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.*;
import net.vpc.upa.EntityExtensionDefinition;

import java.util.*;

import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.StringUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:46 AM
 */
class DecorationEntityDescriptor implements EntityDescriptor {

    public Object source = null;
//        public SequenceInfo generatedIdInfo = null;
    public List<IndexInfo> indexes = new ArrayList<IndexInfo>();
    public FlagSet<EntityModifier> modifiers = FlagSets.noneOf(EntityModifier.class);
    public FlagSet<EntityModifier> excludeModifiers = FlagSets.noneOf(EntityModifier.class);
    public Class idType = null;
    public OverriddenValue<Class> entityType = new OverriddenValue<Class>();
    public OverriddenValue<String> listOrder = new OverriddenValue<String>();
    public OverriddenValue<String> archivingOrder = new OverriddenValue<String>();
    public String name = null;
    public String shortName = null;
    public LinkedHashMap<String, DecorationFieldDescriptor> fieldsMap = new LinkedHashMap<String, DecorationFieldDescriptor>();
    public List<EntityExtensionDefinition> specs = new ArrayList<EntityExtensionDefinition>();
    public List<RelationshipInfo> relations = new ArrayList<RelationshipInfo>();
    public List<DecorationFieldDescriptor> fieldsList;
    public OverriddenValue<String> path = new OverriddenValue<String>();
    public OverriddenValue<Integer> pathPosition = new OverriddenValue<Integer>();
    public LinkedHashMap<String, Object> entityParams = new LinkedHashMap<String, Object>();
    public DecorationRepository repo;
    public ObjectFactory factory;

    //        public Sequence generatedId;
    public DecorationEntityDescriptor(DecorationRepository repo, ObjectFactory factory) {
        this.repo = repo;
        this.factory = factory;
    }

    public ObjectFactory getFactory() {
        return factory;
    }

    public Map<String, Object> getProperties() {
        return entityParams;
    }

    public void addModifiers(Collection<EntityModifier> others) {
        for (EntityModifier m : others) {
            if (excludeModifiers.contains(m)) {
                excludeModifiers=excludeModifiers.remove(m);
            }
            modifiers=modifiers.add(m);
        }
    }

    public void addExcludeModifiers(Collection<EntityModifier> others) {
        for (EntityModifier m : others) {
            if (modifiers.contains(m)) {
                modifiers=modifiers.remove(m);
            }
            excludeModifiers=excludeModifiers.add(m);
        }
    }

    public List<FieldDescriptor> getFieldDescriptors() {
        List<FieldDescriptor> all = new ArrayList<FieldDescriptor>();
        for (DecorationFieldDescriptor fieldInfo : fieldsList) {
            all.add(fieldInfo);
        }
        return all;
    }

    public List<RelationshipDescriptor> getRelationshipDescriptors() {
        List<RelationshipDescriptor> all = new ArrayList<RelationshipDescriptor>();
        for (RelationshipInfo fieldInfo : relations) {
            all.add(fieldInfo);
        }
        return all;
    }

    public List<IndexDescriptor> getIndexDescriptors() {
        List<IndexDescriptor> all = new ArrayList<IndexDescriptor>();
        for (IndexInfo fieldInfo : indexes) {
            all.add(fieldInfo);
        }
        return all;
    }

    public String getName() {
        return name;
    }

    public String getShortName() {
        return shortName;
    }

    public Class getIdType() {
        return idType;
    }

    public Class getEntityType() {
        return entityType.value;
    }

    @Override
    public String getPackagePath() {
        return path.getValue(null);
    }
    
    @Override
    public String getListOrder() {
        return listOrder.getValue(null);
    }
    
    @Override
    public String getArchivingOrder() {
        return archivingOrder.getValue(null);
    }

    @Override
    public int getPosition() {
        return pathPosition.getValue(0);
    }

    @Override
    public List<EntityExtensionDefinition> getEntityExtensions() {
        return specs;
    }

    @Override
    public FlagSet<EntityModifier> getModifiers() {
        return modifiers;
    }

    public FlagSet<EntityModifier> getExcludeModifiers() {
        return excludeModifiers;
    }

    @Override
    public Object getSource() {
        return source;
    }

    public void addIndex(String name, List<String> fields, boolean unique, int configOrder) {
        if (StringUtils.isNullOrEmpty(name)) {
            IndexInfo i = new IndexInfo();
            i.setName(null);
            i.getUnique().setBetterValue(unique, configOrder);
            i.getFieldsNames().addAll(fields);
        } else {
            boolean found = false;
            for (IndexInfo indexInfo : indexes) {
                if (name.equals(indexInfo.getName())) {
                    found = true;
                    List<String> t = new ArrayList<String>(indexInfo.getFieldsNames());
                    t.removeAll(fields);
                    indexInfo.getFieldsNames().addAll(fields);
                    //ignore configOrder
                    if (t.size() > 0) {
                        indexInfo.getUnique().setBetterValue(unique, configOrder);
                    }
                }
            }
            if (!found) {
                IndexInfo i = new IndexInfo();
                i.setName(null);
                i.getUnique().setBetterValue(unique, configOrder);
                i.getFieldsNames().addAll(fields);
            }
        }
    }

    @Override
    public String toString() {
        return "DecorationEntityDescriptor{" + "source=" + ((source instanceof Object[]) ? Arrays.toString((Object[]) source) : String.valueOf(source)) + '}';
    }

}
