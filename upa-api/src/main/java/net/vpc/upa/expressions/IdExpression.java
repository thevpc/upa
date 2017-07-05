/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 15 dec. 02
 * Time: 19:07:14
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.expressions;

import net.vpc.upa.Entity;

import java.util.ArrayList;
import java.util.List;

public class IdExpression extends DefaultExpression implements Cloneable {

    private static final long serialVersionUID = 1L;
    private Object id;
    private String entityName;
    private String alias;
    private Entity entity;

    public IdExpression(Entity entity, Object id, String alias) {
        if (id == null) {
            throw new IllegalArgumentException("Id could not be null");
        }
//        entity.getIdType().cast(key);
        this.id = id;
        this.entityName = entity.getName();
        this.alias = alias;
        this.entity = entity;
    }

    public void setId(Object id) {
        this.id = id;
    }

    public void setEntityName(String entityName) {
        this.entityName = entityName;
    }

    public void setAlias(String alias) {
        this.alias = alias;
    }

    public void setEntity(Entity entity) {
        this.entity = entity;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>(1);
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        throw new IllegalArgumentException("Insupported");
    }

    public Object getId() {
        return id;
    }

    public Entity getEntity() {
        return entity;//PersistenceUnitFilter.getPersistenceUnit().getEntity(entityName);
    }

    public String getAlias() {
        return alias;
    }

    public String getEntityName() {
        return entityName;
    }

    @Override
    public Expression copy() {
        IdExpression o = new IdExpression(entity, id, alias);
        return o;
    }

    @Override
    public String toString() {
        return "Key(" + entityName + "," + alias + "," + id + ")";
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + (this.id != null ? this.id.hashCode() : 0);
        hash = 97 * hash + (this.entityName != null ? this.entityName.hashCode() : 0);
        hash = 97 * hash + (this.alias != null ? this.alias.hashCode() : 0);
        hash = 97 * hash + (this.entity != null ? this.entity.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final IdExpression other = (IdExpression) obj;
        if (this.id != other.id && (this.id == null || !this.id.equals(other.id))) {
            return false;
        }
        if ((this.entityName == null) ? (other.entityName != null) : !this.entityName.equals(other.entityName)) {
            return false;
        }
        if ((this.alias == null) ? (other.alias != null) : !this.alias.equals(other.alias)) {
            return false;
        }
        if (this.entity != other.entity && (this.entity == null || !this.entity.equals(other.entity))) {
            return false;
        }
        return true;
    }

}
