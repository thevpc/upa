package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.impl.EntityTypeFieldPersister;
import net.vpc.upa.impl.transform.PasswordTypeFieldPersister;
import net.vpc.upa.impl.SimpleFieldPersister;
import net.vpc.upa.persistence.PersistenceStore;

import java.util.*;
import net.vpc.upa.impl.AbstractField;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.EntityType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 11:21 PM
 */
public class FieldListPersistenceInfo {

    public Entity entity;
    public PersistenceStore persistenceStore;
    public Map<String, FieldPersistenceInfo> fields = new LinkedHashMap<String, FieldPersistenceInfo>();
    public List<FieldPersistenceInfo> persistSequenceGeneratorFields = new ArrayList<FieldPersistenceInfo>();
    public List<FieldPersistenceInfo> updateSequenceGeneratorFields = new ArrayList<FieldPersistenceInfo>();
    public List<FieldPersistenceInfo> insertExpressions = new ArrayList<FieldPersistenceInfo>();
    public List<FieldPersistenceInfo> updateExpressions = new ArrayList<FieldPersistenceInfo>();

    public void update() {
        Set<String> visited = new HashSet<String>();
        persistSequenceGeneratorFields.clear();
        updateSequenceGeneratorFields.clear();
        insertExpressions.clear();
        updateExpressions.clear();
        List<Field> fields1 = entity.getFields();
        for (Field field : fields1) {
            visited.remove(field.getName());
            FieldPersistenceInfo fieldPersistenceInfo = fields.get(field.getName());
            if (fieldPersistenceInfo == null) {
                fieldPersistenceInfo = new FieldPersistenceInfo();
                fields.put(field.getName(), fieldPersistenceInfo);
            }
            fieldPersistenceInfo.field = field;
            fieldPersistenceInfo.persistenceStore = persistenceStore;
            fieldPersistenceInfo.synchronize();
            if (fieldPersistenceInfo.persistFieldPersister != null) {
                persistSequenceGeneratorFields.add(fieldPersistenceInfo);
            }
            if (fieldPersistenceInfo.updateFieldPersister != null) {
                updateSequenceGeneratorFields.add(fieldPersistenceInfo);
            }
            if (fieldPersistenceInfo.insertExpression != null) {
                insertExpressions.add(fieldPersistenceInfo);
            }
            if (fieldPersistenceInfo.updateExpression != null) {
                updateExpressions.add(fieldPersistenceInfo);
            }
            if (field.getDataType() instanceof EntityType) {
                ((AbstractField) field).setFieldPersister(new EntityTypeFieldPersister());
            } else if (UPAUtils.isPasswordTransform(UPAUtils.getTypeTransformOrIdentity(field))) {
                ((AbstractField) field).setFieldPersister(new PasswordTypeFieldPersister());
            } else {
                ((AbstractField) field).setFieldPersister(new SimpleFieldPersister());
            }
        }
        for (String r : visited) {
            fields.remove(r);
        }
    }

}
