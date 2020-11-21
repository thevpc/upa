/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import net.thevpc.upa.*;
import net.thevpc.upa.Package;
import net.thevpc.upa.exceptions.*;
import net.thevpc.upa.impl.ext.EntityExt;
import net.thevpc.upa.impl.ext.PersistenceUnitExt;
import net.thevpc.upa.impl.util.NamingStrategyHelper;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.UPAUtils;

import net.thevpc.upa.exceptions.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultPersistenceUnitRegistrationModel implements ObjectRegistrationModel {

    private LinkedHashMap<String, Entity> entities = new LinkedHashMap<String, Entity>();
    private LinkedHashMap<String, Package> packages = new LinkedHashMap<String, Package>();
    private LinkedHashMap<String, Relationship> relations = new LinkedHashMap<String, Relationship>();
    private LinkedHashMap<String, Index> indexes = new LinkedHashMap<String, Index>();
    private LinkedHashMap<String, Field> fields = new LinkedHashMap<String, Field>();
    private LinkedHashMap<String, Section> sections = new LinkedHashMap<String, Section>();
    private PersistenceUnitExt unit;
    private HashSet<Class> entityByEntityTypeAmbiguity = new HashSet<Class>();
    private HashMap<Class, Entity> entityByEntityType = new HashMap<Class, Entity>();
    private HashSet<Class> entityByIdTypeAmbiguity = new HashSet<Class>();
    private HashMap<Class, Entity> entityByIdType = new HashMap<Class, Entity>();
    private Map<String, List<Index>> indexesByEntity = new HashMap<String, List<Index>>();
//    private Map<String, Relationship> cache_relationsByName;

    public DefaultPersistenceUnitRegistrationModel(PersistenceUnitExt unit) {
        this.unit = unit;
    }

    public void renameEntity(String oldName,String newName) {
        oldName = uniformName(oldName);
        newName = uniformName(newName);
        Entity item = entities.remove(oldName);
        if(item!=null){
            entities.put(newName,item);
        }
    }

    public void registerPackage(Package item, Package parent) {
        String s = null;
        if (parent == null) {
            s = "/" + item.getName();
        } else {
            s = parent.getPath() + "/" + item.getName();
        }
        packages.put(s, item);
    }

    public boolean containsPackage(Package item, Package parent) {
        String s = null;
        if (parent == null) {
            s = "/" + item.getName();
        } else {
            s = parent.getPath() + "/" + item.getName();
        }
        return (packages.containsKey(s));
    }

    public void unregisterPackage(Package item) {
        String s = item.getPath();
        packages.remove(s);
    }

    public boolean containsEntity(Entity item, Package parent) {
        String s = uniformName(item.getName());
        return (entities.containsKey(s));
    }
    private String uniformName(String name){
        return NamingStrategyHelper.getUniformValue(unit.isCaseSensitiveIdentifiers(),name);
    }

    public void registerEntity(Entity item, Package parent) {
        String s = uniformName(item.getName());
        Entity entity = item;
        entities.put(s, item);

        Class<?> entityType = entity.getEntityType();
        if (!entityByEntityTypeAmbiguity.contains(entityType)) {
            if (entityByEntityType.containsKey(entityType)) {
                entityByEntityType.remove(entityType);
                entityByEntityTypeAmbiguity.add(entityType);
            } else {
                entityByEntityType.put(entityType, entity);
            }
        }

        Class<?> idType = PlatformUtils.toRefType(entity.getIdType());
        if (!entityByIdTypeAmbiguity.contains(idType)) {
            if (entityByIdType.containsKey(idType)) {
                entityByIdType.remove(idType);
                entityByIdTypeAmbiguity.add(idType);
            } else {
                entityByIdType.put(idType, entity);
            }
        }
    }

    public void unregisterEntity(Entity item) {
        String s =  NamingStrategyHelper.getUniformValue(unit.isCaseSensitiveIdentifiers(),item.getName());
        entities.remove(s);
    }

    public void registerSection(Section item) {
        Entity entity = item.getEntity();
        Package module = entity.getParent();
        String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + item.getPath();
        sections.put(s, item);
    }

    public boolean containsSection(Section item) {
        Entity entity = item.getEntity();
        Package module = entity.getParent();
        String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + item.getPath();
        return (sections.containsKey(s));
    }

    public void unregisterSection(Section item) {
        Entity entity = item.getEntity();
        Package module = entity.getParent();
        String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + item.getPath();
        sections.remove(s);
    }

    public void registerField(Field item) {
        EntityExt entity = (EntityExt) item.getEntity();
        Package module = entity.getParent();
        String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + item.getName();
        fields.put(s, item);
        entity.registerField((Field) item);
    }

    public void unregisterField(Field item) {
        Entity entity = item.getEntity();
        Package module = entity.getParent();
        String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + item.getName();
        fields.remove(s);
    }

    public void registerIndex(Index item, Entity entity) {
        String s = item.getName();
        indexes.put(s, item);
        List<Index> indexesByEnt = indexesByEntity.get(item.getEntity().getName());
        if (indexesByEnt == null) {
            indexesByEnt = new ArrayList<Index>();
            indexesByEntity.put(item.getEntity().getName(), indexesByEnt);

        }
        indexesByEnt.add(item);
    }

    public void unregisterIndex(Index item) {
        String s = item.getName();
        indexes.remove(s);
        List<Index> indexesByEnt = indexesByEntity.get(item.getEntity().getName());
        indexesByEnt.remove(item);
    }

    public void registerRelationship(Relationship item) {
        String s = item.getName();
        relations.put(s, item);
    }

    public boolean containsRelationship(Relationship item) {
        String s = item.getName();
        return (relations.containsKey(s));
    }

    public void unregisterRelation(Relationship item) {
        String s = item.getName();
        relations.remove(s);
    }

    public List<Entity> getEntities() {
        return new ArrayList<Entity>(entities.values());
    }

    public List<Index> getIndexes() {
        return new ArrayList<Index>(indexes.values());
    }

    public List<Package> getPackages() {
        return new ArrayList<Package>(packages.values());
    }

    public List<Relationship> getRelationships() {
        return new ArrayList<Relationship>(relations.values());
    }

    public List<Field> getFields() {
        return new ArrayList<Field>(fields.values());
    }

    public List<Index> getIndexes(String entityName) throws UPAException {
        List<Index> a = new ArrayList<Index>();
        List<Index> currIndexes = indexesByEntity.get(entityName);
        if (currIndexes != null) {
            for (Index index : currIndexes) {
                a.add(index);
            }
        }
        return a;
    }

    public Index getIndex(String name) throws UPAException {
        Index item = indexes.get(name);
        if (item == null) {
            throw new NoSuchIndexException(null, name, null);
        }
        return item;
    }

    public Entity getEntity(String name) throws UPAException {
        String s = name;
        name = NamingStrategyHelper.getUniformValue(unit.isCaseSensitiveIdentifiers(),s);

        Entity item = entities.get(name);
        if (item == null) {
            throw new NoSuchEntityException(s);
        }
        return item;
    }

    public Entity findEntity(String name) throws UPAException {
        return entities.get(uniformName(name));
    }

    public Relationship findRelationship(String name) throws UPAException {
        return relations.get(name);
    }

    public Relationship getRelationship(String name) throws UPAException {
        Relationship item = relations.get(name);
        if (item == null) {
            throw new NoSuchRelationshipException(name, null);
        }
        return item;
    }

    public Entity getEntityByIdType(Class idType) throws UPAException {
        idType=PlatformUtils.toRefType(idType);
        Entity entity = entityByIdType.get(idType);
        if (entity != null) {
            return entity;
        }
        if (entityByIdTypeAmbiguity.contains(idType)) {
            throw new MultipleEntityMatchForTypeException(entityByIdTypeAmbiguity.toArray(new Class[0])[0], new String[0]);
        }
        throw new NoSuchEntityException(idType.getName());
    }

    public boolean containsField(Field item) {
        Entity entity = item.getEntity();
        Package module = entity.getParent();
        String s = (module == null ? "/" : module.getPath() + "/") + entity.getName() + "/" + item.getName();
        return (fields.containsKey(s));
    }

    public boolean containsEntity(String entityName) throws UPAException {
        return entities.containsKey(entityName);
    }

    public boolean containsEntity(Class entityType) throws UPAException {
        if(entityType==null){
            return false;
        }
        entityType= UPAUtils.getUserClass(entityType);
        if (entityType == null) {
            return false;
        }
        Entity entity = entityByEntityType.get(entityType);
        if (entity != null) {
            return true;
        }
        if (entityByEntityTypeAmbiguity.contains(entityType)) {
            HashSet<String> entityNamesSet = new HashSet<String>();
            for (Entity entity2 : getEntities()) {
                if (entity2.getEntityType().equals(entityType)) {
                    entityNamesSet.add(entity2.getName());
                }
            }
            return true;
        }
        return false;
    }

    public boolean containsIndex(Index item, Entity parent) {
        return indexes.containsKey(item.getName());
    }

    public List<Entity> findEntities(Class entityType) throws UPAException {
        List<Entity> all = new ArrayList<Entity>();
        if (entityType == null) {
            return all;
        }
        entityType=UPAUtils.getUserClass(entityType);
        if (entityType == null) {
            return null;
        }
        Entity entity = entityByEntityType.get(entityType);
        if (entity != null) {
            all.add(entity);
        }
        if (entityByEntityTypeAmbiguity.contains(entityType)) {
            for (Entity entity2 : getEntities()) {
                if (entity2.getEntityType().equals(entityType)
                        && (entity == null
                        || !entity2.getName().equals(entity.getName()))) {
                    all.add(entity2);
                }
            }
        }
        return all;
    }

    public Entity findEntity(Class entityType) throws UPAException {
        if (entityType == null) {
            return null;
        }
        entityType=UPAUtils.getUserClass(entityType);
        if (entityType == null) {
            return null;
        }
        Entity entity = entityByEntityType.get(entityType);
        if (entity != null) {
            return entity;
        }
        if (entityByEntityTypeAmbiguity.contains(entityType)) {
            HashSet<String> entityNames = new HashSet<String>();
            for (Entity entity2 : getEntities()) {
                if (entity2.getEntityType().equals(entityType)) {
                    entityNames.add(entity2.getName());
                }
            }
            throw new MultipleEntityMatchForTypeException(entityType, entityNames.toArray(new String[entityNames.size()]));
        }
        return null;
    }

    public Entity getEntity(Class entityType) throws UPAException {
        Entity e = findEntity(entityType);
        if (e == null) {
            throw new NoSuchEntityException(entityType == null ? "<null>" : entityType.getName());
        }
        return e;
    }
}
