package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.expressions.IdEnumerationExpression;

import java.util.List;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;

public class IdEnumerationExpressionCompiler implements ExpressionTranslator {

    @Override
    public DefaultCompiledExpression translateExpression(Object x, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        IdEnumerationExpression o = (IdEnumerationExpression) x;
        List<Object> keys = o.getIds();
        Var tableAlias = o.getAlias();
        return new CompiledKeyEnumerationExpression(keys, (CompiledVar) expressionTranslationManager.compileAny(tableAlias,declarations));
//        Entity entityName = null;
//        CompiledVar compiledVar = null;
//        if (tableAlias != null) {
//            compiledVar = (CompiledVar) expressionTranslationManager.compileAny(tableAlias,declarations);
//            entityName = (compiledVar.getReferrer() instanceof Entity) ? ((Entity) compiledVar.getReferrer()) : null;
//        } else {
//            //check if alias
//            List<ExpressionDeclaration> dvalues = declarations.getDeclarations(null);
//            if (dvalues != null) {
//                for (ExpressionDeclaration ref : dvalues) {
//                    switch (ref.getReferrerType()) {
//                        case ENTITY: {
//                            entityName = expressionTranslationManager.getPersistenceUnit().getEntity((String)ref.getReferrerName());
//                            break;
//                        }
//                    }
//                }
//            }
//        }
//        if (entityName == null) {
//            throw new IllegalArgumentException("Key enumeration must by associated to and entity");
//        }
//        if (keys.isEmpty()) {
//            return new CompiledEquals(new CompiledLiteral(1), new CompiledLiteral(2));
//        }
//        List<Field> pfs = entityName.getPrimaryFields();
//        DefaultCompiledExpression o2 = null;
//        for (Object key : keys) {
//            DefaultCompiledExpression a = null;
//            for (int j = 0; j < pfs.size(); j++) {
//                Field f = pfs.get(j);
//                Key uKey = f.getEntity().getBuilder().idToKey(key);
//                CompiledVar rr=new CompiledVar(f);
//                CompiledVar p2=compiledVar==null?null:(CompiledVar)compiledVar.copy();
//                if(p2==null){
//                    p2=rr;
//                }else{
//                    p2.setChild(rr);
//                }
//                CompiledEquals v = new CompiledEquals(p2, new CompiledLiteral(uKey.getObjectAt(j), f.getDataType()));
//                if (a == null) {
//                    a = v;
//                } else {
//                    a = new CompiledAnd(a, v);
//                }
//            }
//            if (o2 == null) {
//                o2 = a;
//            } else {
//                o2 = new CompiledOr(o2, a);
//            }
//        }
//        return o2;
    }
}
