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


    public abstract class DefaultExpression : Net.TheVpc.Upa.Expressions.Expression {



        protected internal DefaultExpression() {
        }

        public virtual bool IsValid() {
            return true;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression FindOne(Net.TheVpc.Upa.Expressions.ExpressionFilter filter) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> all = Find(filter, true);
            return (all.Count==0) ? null : all[0];
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> FindAll(Net.TheVpc.Upa.Expressions.ExpressionFilter filter) {
            return Find(filter, false);
        }

        public virtual void Visit(Net.TheVpc.Upa.Expressions.ExpressionVisitor visitor) {
            System.Collections.Generic.Stack<Net.TheVpc.Upa.Expressions.TaggedExpression> stack = new System.Collections.Generic.Stack<Net.TheVpc.Upa.Expressions.TaggedExpression>();
            stack.Push(new Net.TheVpc.Upa.Expressions.TaggedExpression(this, null));
            while (!(stack.Count==0)) {
                Net.TheVpc.Upa.Expressions.TaggedExpression e = stack.Pop();
                Net.TheVpc.Upa.Expressions.Expression expr = e.GetExpression();
                if (expr != null) {
                    if (!visitor.Visit(expr, e.GetTag())) {
                        return;
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> c = expr.GetChildren();
                    if (c != null) {
                        foreach (Net.TheVpc.Upa.Expressions.TaggedExpression te in c) {
                            stack.Push(te);
                        }
                    }
                }
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.TheVpc.Upa.Expressions.ExpressionTransformer transformer) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> c = this.GetChildren();
            bool updated = false;
            Net.TheVpc.Upa.Expressions.ExpressionTransformerResult r;
            if (c != null) {
                foreach (Net.TheVpc.Upa.Expressions.TaggedExpression te in c) {
                    r = te.GetExpression().Transform(transformer);
                    if (r != null) {
                        if (r.IsChanged()) {
                            if (r.IsUpdated()) {
                                updated = true;
                            }
                            if (r.IsReplaced()) {
                                SetChild(r.GetExpression(), te.GetTag());
                            }
                        }
                    }
                }
            }
            r = transformer.Transform(this);
            if (r == null) {
                return new Net.TheVpc.Upa.Expressions.ExpressionTransformerResult(this, false, updated);
            }
            return new Net.TheVpc.Upa.Expressions.ExpressionTransformerResult(r.GetExpression(), r.IsReplaced(), r.IsUpdated() || updated);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> Find(Net.TheVpc.Upa.Expressions.ExpressionFilter filter, bool firstResult) {
            System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression> found = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(firstResult ? 1 : 5);
            if (filter.Accept(this)) {
                found.Add(this);
                if (firstResult) {
                    return found;
                }
            }
            foreach (Net.TheVpc.Upa.Expressions.TaggedExpression r in GetChildren()) {
                if (firstResult) {
                    Net.TheVpc.Upa.Expressions.Expression x = r.GetExpression().FindOne(filter);
                    if (x != null) {
                        found.Add(x);
                        return found;
                    }
                } else {
                    Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(found, r.GetExpression().FindAll(filter));
                }
            }
            return found;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetChild(Net.TheVpc.Upa.Expressions.Expression arg1, Net.TheVpc.Upa.Expressions.ExpressionTag arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Expressions.Expression Copy();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
