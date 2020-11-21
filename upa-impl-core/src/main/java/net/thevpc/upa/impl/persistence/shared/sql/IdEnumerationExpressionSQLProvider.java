package net.thevpc.upa.impl.persistence.shared.sql;

import java.util.List;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.Key;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclaration;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledIdEnumerationExpression;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.RelationDataType;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class IdEnumerationExpressionSQLProvider extends AbstractSQLProvider {

    public IdEnumerationExpressionSQLProvider() {
        super(CompiledIdEnumerationExpression.class);
    }

    @Override
    public String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledIdEnumerationExpression ee = (CompiledIdEnumerationExpression) o;
        Entity entity = null;
        CompiledVar compiledVar = null;
        if (ee.getAlias() != null) {
            compiledVar = ee.getAlias();
            entity = (compiledVar.getReferrer() instanceof Entity) ? ((Entity) compiledVar.getReferrer()) : null;
        } else {
            //check if alias
            List<ExpressionDeclaration> dvalues = ee.getDeclarations(null);
            if (dvalues != null) {
                for (ExpressionDeclaration ref : dvalues) {
                    switch (ref.getReferrerType()) {
                        case ENTITY: {
                            entity = qlContext.getPersistenceUnit().getEntity((String) ref.getReferrerName());
                            break;
                        }
                    }
                }
            }
        }
        if (entity == null) {
            throw new IllegalUPAArgumentException("Id enumeration must by associated to and entity");
        }
        if (ee.getKeys().isEmpty()) {
            return "1=2";//sqlManager.getSQL(new CompiledEquals(new CompiledLiteral(1), new CompiledLiteral(2)), qlContext, declarations);
        }
        List<Field> pfs = entity.getIdFields();
        CompiledExpressionExt o2 = null;
        final boolean singleIdEntity = entity.getIdFields().size() == 1;
        final boolean simpleIdIsEntity = entity.getPersistenceUnit().containsEntity(entity.getIdType());

        if (ee.getKeys().size() > 1 && singleIdEntity) {
            Field f = pfs.get(0);
            StringBuilder sb = new StringBuilder();
            sb.append(sqlManager.getSQL(UPQLUtils.fieldVar(compiledVar, f), qlContext, declarations));
            sb.append(" in (");
            boolean first = true;
            for (Object key : ee.getKeys()) {
                if (first) {
                    first = false;
                } else {
                    sb.append(", ");
                }
                if (simpleIdIsEntity && !entity.isIdInstance(key)) {
                    RelationDataType et = (RelationDataType) entity.getIdFields().get(0).getDataType();
                    List<Field> ff = et.getRelationship().getSourceRole().getFields();
                    Key key2 = et.getRelationship().getTargetEntity().getBuilder().idToKey(key);
                    sb.append(sqlManager.getSQL(UPQLUtils.fieldLiteral(key2.getObjectAt(0), ff.get(0)), qlContext, declarations));
                } else {
                    Key uKey = entity.getBuilder().idToKey(key);
                    sb.append(sqlManager.getSQL(UPQLUtils.fieldLiteral(uKey.getObjectAt(0), f), qlContext, declarations));
                }
            }
            sb.append(")");
            return sb.toString();
        }

        for (Object key : ee.getKeys()) {
            CompiledExpressionExt a = null;
            boolean processed = false;
            if (simpleIdIsEntity && singleIdEntity) {
                if (!entity.isIdInstance(key)) {
                    //primitive seen as entity?
                    // A's id is A.b where b is an entity
                    //TODO fix all cases!
                    RelationDataType et = (RelationDataType) entity.getIdFields().get(0).getDataType();
                    List<Field> ff = et.getRelationship().getSourceRole().getFields();
                    Key key2 = et.getRelationship().getTargetEntity().getBuilder().idToKey(key);
                    for (int j = 0; j < ff.size(); j++) {
                        a = UPQLUtils.and(a, UPQLUtils.fieldEqLiteral(compiledVar, key2.getObjectAt(j), ff.get(j)));
                    }
                    o2 = UPQLUtils.or(o2, a);
                    processed = true;
                }
            }
            if (!processed) {
                Key uKey = entity.getBuilder().idToKey(key);
                for (int j = 0; j < pfs.size(); j++) {
                    a = UPQLUtils.and(a, UPQLUtils.fieldEqLiteral(compiledVar, uKey.getObjectAt(j), pfs.get(j)));
                }
                o2 = UPQLUtils.or(o2, a);
            }
        }
        return sqlManager.getSQL(o2, qlContext, declarations);
    }
}
