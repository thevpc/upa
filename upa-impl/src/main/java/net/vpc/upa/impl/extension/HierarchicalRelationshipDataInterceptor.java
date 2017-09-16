package net.vpc.upa.impl.extension;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.impl.ext.persistence.EntityExecutionContextExt;
import net.vpc.upa.impl.uql.util.UQLCompiledUtils;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import net.vpc.upa.callbacks.EntityListenerAdapter;
import net.vpc.upa.callbacks.PersistEvent;
import net.vpc.upa.callbacks.UpdateEvent;
import net.vpc.upa.callbacks.UpdateFormulaEvent;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/6/13 12:09 AM
 */
public class HierarchicalRelationshipDataInterceptor extends EntityListenerAdapter {

    private Relationship relation;
    private HierarchicalRelationshipSupport support;

    public HierarchicalRelationshipDataInterceptor(Relationship defaultTreeEntityExtensionSupport) {
        super();
        this.relation = defaultTreeEntityExtensionSupport;
        support = (HierarchicalRelationshipSupport)relation.getHierarchyExtension();
    }

    @Override
    public void onPreUpdateFormula(UpdateFormulaEvent event) throws UPAException {
        EntityExecutionContext executionContext = event.getContext();
        Relationship r = relation;
        List<Field> fs = r.getSourceRole().getFields();
        Expression cond = new Equals(new Var(fs.get(0).getName()), Literal.NULL);
        if(event.getFilterExpression()!=null){
            cond = new And(cond, event.getFilterExpression());
        }
        List<Object> keys = relation.getSourceRole().getEntity().createQueryBuilder().byExpression(cond).getIdList();
        for (Object key : keys) {
            support.validatePathField(key, executionContext);
            support.validateChildren(key, executionContext);
        }
    }

    @Override
    public void onPersist(PersistEvent event) throws UPAException {
        Object parent_id = relation.extractId(event.getPersistedDocument());
        String path = support.getHierarchyPathSeparator() + support.toStringId(event.getPersistedId());
        String pathFieldName = support.getHierarchyPathField();
        Entity entity = relation.getSourceRole().getEntity();
        if (parent_id != null) {
            Document r = entity.createQueryBuilder().byExpression(entity.getBuilder().idToExpression(parent_id, UQLUtils.THIS)).setFieldFilter(FieldFilters.byName(pathFieldName)).getDocument();
            if (r != null) {
                path = r.getString(pathFieldName) + path;
            }
        }
        event.getPersistedDocument().setString(pathFieldName, path);
        EntityExecutionContext executionContext = event.getContext();

        EntityExecutionContextExt updateContext = (EntityExecutionContextExt) executionContext.getPersistenceUnit().getFactory().createObject(EntityExecutionContext.class);
        updateContext.initPersistenceUnit(executionContext.getPersistenceUnit(), executionContext.getPersistenceStore(), ContextOperation.UPDATE);

        Document u2 = entity.getBuilder().createDocument();
        u2.setString(pathFieldName, path);
        ((EntityExt)entity).updateCore(u2, entity.getBuilder().idToExpression(event.getPersistedId(), UQLUtils.THIS), updateContext);

        //context.getExecutionContext().getPersistenceStore().executeUpdate(new Update().entity(entity.getName()).set(pathFieldName, path).where(new KeyExpression(entity, insertedId, null)), executionContext2);
    }

    private List<Field> getUpdateTreeFields() {
        Relationship treeRelation = relation;
        List<Field> updateTreeFields = new ArrayList<Field>();
        switch (treeRelation.getSourceRole().getRelationshipUpdateType()) {
            case COMPOSED: {
                Field f = treeRelation.getSourceRole().getEntityField();
                if (f != null) {
                    updateTreeFields.add(f);
                }
                break;
            }
            case FLAT: {
                List<Field> fields = treeRelation.getSourceRole().getFields();
                if (fields != null) {
                    for (Field f : fields) {
                        updateTreeFields.add(f);
                    }
                }
                break;
            }
        }
        return updateTreeFields;
    }

    @Override
    public void onPreUpdate(UpdateEvent event)
            throws UPAException {
        EntityExecutionContext executionContext = event.getContext();

        List<Field> updateTreeFields = getUpdateTreeFields();
        Document updates = event.getUpdatesDocument();
        if (!updates.isSet(updateTreeFields.get(0).getName())) {
            return;
        }
        boolean valSet=updates.isSet(updateTreeFields.get(0).getName());
        if (valSet) {
            Object parentId = relation.extractId(updates);
            Entity entity = event.getEntity();
            String k = "recurse";
            if (!executionContext.isSet(k)) {
                List<Object> idList = entity.createQueryBuilder().byExpression(event.getFilterExpression()).orderBy(entity.getUpdateFormulasOrder()).getIdList();
                executionContext.setObject(k, idList);
            }
            List<Object> r = (List<Object>) executionContext.getObject("recurse");
            if(parentId!=null) {
                for (Object aR : r) {
                    if (support.isEqualOrIsParent(aR, parentId)) {
                        throw new UPAException("RedundancyProblem with id "+aR+" for Entity "+entity.getName());
                    }
                }
            }
        }
    }

    @Override
    public void onUpdate(UpdateEvent event)
            throws UPAException {
        EntityExecutionContext executionContext = event.getContext();
//        RelationRole detailRole = defaultTreeEntityExtensionSupport.getTreeRelation().getSourceRole();
//        if (!map.isSet(detailRole.getField(0).getName())) {
//            return;
//        }
        List<Field> updateTreeFields = getUpdateTreeFields();
        if (!event.getUpdatesDocument().isSet(updateTreeFields.get(0).getName())) {
            return;
        }
        List<Object> r = (List<Object>) executionContext.getObject("recurse");
        if (r != null) {
            for (Object aR : r) {
                support.validatePathField(aR, executionContext);
                support.validateChildren(aR, executionContext);
            }
        }
    }
}
