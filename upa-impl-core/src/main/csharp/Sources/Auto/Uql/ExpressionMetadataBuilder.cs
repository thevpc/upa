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
namespace Net.TheVpc.Upa.Impl.Uql
{


    /**
     * Created by vpc on 6/28/16.
     */
    public class ExpressionMetadataBuilder {

        internal Net.TheVpc.Upa.ExpressionManager expressionManager;

        internal Net.TheVpc.Upa.PersistenceUnit pu;

        public ExpressionMetadataBuilder(Net.TheVpc.Upa.ExpressionManager expressionManager, Net.TheVpc.Upa.PersistenceUnit pu) {
            this.expressionManager = expressionManager;
            this.pu = pu;
        }

        public virtual Net.TheVpc.Upa.Persistence.ResultMetaData CreateResultMetaData(Net.TheVpc.Upa.Expressions.Expression baseExpression, Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) {
            return CreateResultMetaData(baseExpression, fieldFilter, new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryStatement>());
        }

        public virtual Net.TheVpc.Upa.Persistence.ResultMetaData CreateResultMetaData(Net.TheVpc.Upa.Expressions.Expression baseExpression, Net.TheVpc.Upa.Filters.FieldFilter fieldFilter, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> context) {
            baseExpression = Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.ParseUserExpressions(baseExpression, pu);
            Net.TheVpc.Upa.Impl.Persistence.DefaultResultMetaData m = new Net.TheVpc.Upa.Impl.Persistence.DefaultResultMetaData();
            if (baseExpression is Net.TheVpc.Upa.Expressions.NonQueryStatement) {
                m.SetStatement((Net.TheVpc.Upa.Expressions.EntityStatement) baseExpression);
                m.AddField(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(null, "result", Net.TheVpc.Upa.Types.TypesFactory.INT, null, null));
                return m;
            } else {
                Net.TheVpc.Upa.Expressions.QueryStatement q = (Net.TheVpc.Upa.Expressions.QueryStatement) baseExpression;
                if (q is Net.TheVpc.Upa.Expressions.Select) {
                    Net.TheVpc.Upa.Expressions.Select qs = (Net.TheVpc.Upa.Expressions.Select) q;
                    if ((qs.GetFields()).Count == 0) {
                        if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(qs.GetEntityAlias())) {
                            qs.Field(new Net.TheVpc.Upa.Expressions.Var(qs.GetEntityAlias()));
                        } else if (qs.GetEntityName() != null) {
                            qs.Field(new Net.TheVpc.Upa.Expressions.Var(qs.GetEntityName()));
                        } else {
                            throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingAlias");
                        }
                        foreach (Net.TheVpc.Upa.Expressions.JoinCriteria joinCriteria in qs.GetJoins()) {
                            if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(joinCriteria.GetEntityAlias())) {
                                qs.Field(new Net.TheVpc.Upa.Expressions.Var(joinCriteria.GetEntityAlias()));
                            } else if (joinCriteria.GetEntityName() != null) {
                                qs.Field(new Net.TheVpc.Upa.Expressions.Var(joinCriteria.GetEntityName()));
                            } else {
                                throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingAlias");
                            }
                        }
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryField> oldFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryField>(q.GetFields());
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryField> newFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryField>();
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> newResults = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.ResultField>();
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> context2 = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryStatement>();
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(context2, context);
                    context2.Add(q);
                    foreach (Net.TheVpc.Upa.Expressions.QueryField f in oldFields) {
                        Net.TheVpc.Upa.Expressions.Expression expression = f.GetExpression();
                        string oldAlias = f.GetAlias();
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> newVal = CreateResultFields(expression, oldAlias, fieldFilter, context2);
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(newResults, newVal);
                        if ((newVal).Count == 0) {
                        } else if ((newVal).Count == 1) {
                            f.SetExpression(newVal[0].GetExpression());
                            f.SetAlias(Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(oldAlias) ? oldAlias : newVal[0].GetAlias());
                            newFields.Add(f);
                        } else {
                            foreach (Net.TheVpc.Upa.Persistence.ResultField nf in newVal) {
                                Net.TheVpc.Upa.Expressions.QueryField f2 = new Net.TheVpc.Upa.Expressions.QueryField(Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(oldAlias) ? oldAlias : nf.GetAlias(), nf.GetExpression());
                                newFields.Add(f2);
                            }
                        }
                    }
                    qs.ClearFields();
                    foreach (Net.TheVpc.Upa.Expressions.QueryField newField in newFields) {
                        qs.Field(newField);
                    }
                    m.SetStatement(qs);
                    foreach (Net.TheVpc.Upa.Persistence.ResultField newResult in newResults) {
                        m.AddField(newResult);
                    }
                } else if (q is Net.TheVpc.Upa.Expressions.Union) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> context2 = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryStatement>();
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(context2, context);
                    context2.Add(q);
                    Net.TheVpc.Upa.Expressions.Union u0 = (Net.TheVpc.Upa.Expressions.Union) q;
                    Net.TheVpc.Upa.Expressions.Union u = new Net.TheVpc.Upa.Expressions.Union();
                    Net.TheVpc.Upa.Persistence.ResultField[] fields = null;
                    foreach (Net.TheVpc.Upa.Expressions.QueryStatement qs in u0.GetQueryStatements()) {
                        Net.TheVpc.Upa.Persistence.ResultMetaData resultMetaData = CreateResultMetaData(qs, fieldFilter, context2);
                        u.Add((Net.TheVpc.Upa.Expressions.QueryStatement) resultMetaData.GetStatement());
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> f = resultMetaData.GetFields();
                        if (fields == null) {
                            fields = f.ToArray();
                        } else {
                            if (fields.Length != (f).Count) {
                                throw new Net.TheVpc.Upa.Exceptions.UPAException("InvalidUnion");
                            }
                            for (int i = 0; i < fields.Length; i++) {
                                fields[i] = Merge(fields[i], f[i]);
                            }
                        }
                    }
                    m.SetStatement(u);
                    if (fields != null) {
                        foreach (Net.TheVpc.Upa.Persistence.ResultField field in fields) {
                            m.AddField(field);
                        }
                    }
                } else {
                    throw new System.Exception();
                }
            }
            return m;
        }

        protected internal virtual Net.TheVpc.Upa.Persistence.ResultField Merge(Net.TheVpc.Upa.Persistence.ResultField first, Net.TheVpc.Upa.Persistence.ResultField second) {
            throw new Net.TheVpc.Upa.Exceptions.UPAException("NoSupportedYet");
        }

        protected internal virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> CreateResultFields(Net.TheVpc.Upa.Expressions.Expression expression, string alias, Net.TheVpc.Upa.Filters.FieldFilter fieldFilter, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> context) {
            expression = expressionManager.ParseExpression(expression);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> results = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.ResultField>();
            if (expression is Net.TheVpc.Upa.Expressions.Var) {
                Net.TheVpc.Upa.Expressions.Var v = (Net.TheVpc.Upa.Expressions.Var) expression;
                Net.TheVpc.Upa.Expressions.Expression parent = v.GetApplier();
                if (parent != null) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> parentResults = CreateResultFields(parent, null, fieldFilter, context);
                    int size = (parentResults).Count;
                    foreach (Net.TheVpc.Upa.Persistence.ResultField p in parentResults) {
                        if (size > 1) {
                            v = (Net.TheVpc.Upa.Expressions.Var) v.Copy();
                        }
                        if (p.GetExpression() != parent) {
                            //change parent
                            v.SetApplier((Net.TheVpc.Upa.Expressions.Var) p.GetExpression());
                        }
                        if (p.GetEntity() != null) {
                            if (v.GetName().Equals("*")) {
                                foreach (Net.TheVpc.Upa.Field field in p.GetEntity().GetFields(fieldFilter)) {
                                    results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                }
                            } else {
                                Net.TheVpc.Upa.Field field = p.GetEntity().GetField(v.GetName());
                                results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                            }
                        } else if (p.GetField() != null) {
                            if (p.GetField().GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                                Net.TheVpc.Upa.Entity entity = ((Net.TheVpc.Upa.Types.ManyToOneType) p.GetField().GetDataType()).GetTargetEntity();
                                if (v.GetName().Equals("*")) {
                                    foreach (Net.TheVpc.Upa.Field field in entity.GetFields(fieldFilter)) {
                                        results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                    }
                                } else {
                                    Net.TheVpc.Upa.Field field = entity.GetField(v.GetName());
                                    results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                }
                            } else {
                                results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.TheVpc.Upa.Types.TypesFactory.OBJECT, null, null));
                            }
                        } else {
                            results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.TheVpc.Upa.Types.TypesFactory.OBJECT, null, null));
                        }
                    }
                } else {
                    string name = v.GetName();
                    System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery> declarations = FindDeclarations(context);
                    Net.TheVpc.Upa.Expressions.NameOrQuery r = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Expressions.NameOrQuery>(declarations,name);
                    if (r != null) {
                        if (r is Net.TheVpc.Upa.Expressions.EntityName) {
                            Net.TheVpc.Upa.Entity entity = pu.GetEntity(((Net.TheVpc.Upa.Expressions.EntityName) r).GetName());
                            results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, entity.GetDataType(), null, entity));
                        } else {
                            results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.TheVpc.Upa.Types.TypesFactory.OBJECT, null, null));
                        }
                    } else {
                        if ("*".Equals(name)) {
                            foreach (System.Collections.Generic.KeyValuePair<string , Net.TheVpc.Upa.Expressions.NameOrQuery> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.TheVpc.Upa.Expressions.NameOrQuery>>(declarations)) {
                                r = (entry).Value;
                                if (r is Net.TheVpc.Upa.Expressions.EntityName) {
                                    Net.TheVpc.Upa.Entity entity = pu.GetEntity(((Net.TheVpc.Upa.Expressions.EntityName) r).GetName());
                                    Net.TheVpc.Upa.Field field = entity.FindField(name);
                                    results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                                    break;
                                }
                            }
                        } else {
                            Net.TheVpc.Upa.Field field = null;
                            foreach (System.Collections.Generic.KeyValuePair<string , Net.TheVpc.Upa.Expressions.NameOrQuery> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,Net.TheVpc.Upa.Expressions.NameOrQuery>>(declarations)) {
                                r = (entry).Value;
                                if (r is Net.TheVpc.Upa.Expressions.EntityName) {
                                    Net.TheVpc.Upa.Entity entity = pu.GetEntity(((Net.TheVpc.Upa.Expressions.EntityName) r).GetName());
                                    field = entity.FindField(name);
                                    break;
                                }
                            }
                            if (field != null) {
                                results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, field.GetDataType(), field, null));
                            } else {
                                results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(v, alias, Net.TheVpc.Upa.Types.TypesFactory.OBJECT, null, null));
                            }
                        }
                    }
                }
                return results;
            }
            results.Add(new Net.TheVpc.Upa.Impl.Persistence.DefaultResultField(expression, alias, Net.TheVpc.Upa.Types.TypesFactory.OBJECT, null, null));
            return results;
        }

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery> FindDeclarations(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> queryStatements) {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery> names = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery>();
            for (int i = 0; i < (queryStatements).Count; i++) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,Net.TheVpc.Upa.Expressions.NameOrQuery>(names,FindDeclarations(queryStatements[0]));
            }
            return names;
        }

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery> FindDeclarations(Net.TheVpc.Upa.Expressions.QueryStatement queryStatement) {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery> names = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Expressions.NameOrQuery>();
            if (queryStatement is Net.TheVpc.Upa.Expressions.Select) {
                Net.TheVpc.Upa.Expressions.Select s = (Net.TheVpc.Upa.Expressions.Select) queryStatement;
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(s.GetEntityAlias())) {
                    names[s.GetEntityAlias()]=s.GetEntity();
                } else {
                    string t = s.GetEntityName();
                    if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(t)) {
                        names[s.GetEntityAlias()]=s.GetEntity();
                    }
                }
                foreach (Net.TheVpc.Upa.Expressions.JoinCriteria j in s.GetJoins()) {
                    if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(j.GetEntityAlias())) {
                        names[j.GetEntityAlias()]=j.GetEntity();
                    } else {
                        string t = j.GetEntityName();
                        if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(t)) {
                            names[j.GetEntityAlias()]=j.GetEntity();
                        }
                    }
                }
            } else if (queryStatement is Net.TheVpc.Upa.Expressions.Union) {
            }
            // do nothing
            return names;
        }
    }
}
