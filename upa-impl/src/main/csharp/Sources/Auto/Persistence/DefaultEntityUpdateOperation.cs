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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:09 AM
     */
    public class DefaultEntityUpdateOperation : Net.Vpc.Upa.Persistence.EntityUpdateOperation {

        public virtual int Update(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Update u = new Net.Vpc.Upa.Expressions.Update().Entity(entity.GetName());
            foreach (string fieldName in updates.KeySet()) {
                Net.Vpc.Upa.Field f = entity.FindField(fieldName);
                if (f != null && Net.Vpc.Upa.Impl.Util.Filters.Fields2.UPDATE.Accept(f)) {
                    object @value = updates.GetObject<T>(fieldName);
                    if ((f.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType)) {
                        Net.Vpc.Upa.Types.ManyToOneType e = (Net.Vpc.Upa.Types.ManyToOneType) f.GetDataType();
                        if (e.IsUpdatable()) {
                            Net.Vpc.Upa.Entity masterEntity = context.GetPersistenceUnit().GetEntity(e.GetTargetEntityName());
                            Net.Vpc.Upa.EntityBuilder mbuilder = masterEntity.GetBuilder();
                            if (@value is Net.Vpc.Upa.Expressions.Expression) {
                                Net.Vpc.Upa.Expressions.Expression evalue;
                                System.Collections.Generic.IList<Net.Vpc.Upa.Field> sfields = e.GetRelationship().GetSourceRole().GetFields();
                                System.Collections.Generic.IList<Net.Vpc.Upa.Field> tfields = e.GetRelationship().GetTargetRole().GetFields();
                                for (int i = 0; i < (sfields).Count; i++) {
                                    Net.Vpc.Upa.Field fk = sfields[i];
                                    Net.Vpc.Upa.Field fid = tfields[i];
                                    evalue = ((Net.Vpc.Upa.Expressions.Expression) @value).Copy();
                                    evalue = context.GetPersistenceUnit().GetExpressionManager().ParseExpression(evalue);
                                    if (evalue is Net.Vpc.Upa.Expressions.Select) {
                                        Net.Vpc.Upa.Expressions.Select svalue = (Net.Vpc.Upa.Expressions.Select) evalue;
                                        if (svalue.CountFields() != 1) {
                                            throw new System.Exception("Invalid Expression " + svalue + " as formula for field " + f.GetAbsoluteName());
                                        }
                                        if (svalue.GetField(0).GetExpression() is Net.Vpc.Upa.Expressions.Var) {
                                            svalue.GetField(0).SetExpression(new Net.Vpc.Upa.Expressions.Var((Net.Vpc.Upa.Expressions.Var) svalue.GetField(0).GetExpression(), fid.GetName()));
                                        } else {
                                            throw new System.Exception("Invalid Expression " + svalue + " as formula for field " + f.GetAbsoluteName());
                                        }
                                    } else if (evalue is Net.Vpc.Upa.Expressions.Var) {
                                        evalue = (new Net.Vpc.Upa.Expressions.Var((Net.Vpc.Upa.Expressions.Var) evalue, fk.GetName()));
                                    } else if (evalue is Net.Vpc.Upa.Expressions.Param) {
                                    } else if (evalue is Net.Vpc.Upa.Expressions.Literal) {
                                    } else {
                                        throw new System.Exception("Invalid Expression " + evalue + " as formula for field " + f.GetAbsoluteName());
                                    }
                                    u.Set(fk.GetName(), evalue);
                                }
                            } else {
                                Net.Vpc.Upa.Key k = null;
                                if (@value is Net.Vpc.Upa.Record) {
                                    k = mbuilder.RecordToKey((Net.Vpc.Upa.Record) @value);
                                } else {
                                    k = mbuilder.ObjectToKey(@value);
                                }
                                int x = 0;
                                foreach (Net.Vpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                                    u.Set(fk.GetName(), new Net.Vpc.Upa.Expressions.Param(fk.GetName(), k == null ? null : k.GetObjectAt(x)));
                                    x++;
                                }
                            }
                        }
                    } else {
                        Net.Vpc.Upa.Expressions.Expression expression = (@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)((Net.Vpc.Upa.Expressions.Expression) @value)) : new Net.Vpc.Upa.Expressions.Param(null, @value);
                        u.Set(fieldName, expression);
                    }
                }
            }
            u.Where(condition);
            return context.GetPersistenceStore().CreateQuery(u, context).ExecuteNonQuery();
        }

        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Update query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
