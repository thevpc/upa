package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.Entity;
import net.vpc.upa.Key;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.expressions.IdExpression;

import java.util.List;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.impl.uql.ExpressionDeclaration;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.util.UPAUtils;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class IdExpressionCompiler implements ExpressionTranslator {

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
                            entity = persistenceUnit.getEntity((String)ref.getReferrerName());
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
            throw new IllegalArgumentException("Key enumeration must by associated to and entity");
        }

        Key key = entity.getBuilder().idToKey(o.getId());
        Object[] values = key==null?null:key.getValue();
        Entity entity1 = o.getEntity();
        List<PrimitiveField> f = entity1.toPrimitiveFields(entity1.getIdFields());
        for (int i = 0; i < f.size(); i++) {
            CompiledVar ppp = o.getAlias() == null ? null : new CompiledVar(o.getAlias());
            if(ppp==null){
                ppp=new CompiledVar(f.get(i).getName());
            }else{
                ppp.setChild(new CompiledVar(f.get(i).getName()));
            }
            CompiledEquals e = new CompiledEquals(ppp, new CompiledLiteral(values==null?null:values[i], UPAUtils.getTypeTransformOrIdentity(f.get(i))));
            ret = (ret == null) ? e : new CompiledAnd(ret, e);
        }
        if (ret == null) {
            ret = new CompiledEquals(new CompiledLiteral(1), new CompiledLiteral(1));
        }
        return ret;
    }
}
