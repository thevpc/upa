package net.vpc.upa.impl.uql.util;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.ReplaceResult;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.uql.compiledfilteredreplacers.*;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionFilterLeafVar;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionFilterRootVar;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionFilterThisVar;
import net.vpc.upa.impl.uql.compiledfilters.TypeCompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledExpressionThisRemover;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 6/9/17.
 */
public class UQLCompiledUtils {
    public static CompiledExpressionFilter PARAM_FILTER = new TypeCompiledExpressionFilter(CompiledParam.class);
    public static CompiledExpressionFilter SELECT_FILTER = new TypeCompiledExpressionFilter(CompiledSelect.class);
    public static CompiledExpressionFilter QUERY_STATEMENT_FILTER = new TypeCompiledExpressionFilter(CompiledQueryStatement.class);
    public static CompiledExpressionFilter THIS_VAR_FILTER = new CompiledExpressionFilterThisVar(true);
    public static CompiledExpressionFilter THIS_VAR_OR_ALIAS_FILTER = new CompiledExpressionFilterThisVar(false);
    public static CompiledExpressionFilteredReplacer ALIAS_ENFORCER = new AliasEnforcerCompiledExpressionFilteredReplacer();

    private UQLCompiledUtils() {
    }

    public static List<CompiledVar> findChildrenLeafVars(CompiledExpression v) {
        return ((CompiledExpressionExt) v).findExpressionsList(CompiledExpressionFilterLeafVar.INSTANCE);
    }

    public static List<CompiledVar> findChildrenRootVars(CompiledExpression v) {
        return ((CompiledExpressionExt) v).findExpressionsList(CompiledExpressionFilterRootVar.INSTANCE);
    }

    public static CompiledVar findThisVar(CompiledExpression v) {
        return ((CompiledExpressionExt)v).findFirstExpression(THIS_VAR_FILTER);
    }

    public static CompiledExpressionExt findThisVarOrAlias(CompiledExpression v) {
        return ((CompiledExpressionExt)v).findFirstExpression(THIS_VAR_OR_ALIAS_FILTER);
    }

    public static CompiledVar copyToRootVar(CompiledVar v) {
        v=(CompiledVar) v.copy();
        CompiledExpressionExt r = v.getParentExpression();
        if(r instanceof CompiledVar) {
            CompiledVar compiledVar = copyToRootVar((CompiledVar) r);
            compiledVar.setChild(v);
            return compiledVar;
        }
        return v;
    }

    public static CompiledVar findRootVar(CompiledVar v) {
        while (v != null) {
            if (v.getParentExpression() instanceof CompiledVar) {
                v = (CompiledVar) v.getParentExpression();
            } else {
                break;
            }
        }
        return v;
    }

    public static CompiledExpressionExt findRootNonVar(CompiledVarOrMethod v0) {
        CompiledExpressionExt v=v0;
        while (v != null) {
            if (v instanceof CompiledVarOrMethod) {
                v = v.getParentExpression();
            } else {
                break;
            }
        }
        return v;
    }

    public static CompiledUpdate findRootCompiledUpdate(CompiledVar v) {
        CompiledExpressionExt e=v;
        while (e != null) {
            if(e instanceof CompiledUpdate){
                return (CompiledUpdate) e;
            }
            e=e.getParentExpression();
        }
        return null;
    }

    public static CompiledVarVal findRootCompiledVarVal(CompiledVar v) {
        CompiledExpressionExt e=v;
        while (e != null) {
            if(e instanceof CompiledVarVal){
                return (CompiledVarVal) e;
            }
            e=e.getParentExpression();
        }
        return null;
    }

    public static CompiledQueryField findRootCompiledQueryField(CompiledVar v) {
        CompiledExpressionExt e=v;
        while (e != null) {
            if(e instanceof CompiledQueryField){
                return (CompiledQueryField) e;
            }
            e=e.getParentExpression();
        }
        return null;
    }

    public static CompiledEntityStatement findEnclosingStatement(CompiledVar v, PersistenceUnit pu) {
        CompiledExpressionExt e = v;
        CompiledVar rv = findRootVar(v);
        while (e != null) {
            if (e instanceof CompiledSelect) {
                CompiledSelect s = (CompiledSelect) e;
                if(rv.getName().equals("*")){
                    return s;
                }
                if(s.getParentExpression()==null && UQLUtils.THIS.equals(rv.getName())){
                    return s;
                }
                if(isDeclaredSymbol(rv.getName(),s.getEntityName(),s.getEntityAlias(),pu)){
                    return s;
                }
                for (CompiledJoinCriteria c : s.getJoins()) {
                    if(isDeclaredSymbol(rv.getName(),c.getEntityName(),c.getEntityAlias(),pu)){
                        return s;
                    }
                }
            }else if (e instanceof CompiledUpdate) {
                CompiledUpdate s = (CompiledUpdate) e;
                if(UQLUtils.THIS.equals(rv.getName())){
                    return s;
                }
                if(isDeclaredSymbol(rv.getName(),s.getEntityName(),s.getEntityAlias(),pu)){
                    return s;
                }
                for (CompiledJoinCriteria c : s.getJoins()) {
                    if(isDeclaredSymbol(rv.getName(),c.getEntityName(),c.getEntityAlias(),pu)){
                        return s;
                    }
                }
            }else if (e instanceof CompiledDelete) {
                CompiledDelete s = (CompiledDelete) e;
                if(UQLUtils.THIS.equals(rv.getName())){
                    return s;
                }
                if(isDeclaredSymbol(rv.getName(),s.getEntityName(),s.getEntityAlias(),pu)){
                    return s;
                }
//                for (CompiledJoinCriteria c : s.getJoins()) {
//                    if(isDeclaredSymbol(rv.getName(),c.getEntityName(),c.getEntityAlias(),pu)){
//                        return s;
//                    }
//                }
            }else if (e instanceof CompiledInsert) {
                CompiledInsert s = (CompiledInsert) e;
                if(UQLUtils.THIS.equals(rv.getName())){
                    return s;
                }
                if(isDeclaredSymbol(rv.getName(),s.getEntityName(),s.getEntityAlias(),pu)){
                    return s;
                }
//                for (CompiledJoinCriteria c : s.getJoins()) {
//                    if(isDeclaredSymbol(rv.getName(),c.getEntityName(),c.getEntityAlias(),pu)){
//                        return s;
//                    }
//                }
            }
            e = e.getParentExpression();
        }
        return null;
    }

    public static CompiledEntityStatement findRootStatement(CompiledVar v, PersistenceUnit pu) {
        CompiledExpressionExt e = v;
        while (e != null) {
            if (e instanceof CompiledEntityStatement && e.getParentExpression()==null) {
                return (CompiledEntityStatement) e;
            }
            e = e.getParentExpression();
        }
        return null;
    }

    private static boolean isDeclaredSymbol(String symbol, String entityName, String entityAlias, PersistenceUnit pu){
        if (entityAlias != null && entityAlias.length() > 0) {
            if (symbol.equals(entityAlias)) {
                return true;
            }
        } else {
            if (symbol.equals(entityName)) {
                return true;
            }
        }
        if(entityName!=null) {
            if (pu.getEntity(entityName).containsField(symbol)){
                return true;
            }
        }
        return false;
    }

    public static CompiledExpressionExt cast(CompiledExpression expression) {
        return (CompiledExpressionExt) expression;
    }

    public static ReplaceResult replaceThisVar(CompiledExpression expression, String newName, Map<String, Object> updateContext) {
        return cast(expression).replaceExpressions(new CompiledExpressionThisReplacer(newName), updateContext);
    }

    public static ReplaceResult replaceThisVar(CompiledExpression expression, CompiledVarOrMethod thisReplacement, Map<String, Object> updateContext) {
        return UQLCompiledUtils.replaceExpressions(cast(expression),new CompiledThisRefReplacer(thisReplacement), updateContext);
    }

    public static ReplaceResult replaceParam(CompiledExpression expression, String paramName,CompiledExpression replacement, Map<String, Object> updateContext) {
        return UQLCompiledUtils.replaceExpressions(cast(expression),new CompiledParamRefReplacer(paramName,replacement), updateContext);
    }

    public static CompiledExpressionExt removeThisVar(CompiledExpression expression, Map<String, Object> updateContext) {
        return cast(expression).replaceExpressions(THIS_VAR_FILTER, new CompiledExpressionThisRemover());
    }

    public static void replaceRef(CompiledExpression baseExpr, CompiledExpression oldExpr, CompiledExpression newRef, Map<String, Object> updateContext) {
        if(oldExpr!=newRef){
            UQLCompiledUtils.replaceExpressions(cast(baseExpr),new CompiledExpressionRefReplacer(cast(oldExpr),cast(newRef)), updateContext);
        }
    }

    public static ReplaceResult replaceExpressionChildren(CompiledExpressionExt newParent, CompiledExpressionFilteredReplacer replacer, Map<String, Object> updateContext) {
        List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
        int i = 0;
        CompiledExpressionExt[] subExpressions = newParent.getSubExpressions();
        if (subExpressions == null) {
            subExpressions = new CompiledExpressionExt[0];
        }
        for (CompiledExpressionExt expression : subExpressions) {
            replacementPositions.add(new ReplacementPosition(newParent, expression, i));
            i++;
        }
        boolean someChildUpdates = false;
        List<ReplacementPosition> toRemove = new ArrayList<ReplacementPosition>();
        for (ReplacementPosition r : replacementPositions) {
            CompiledExpressionExt child = r.getChild();
                if (child == null) {
                    //System.out.println("Child is null?");
                } else {
                    ReplaceResult c = replaceExpressions(child,replacer, updateContext);
                    switch (c.getType()) {
                        case NO_UPDATES: {
                            break;
                        }
                        case NEW_INSTANCE:{
                            someChildUpdates = true;
                            if(c.getExpression().getParentExpression()==null || c.getExpression().getParentExpression()==newParent) {
                                newParent.setSubExpression(r.getPos(), c.getExpression());
                            }else{
                                return c;
                            }
                            break;
                        }
                        case UPDATE: {
                            someChildUpdates = true;
                            break;
                        }
                        case REMOVE: {
                            toRemove.add(r);
                            break;
                        }
                    }
                }

        }

        if (toRemove.size() > 0) {
            for (int j = toRemove.size() - 1; j >= 0; j--) {
                newParent.removeSubExpression(toRemove.get(j).getPos());
            }
        }
        if(someChildUpdates){
            return ReplaceResult.UPDATE_AND_STOP;
        }
        return ReplaceResult.UPDATE_AND_STOP;
    }

    private static ReplaceResult replaceExpressionNodeToClean(CompiledExpressionExt expr, CompiledExpressionFilteredReplacer replacer, Map<String, Object> updateContext) {
        ReplaceResult exprUpdate=null;
        boolean remove=false;
        boolean stop=false;
        boolean newInstance=false;
        boolean update=false;
        CompiledExpressionExt oldParent=expr.getParentExpression();
        while(!remove) {
            exprUpdate = replacer.update(expr, updateContext);
            expr=exprUpdate.getExpression(expr);
            if(exprUpdate.isStop()){
                stop=true;
            }
            switch (exprUpdate.getType()){
                case REMOVE:{
                    remove=true;
                    break;
                }
                case NEW_INSTANCE:{
//                    if(expr.getParentExpression()==null) {
//                        expr.setParentExpression(oldParent);
//                    }
                    newInstance=true;
                    break;
                }
                case UPDATE:{
                    update=true;
                    break;
                }
            }
            if(exprUpdate.isClean()){
               break;
            }

        }
        if(stop) {
            if (remove) {
                return ReplaceResult.REMOVE_AND_STOP;
            }
            if (newInstance) {
                return ReplaceResult.stopWithNewObj(expr);
            }
            if (update) {
                return ReplaceResult.UPDATE_AND_STOP;
            }
            return ReplaceResult.NO_UPDATES_STOP;
        }else {
            if (remove) {
                return ReplaceResult.REMOVE_AND_STOP;
            }
            if (newInstance) {
                return ReplaceResult.continueWithNewCleanObj(expr);
            }
            if (update) {
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
            return ReplaceResult.NO_UPDATES_CONTINUE;
        }
    }

    public static ReplaceResult replaceExpressions(CompiledExpressionExt expr, CompiledExpressionFilteredReplacer replacer, Map<String, Object> updateContext) {
        if (replacer == null) {
            return ReplaceResult.NO_UPDATES_STOP;
        }
        if (replacer.isTopDown()) {
            ReplaceResult exprUpdate = replaceExpressionNodeToClean(expr,replacer, updateContext);
            //if stop will not check children!
            if (exprUpdate.isStop()) {
                switch (exprUpdate.getType()) {
                    case NEW_INSTANCE: {
                        return exprUpdate;
                    }
                    case NO_UPDATES: {
                        return ReplaceResult.NO_UPDATES_CONTINUE;
                    }
                    case UPDATE: {
                        return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
                    }
                    case REMOVE: {
                        return ReplaceResult.REMOVE_AND_STOP;
                    }
                }
                return exprUpdate;
            }
//            CompiledExpressionExt oldParent = expr.getParentExpression();
            CompiledExpressionExt newExpr = exprUpdate.getExpression(expr);
            switch (exprUpdate.getType()) {
                case REMOVE: {
                    return ReplaceResult.REMOVE_AND_STOP;
                }
            }
//            if(newExpr.getParentExpression()!=null){
//
//            }
            //newExpr.setParentExpression(oldParent);

            ReplaceResult creplaceResult = replaceExpressionChildren(newExpr, replacer, updateContext);
            switch (exprUpdate.getType()) {
                case NEW_INSTANCE: {
                    return ReplaceResult.stopWithNewObj(exprUpdate.getExpression());
                }
                default: {
                    switch (creplaceResult.getType()){
                        case NO_UPDATES:{
                            return ReplaceResult.NO_UPDATES_STOP;
                        }
                    }
                    return ReplaceResult.UPDATE_AND_STOP;
                }
            }
//
//            List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
//            int i = 0;
//            CompiledExpressionExt[] subExpressions = newParent.getSubExpressions();
//            if (subExpressions == null) {
//                subExpressions = new CompiledExpressionExt[0];
//            }
//            for (CompiledExpressionExt expression : subExpressions) {
//                replacementPositions.add(new ReplacementPosition(expr, expression, i));
//                i++;
//            }
//            boolean someChildUpdates = false;
//            List<ReplacementPosition> toRemove = new ArrayList<>();
//            for (ReplacementPosition r : replacementPositions) {
//                CompiledExpressionExt child = r.getChild();
//                boolean again = true;
//                while (again) {
//                    again=false;
//                    if (child == null) {
//                        //System.out.println("Child is null?");
//                    } else {
//                        ReplaceResult c = child.replaceExpressions(replacer);
//                        switch (c.getType()) {
//                            case NO_UPDATES: {
//                                break;
//                            }
//                            case NEW_INSTANCE:{
//                                someChildUpdates = true;
//                                subExpressions[r.getPos()].unsetParent();
//                                expr.setSubExpression(r.getPos(), c.getExpression());
//                                if(!c.isStop()) {
//                                    child = c.getExpression();
//                                    again = true;
//                                }else {
//                                    switch (parentUpdate.getType()) {
//                                        case NEW_INSTANCE: {
//                                            return ReplaceResult.stopWithNewObj(parentUpdate.getExpression());
//                                        }
//                                        default: {
//                                            return ReplaceResult.NO_UPDATES_STOP;
//                                        }
//                                    }
//                                }
//                                break;
//                            }
//                            case UPDATE: {
//                                someChildUpdates = true;
//                                if (c.isStop()) {
//                                    switch (parentUpdate.getType()) {
//                                        case NEW_INSTANCE: {
//                                            return ReplaceResult.stopWithNewObj(parentUpdate.getExpression());
//                                        }
//                                        default: {
//                                            return ReplaceResult.NO_UPDATES_STOP;
//                                        }
//                                    }
//                                }
//                                break;
//                            }
//                            case REMOVE: {
//                                toRemove.add(r);
//                                break;
//                            }
//                        }
//                    }
//                }
//            }
//
//            if (toRemove.size() > 0) {
//                for (int j = toRemove.size() - 1; j >= 0; j--) {
//                    expr.removeSubExpression(toRemove.get(j).getPos());
//                }
//            }
//            if (someChildUpdates && parentUpdate.getType() == ReplaceResultType.NO_UPDATES) {
//                return ReplaceResult.UPDATE_AND_CONTINUE;
//            }
//            return parentUpdate;
        } else {
            List<ReplacementPosition> replacementPositions = new ArrayList<ReplacementPosition>();
            int i = 0;
            CompiledExpressionExt[] subExpressions = expr.getSubExpressions();
            if (subExpressions == null) {
                subExpressions = new CompiledExpressionExt[0];
            }
            for (CompiledExpressionExt expression : subExpressions) {
                replacementPositions.add(new ReplacementPosition(expr, expression, i));
                i++;
            }
            boolean someChildUpdates = false;
            for (ReplacementPosition r : replacementPositions) {
                CompiledExpressionExt child = r.getChild();
                if (child == null) {
                    //System.out.println("Child is null?");
                } else {
                    ReplaceResult c = child.replaceExpressions(replacer, updateContext);
                    switch (c.getType()) {
                        case UPDATE: {
                            someChildUpdates = true;
                            if (c.isStop()) {
                                return ReplaceResult.UPDATE_AND_STOP;
                            }
                            break;
                        }
                        case NEW_INSTANCE: {
                            someChildUpdates = true;
                            int pos = r.getPos();
                            if (subExpressions[pos] != c.getExpression()) {
                                subExpressions[pos].unsetParent();
                                expr.setSubExpression(pos, (CompiledExpressionExt) c.getExpression());
                            }
                            if (c.isStop()) {
                                return ReplaceResult.UPDATE_AND_STOP;
                            }
                            break;
                        }
                        case NO_UPDATES: {
                            if (c.isStop()) {
                                return ReplaceResult.NO_UPDATES_STOP;
                            }
                        }
                    }
                }
            }
            ReplaceResult update = replacer.update(expr, updateContext);
            switch (update.getType()) {
                case NO_UPDATES: {
                    if (someChildUpdates) {
                        return update.isStop() ? ReplaceResult.UPDATE_AND_STOP : ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
                    }
                }
                default: {
                    return update;
                }
            }
        }
    }
}
