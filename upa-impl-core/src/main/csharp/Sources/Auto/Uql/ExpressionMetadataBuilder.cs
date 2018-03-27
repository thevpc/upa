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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * Created by vpc on 6/28/16.
     */
    public class ExpressionMetadataBuilder {

        internal Net.Vpc.Upa.ExpressionManager expressionManager;

        internal Net.Vpc.Upa.PersistenceUnit pu;

        public ExpressionMetadataBuilder(Net.Vpc.Upa.ExpressionManager expressionManager, Net.Vpc.Upa.PersistenceUnit pu) {
            this.expressionManager = expressionManager;
            this.pu = pu;
        }

        public virtual Net.Vpc.Upa.Persistence.ResultMetaData CreateResultMetaData(Net.Vpc.Upa.Expressions.Expression baseExpression, Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            return CreateResultMetaData(baseExpression, fieldFilter, new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryStatement>());
        }

        public virtual Net.Vpc.Upa.Persistence.ResultMetaData CreateResultMetaData(Net.Vpc.Upa.Expressions.Expression baseExpression, Net.Vpc.Upa.Filters.FieldFilter fieldFilter, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> context) {
            baseExpression = Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.ParseUserExpressions(baseExpression, pu);
            Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData m = new Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData();
            if (baseExpression is Net.Vpc.Upa.Expressions.NonQueryStatement) {
                m.SetStatement((Net.Vpc.Upa.Expressions.EntityStatement) baseExpression);
                m.AddField(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(null, "result", Net.Vpc.Upa.Types.TypesFactory.INT, null, null));
                return m;
            } else {
                Net.Vpc.Upa.Expressions.QueryStatement q = (Net.Vpc.Upa.Expressions.QueryStatement) baseExpression;
                if (q is Net.Vpc.Upa.Expressions.Select) {
                    Net.Vpc.Upa.Expressions.Select qs = (Net.Vpc.Upa.Expressions.Select) q;
                    if ((qs.GetFields()).Count == 0) {
                        if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(qs.GetEntityAlias())) {
                            qs.Field(new Net.Vpc.Upa.Expressions.Var(qs.GetEntityAlias()));
                        } else if (qs.GetEntityName() != null) {
                            qs.Field(new Net.Vpc.Upa.Expressions.Var(qs.GetEntityName()));
                        } else {
                            throw new Net.Vpc.Upa.Exceptions.UPAException("MissingAlias");
                        }
                        foreach (Net.Vpc.Upa.Expressions.JoinCriteria joinCriteria in qs.GetJoins()) {
                            if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(joinCriteria.GetEntityAlias())) {
                                qs.Field(new Net.Vpc.Upa.Expressions.Var(joinCriteria.GetEntityAlias()));
                            } else if (joinCriteria.GetEntityName() != null) {
                                qs.Field(new Net.Vpc.Upa.Expressions.Var(joinCriteria.GetEntityName()));
                            } else {
                                throw new Net.Vpc.Upa.Exceptions.UPAException("MissingAlias");
                            }
                        }
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryField> oldFields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryField>(q.GetFields());
                    System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryField> newFields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryField>();
                    System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> newResults = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.ResultField>();
                    System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> context2 = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryStatement>();
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(context2, context);
                    context2.Add(q);
                    foreach (Net.Vpc.Upa.Expressions.QueryField f in oldFields) {
                        Net.Vpc.Upa.Expressions.Expression expression = f.GetExpression();
                        string oldAlias = f.GetAlias();
                        System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> newVal = CreateResultFields(expression, oldAlias, fieldFilter, context2);
                        Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(newResults, newVal);
                        if ((newVal).Count == 0) {
                        } else if ((newVal).Count == 1) {
                            f.SetExpression(newVal[0].GetExpression());
                            f.SetAlias(Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(oldAlias) ? oldAlias : newVal[0].GetAlias());
                            newFields.Add(f);
                        } else {
                            foreach (Net.Vpc.Upa.Persistence.ResultField nf in newVal) {
                                Net.Vpc.Upa.Expressions.QueryField f2 = new Net.Vpc.Upa.Expressions.QueryField(Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(oldAlias) ? oldAlias : nf.GetAlias(), nf.GetExpression());
                                newFields.Add(f2);
                            }
                        }
                    }
                    qs.ClearFields();
                    foreach (Net.Vpc.Upa.Expressions.QueryField newField in newFields) {
                        qs.Field(newField);
                    }
                    m.SetStatement(qs);
                    foreach (Net.Vpc.Upa.Persistence.ResultField newResult in newResults) {
                        m.AddField(newResult);
                    }
                } else if (q is Net.Vpc.Upa.Expressions.Union) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> context2 = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryStatement>();
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(context2, context);
                    context2.Add(q);
                    Net.Vpc.Upa.Expressions.Union u0 = (Net.Vpc.Upa.Expressions.Union) q;
                    Net.Vpc.Upa.Expressions.Union u = new Net.Vpc.Upa.Expressions.Union();
                    Net.Vpc.Upa.Persistence.ResultField[] fields = null;
                    foreach (Net.Vpc.Upa.Expressions.QueryStatement qs in u0.GetQueryStatements()) {
                        Net.Vpc.Upa.Persistence.ResultMetaData resultMetaData = CreateResultMetaData(qs, fieldFilter, context2);
                        u.Add((Net.Vpc.Upa.Expressions.QueryStatement) resultMetaData.GetStatement());
                        System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> f = resultMetaData.GetFields();
                        if (fields == null) {
                            fields = f.ToArray();
                        } else {
                            if (fields.Length != (f).Count) {
                                throw new Net.Vpc.Upa.Exceptions.UPAException("InvalidUnion");
                            }
                            for (int i = 0; i < fields.Length; i++) {
                                fields[i] = Merge(fields[i], f[i]);
                            }
                        }
                    }
                    m.SetStatement(u);
                    if (fields != null) {
                        foreach (Net.Vpc.Upa.Persistence.ResultField field in fields) {
                            m.AddField(field);
                        }
                    }
                } else {
                    throw new System.Exception();
                }
            }
            return m;
        }

        protected internal virtual Net.Vpc.Upa.Persistence.ResultField Merge(Net.Vpc.Upa.Persistence.ResultField first, Net.Vpc.Upa.Persistence.ResultField second) {
            throw new Net.Vpc.Upa.Exceptions.UPAException("NoSupportedYet");
        }

        protected internal virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> CreateResultFields(Net.Vpc.Upa.Expressions.Expression expression, string alias, Net.Vpc.Upa.Filters.FieldFilter fieldFilter, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> context) {
            expression = expressionManager.ParseExpression(expression);
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> results = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.ResultField>();
            if (expression is Net.Vpc.Upa.Expressions.Var) {
                Net.Vpc.Upa.Expressions.Var v = (Net.Vpc.Upa.Expressions.Var) expression;
                Net.Vpc.Upa.Expressions.Expression parent = v.GetApplier();
                if (parent != null) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> parentResults = CreateResultFields(parent, null, fieldFilter, context);
                    int size = (parentResults).Count;
                    foreach (Net.Vpc.Upa.Persistence.ResultField p in parentResults) {
                        if (size > 1) {
                            v = (Net.Vpc.Upa.Expressions.Var) v.Copy();
                        }
                        if (p.GetExpression() != parent) {
                            //change parent
                            v.SetApplier((Net.Vpc.Upa.Expressions.Var) p.GetExpression());
                        }
                        if (p.GetEntity() != null) {
                            if (v.GetName().Equals("*")) {
                                foreach (Net.Vpc.Upa.Field field in p.GetEntity().GetFields(fieldFilter)) {
                                    results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                }
                            } else {
                                Net.Vpc.Upa.Field field = p.GetEntity().GetField(v.GetName());
                                results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                            }
                        } else if (p.GetField() != null) {
                            if (p.GetField().GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                                Net.Vpc.Upa.Entity entity = ((Net.Vpc.Upa.Types.ManyToOneType) p.GetField().GetDataType()).GetTargetEntity();
                                if (v.GetName().Equals("*")) {
                                    foreach (Net.Vpc.Upa.Field field in entity.GetFields(fieldFilter)) {
                                        results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                    }
                                } else {
                                    Net.Vpc.Upa.Field field = entity.GetField(v.GetName());
                                    results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                }
                            } else {
                                results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.Vpc.Upa.Types.TypesFactory.OBJECT, null, null));
                            }
                        } else {
                            results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.Vpc.Upa.Types.TypesFactory.OBJECT, null, null));
                        }
                    }
                } else {
                    string name = v.GetName();
                    System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery> declarations = FindDeclarations(context);
                    Net.Vpc.Upa.Expressions.NameOrQuery r = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Expressions.NameOrQuery>(declarations,name);
                    if (r != null) {
                        if (r is Net.Vpc.Upa.Expressions.EntityName) {
                            Net.Vpc.Upa.Entity entity = pu.GetEntity(((Net.Vpc.Upa.Expressions.EntityName) r).GetName());
                            results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, entity.GetDataType(), null, entity));
                        } else {
                            results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.Vpc.Upa.Types.TypesFactory.OBJECT, null, null));
                        }
                    } else {
                        if ("*".Equals(name)) {
                            foreach (System.Collections.Generic.KeyValuePair<string , Net.Vpc.Upa.Expressions.NameOrQuery> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.Vpc.Upa.Expressions.NameOrQuery>>(declarations)) {
                                r = (entry).Value;
                                if (r is Net.Vpc.Upa.Expressions.EntityName) {
                                    Net.Vpc.Upa.Entity entity = pu.GetEntity(((Net.Vpc.Upa.Expressions.EntityName) r).GetName());
                                    Net.Vpc.Upa.Field field = entity.FindField(name);
                                    results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                    break;
                                }
                            }
                        } else {
                            Net.Vpc.Upa.Field field = null;
                            foreach (System.Collections.Generic.KeyValuePair<string , Net.Vpc.Upa.Expressions.NameOrQuery> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.Vpc.Upa.Expressions.NameOrQuery>>(declarations)) {
                                r = (entry).Value;
                                if (r is Net.Vpc.Upa.Expressions.EntityName) {
                                    Net.Vpc.Upa.Entity entity = pu.GetEntity(((Net.Vpc.Upa.Expressions.EntityName) r).GetName());
                                    field = entity.FindField(name);
                                    break;
                                }
                            }
                            if (field != null) {
                                results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                            } else {
                                results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.Vpc.Upa.Types.TypesFactory.OBJECT, null, null));
                            }
                        }
                    }
                }
                return results;
            }
            results.Add(new Net.Vpc.Upa.Impl.Persistence.DefaultResultField(expression, alias, Net.Vpc.Upa.Types.TypesFactory.OBJECT, null, null));
            return results;
        }

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery> FindDeclarations(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> queryStatements) {
            System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery> names = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery>();
            for (int i = 0; i < (queryStatements).Count; i++) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,Net.Vpc.Upa.Expressions.NameOrQuery>(names,FindDeclarations(queryStatements[0]));
            }
            return names;
        }

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery> FindDeclarations(Net.Vpc.Upa.Expressions.QueryStatement queryStatement) {
            System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery> names = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Expressions.NameOrQuery>();
            if (queryStatement is Net.Vpc.Upa.Expressions.Select) {
                Net.Vpc.Upa.Expressions.Select s = (Net.Vpc.Upa.Expressions.Select) queryStatement;
                if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(s.GetEntityAlias())) {
                    names[s.GetEntityAlias()]=s.GetEntity();
                } else {
                    string t = s.GetEntityName();
                    if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(t)) {
                        names[s.GetEntityAlias()]=s.GetEntity();
                    }
                }
                foreach (Net.Vpc.Upa.Expressions.JoinCriteria j in s.GetJoins()) {
                    if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(j.GetEntityAlias())) {
                        names[j.GetEntityAlias()]=j.GetEntity();
                    } else {
                        string t = j.GetEntityName();
                        if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(t)) {
                            names[j.GetEntityAlias()]=j.GetEntity();
                        }
                    }
                }
            } else if (queryStatement is Net.Vpc.Upa.Expressions.Union) {
            }
            // do nothing
            return names;
        }
    }
}
