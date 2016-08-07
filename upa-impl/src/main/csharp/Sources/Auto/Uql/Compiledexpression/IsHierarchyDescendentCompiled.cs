/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{

    public sealed class IsHierarchyDescendentCompiled : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ancestorExpression;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression childExpression;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName;

        public IsHierarchyDescendentCompiled(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ancestorExpression, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression childExpression, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName)  : base("treeAncestor"){

            this.ancestorExpression = ancestorExpression;
            this.childExpression = childExpression;
            this.entityName = entityName;
            ProtectedAddArgument(ancestorExpression);
            ProtectedAddArgument(childExpression);
            ProtectedAddArgument(entityName);
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetAncestorExpression() {
            return ancestorExpression;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetChildExpression() {
            return childExpression;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntityName() {
            return entityName;
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled(ancestorExpression.Copy(), childExpression.Copy(), (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) entityName.Copy());
        }
    }
}
