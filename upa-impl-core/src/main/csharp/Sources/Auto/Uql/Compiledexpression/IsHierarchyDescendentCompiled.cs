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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{

    public sealed class IsHierarchyDescendentCompiled : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ancestorExpression;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression childExpression;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName;

        public IsHierarchyDescendentCompiled(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ancestorExpression, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression childExpression, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName)  : base("treeAncestor"){

            this.ancestorExpression = ancestorExpression;
            this.childExpression = childExpression;
            this.entityName = entityName;
            ProtectedAddArgument(ancestorExpression);
            ProtectedAddArgument(childExpression);
            ProtectedAddArgument(entityName);
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetAncestorExpression() {
            return ancestorExpression;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetChildExpression() {
            return childExpression;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntityName() {
            return entityName;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled(ancestorExpression.Copy(), childExpression.Copy(), (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) entityName.Copy());
        }
    }
}
