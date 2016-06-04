/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;

import net.vpc.upa.*;
import net.vpc.upa.expressions.Delete;
import net.vpc.upa.filters.EntityFilter;
import net.vpc.upa.impl.transform.PasswordDataTypeTransform;
import net.vpc.upa.types.EntityType;
import net.vpc.upa.bulk.ImportPersistenceUnitListener;

/**
 *
 * @author vpc
 */
public class PersistenceUnitImporter {

    private static class ExecInfo {

        EntityFilter filter;
        ImportPersistenceUnitListener listener;
        PersistenceUnit source;
        PersistenceUnit target;
        boolean deleteExisting;
        SyncStat globalStat = new SyncStat();
        Map<String, SyncStat> stats = new TreeMap<String, SyncStat>();
        List<Entity> entities;
        Set<String> finishedEntities=new HashSet<String>();
        public SyncStat getStat(String entityName){
            SyncStat s = stats.get(entityName);
            if(s==null){
                s=new SyncStat();
                stats.put(entityName, s);
            }
            return s;
        }
    }

    public void importObjectById(PersistenceUnit source, PersistenceUnit target, String entityName, int sourceId, ImportPersistenceUnitListener listener) {
        ExecInfo ii = new ExecInfo();
//        ii.filter = filter;
        ii.listener = listener;
//        ii.entities = source.getEntities(filter);
        importObjectById(entityName, sourceId, ii);
    }

    public void importEntity(PersistenceUnit source, PersistenceUnit target, String entityName, boolean deleteExisting, ImportPersistenceUnitListener listener) {
        ExecInfo ii = new ExecInfo();
        ii.source = source;
        ii.target = target;
        ii.deleteExisting = deleteExisting;
//        ii.filter = filter;
        ii.listener = listener;
//        ii.entities = source.getEntities(filter);
        importEntity(entityName, -1, ii);
    }

    public void importEntities(PersistenceUnit source, PersistenceUnit target, EntityFilter filter, boolean deleteExisting,ImportPersistenceUnitListener listener) {
        ExecInfo ii = new ExecInfo();
        ii.source = source;
        ii.target = target;
        ii.filter = filter;
        ii.listener = listener;
        ii.deleteExisting = deleteExisting;
        ii.entities = source.getEntities(filter);

//        importEntity("Equipment", 0);
//        importObject(new Obj("Equipment", source.findById("Equipment", 555)), true, true, true, "");
//        importObject(new Obj("AppUserProfileBinding", source.findById("AppUserProfileBinding", 1)), true, true, true, "");
//        importObject(new Obj("AppUser", source.findById("AppUser", 1)), true, true, true, "");
//        importObjectById("AcademicTeacherSemestrialLoad", 39);
//        importEntity("AcademicTeacherSemestrialLoad", 39);
        importEntities(ii);

//        importEntities();
    }

    private void importEntities(ExecInfo ii) {
        if(ii.deleteExisting){
            for (int j = 0; j < ii.entities.size(); j++) {
                ii.target.remove(ii.entities.get(j).getName(), RemoveOptions.forAll());
//                ii.source.createQuery((new Delete()).from(ii.entities.get(j).getName()))
//                        .executeNonQuery();
            }
        }
        for (int j = 0; j < ii.entities.size(); j++) {
            importEntity(ii.entities.get(j).getName(), j, ii);
        }
        for (Map.Entry<String, SyncStat> entry : ii.stats.entrySet()) {
            System.out.println(entry.getKey() + " : " + entry.getValue().debugString());
        }
        System.out.println("GLOBAL" + " : " + ii.globalStat.debugString());
    }

    private void importEntity(String entityName, int index, ExecInfo ii) {
        Entity de = ii.source.getEntity(entityName);
        String tab_progress = (index + 1) + "/" + ii.entities.size();
        SyncStat estat = ii.getStat(de.getName());
        System.out.println(">> " + tab_progress + " : copying " + de);
        Entity me = ii.target.getEntity(de.getName());
        List<Object> a = de.findAllIds();
        for (int i = 0; i < a.size(); i++) {
            Object ob = a.get(i);
            System.out.println(">>\t " + tab_progress + "-" + ((i + 1) + "/" + a.size()) + " : " + de);
            importObjectById(me.getName(), ob, ii);
        }
        ii.finishedEntities.add(entityName);
        System.out.println(">>>>>> " + de.getName() + " : " + estat.debugString());
    }

    private static Object resolveId(String entityName, Object t, PersistenceUnit pu) {
        Entity entity = pu.getEntity(entityName);
        if (t instanceof Record) {
            return entity.getBuilder().recordToId((Record) t);
        }
        return entity.getBuilder().objectToId(t);

    }

    private static class Obj {

        String name;
        Object value;

        public Obj(String name, Object value) {
            this.name = name;
            this.value = value;
        }

    }

    private static class SyncStat {

        long validMerges;
        long validPersists;
        long erronousPersists;
        long erronousMerges;

        public void add(SyncStat o) {
            validMerges += o.validMerges;
            validPersists += o.validPersists;
            erronousPersists += o.erronousPersists;
            erronousMerges += o.erronousMerges;
        }

        public String debugString() {
            StringBuilder sb = new StringBuilder();
            sb.append("persists : " + (validPersists + erronousPersists) + "=" + validPersists + "ok + " + erronousPersists + "ko");
            sb.append(" ;; ");
            sb.append("merges   : " + (validMerges + erronousMerges) + "=" + validMerges + "ok + " + erronousMerges + "ko");
            return sb.toString();
        }

    }

    private static class UniqueValue {

        String[] properties;
        Object[] values;
    }

    public static UniqueValue[] resolveUnique(String entityName, Object t, PersistenceUnit pu) {
        Entity entity = pu.getEntity(entityName);
        List<UniqueValue> uniques = new ArrayList<UniqueValue>();
        for (Index idx : entity.getIndexes(true)) {
            UniqueValue u = new UniqueValue();
            u.properties = idx.getFieldNames();
            u.values = new Object[u.properties.length];
            for (int i = 0; i < u.properties.length; i++) {
                String property = u.properties[i];
                u.values[i] = entity.getBuilder().getRecord(t, true).getObject(property);
            }
            uniques.add(u);
        }
        return uniques.toArray(new UniqueValue[uniques.size()]);
    }

    private Map<String, Obj> getNonNullRelations(String entityName, Object instance, PersistenceUnit target) {
        Entity entity = target.getEntity(entityName);
        Map<String, Obj> t = new HashMap<String, Obj>();
        EntityBuilder bb = entity.getBuilder();
        for (Field field : entity.getFields()) {
            if (field.getDataType() instanceof EntityType) {
                EntityType g = (EntityType) field.getDataType();
                Entity rr = target.getEntity(g.getReferencedEntityName());
                Object v2 = bb.getProperty(instance, field.getName());
                if (v2 != null) {
                    t.put(field.getName(), new Obj(rr.getName(), v2));
                } else {
                    //try foreigns
                    List<Field> rfields = g.getRelationship().getSourceRole().getFields();
                    for (Field rfield : rfields) {
                        Object v3 = bb.getProperty(instance, rfield.getName());
                        if (v3 != null) {
                            t.put(rfield.getName(), new Obj(rr.getName(), v3));
                        }
                    }
                }
            }
        }
        return t;
    }

    private Object loadSourceObject(String type, Object id, PersistenceUnit source) {
        Entity entity = source.getEntity(type);
        QueryBuilder queryBuilder = entity.createQueryBuilder();
        for (Field field : entity.getFields()) {
            if(field.getTypeTransform() instanceof PasswordDataTypeTransform){
                queryBuilder.setHint("NoTypeTransform." + field.getAbsoluteName(), true);
            }
        }
        Object reloaded = queryBuilder.setHint("navigationDepth", 1).setId(id).getEntity();
        return reloaded;
    }

    private Object loadTargetObject(String type, Object id, PersistenceUnit target) {
        Entity entity = target.getEntity(type);
//        Object reloaded = entity.createQueryBuilder().setHint("navigationDepth", 1).setId(id).getEntity();
        Object reloaded0 = entity.createQueryBuilder().setHint("navigationDepth", 0).setId(id).getRecord();
//        Object reloaded1 = entity.createQueryBuilder().setHint("navigationDepth", 1).setId(id).getRecord();
        return reloaded0;
    }

//    public Obj reloadSourceObject(Obj oo) {
//        Entity entity = source.getEntity(oo.name);
//        Object id = resolveId(entity.getName(), oo.value, source);
//        Object reloaded = entity.createQueryBuilder().setHint("navigationDepth", 1).setId(id).getEntity();
//        return new Obj(oo.name, reloaded);
//    }
//
//    public Obj reloadTargetObject(Obj oo) {
//        Entity entity = target.getEntity(oo.name);
//        Object id = resolveId(entity.getName(), oo.value, source);
//        Object reloaded = entity.createQueryBuilder().setHint("navigationDepth", 1).setId(id).getEntity();
//        return new Obj(oo.name, reloaded);
//    }
    private Object importObjectById(String type, Object id, ExecInfo ii) {
        return importObjectById(type, id, true, true, true, "", ii);
    }

    private Object importObjectById(String entityName, Object id, boolean importRelations, boolean allowPersist, boolean allowMerge, String prefix, ExecInfo ii) {
//        return importObject(new Obj(type, source.findById(type, id)), importRelations, allowPersist, allowMerge,  prefix);
//    }
//    public Object importObject(Obj oo, boolean importRelations, boolean allowPersist, boolean allowMerge, String prefix) {
        Entity entity = ii.target.getEntity(entityName);
        EntityBuilder eb = entity.getBuilder();
        Object instance0 = loadSourceObject(entityName, id, ii.source);
        Object instance = (instance0 instanceof Record) ? eb.copyRecord((Record) instance0) : eb.copyObject(instance0);
        System.out.println(">>>>\t\t" + prefix + " import" + (importRelations ? " " : "*") + " " + entityName + " : " + id + " = " + instance);
        SyncStat istat = new SyncStat();
        Boolean persist = null;
        for (UniqueValue uniqueValue : resolveUnique(entityName, instance, ii.target)) {
            QueryBuilder b = entity.createQueryBuilder();
            for (int i = 0; i < uniqueValue.properties.length; i++) {
                b.addAndField(uniqueValue.properties[i], uniqueValue.values[i]);
            }
            Object foundObject = b.getEntity();
            Object id2 = resolveId(entityName, foundObject, ii.target);
            if (foundObject == null) {
                //do nothing
            } else {
                id = id2;
                break;
            }
        }
        if (persist == null) {
            persist = !entity.existsById(id);
        }
//        if (oldId == null) {
//            persist = true;
//        } else if (pf.size() <= 1) {
//            DataType dt = pf.get(0).getDataType();
//            if (dt instanceof EntityType) {
//                persist = !entity.existsById(oldId);
//            } else if (pf.size() == 1 && pf.get(0).getModifiers().contains(FieldModifier.PERSIST_SEQUENCE)) {
//                //persist = Objects.equals(dt.getDefaultUnspecifiedValue(), oldId);
//                persist = !entity.existsById(oldId);
//            } else {
//                persist = !entity.existsById(oldId);
//            }
//        } else {
//        }
        if (persist) {
            if (allowPersist) {
                if (importRelations) {
                    Map<String, Obj> rels = getNonNullRelations(entityName, instance, ii.target);
                    for (Map.Entry<String, Obj> mm : rels.entrySet()) {
                        Obj or = mm.getValue();
                        Object oldId2 = resolveId(or.name, or.value, ii.target);
                        Object n = importObjectById(or.name, oldId2, importRelations, true, false, prefix + "\t", ii);
                        if (n instanceof Record) {
                            n = ii.target.getEntity(or.name).getBuilder().recordToObject((Record) n);
                        }
                        eb.setProperty(instance, mm.getKey(), n);
                    }
                }
                try {
                    ii.target.setIdentityConstraintsEnabled(entity, false);
                    ii.target.persist(entityName, instance);
                    ii.target.setIdentityConstraintsEnabled(entity, true);
                    istat.validPersists++;
                    if (ii.listener != null) {
                        ii.listener.objectPersisted(entityName, instance0, instance);
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                    istat.erronousPersists++;
                    if (ii.listener != null) {
                        ii.listener.objectPersistFailed(entityName, instance0, instance, ex);
                    }
                }
            }
        } else if (allowMerge) {
            if (importRelations) {
                Map<String, Obj> rels = getNonNullRelations(entityName, instance, ii.target);
                for (Map.Entry<String, Obj> mm : rels.entrySet()) {
                    Obj or = mm.getValue();
                    Object oldId2 = resolveId(or.name, or.value, ii.target);
                    Object n = importObjectById(or.name, oldId2, false, true, false, prefix + "\t", ii);
                    if (n instanceof Record) {
                        n = ii.target.getEntity(or.name).getBuilder().recordToObject((Record) n);
                    }
                    eb.setProperty(instance, mm.getKey(), n);
                }
            }
            try {
                ii.target.merge(entityName, instance);
                istat.validMerges++;
                if (ii.listener != null) {
                    ii.listener.objectMerged(entityName, instance0, instance);
                }
            } catch (Exception ex) {
                istat.erronousMerges++;
                ex.printStackTrace();
                if (ii.listener != null) {
                    ii.listener.objectMergeFailed(entityName, instance0, instance, ex);
                }
            }
        } else {
            instance = loadTargetObject(entityName, id, ii.target);
        }

        ii.globalStat.add(istat);
        ii.getStat(entityName).add(istat);
        return instance;
    }

}
