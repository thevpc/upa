package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Document;
import net.thevpc.upa.MultiDocument;
import net.thevpc.upa.Query;
import net.thevpc.upa.QueryBuilder;
import net.thevpc.upa.exceptions.NoResultException;
import net.thevpc.upa.exceptions.NonUniqueResultException;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.util.UPAUtils;

import java.util.Date;
import java.util.List;
import java.util.Map;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
 * this template use File | Settings | File Templates.
 */
public abstract class AbstractQueryBuilder implements QueryBuilder {

    private boolean updatable = false;
    private Query adapted = null;

    @Override
    public Date getDate() throws UPAException {
        return (Date) getSingleValue();
    }

    @Override
    public Boolean getBoolean() throws UPAException {
        return (Boolean) getSingleValue();
    }

    @Override
    public Integer getInteger() throws UPAException {
        Number n = (Number) getSingleValue();
        return n == null ? null : n.intValue();
    }

    @Override
    public Long getLong() throws UPAException {
        Number n = (Number) getSingleValue();
        return n == null ? null : n.longValue();
    }

    @Override
    public Double getDouble() throws UPAException {
        Number n = (Number) getSingleValue();
        return n == null ? null : n.doubleValue();
    }

    @Override
    public String getString() throws UPAException {
        return (String) getSingleValue();
    }

    @Override
    public Number getNumber() throws UPAException {
        return (Number) getSingleValue();
    }

    @Override
    public Object getSingleValue() throws UPAException {
        return getSingleValue(null);
    }

    @Override
    public Object getSingleValue(Object defaultValue) throws UPAException {
        Document mergedDocument = getDocument();
        if (mergedDocument == null) {
            return defaultValue;
        }
        return mergedDocument.getSingleResult();
    }

    @Override
    public MultiDocument getMultiDocument() throws UPAException {
        List<MultiDocument> multiDocumentList = null;
        try {
            multiDocumentList = getMultiDocumentList();
            if (!multiDocumentList.isEmpty()) {
                return multiDocumentList.get(0);
            }
            return null;
        } finally {
            UPAUtils.close(multiDocumentList);
        }
    }

    @Override
    public Document getDocument() throws UPAException {
        List<Document> multiDocumentList = null;
        try {
            multiDocumentList = getDocumentList();
            boolean empty = multiDocumentList.isEmpty();
            if (!empty) {
                return multiDocumentList.get(0);
            }
            return null;
        } finally {
            UPAUtils.close(multiDocumentList);
        }
    }


    public <R> R getSingleResult() throws UPAException {
        List<R> entityList = null;
        try {
            entityList = getResultList();
            if (entityList.isEmpty()) {
                throw new NoResultException();
            }
            //do not call size, as it will load all entities if fount
            //just iterate and throw exception if ambiguity
            int x = 0;
            for (Object object : entityList) {
                x++;
                if (x > 1) {
                    throw new NonUniqueResultException();
                }
            }
            return entityList.get(0);
        } finally {
            UPAUtils.close(entityList);
        }
    }

    public <R> R getSingleResultOrNull() throws UPAException {
        List<R> entityList = null;
        try {
            entityList = getResultList();
            if (entityList.isEmpty()) {
                return null;
            }
            int x = 0;
            for (Object object : entityList) {
                x++;
                if (x > 1) {
                    throw new NonUniqueResultException();
                }
            }
            return entityList.get(0);
        } finally {
            UPAUtils.close(entityList);
        }
    }

    public <R> R getFirstResultOrNull() throws UPAException {
        List<R> entityList = null;
        try {
            entityList = getResultList();
            if (entityList.isEmpty()) {
                return null;
            }
            return entityList.get(0);
        } finally {
            UPAUtils.close(entityList);
        }
    }

    public boolean isUpdatable() {
        return updatable;
    }

    public QueryBuilder setParameters(Map<String, Object> parameters) {
        if (parameters != null) {
            for (Map.Entry<String, Object> entry : parameters.entrySet()) {
                setParameter(entry.getKey(), entry.getValue());
            }
        }
        return this;
    }

    public QueryBuilder setUpdatable(boolean forUpdate) {
        this.updatable = forUpdate;
        return this;
    }

    @Override
    public QueryBuilder setParameter(String name, Object value, boolean condition) {
        if (!condition) {
            return this;
        }
        return setParameter(name, value);
    }

    @Override
    public QueryBuilder setParameters(Map<String, Object> parameters, boolean condition) {
        if (!condition) {
            return this;
        }
        return setParameters(parameters);
    }

    @Override
    public QueryBuilder setParameter(int index, Object value, boolean condition) {
        if (!condition) {
            return this;
        }
        return setParameter(index, value);
    }

    @Override
    public Query toQuery() {
        if(adapted==null){
            adapted=new QueryBuilderToQueryAdapter(this);
        }
        return adapted;
    }
}
