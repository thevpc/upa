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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 12:45 AM
     */
    public class DefaultEntityConverter : Net.Vpc.Upa.Impl.EntityConverter {

        private Net.Vpc.Upa.Entity entity;

        public DefaultEntityConverter(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual  R IdToEntity<R>(object k) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (k == null) {
                return default(R);
            }
            R r = entity.GetBuilder().CreateObject<R>();
            Net.Vpc.Upa.Record ur = EntityToRecord(r, true);
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = entity.GetPrimaryFields();
            if (k == null) {
                foreach (Net.Vpc.Upa.Field aF in primaryFields) {
                    ur.SetObject(aF.GetName(), null);
                }
            } else {
                object[] uk = entity.GetBuilder().GetKey(k).GetValue();
                for (int i = 0; i < (primaryFields).Count; i++) {
                    ur.SetObject(primaryFields[i].GetName(), uk[i]);
                }
            }
            return r;
        }


        public virtual Net.Vpc.Upa.Record IdToRecord(object k) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (k == null) {
                return null;
            }
            Net.Vpc.Upa.Record ur = entity.GetBuilder().CreateRecord();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = entity.GetPrimaryFields();
            //        if (k == null) {
            //            for (Field aF : primaryFields) {
            //                ur.setObject(aF.getName(), null);
            //            }
            //        } else {
            object[] uk = entity.GetBuilder().GetKey(k).GetValue();
            for (int i = 0; i < (primaryFields).Count; i++) {
                ur.SetObject(primaryFields[i].GetName(), uk[i]);
            }
            //        }
            return ur;
        }


        public virtual object EntityToId(object r) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (r == null) {
                return null;
            }
            return RecordToId(EntityToRecord(r, true));
        }


        public virtual object RecordToId(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (record == null) {
                return null;
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] rawKey = new object[(f).Count];
            for (int i = 0; i < rawKey.Length; i++) {
                Net.Vpc.Upa.Field field = f[i];
                string name = field.GetName();
                if (record.IsSet(name)) {
                    rawKey[i] = record.GetObject<object>(name);
                } else {
                    return null;
                }
            }
            return entity.GetBuilder().CreateId(rawKey);
        }


        public virtual Net.Vpc.Upa.Key EntityToKey(object r) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (r == null) {
                return null;
            }
            return RecordToKey(EntityToRecord(r, true));
        }


        public virtual Net.Vpc.Upa.Key RecordToKey(Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (record == null) {
                return null;
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] rawKey = new object[(f).Count];
            for (int i = 0; i < rawKey.Length; i++) {
                Net.Vpc.Upa.Field field = f[i];
                string name = field.GetName();
                if (record.IsSet(name)) {
                    rawKey[i] = record.GetObject<object>(name);
                } else {
                    return entity.GetBuilder().CreateKey((object[]) null);
                }
            }
            return entity.GetBuilder().CreateKey(rawKey);
        }


        public virtual object KeyToEntity(Net.Vpc.Upa.Key uk) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (uk == null) {
                return null;
            }
            return entity.GetBuilder().GetEntity<object>(KeyToRecord(uk));
        }


        public virtual Net.Vpc.Upa.Record KeyToRecord(Net.Vpc.Upa.Key k) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (k == null) {
                return null;
            }
            Net.Vpc.Upa.Record ur = entity.GetBuilder().CreateRecord();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = entity.GetPrimaryFields();
            if (k == null) {
                foreach (Net.Vpc.Upa.Field aF in primaryFields) {
                    ur.SetObject(aF.GetName(), null);
                }
            } else {
                object[] uk = k.GetValue();
                for (int i = 0; i < (primaryFields).Count; i++) {
                    ur.SetObject(primaryFields[i].GetName(), uk[i]);
                }
            }
            return ur;
        }


        public virtual Net.Vpc.Upa.Key IdToKey(object entityId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityId == null) {
                return null;
            }
            return entity.GetBuilder().GetKey(entityId);
        }


        public virtual object KeyToId(Net.Vpc.Upa.Key uk) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (uk == null) {
                return null;
            }
            return entity.GetBuilder().GetId(uk);
        }

        public virtual Net.Vpc.Upa.Record EntityToRecord(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return EntityToRecord(entityValue, false);
        }

        public virtual Net.Vpc.Upa.Record EntityToRecord(object entityValue, bool ignoreUnspecified) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entityValue == null) {
                return null;
            }
            return entity.GetBuilder().GetRecord<object>(entityValue, ignoreUnspecified);
        }

        public virtual object GetMainProperty(object entityValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetProperty(entityValue, entity.GetMainField().GetName());
        }


        public virtual  R RecordToEntity<R>(Net.Vpc.Upa.Record ur) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (ur == null) {
                return default(R);
            }
            return entity.GetBuilder().GetEntity<R>(ur);
        }

        public virtual void SetRecordId(Net.Vpc.Upa.Record r, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> f = entity.GetPrimaryFields();
            if (id == null) {
                foreach (Net.Vpc.Upa.Field aF in f) {
                    r.Remove(aF.GetName());
                }
                return;
            }
            object[] uk = IdToKey(id).GetValue();
            if ((f).Count > 0) {
                if (uk.Length != (f).Count) {
                    throw new System.Exception("key " + id + " could not denote for entity " + entity.GetName() + " ; got " + uk.Length + " elements instread of " + (f).Count);
                }
                for (int i = 0; i < (f).Count; i++) {
                    r.SetObject(f[i].GetName(), uk[i]);
                }
            }
        }

        public virtual void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            entity.GetBuilder().SetProperty(entityObject, property, @value);
        }

        public virtual object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entity.GetBuilder().GetProperty(entityObject, property);
        }

        public virtual void SetEntityId(object entity, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            SetRecordId(EntityToRecord(entity, true), id);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression EntityToExpression(object obj, bool ignoreUnspecified, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return RecordToExpression(EntityToRecord(obj, ignoreUnspecified), entityAlias);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression RecordToExpression(Net.Vpc.Upa.Record record, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (record == null) {
                return null;
            }
            Net.Vpc.Upa.Expressions.Expression a = null;
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in record.ToMap()) {
                string key = (entry).Key;
                object @value = (entry).Value;
                Net.Vpc.Upa.Field field = entity.GetField(key);
                if (!field.IsUnspecifiedValue(@value)) {
                    Net.Vpc.Upa.Expressions.Expression e = null;
                    Net.Vpc.Upa.Expressions.Var p = new Net.Vpc.Upa.Expressions.Var(Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(entityAlias) ? entity.GetName() : entityAlias);
                    switch(field.GetSearchOperator()) {
                        case Net.Vpc.Upa.SearchOperator.DEFAULT:
                        case Net.Vpc.Upa.SearchOperator.EQ:
                            {
                                if (field.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                                    Net.Vpc.Upa.Types.EntityType et = (Net.Vpc.Upa.Types.EntityType) field.GetDataType();
                                    Net.Vpc.Upa.Key foreignKey = et.GetRelationship().GetTargetRole().GetEntity().GetBuilder().EntityToKey(@value);
                                    Net.Vpc.Upa.Expressions.Expression b = null;
                                    int i = 0;
                                    foreach (Net.Vpc.Upa.Field df in et.GetRelationship().GetSourceRole().GetFields()) {
                                        e = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var((Net.Vpc.Upa.Expressions.Var) p.Copy(), df.GetName()), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(foreignKey.GetObjectAt(i)));
                                        b = b == null ? ((Net.Vpc.Upa.Expressions.Expression)(b)) : new Net.Vpc.Upa.Expressions.And(b, e);
                                        i++;
                                    }
                                } else {
                                    e = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                }
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.NE:
                            {
                                e = new Net.Vpc.Upa.Expressions.Different(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.GT:
                            {
                                e = new Net.Vpc.Upa.Expressions.GreaterThan(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.GTE:
                            {
                                e = new Net.Vpc.Upa.Expressions.GreaterEqualThan(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.LT:
                            {
                                e = new Net.Vpc.Upa.Expressions.LessThan(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.LTE:
                            {
                                e = new Net.Vpc.Upa.Expressions.LessEqualThan(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.CONTAINS:
                            {
                                e = new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral("%" + @value + "%"));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.STARTS_WITH:
                            {
                                e = new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value + "%"));
                                break;
                            }
                        case Net.Vpc.Upa.SearchOperator.ENDS_WITH:
                            {
                                e = new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(p, key), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral("%" + @value));
                                break;
                            }
                    }
                    if (e != null) {
                        a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(a, e);
                    }
                }
            }
            return a;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression IdToExpression(object key, string entityAlias) {
            if (key == null) {
                return null;
            }
            //        keyExpression.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
            return new Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression(entity, key, entityAlias);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression KeyToExpression(Net.Vpc.Upa.Key key, string entityAlias) {
            object id = KeyToId(key);
            return IdToExpression(id, entityAlias);
        }

        public virtual  Net.Vpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string entityAlias) {
            System.Collections.Generic.IList<object> convertedList = new Net.Vpc.Upa.Impl.Util.ConvertedList<K , object>(idList, new Net.Vpc.Upa.Impl.Util.CastConverter<K , object>());
            //        keyEnumerationExpression.setClientProperty(EXPRESSION_SURELY_EXISTS,keys.size() > 0);
            return new Net.Vpc.Upa.Impl.Uql.Expression.KeyEnumerationExpression(convertedList, entityAlias == null ? null : new Net.Vpc.Upa.Expressions.Var(entityAlias));
        }


        public virtual Net.Vpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.Vpc.Upa.Key> keyList, string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<object> list = new Net.Vpc.Upa.Impl.Util.ConvertedList<Net.Vpc.Upa.Key , object>(keyList, new Net.Vpc.Upa.Impl.KeyToIdConverter<object>(entity));
            return IdListToExpression<object>(list, alias);
        }
    }
}
