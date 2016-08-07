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



namespace Net.Vpc.Upa.Expressions
{

    public sealed class IsHierarchyDescendent : Net.Vpc.Upa.Expressions.FunctionExpression {



        private Net.Vpc.Upa.Expressions.EntityName entityName;

        private Net.Vpc.Upa.Expressions.Expression ancestorExpression;

        private Net.Vpc.Upa.Expressions.Expression childExpression;

        public IsHierarchyDescendent(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 3);
            Init(expressions[0], expressions[1], expressions[2]);
        }

        public IsHierarchyDescendent(Net.Vpc.Upa.Expressions.Expression ancestorExpression, Net.Vpc.Upa.Expressions.Expression childExpression, Net.Vpc.Upa.Expressions.Expression entityName) {
            Init(ancestorExpression, childExpression, entityName);
        }

        private void Init(Net.Vpc.Upa.Expressions.Expression ancestorExpression, Net.Vpc.Upa.Expressions.Expression childExpression, Net.Vpc.Upa.Expressions.Expression entityName) {
            if (entityName != null) {
                if (entityName is Net.Vpc.Upa.Expressions.EntityName) {
                    this.entityName = (Net.Vpc.Upa.Expressions.EntityName) entityName;
                } else if (entityName is Net.Vpc.Upa.Expressions.Var) {
                    Net.Vpc.Upa.Expressions.Var v = (Net.Vpc.Upa.Expressions.Var) entityName;
                    if (v.GetApplier() != null) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Invalid EntityName");
                    }
                    this.entityName = new Net.Vpc.Upa.Expressions.EntityName(v.GetName());
                } else if (entityName is Net.Vpc.Upa.Expressions.Literal) {
                    Net.Vpc.Upa.Expressions.Literal v = (Net.Vpc.Upa.Expressions.Literal) entityName;
                    if (!(v.GetValue() is string)) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Invalid EntityName");
                    }
                    this.entityName = new Net.Vpc.Upa.Expressions.EntityName((string) v.GetValue());
                } else {
                    throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Invalid EntityName");
                }
            } else {
                this.entityName = new Net.Vpc.Upa.Expressions.EntityName("");
            }
            this.ancestorExpression = ancestorExpression;
            this.childExpression = childExpression;
        }

        public int Size() {
            return 1;
        }

        public override bool IsValid() {
            return entityName.IsValid() && ancestorExpression.IsValid() && childExpression.IsValid();
        }


        public override string GetName() {
            return "TreeAncestor";
        }


        public override int GetArgumentsCount() {
            return 3;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    {
                        return ancestorExpression;
                    }
                case 1:
                    {
                        return childExpression;
                    }
                case 2:
                    {
                        return entityName;
                    }
            }
            throw new System.IndexOutOfRangeException();
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            switch(index) {
                case 0:
                    {
                        this.ancestorExpression = e;
                        break;
                    }
                case 1:
                    {
                        this.childExpression = e;
                        break;
                    }
                case 2:
                    {
                        this.entityName = (Net.Vpc.Upa.Expressions.EntityName) e;
                        break;
                    }
            }
            throw new System.IndexOutOfRangeException();
        }

        public Net.Vpc.Upa.Expressions.EntityName GetEntityName() {
            return entityName;
        }

        public void SetEntityName(Net.Vpc.Upa.Expressions.EntityName entityName) {
            this.entityName = entityName;
        }

        public Net.Vpc.Upa.Expressions.Expression GetAncestorExpression() {
            return ancestorExpression;
        }

        public void SetAncestorExpression(Net.Vpc.Upa.Expressions.Expression ancestorExpression) {
            this.ancestorExpression = ancestorExpression;
        }

        public Net.Vpc.Upa.Expressions.Expression GetChildExpression() {
            return childExpression;
        }

        public void SetChildExpression(Net.Vpc.Upa.Expressions.Expression childExpression) {
            this.childExpression = childExpression;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.IsHierarchyDescendent o = new Net.Vpc.Upa.Expressions.IsHierarchyDescendent(ancestorExpression.Copy(), childExpression.Copy(), (Net.Vpc.Upa.Expressions.EntityName) entityName.Copy());
            return o;
        }
    }
}
