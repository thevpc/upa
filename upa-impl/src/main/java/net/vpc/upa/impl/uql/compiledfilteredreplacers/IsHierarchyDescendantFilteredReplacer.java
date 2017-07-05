///*
// * To change this template, choose Tools | Templates
// * and open the template in the editor.
// */
//package net.vpc.upa.impl.uql.compiledfilteredreplacers;
//
//import net.vpc.upa.Entity;
//import net.vpc.upa.Field;
//import net.vpc.upa.PersistenceUnit;
//import net.vpc.upa.Relationship;
//import net.vpc.upa.exceptions.UPAException;
//import net.vpc.upa.expressions.CompiledExpression;
//import net.vpc.upa.extensions.HierarchyExtension;
//import net.vpc.upa.impl.extension.HierarchicalRelationshipSupport;
//import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
//import net.vpc.upa.impl.uql.*;
//import net.vpc.upa.impl.uql.compiledexpression.*;
//import net.vpc.upa.impl.util.UPAUtils;
//import net.vpc.upa.types.*;
//
//import java.util.List;
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// */
//public class IsHierarchyDescendantFilteredReplacer implements CompiledExpressionFilteredReplacer {
//
//    private PersistenceUnit persistenceUnit;
//    private ExpressionCompiler workspace;
//
//    public IsHierarchyDescendantFilteredReplacer(PersistenceUnit persistenceUnit, ExpressionCompiler workspace) {
//        this.persistenceUnit = persistenceUnit;
//        this.workspace = workspace;
//    }
//
//    @Override
//    public boolean isTopDown() {
//        return false;
//    }
//
//}
