/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.vpc.upa.*;
import net.vpc.upa.bulk.ImportEntityFinder;
import net.vpc.upa.bulk.ImportEntityMapper;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.And;
import net.vpc.upa.expressions.Equals;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.extensions.HierarchyExtension;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultImportEntityFinder implements ImportEntityFinder, ImportEntityMapper {

    public Map<String, Object> valueToMap(Entity entity, Object value) {
        List<HierarchyExtension> c = new ArrayList<HierarchyExtension>();
        for (Relationship relation : entity.getRelationships()) {
            if(relation instanceof ManyToOneRelationship) {
                ManyToOneRelationship m=(ManyToOneRelationship) relation;
                if (m.getHierarchyExtension() != null) {
                    c.add(m.getHierarchyExtension());
                }
            }
        }
        if (c.isEmpty()) {
            List<Index> indexes = entity.getIndexes(true);
            if (indexes.isEmpty()) {
                throw new IllegalUPAArgumentException("No Index found for entity " + entity);
            }
            for (Index index : indexes) {
                String[] indexedFieldNames = index.getFieldNames();
                if (indexedFieldNames.length == 1) {
                    Map<String, Object> m = new HashMap<String, Object>();
                    m.put(indexedFieldNames[0], value);
                    return m;
                }
            }
            throw new IllegalUPAArgumentException("Unsupported Multiple Field Index on import");

        } else {
            Map<String, Object> map = new HashMap<String, Object>();
            String v = String.valueOf(value == null ? "" : value);
            if (v.startsWith("/")) {
                v = v.substring(1);
            }
            if (v.contains("/")) {
                int i = v.lastIndexOf('/');
                map.put(entity.getMainField().getName(), v.substring(i + 1));
                map.put(c.get(0).getTreeRelationship().getSourceRole().getEntityField().getName(), v.subSequence(0, i));
            } else {
                map.put(entity.getMainField().getName(), value);
            }
            return map;
        }
    }

    public Object findEntity(Entity entity, Map<String, Object> values) {
        List<HierarchyExtension> c = new ArrayList<HierarchyExtension>();
        for (Relationship relation : entity.getRelationships()) {
            if(relation instanceof ManyToOneRelationship) {
                ManyToOneRelationship m = (ManyToOneRelationship) relation;
                if (m.getHierarchyExtension() != null) {
                    c.add(m.getHierarchyExtension());
                }
            }
        }
        if (c.isEmpty()) {
            List<Index> indexes = entity.getIndexes(true);
            for (Index index : indexes) {
                Expression expr = null;
                String[] indexedFieldNames = index.getFieldNames();
                for (String f : indexedFieldNames) {
                    Equals e = new Equals(new Var(new Var(entity.getName()), f), values.get(f));
                    expr = (expr == null) ? e : new And(expr, e);
                }
                return entity.createQueryBuilder().byExpression(expr).getFirstResultOrNull();
            }
            return null;
        } else {
            HierarchyExtension extension = c.get(0);
            RelationshipRole detailRole = extension.getTreeRelationship().getSourceRole();
            String parentFieldName = detailRole.getEntityField().getName();
            Object parent = values.get(parentFieldName);
            String mainFieldName = entity.getMainField().getName();
            if (parent != null && (parent instanceof String)) {
                parent = extension.findEntityByMainPath(String.valueOf(parent));
            }
            Expression expr = null;
            expr = new Equals(new Var(new Var(entity.getName()), mainFieldName), values.get(mainFieldName));
            Key entityToKey = parent == null ? null : entity.getBuilder().objectToKey(parent);
            List<Field> primaryFields = detailRole.getFields();
            for (int index = 0; index < primaryFields.size(); index++) {
                Field field = primaryFields.get(index);
                expr = new And(expr, new Equals(new Var(new Var(entity.getName()), field.getName()), entityToKey == null ? null : entityToKey.getObjectAt(index)));
            }
            return entity.createQueryBuilder().byExpression(expr).getFirstResultOrNull();
        }
    }

    public boolean accept(Entity entity) {
        return true;
    }
}
