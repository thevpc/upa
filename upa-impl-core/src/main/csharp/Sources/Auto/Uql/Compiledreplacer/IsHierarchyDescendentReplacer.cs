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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledreplacer
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class IsHierarchyDescendentReplacer : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        public IsHierarchyDescendentReplacer(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression Update(Net.TheVpc.Upa.Expressions.CompiledExpression e) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled) e;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c = o.GetChildExpression();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression p = o.GetAncestorExpression();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName n = o.GetEntityName();
            Net.TheVpc.Upa.Entity treeEntity = null;
            Net.TheVpc.Upa.Field treeField = null;
            if (c is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                object childReferrer = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) c).GetFinest().GetReferrer();
                if (childReferrer != null) {
                    if (childReferrer is Net.TheVpc.Upa.Entity) {
                        if (treeEntity == null) {
                            treeEntity = (Net.TheVpc.Upa.Entity) childReferrer;
                        } else {
                            if (!treeEntity.GetName().Equals(((Net.TheVpc.Upa.Entity) childReferrer).GetName())) {
                                throw new System.ArgumentException ("Ambiguous or Invalid Type " + treeEntity.GetName() + " in TreeEntity near " + e);
                            }
                        }
                    }
                }
            } else if (c is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                object co = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) c).GetValue();
                if (co != null && persistenceUnit.ContainsEntity(co.GetType())) {
                    Net.TheVpc.Upa.Entity rr = persistenceUnit.GetEntity(co.GetType());
                    if (treeEntity == null) {
                        treeEntity = rr;
                    }
                    ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) c).SetValue(rr.GetBuilder().ObjectToId(co));
                }
            }
            //            Object co = ((CompiledParam) c).getEffectiveDataType();
            if (p is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                object parentReferrer = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p).GetFinest().GetReferrer();
                if (parentReferrer != null) {
                    if (parentReferrer is Net.TheVpc.Upa.Entity) {
                        if (treeEntity == null) {
                            treeEntity = (Net.TheVpc.Upa.Entity) parentReferrer;
                        } else {
                            if (!treeEntity.GetName().Equals(((Net.TheVpc.Upa.Entity) parentReferrer).GetName())) {
                                throw new System.ArgumentException ("Ambiguous or Invalid Type " + treeEntity.GetName() + " in TreeEntity near " + e);
                            }
                        }
                    }
                }
            } else if (p is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                object co = ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) p).GetValue();
                if (co != null && persistenceUnit.ContainsEntity(co.GetType())) {
                    Net.TheVpc.Upa.Entity rr = persistenceUnit.FindEntity(co.GetType());
                    if (treeEntity == null) {
                        treeEntity = rr;
                    }
                    ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) p).SetValue(rr.GetBuilder().ObjectToId(co));
                    if ((rr.GetPrimaryFields()).Count > 1) {
                        throw new System.ArgumentException ("Not supported");
                    }
                    ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) p).SetTypeTransform(Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(rr.GetPrimaryFields()[0]));
                }
            }
            //            Object co = ((CompiledParam) c).getEffectiveDataType();
            if (treeEntity == null) {
                treeEntity = persistenceUnit.GetEntity(n.GetName());
            }
            Net.TheVpc.Upa.Relationship t = Net.TheVpc.Upa.Impl.Extension.HierarchicalRelationshipSupport.GetTreeRelationName(treeEntity);
            if (t == null) {
                throw new System.ArgumentException ("Hierarchy Relationship not found");
            }
            Net.TheVpc.Upa.Extensions.HierarchyExtension s = t.GetHierarchyExtension();
            if (s == null) {
                throw new System.ArgumentException ("Not a valid TreeEntity");
            }
            Net.TheVpc.Upa.Field pathField = treeEntity.GetField(s.GetHierarchyPathField());
            string pathSep = s.GetHierarchyPathSeparator();
            return CreateConditionForDeepSearch(c, (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) p, true, pathField, pathSep);
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression CreateConditionForDeepSearch(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression id, bool includeId, Net.TheVpc.Upa.Field field, string pathSep) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            alias = alias.Copy();
            if (alias is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar cv = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) alias;
                if (cv.GetReferrer() is Net.TheVpc.Upa.Entity) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(field.GetName());
                    ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) alias).SetChild(v);
                } else {
                    throw new System.ArgumentException ("Expected " + field.GetEntity().GetName() + " var name");
                }
            } else {
                throw new System.ArgumentException ("Expected " + field.GetEntity().GetName() + " var name");
            }
            id = id.Copy();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = field.GetEntity().GetPrimaryFields();
            if ((primaryFields).Count > 1) {
                throw new System.ArgumentException ("Composite ID unsupported for function treeancestor");
            }
            Net.TheVpc.Upa.Types.DataType pkType = primaryFields[0].GetDataType();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression strId = null;
            if (pkType is Net.TheVpc.Upa.Types.IntType) {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.TheVpc.Upa.Types.LongType) {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.TheVpc.Upa.Types.ShortType) {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.TheVpc.Upa.Types.ByteType) {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(id);
            } else if (pkType is Net.TheVpc.Upa.Types.FloatType) {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(id);
            } else if (pkType is Net.TheVpc.Upa.Types.DoubleType) {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(id);
            } else if (pkType is Net.TheVpc.Upa.Types.StringType) {
                strId = id;
            } else {
                strId = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCast(id, Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING);
            }
            if (includeId) {
                return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOr(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(alias.Copy(), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("%" + pathSep), strId.Copy())), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(alias.Copy(), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("%" + pathSep), strId.Copy(), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(pathSep + "%"))));
            } else {
                return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(alias.Copy(), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral("%" + pathSep), strId.Copy(), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(pathSep + "%")));
            }
        }
    }
}
