/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Expressions
{


    public sealed class IsHierarchyDescendant : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.EntityName entityName;

        private Net.TheVpc.Upa.Expressions.Expression ancestorExpression;

        private Net.TheVpc.Upa.Expressions.Expression childExpression;

        public IsHierarchyDescendant(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 3);
            Init(expressions[0], expressions[1], expressions[2]);
        }

        public IsHierarchyDescendant(Net.TheVpc.Upa.Expressions.Expression ancestorExpression, Net.TheVpc.Upa.Expressions.Expression childExpression, Net.TheVpc.Upa.Expressions.Expression entityName) {
            Init(ancestorExpression, childExpression, entityName);
        }

        private void Init(Net.TheVpc.Upa.Expressions.Expression ancestorExpression, Net.TheVpc.Upa.Expressions.Expression childExpression, Net.TheVpc.Upa.Expressions.Expression entityName) {
            if (entityName != null) {
                if (entityName is Net.TheVpc.Upa.Expressions.EntityName) {
                    this.entityName = (Net.TheVpc.Upa.Expressions.EntityName) entityName;
                } else if (entityName is Net.TheVpc.Upa.Expressions.Var) {
                    Net.TheVpc.Upa.Expressions.Var v = (Net.TheVpc.Upa.Expressions.Var) entityName;
                    if (v.GetApplier() != null) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Invalid EntityName");
                    }
                    this.entityName = new Net.TheVpc.Upa.Expressions.EntityName(v.GetName());
                } else if (entityName is Net.TheVpc.Upa.Expressions.Literal) {
                    Net.TheVpc.Upa.Expressions.Literal v = (Net.TheVpc.Upa.Expressions.Literal) entityName;
                    if (v.GetValue() == null) {
                        this.entityName = new Net.TheVpc.Upa.Expressions.EntityName((string) v.GetValue());
                    } else if ((v.GetValue() is string)) {
                        this.entityName = new Net.TheVpc.Upa.Expressions.EntityName((string) v.GetValue());
                    } else {
                        throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Invalid EntityName");
                    }
                } else {
                    throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Invalid EntityName");
                }
            } else {
                this.entityName = new Net.TheVpc.Upa.Expressions.EntityName("");
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


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
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


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
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
                        this.entityName = (Net.TheVpc.Upa.Expressions.EntityName) e;
                        break;
                    }
            }
            throw new System.IndexOutOfRangeException();
        }

        public Net.TheVpc.Upa.Expressions.EntityName GetEntityName() {
            return entityName;
        }

        public void SetEntityName(Net.TheVpc.Upa.Expressions.EntityName entityName) {
            this.entityName = entityName;
        }

        public Net.TheVpc.Upa.Expressions.Expression GetAncestorExpression() {
            return ancestorExpression;
        }

        public void SetAncestorExpression(Net.TheVpc.Upa.Expressions.Expression ancestorExpression) {
            this.ancestorExpression = ancestorExpression;
        }

        public Net.TheVpc.Upa.Expressions.Expression GetChildExpression() {
            return childExpression;
        }

        public void SetChildExpression(Net.TheVpc.Upa.Expressions.Expression childExpression) {
            this.childExpression = childExpression;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.IsHierarchyDescendant o = new Net.TheVpc.Upa.Expressions.IsHierarchyDescendant(ancestorExpression.Copy(), childExpression.Copy(), (Net.TheVpc.Upa.Expressions.EntityName) entityName.Copy());
            return o;
        }
    }
}
