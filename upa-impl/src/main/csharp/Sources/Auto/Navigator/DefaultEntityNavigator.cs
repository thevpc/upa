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



namespace Net.Vpc.Upa.Impl.Navigator
{


    public class DefaultEntityNavigator : Net.Vpc.Upa.EntityNavigator {

        protected internal Net.Vpc.Upa.Entity entity;

        public DefaultEntityNavigator(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object GetNextKey(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return id == null ? GetFirstKey() : GetNavigateKey(entity, id, '>');
        }

        public virtual object GetFirstKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetNavigateKey(entity, null, '<');
        }

        public virtual object GetLastKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetNavigateKey(entity, null, '>');
        }

        public virtual object GetPreviousKey(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return id == null ? GetFirstKey() : GetNavigateKey(entity, id, '<');
        }

        private object GetNavigateKey(Net.Vpc.Upa.Entity entity, object id, char @operator) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pk = entity.GetPrimaryFields();
            if ((pk).Count == 1) {
                Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select().From(entity.GetName());
                s.From(entity.GetName());
                string fieldName = pk[0].GetName();
                if (id != null) {
                    object[] @value = entity.GetBuilder().IdToKey(id).GetValue();
                    if (@operator == '<') {
                        s.Field(new Net.Vpc.Upa.Expressions.Max(new Net.Vpc.Upa.Expressions.Var(fieldName)), "next");
                        s.SetWhere(new Net.Vpc.Upa.Expressions.LessThan(new Net.Vpc.Upa.Expressions.Var(fieldName), new Net.Vpc.Upa.Expressions.Param(null, @value[0])));
                    } else if (@operator == '>') {
                        s.Field(new Net.Vpc.Upa.Expressions.Min(new Net.Vpc.Upa.Expressions.Var(fieldName)), "next");
                        s.SetWhere(new Net.Vpc.Upa.Expressions.GreaterThan(new Net.Vpc.Upa.Expressions.Var(fieldName), new Net.Vpc.Upa.Expressions.Param(null, @value[0])));
                    } else {
                        throw new System.Exception("WouldNeverBeThrownException");
                    }
                } else {
                    if (@operator == '<') {
                        s.Field(new Net.Vpc.Upa.Expressions.Min(new Net.Vpc.Upa.Expressions.Var(fieldName)), "next");
                    } else if (@operator == '>') {
                        s.Field(new Net.Vpc.Upa.Expressions.Max(new Net.Vpc.Upa.Expressions.Var(fieldName)), "next");
                    } else {
                        throw new System.Exception("WouldNeverBeThrownException");
                    }
                }
                Net.Vpc.Upa.Record next = entity.GetPersistenceUnit().CreateQuery(s).GetRecord();
                if (next != null) {
                    object o = next.GetObject<object>("next");
                    if (o != null) {
                        return entity.CreateId(o);
                    }
                }
                return null;
            } else {
                object[] v;
                Net.Vpc.Upa.Expressions.Select sb = new Net.Vpc.Upa.Expressions.Select();
                sb.Top(1);
                foreach (Net.Vpc.Upa.Field aPk in pk) {
                    sb.Field(new Net.Vpc.Upa.Expressions.Var(aPk.GetName()));
                }
                sb.From(entity.GetName());
                if (id != null) {
                    object[] @value = entity.GetBuilder().IdToKey(id).GetValue();
                    Net.Vpc.Upa.Expressions.Expression or = null;
                    for (int i = 0; i < (pk).Count; i++) {
                        Net.Vpc.Upa.Field pki = pk[i];
                        Net.Vpc.Upa.Expressions.Expression a = null;
                        for (int j = 0; j < i; j++) {
                            Net.Vpc.Upa.Field pkj = pk[j];
                            Net.Vpc.Upa.Expressions.Expression e = (new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(pkj.GetName()), (new Net.Vpc.Upa.Expressions.Param(null, @value[j]))));
                            a = (a == null) ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(a, e);
                        }
                        Net.Vpc.Upa.Expressions.Expression e2 = new Net.Vpc.Upa.Expressions.LessThan(new Net.Vpc.Upa.Expressions.Var(pki.GetName()), new Net.Vpc.Upa.Expressions.Param(null, @value[i]));
                        a = (a == null) ? ((Net.Vpc.Upa.Expressions.Expression)(e2)) : new Net.Vpc.Upa.Expressions.And(a, e2);
                        or = or == null ? ((Net.Vpc.Upa.Expressions.Expression)(a)) : new Net.Vpc.Upa.Expressions.Or(or, a);
                    }
                    sb.SetWhere(or);
                }
                foreach (Net.Vpc.Upa.Field aPk in pk) {
                    sb.OrderBy(new Net.Vpc.Upa.Expressions.Var(aPk.GetName()), @operator == '>');
                }
                Net.Vpc.Upa.Record r = entity.GetPersistenceUnit().CreateQuery(sb).GetRecord();
                if (r != null) {
                    object[] k = new object[(pk).Count];
                    for (int i = 0; i < k.Length; i++) {
                        k[i] = r.GetObject<object>(pk[i].GetName());
                    }
                    return entity.CreateId(k);
                }
            }
            return null;
        }

        public virtual object GetNewKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return null;
        }
    }
}
