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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:09 AM
     */
    public class DefaultEntityUpdateOperation : Net.TheVpc.Upa.Persistence.EntityUpdateOperation {

        public virtual int Update(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Record updates, Net.TheVpc.Upa.Expressions.Expression condition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.Update u = new Net.TheVpc.Upa.Expressions.Update().Entity(entity.GetName());
            foreach (string fieldName in updates.KeySet()) {
                Net.TheVpc.Upa.Field f = entity.FindField(fieldName);
                if (f != null && Net.TheVpc.Upa.Impl.Util.Filters.Fields2.UPDATE.Accept(f)) {
                    object @value = updates.GetObject<T>(fieldName);
                    if ((f.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType)) {
                        Net.TheVpc.Upa.Types.ManyToOneType e = (Net.TheVpc.Upa.Types.ManyToOneType) f.GetDataType();
                        if (e.IsUpdatable()) {
                            Net.TheVpc.Upa.Entity masterEntity = context.GetPersistenceUnit().GetEntity(e.GetTargetEntityName());
                            Net.TheVpc.Upa.EntityBuilder mbuilder = masterEntity.GetBuilder();
                            if (@value is Net.TheVpc.Upa.Expressions.Expression) {
                                Net.TheVpc.Upa.Expressions.Expression evalue;
                                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> sfields = e.GetRelationship().GetSourceRole().GetFields();
                                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> tfields = e.GetRelationship().GetTargetRole().GetFields();
                                for (int i = 0; i < (sfields).Count; i++) {
                                    Net.TheVpc.Upa.Field fk = sfields[i];
                                    Net.TheVpc.Upa.Field fid = tfields[i];
                                    evalue = ((Net.TheVpc.Upa.Expressions.Expression) @value).Copy();
                                    evalue = context.GetPersistenceUnit().GetExpressionManager().ParseExpression(evalue);
                                    if (evalue is Net.TheVpc.Upa.Expressions.Select) {
                                        Net.TheVpc.Upa.Expressions.Select svalue = (Net.TheVpc.Upa.Expressions.Select) evalue;
                                        if (svalue.CountFields() != 1) {
                                            throw new System.Exception("Invalid Expression " + svalue + " as formula for field " + f.GetAbsoluteName());
                                        }
                                        if (svalue.GetField(0).GetExpression() is Net.TheVpc.Upa.Expressions.Var) {
                                            svalue.GetField(0).SetExpression(new Net.TheVpc.Upa.Expressions.Var((Net.TheVpc.Upa.Expressions.Var) svalue.GetField(0).GetExpression(), fid.GetName()));
                                        } else {
                                            throw new System.Exception("Invalid Expression " + svalue + " as formula for field " + f.GetAbsoluteName());
                                        }
                                    } else if (evalue is Net.TheVpc.Upa.Expressions.Var) {
                                        evalue = (new Net.TheVpc.Upa.Expressions.Var((Net.TheVpc.Upa.Expressions.Var) evalue, fk.GetName()));
                                    } else if (evalue is Net.TheVpc.Upa.Expressions.Param) {
                                    } else if (evalue is Net.TheVpc.Upa.Expressions.Literal) {
                                    } else {
                                        throw new System.Exception("Invalid Expression " + evalue + " as formula for field " + f.GetAbsoluteName());
                                    }
                                    u.Set(fk.GetName(), evalue);
                                }
                            } else {
                                Net.TheVpc.Upa.Key k = null;
                                if (@value is Net.TheVpc.Upa.Record) {
                                    k = mbuilder.RecordToKey((Net.TheVpc.Upa.Record) @value);
                                } else {
                                    k = mbuilder.ObjectToKey(@value);
                                }
                                int x = 0;
                                foreach (Net.TheVpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                                    u.Set(fk.GetName(), new Net.TheVpc.Upa.Expressions.Param(fk.GetName(), k == null ? null : k.GetObjectAt(x)));
                                    x++;
                                }
                            }
                        }
                    } else {
                        Net.TheVpc.Upa.Expressions.Expression expression = (@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)((Net.TheVpc.Upa.Expressions.Expression) @value)) : new Net.TheVpc.Upa.Expressions.Param(null, @value);
                        u.Set(fieldName, expression);
                    }
                }
            }
            u.Where(condition);
            return context.GetPersistenceStore().CreateQuery(u, context).ExecuteNonQuery();
        }

        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity e, Net.TheVpc.Upa.Expressions.Update query, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
