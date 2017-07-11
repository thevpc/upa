package net.vpc.upa.impl.persistence.shared.sql;

import java.util.List;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Key;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclaration;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledAnd;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEquals;
import net.vpc.upa.impl.uql.compiledexpression.CompiledIdEnumerationExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledOr;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.ManyToOneType;

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
            throw new UPAIllegalArgumentException("Id enumeration must by associated to and entity");
        }
        if (ee.getKeys().isEmpty()) {
            return sqlManager.getSQL(new CompiledEquals(new CompiledLiteral(1), new CompiledLiteral(2)), qlContext, declarations);
        }
        List<Field> pfs = entity.getIdFields();
        CompiledExpressionExt o2 = null;
        for (Object key : ee.getKeys()) {
            CompiledExpressionExt a = null;
            boolean processed = false;
            if (entity.getPersistenceUnit().containsEntity(entity.getIdType())) {
                if (!entity.getIdType().isInstance(key)) {
                    //primitive seen as entity?
                    // A's id is A.b where b is an entity
                    //TODO fix all cases!
                    if (entity.getIdFields().size() == 1) {
                        ManyToOneType et = (ManyToOneType) entity.getIdFields().get(0).getDataType();
                        List<Field> ff = et.getRelationship().getSourceRole().getFields();
                        Key key2 = et.getRelationship().getTargetEntity().getBuilder().idToKey(key);
                        for (int j = 0; j < ff.size(); j++) {
                            Field f = ff.get(j);
                            CompiledVar rr = new CompiledVar(f);
                            CompiledVar p2 = compiledVar == null ? null : (CompiledVar) compiledVar.copy();
                            if (p2 == null) {
                                p2 = rr;
                            } else {
                                p2.setChild(rr);
                            }
                            CompiledEquals v = new CompiledEquals(p2, new CompiledLiteral(key2.getObjectAt(j), UPAUtils.getTypeTransformOrIdentity(f)));
                            if (a == null) {
                                a = v;
                            } else {
                                a = new CompiledAnd(a, v);
                            }
                        }
                        if (o2 == null) {
                            o2 = a;
                        } else {
                            o2 = new CompiledOr(o2, a);
                        }
                        processed=true;
                    }
                }
            }
            if (!processed) {
                Key uKey = entity.getBuilder().idToKey(key);
                for (int j = 0; j < pfs.size(); j++) {
                    Field f = pfs.get(j);
                    CompiledVar rr = new CompiledVar(f);
                    CompiledVar p2 = compiledVar == null ? null : (CompiledVar) compiledVar.copy();
                    if (p2 == null) {
                        p2 = rr;
                    } else {
                        p2.setChild(rr);
                    }
                    CompiledEquals v = new CompiledEquals(p2, new CompiledLiteral(uKey.getObjectAt(j), UPAUtils.getTypeTransformOrIdentity(f)));
                    if (a == null) {
                        a = v;
                    } else {
                        a = new CompiledAnd(a, v);
                    }
                }
                if (o2 == null) {
                    o2 = a;
                } else {
                    o2 = new CompiledOr(o2, a);
                }
            }
        }
        return sqlManager.getSQL(o2, qlContext, declarations);
    }
}
