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



namespace Net.TheVpc.Upa.Impl.Navigator
{


    public class DefaultEntityNavigator : Net.TheVpc.Upa.EntityNavigator {

        protected internal Net.TheVpc.Upa.Entity entity;

        public DefaultEntityNavigator(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual object GetNextKey(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return id == null ? GetFirstKey() : GetNavigateKey(entity, id, '>');
        }

        public virtual object GetFirstKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetNavigateKey(entity, null, '<');
        }

        public virtual object GetLastKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetNavigateKey(entity, null, '>');
        }

        public virtual object GetPreviousKey(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return id == null ? GetFirstKey() : GetNavigateKey(entity, id, '<');
        }

        private object GetNavigateKey(Net.TheVpc.Upa.Entity entity, object id, char @operator) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pk = entity.GetPrimaryFields();
            if ((pk).Count == 1) {
                Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select().From(entity.GetName());
                s.From(entity.GetName());
                string fieldName = pk[0].GetName();
                if (id != null) {
                    object[] @value = entity.GetBuilder().IdToKey(id).GetValue();
                    if (@operator == '<') {
                        s.Field(new Net.TheVpc.Upa.Expressions.Max(new Net.TheVpc.Upa.Expressions.Var(fieldName)), "next");
                        s.SetWhere(new Net.TheVpc.Upa.Expressions.LessThan(new Net.TheVpc.Upa.Expressions.Var(fieldName), new Net.TheVpc.Upa.Expressions.Param(null, @value[0])));
                    } else if (@operator == '>') {
                        s.Field(new Net.TheVpc.Upa.Expressions.Min(new Net.TheVpc.Upa.Expressions.Var(fieldName)), "next");
                        s.SetWhere(new Net.TheVpc.Upa.Expressions.GreaterThan(new Net.TheVpc.Upa.Expressions.Var(fieldName), new Net.TheVpc.Upa.Expressions.Param(null, @value[0])));
                    } else {
                        throw new System.Exception("WouldNeverBeThrownException");
                    }
                } else {
                    if (@operator == '<') {
                        s.Field(new Net.TheVpc.Upa.Expressions.Min(new Net.TheVpc.Upa.Expressions.Var(fieldName)), "next");
                    } else if (@operator == '>') {
                        s.Field(new Net.TheVpc.Upa.Expressions.Max(new Net.TheVpc.Upa.Expressions.Var(fieldName)), "next");
                    } else {
                        throw new System.Exception("WouldNeverBeThrownException");
                    }
                }
                Net.TheVpc.Upa.Record next = entity.GetPersistenceUnit().CreateQuery(s).GetRecord();
                if (next != null) {
                    object o = next.GetObject<T>("next");
                    if (o != null) {
                        return entity.CreateId(o);
                    }
                }
                return null;
            } else {
                object[] v;
                Net.TheVpc.Upa.Expressions.Select sb = new Net.TheVpc.Upa.Expressions.Select();
                sb.Top(1);
                foreach (Net.TheVpc.Upa.Field aPk in pk) {
                    sb.Field(new Net.TheVpc.Upa.Expressions.Var(aPk.GetName()));
                }
                sb.From(entity.GetName());
                if (id != null) {
                    object[] @value = entity.GetBuilder().IdToKey(id).GetValue();
                    Net.TheVpc.Upa.Expressions.Expression or = null;
                    for (int i = 0; i < (pk).Count; i++) {
                        Net.TheVpc.Upa.Field pki = pk[i];
                        Net.TheVpc.Upa.Expressions.Expression a = null;
                        for (int j = 0; j < i; j++) {
                            Net.TheVpc.Upa.Field pkj = pk[j];
                            Net.TheVpc.Upa.Expressions.Expression e = (new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(pkj.GetName()), (new Net.TheVpc.Upa.Expressions.Param(null, @value[j]))));
                            a = (a == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(a, e);
                        }
                        Net.TheVpc.Upa.Expressions.Expression e2 = new Net.TheVpc.Upa.Expressions.LessThan(new Net.TheVpc.Upa.Expressions.Var(pki.GetName()), new Net.TheVpc.Upa.Expressions.Param(null, @value[i]));
                        a = (a == null) ? ((Net.TheVpc.Upa.Expressions.Expression)(e2)) : new Net.TheVpc.Upa.Expressions.And(a, e2);
                        or = or == null ? ((Net.TheVpc.Upa.Expressions.Expression)(a)) : new Net.TheVpc.Upa.Expressions.Or(or, a);
                    }
                    sb.SetWhere(or);
                }
                foreach (Net.TheVpc.Upa.Field aPk in pk) {
                    sb.OrderBy(new Net.TheVpc.Upa.Expressions.Var(aPk.GetName()), @operator == '>');
                }
                Net.TheVpc.Upa.Record r = entity.GetPersistenceUnit().CreateQuery(sb).GetRecord();
                if (r != null) {
                    object[] k = new object[(pk).Count];
                    for (int i = 0; i < k.Length; i++) {
                        k[i] = r.GetObject<T>(pk[i].GetName());
                    }
                    return entity.CreateId(k);
                }
            }
            return null;
        }

        public virtual object GetNewKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return null;
        }
    }
}
