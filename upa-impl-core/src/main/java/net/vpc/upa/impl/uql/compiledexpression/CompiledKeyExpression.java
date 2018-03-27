/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 15 dec. 02
 * Time: 19:07:14
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Key;
import net.vpc.upa.exceptions.UPAException;

import java.util.List;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataTypeTransform;

public class CompiledKeyExpression extends DefaultCompiledExpressionImpl implements Cloneable {

    private static final long serialVersionUID = 1L;
    private Object key;
    private String entityName;
    private String entityAlias;
//    private String query;
    private String desc;
    private Entity entity;

    public CompiledKeyExpression(Entity entity, Object key, String alias) {
        if (key == null) {
            throw new UPAIllegalArgumentException("Key could not be null");
        }
//        entity.getIdType().cast(key);
        this.key = key;
        entityName = entity.getName();
        this.entityAlias = alias;
        this.entity = entity;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public Object getKey() {
        return key;
    }

    @Override
    public String getDescription() {
        if (desc == null) {
            try {
                Entity _entity = getEntity();
                Key ukey = _entity.getBuilder().idToKey(key);
                List<Field> f = _entity.getIdFields();
                StringBuilder descsb = new StringBuilder();
                Object[] values = ukey.getValue();
                for (int i = 0; i < f.size(); i++) {
                    if (i > 0) {
                        descsb.append(" ");
                        descsb.append(" and ");
                        descsb.append(" ");
                    }
                    if (values[i] == null) {
                        descsb.append(f.get(i).getI18NTitle()).append(
                                " undefined operator ");
                    } else {
                        descsb.append(f.get(i).getI18NTitle()).append(" = ").append(new CompiledLiteral(values[i], UPAUtils.getTypeTransformOrIdentity(f.get(i))).toString());
                    }
                }
                desc = descsb.toString();
            } catch (UPAException ex) {
                desc = "";
            }
        }
        return desc;
    }

    public Entity getEntity() {
        return entity;//PersistenceUnitFilter.getPersistenceUnit().getEntity(entityName);
    }

//    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        if (query == null) {
//            StringBuilder exprsb = new StringBuilder();
//            Object[] values = key.getValue();
//            Field[] f = getEntity().getIdFields();
//            for (int i = 0; i < f.length; i++) {
//                if (i > 0) {
//                    exprsb.append(" AND ");
//                }
//                if (entityAlias != null) {
//                    exprsb.append(entityAlias).append(".");
//                }
//                exprsb.append(f[i].getName());
//                if (values[i] == null) {
//                    exprsb.append(" IS NULL");
//
//                } else {
//                    exprsb.append(" = " + new Literal(values[i],f[i].getDataType()).toSQL(entity.getPersistenceUnit()));
//                }
//            }
//            query = "(" + exprsb.toString() + ")";
//        }
//        return query;
//    }
    public String getTableAlias() {
        return entityAlias;
    }

    public String getEntityName() {
        return entityName;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledKeyExpression o = new CompiledKeyExpression(entity, key, entityAlias);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedOperationException("Not supported.");
    }
    
}
