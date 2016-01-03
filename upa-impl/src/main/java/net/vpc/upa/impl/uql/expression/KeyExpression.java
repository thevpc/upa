/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 15 dec. 02
 * Time: 19:07:14
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.uql.expression;

import net.vpc.upa.Entity;
import net.vpc.upa.expressions.DefaultExpression;
import net.vpc.upa.expressions.Expression;

public class KeyExpression extends DefaultExpression implements Cloneable {

    private static final long serialVersionUID = 1L;
    private Object key;
    private String entityName;
    private String alias;
    private Entity entity;

    public KeyExpression(Entity entity, Object key, String alias) {
        if (key == null) {
            throw new IllegalArgumentException("Key could not be null");
        }
//        entity.getIdType().cast(key);
        this.key = key;
        entityName = entity.getName();
        this.alias = alias;
        this.entity = entity;
    }

    public Object getKey() {
        return key;
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
        KeyExpression o = new KeyExpression(entity, key, alias);
        return o;
    }

    @Override
    public String toString() {
        return "Key("+entityName+","+alias+","+key+")";
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + (this.key != null ? this.key.hashCode() : 0);
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
        final KeyExpression other = (KeyExpression) obj;
        if (this.key != other.key && (this.key == null || !this.key.equals(other.key))) {
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
