//package net.vpc.upa.impl.uql.compiledfilteredreplacers;
//
//import net.vpc.upa.*;
//import net.vpc.upa.expressions.CompiledExpression;
//import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
//import net.vpc.upa.impl.uql.ExpressionCompiler;
//import net.vpc.upa.impl.uql.ReplaceResult;
//import net.vpc.upa.impl.uql.ReplaceResultType;
//import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
//import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;
//import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
//import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionUtils;
//import net.vpc.upa.persistence.ExpressionCompilerConfig;
//
///**
// * Created by vpc on 6/25/17.
// */
//public class LiveFieldCompiledExpressionFilteredReplacer implements CompiledExpressionFilteredReplacer {
//    PersistenceUnit persistenceUnit;
//    ExpressionCompiler workspace;
//
//    public LiveFieldCompiledExpressionFilteredReplacer(PersistenceUnit persistenceUnit, ExpressionCompiler workspace) {
//        this.persistenceUnit = persistenceUnit;
//        this.workspace = workspace;
//    }
//
//    @Override
//    public boolean isTopDown() {
//        return false;
//    }
//
//    @Override
//    public ReplaceResult update(CompiledExpression e) {
//        boolean ok=false;
//        if (e instanceof CompiledVar) {
//            Object r = workspace.resolveReferrer(((CompiledVar) e));
//            if (r instanceof Field) {
//                Field referrer = (Field) r;
//                if (referrer.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
//                    Formula selectFormula = referrer.getSelectFormula();
//                    ok= selectFormula instanceof ExpressionFormula;
//                }
//            }
//        }
//        if(!ok){
//            return ReplaceResult.NO_UPDATES_CONTINUE;
//        }
//
//
//        CompiledVar v = (CompiledVar) e;
//        CompiledVarOrMethod c = v.getChild();
//        Field referrer = (Field) workspace.resolveReferrer(v);
//        Formula selectFormula = referrer.getSelectFormula();
//        if (selectFormula instanceof ExpressionFormula) {
//            CompiledExpressionExt expr2 = (CompiledExpressionExt) persistenceUnit.getExpressionManager().compileExpression(((ExpressionFormula) selectFormula).getExpression(), new ExpressionCompilerConfig().setExpandFields(false).setValidate(false));
//            //Remove this!
//            expr2 = CompiledExpressionUtils.removeThisVar(expr2);
//            if (c == null) {
//                if (expr2 instanceof CompiledVarOrMethod) {
//                    ((CompiledVarOrMethod) expr2).getFinest().setBaseReferrer(referrer);
//                }
//                return ReplaceResult.continueWithNewObj(expr2);
//            } else {
//                if (expr2 instanceof CompiledVar) {
//                    CompiledVar vexpr2 = (CompiledVar) expr2;
//                    vexpr2.getFinest().setChild(c);
//                    vexpr2.setBaseReferrer(referrer);
//                    return ReplaceResult.continueWithNewObj(vexpr2);
//                } else {
//                    throw new UPAIllegalArgumentException("Invalid expression when expanding LiveFormula for " + referrer + " (" + expr2 + ")." + c);
//                }
//            }
//        }
//        return null;
//    }
//}
