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



namespace Net.Vpc.Upa.Impl.Uql.Compiledreplacer
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class IsHierarchyDescendentReplacer : Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        public IsHierarchyDescendentReplacer(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression Update(Net.Vpc.Upa.Expressions.CompiledExpression e) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled) e;
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c = o.GetChildExpression();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression p = o.GetAncestorExpression();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName n = o.GetEntityName();
            Net.Vpc.Upa.Entity treeEntity = null;
            Net.Vpc.Upa.Field treeField = null;
            if (c is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                object childReferrer = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) c).GetFinest().GetReferrer();
                if (childReferrer != null) {
                    if (childReferrer is Net.Vpc.Upa.Entity) {
                        if (treeEntity == null) {
                            treeEntity = (Net.Vpc.Upa.Entity) childReferrer;
                        } else {
                            if (!treeEntity.GetName().Equals(((Net.Vpc.Upa.Entity) childReferrer).GetName())) {
                                throw new System.ArgumentException ("Ambiguous or Invalid Type " + treeEntity.GetName() + " in TreeEntity near " + e);
                            }
                        }
                    }
                }
            } else if (c is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                object co = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) c).GetValue();
                if (co != null && persistenceUnit.ContainsEntity(co.GetType())) {
                    Net.Vpc.Upa.Entity rr = persistenceUnit.GetEntity(co.GetType());
                    if (treeEntity == null) {
                        treeEntity = rr;
                    }
                    ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) c).SetValue(rr.GetBuilder().ObjectToId(co));
                }
            }
            //            Object co = ((CompiledParam) c).getEffectiveDataType();
            if (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                object parentReferrer = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p).GetFinest().GetReferrer();
                if (parentReferrer != null) {
                    if (parentReferrer is Net.Vpc.Upa.Entity) {
                        if (treeEntity == null) {
                            treeEntity = (Net.Vpc.Upa.Entity) parentReferrer;
                        } else {
                            if (!treeEntity.GetName().Equals(((Net.Vpc.Upa.Entity) parentReferrer).GetName())) {
                                throw new System.ArgumentException ("Ambiguous or Invalid Type " + treeEntity.GetName() + " in TreeEntity near " + e);
                            }
                        }
                    }
                }
            } else if (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                object co = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) p).GetValue();
                if (co != null && persistenceUnit.ContainsEntity(co.GetType())) {
                    Net.Vpc.Upa.Entity rr = persistenceUnit.FindEntity(co.GetType());
                    if (treeEntity == null) {
                        treeEntity = rr;
                    }
                    ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) p).SetValue(rr.GetBuilder().ObjectToId(co));
                    if ((rr.GetPrimaryFields()).Count > 1) {
                        throw new System.ArgumentException ("Not supported");
                    }
                    ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) p).SetTypeTransform(Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(rr.GetPrimaryFields()[0]));
                }
            }
            //            Object co = ((CompiledParam) c).getEffectiveDataType();
            if (treeEntity == null) {
                treeEntity = persistenceUnit.GetEntity(n.GetName());
            }
            Net.Vpc.Upa.Relationship t = Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipSupport.GetTreeRelationName(treeEntity);
            if (t == null) {
                throw new System.ArgumentException ("Hierarchy Relationship not found");
            }
            Net.Vpc.Upa.Extensions.HierarchyExtension s = t.GetHierarchyExtension();
            if (s == null) {
                throw new System.ArgumentException ("Not a valid TreeEntity");
            }
            Net.Vpc.Upa.Field pathField = treeEntity.GetField(s.GetHierarchyPathField());
            string pathSep = s.GetHierarchyPathSeparator();
            return CreateConditionForDeepSearch(c, (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) p, true, pathField, pathSep);
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression CreateConditionForDeepSearch(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression id, bool includeId, Net.Vpc.Upa.Field field, string pathSep) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            alias = alias.Copy();
            if (alias is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar cv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) alias;
                if (cv.GetReferrer() is Net.Vpc.Upa.Entity) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(field.GetName());
                    ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) alias).SetChild(v);
                } else {
                    throw new System.ArgumentException ("Expected " + field.GetEntity().GetName() + " var name");
                }
            } else {
                throw new System.ArgumentException ("Expected " + field.GetEntity().GetName() + " var name");
            }
            id = id.Copy();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = field.GetEntity().GetPrimaryFields();
            if ((primaryFields).Count > 1) {
                throw new System.ArgumentException ("Composite ID unsupported for function treeancestor");
            }
            Net.Vpc.Upa.Types.DataType pkType = primaryFields[0].GetDataType();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression strId = null;
            if (pkType is Net.Vpc.Upa.Types.IntType) {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.Vpc.Upa.Types.LongType) {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.Vpc.Upa.Types.ShortType) {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.Vpc.Upa.Types.ByteType) {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.Vpc.Upa.Types.FloatType) {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(id);
            } else if (pkType is Net.Vpc.Upa.Types.DoubleType) {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(id);
            } else if (pkType is Net.Vpc.Upa.Types.StringType) {
                strId = id;
            } else {
                strId = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCast(id, Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING);
            }
            if (includeId) {
                return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOr(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(alias.Copy(), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("%" + pathSep), strId.Copy())), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(alias.Copy(), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("%" + pathSep), strId.Copy(), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(pathSep + "%"))));
            } else {
                return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(alias.Copy(), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("%" + pathSep), strId.Copy(), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(pathSep + "%")));
            }
        }
    }
}
