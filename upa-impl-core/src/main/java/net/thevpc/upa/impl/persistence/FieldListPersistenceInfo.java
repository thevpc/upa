package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.PersistenceStore;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.impl.EntityTypeFieldPersister;
import net.thevpc.upa.impl.transform.PasswordTypeFieldPersister;
import net.thevpc.upa.impl.SimpleFieldPersister;

import java.util.*;
import net.thevpc.upa.impl.AbstractField;
import net.thevpc.upa.impl.util.UPAUtils;

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
            if (field.isManyToOne()) {
                ((AbstractField) field).setFieldPersister(new EntityTypeFieldPersister());
            } else if (UPAUtils.isPasswordTransform(field.getEffectiveTypeTransform())) {
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
