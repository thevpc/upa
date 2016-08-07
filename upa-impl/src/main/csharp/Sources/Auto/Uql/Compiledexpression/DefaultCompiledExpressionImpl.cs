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


    public abstract class DefaultCompiledExpressionImpl : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression {



        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] EMPTY_ERRAY = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl[0];

        private string description;

        private Net.Vpc.Upa.Properties clientParameters;

        private Net.Vpc.Upa.Types.DataTypeTransform type;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> exportedDeclarations;

        protected internal DefaultCompiledExpressionImpl() {
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetParentExpression() {
            return parent;
        }

        public virtual void SetParentExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent) {
            if (parent != null) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression x = parent;
                while (x != null) {
                    if (x == this) {
                        throw new System.ArgumentException ("Recursive Tree");
                    }
                    x = x.GetParentExpression();
                }
            }
            if (this.parent != null && parent != null) {
                throw new System.ArgumentException ("Unexpected");
            }
            this.parent = parent;
        }

        public virtual bool IsValid() {
            return true;
        }

        public abstract Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions();


        public abstract void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression);

        public virtual string GetDescription() {
            return description;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression SetDescription(string newDesc) {
            description = newDesc;
            return this;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return this.type;
        }

        public virtual void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform type) {
            this.type = type;
        }

        public virtual Net.Vpc.Upa.Properties GetClientParameters() {
            if (clientParameters == null) {
                clientParameters = new Net.Vpc.Upa.Impl.DefaultProperties();
            }
            return clientParameters;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression SetClientProperty(string name, object @value) {
            if (@value != null) {
                GetClientParameters().SetObject(name, @value);
            } else {
                GetClientParameters().Remove(name);
            }
            return this;
        }

        public virtual object GetClientProperty(string name) {
            return clientParameters == null ? null : clientParameters.GetObject<T>(name);
        }

        public virtual bool Visit(Net.Vpc.Upa.Impl.Uql.CompiledExpressionVisitor visitor) {
            if (!visitor.Visit(this)) {
                return false;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] subExpressions = GetSubExpressions();
            if (subExpressions != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression subExpression in subExpressions) {
                    if (subExpression != null) {
                        if (!subExpression.Visit(visitor)) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public virtual  System.Collections.Generic.IList<T> FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter) where  T : Net.Vpc.Upa.Expressions.CompiledExpression {
            System.Collections.Generic.IList<T> list = new System.Collections.Generic.List<T>();
            FindExpressionsList<T>(filter, list);
            return list;
        }

        private  void FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter, System.Collections.Generic.IList<T> list) where  T : Net.Vpc.Upa.Expressions.CompiledExpression {
            if (filter.Accept(this)) {
                //this double casting is needed in C#
                list.Add((T) (object) this);
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] subExpressions = GetSubExpressions();
            if (subExpressions != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression subExpression in subExpressions) {
                    if (subExpression != null) {
                        ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl) subExpression).FindExpressionsList<T>(filter, list);
                    }
                }
            }
        }


        public virtual  T FindFirstExpression<T>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter) where  T : Net.Vpc.Upa.Expressions.CompiledExpression {
            if (filter.Accept(this)) {
                //this double casting is needed in C#
                return ((T) (object) this);
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] subExpressions = GetSubExpressions();
            if (subExpressions != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression subExpression in subExpressions) {
                    if (subExpression != null) {
                        Net.Vpc.Upa.Expressions.CompiledExpression e = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl) subExpression).FindFirstExpression<T>(filter);
                        if (e != null) {
                            return (T) e;
                        }
                    }
                }
            }
            return default(T);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ReplaceExpressions(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter, Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacer replacer) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression t = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) ((filter == null || filter.Accept(this)) ? replacer.Update(this) : null);
            bool updated = false;
            if (t != null) {
                updated = true;
            } else {
                t = this;
            }
            if (!updated) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.ReplacementPosition> replacementPositions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.ReplacementPosition>();
                int i = 0;
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] subExpressions = t.GetSubExpressions();
                if (subExpressions != null) {
                    foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in subExpressions) {
                        replacementPositions.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.ReplacementPosition(t, expression, i));
                        i++;
                    }
                }
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.ReplacementPosition r in replacementPositions) {
                    if (r.GetChild() == null) {
                    } else {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c = r.GetChild().ReplaceExpressions(filter, replacer);
                        if (c != null) {
                            int pos = r.GetPos();
                            //                if (!updated) {
                            //                    t = t.copy();
                            //                }
                            if (subExpressions[pos] != c) {
                                subExpressions[pos].SetParentExpression(null);
                                t.SetSubExpression(pos, c);
                            }
                            updated = true;
                        }
                    }
                }
            }
            if (updated) {
                return t;
            }
            return null;
        }

        protected internal void PrepareChildren(params Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] children) {
            if (children != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e in children) {
                    if (e != null) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression oldParent = e.GetParentExpression();
                        if (oldParent != null) {
                            throw new System.ArgumentException ("Expression already bound");
                        }
                        e.SetParentExpression(this);
                    }
                }
            }
        }

        protected internal void PrepareChildren(System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> children) {
            if (children != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e in children) {
                    e.SetParentExpression(this);
                }
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetExportedDeclarations() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> emptyList = Net.Vpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
            return exportedDeclarations == null ? emptyList : exportedDeclarations;
        }

        public virtual void ExportDeclaration(string name, Net.Vpc.Upa.Impl.Uql.DecObjectType type, object referrerName, object referrerParentId) {
            if (exportedDeclarations == null) {
                exportedDeclarations = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>(3);
            }
            exportedDeclarations.Add(new Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration(name, type, referrerName, referrerParentId));
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetDeclarations(string alias) {
            if (alias == null) {
                //check all
                System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> objects = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>();
                if (exportedDeclarations != null) {
                    for (int i = (exportedDeclarations).Count - 1; i >= 0; i--) {
                        Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d = exportedDeclarations[i];
                        objects.Add(d);
                    }
                }
                if (GetParentExpression() != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(objects, GetParentExpression().GetDeclarations(alias));
                }
                return objects;
            } else {
                System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> objects = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration>();
                if (exportedDeclarations != null) {
                    for (int i = (exportedDeclarations).Count - 1; i >= 0; i--) {
                        Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d = exportedDeclarations[i];
                        if (alias.Equals(d.GetValidName())) {
                            objects.Add(d);
                        }
                    }
                }
                if (GetParentExpression() != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(objects, GetParentExpression().GetDeclarations(alias));
                }
                return objects;
            }
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration GetDeclaration(string name) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> values = GetDeclarations(name);
            if ((values.Count==0)) {
                return null;
            }
            return values[0];
        }

        public virtual void UnsetParent() {
            SetParentExpression(null);
        }

        public virtual void Validate() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] subExpressions = GetSubExpressions();
            if (subExpressions != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e in subExpressions) {
                    if (e.GetParentExpression() != this) {
                        throw new System.ArgumentException ("Illegal Hierarchy");
                    }
                    e.Validate();
                }
            }
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform GetEffectiveDataType() {
            return GetTypeTransform();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
