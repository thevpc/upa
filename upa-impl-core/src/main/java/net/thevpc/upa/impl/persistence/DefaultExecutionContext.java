package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.*;
import net.thevpc.upa.persistence.*;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.DefaultProperties;
import net.thevpc.upa.impl.ext.persistence.EntityExecutionContextExt;
import net.thevpc.upa.persistence.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.types.DataType;

public class DefaultExecutionContext extends DefaultProperties implements EntityExecutionContextExt {

    private ContextOperation contextOperation;
    private Entity currentEntity;
    private PersistenceUnit persistenceUnit;
    private PersistenceStore persistenceStore;
    private EntityOperationManager entityOperationManager;
    private Map<String, Object> values;
    private LinkedHashMap<String, Parameter> generatedValues = new LinkedHashMap<String, Parameter>();
    private Map<String, Object> hints;
    private Document updateDocument;
    private UpdateQuery updateQuery;

    public DefaultExecutionContext() {
    }

    public void initPersistenceUnit(PersistenceUnit persistenceUnit, PersistenceStore persistenceStore, ContextOperation contextOperation) {
        this.persistenceUnit = persistenceUnit;
        this.contextOperation = contextOperation;
        this.persistenceStore = persistenceStore;
    }

    @Override
    public void setUpdateDocument(Document updateDocument) {
        this.updateDocument = updateDocument;
    }

    @Override
    public void setUpdateQuery(UpdateQuery updateQuery) {
        this.updateQuery = updateQuery;
    }

    @Override
    public Document getUpdateDocument() {
        return updateDocument;
    }

    @Override
    public UpdateQuery getUpdateQuery() {
        return updateQuery;
    }

    @Override
    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    @Override
    public UConnection getConnection() {
        return getPersistenceUnit().getConnection();
    }

    @Override
    public Session getSession() {
        return getPersistenceUnit().getCurrentSession();
    }

    public Entity getEntity() {
        return currentEntity;
    }

    @Override
    public void initEntity(Entity currentEntity, EntityOperationManager entityOperationManager) {
        this.currentEntity = currentEntity;
        this.entityOperationManager = entityOperationManager;
    }

    public Map<String, Object> getValues() {
        if (this.values == null) {
            values = new HashMap<String, Object>();
        }
        return values;
    }

    public PersistenceStore getPersistenceStore() {
        return persistenceStore;
    }

    public EntityOperationManager getEntityOperationManager() {
        return entityOperationManager;
    }

    @Override
    public ContextOperation getOperation() {
        return contextOperation;
    }

    public void addGeneratedValue(String name, DataType type) {
        if (generatedValues.containsKey(name)) {
            throw new IllegalUPAArgumentException("GeneratedValue already exists " + name);
        }
        generatedValues.put(name, new DefaultParameter(name, null, IdentityDataTypeTransform.ofType(type)));
    }

    public void removeGeneratedValue(Parameter parameter) {
        generatedValues.remove(parameter.getName());
    }

    public List<Parameter> getGeneratedValues() {
        return new ArrayList<Parameter>(generatedValues.values());
    }

    @Override
    public Parameter getGeneratedValue(String name) {
        return generatedValues.get(name);
    }

    @Override
    public Map<String, Object> getHints() {
        return hints;
    }

    public Object getHint(String hintName) {
        return hints==null?null:hints.get(hintName);
    }

    public Object getHint(String hintName,Object defaultValue) {
        Object c = hints == null ? null : hints.get(hintName);
        return c==null?defaultValue:c;
    }


    public EntityExecutionContext resetHints() {
        if(hints!=null){
            hints.clear();
        }
        hints=null;
        return this;
    }

    public EntityExecutionContext setHint(String name, Object value) {
        if(value==null){
            if (hints != null) {
                hints.remove(name);
            }
        }else {
            if (hints == null) {
                hints = new HashMap<String, Object>();
            }
            hints.put(name,value);
        }
        return this;
    }

    public EntityExecutionContext setHints(Map<String, Object> hints) {
        if(hints!=null) {
            for (Map.Entry<String, Object> e : hints.entrySet()) {
                setHint(e.getKey(),e.getValue());
            }
        }
        return this;
    }
}
