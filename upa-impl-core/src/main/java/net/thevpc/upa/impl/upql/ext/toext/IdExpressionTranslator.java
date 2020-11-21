package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEquals;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Key;
import net.thevpc.upa.PrimitiveField;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.expressions.IdExpression;

import java.util.List;

import net.thevpc.upa.impl.upql.ExpressionDeclaration;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class IdExpressionTranslator implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object x, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) throws UPAException {
        IdExpression o = (IdExpression) x;
        CompiledExpressionExt ret = null;

        Entity entity = null;
        if (o.getEntity() != null) {
            entity = o.getEntity();
        }
        PersistenceUnit persistenceUnit = manager.getPersistenceUnit();
        if (entity == null && o.getEntityName() != null) {
            entity = persistenceUnit.getEntity(o.getEntityName());
        }
        if (entity == null && o.getAlias() != null) {
            //check if alias
            List<ExpressionDeclaration> dvalues = declarations.getDeclarations(null);
            if (dvalues != null) {
                for (ExpressionDeclaration ref : dvalues) {
                    switch (ref.getReferrerType()) {
                        case ENTITY: {
                            entity = persistenceUnit.getEntity((String) ref.getReferrerName());
                            break;
                        }
                    }
                }
            }
        }

        if (entity == null && o.getAlias() != null) {
            //check if entity
            if (persistenceUnit.containsEntity(o.getAlias())) {
                entity = persistenceUnit.getEntity(o.getAlias());
            }
        }
        if (entity == null) {
            throw new IllegalUPAArgumentException("Key enumeration must by associated to and entity");
        }

        Key key = entity.getBuilder().idToKey(o.getId());
        Object[] values = key == null ? null : key.getValue();
        Entity entity1 = o.getEntity();
        List<PrimitiveField> f = entity1.toPrimitiveFields(entity1.getIdFields());
        for (int i = 0; i < f.size(); i++) {
            CompiledVar ppp = o.getAlias() == null ? null : new CompiledVar(o.getAlias());
            if (ppp == null) {
                ppp = new CompiledVar(f.get(i).getName());
            } else {
                ppp.setChild(new CompiledVar(f.get(i).getName()));
            }
            CompiledEquals e = new CompiledEquals(ppp, new CompiledLiteral(values == null ? null : values[i], (f.get(i)).getEffectiveTypeTransform()));
            ret = UPQLUtils.and(ret, e);
        }
        if (ret == null) {
            ret = new CompiledEquals(new CompiledLiteral(1), new CompiledLiteral(1));
        }
        return ret;
    }
}
