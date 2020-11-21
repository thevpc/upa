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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 12:45 AM
     */
    public abstract class AbstractEntityFactory : Net.TheVpc.Upa.Impl.EntityFactory {


        public virtual Net.TheVpc.Upa.Record ObjectToRecord(object @object, System.Collections.Generic.ISet<string> fields, bool ignoreUnspecified, bool ensureIncludeIds) {
            Net.TheVpc.Upa.Record r = CreateRecord();
            Net.TheVpc.Upa.Record allFieldsRecord = ObjectToRecord(@object, ignoreUnspecified);
            if (fields == null || (fields.Count==0)) {
                r.SetAll(r);
                return r;
            } else {
                foreach (string k in fields) {
                    r.SetObject(k, allFieldsRecord.GetObject<T>(k));
                }
                if (ensureIncludeIds) {
                    foreach (Net.TheVpc.Upa.Field o in GetEntity().GetPrimaryFields()) {
                        string idname = o.GetName();
                        if (!r.IsSet(idname)) {
                            r.SetObject(idname, allFieldsRecord.GetObject<T>(idname));
                        }
                    }
                }
                return r;
            }
        }

        protected internal abstract Net.TheVpc.Upa.Entity GetEntity();


        public virtual  R IdToObject<R>(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (id == null) {
                return default(R);
            }
            Net.TheVpc.Upa.Entity entity = GetEntity();
            R r = CreateObject<R>();
            Net.TheVpc.Upa.Record ur = ObjectToRecord(r, true);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = entity.GetPrimaryFields();
            if (id == null) {
                foreach (Net.TheVpc.Upa.Field aF in primaryFields) {
                    ur.SetObject(aF.GetName(), null);
                }
            } else {
                object[] uk = entity.GetBuilder().GetKey(id).GetValue();
                for (int i = 0; i < (primaryFields).Count; i++) {
                    ur.SetObject(primaryFields[i].GetName(), uk[i]);
                }
            }
            return r;
        }


        public virtual Net.TheVpc.Upa.Record IdToRecord(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (id == null) {
                return null;
            }
            Net.TheVpc.Upa.Entity entity = GetEntity();
            Net.TheVpc.Upa.Record ur = CreateRecord();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = entity.GetPrimaryFields();
            //        if (k == null) {
            //            for (Field aF : primaryFields) {
            //                ur.setObject(aF.getName(), null);
            //            }
            //        } else {
            object[] uk = entity.GetBuilder().GetKey(id).GetValue();
            for (int i = 0; i < (primaryFields).Count; i++) {
                ur.SetObject(primaryFields[i].GetName(), uk[i]);
            }
            //        }
            return ur;
        }


        public virtual object ObjectToId(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object == null) {
                return null;
            }
            if (@object is Net.TheVpc.Upa.Record) {
                return RecordToId((Net.TheVpc.Upa.Record) @object);
            }
            Net.TheVpc.Upa.Entity entity = GetEntity();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] rawKey = new object[(f).Count];
            for (int i = 0; i < rawKey.Length; i++) {
                Net.TheVpc.Upa.Field field = f[i];
                string name = field.GetName();
                if (!entity.GetBeanType().IsDefaultValue(@object, name)) {
                    rawKey[i] = GetProperty(@object, name);
                } else {
                    return null;
                }
            }
            return entity.GetBuilder().CreateId(rawKey);
        }


        public virtual object RecordToId(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (record == null) {
                return null;
            }
            Net.TheVpc.Upa.Entity entity = GetEntity();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] rawKey = new object[(f).Count];
            for (int i = 0; i < rawKey.Length; i++) {
                Net.TheVpc.Upa.Field field = f[i];
                string name = field.GetName();
                if (record.IsSet(name)) {
                    rawKey[i] = record.GetObject<T>(name);
                } else {
                    return null;
                }
            }
            return entity.GetBuilder().CreateId(rawKey);
        }


        public virtual Net.TheVpc.Upa.Key ObjectToKey(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object == null) {
                return null;
            }
            if (@object is Net.TheVpc.Upa.Record) {
                return RecordToKey((Net.TheVpc.Upa.Record) @object);
            }
            Net.TheVpc.Upa.Entity entity = GetEntity();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] rawKey = new object[(f).Count];
            for (int i = 0; i < rawKey.Length; i++) {
                Net.TheVpc.Upa.Field field = f[i];
                string name = field.GetName();
                if (!entity.GetBeanType().IsDefaultValue(@object, name)) {
                    rawKey[i] = GetProperty(@object, name);
                } else {
                    return null;
                }
            }
            return entity.GetBuilder().CreateKey(rawKey);
        }


        public virtual Net.TheVpc.Upa.Key RecordToKey(Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (record == null) {
                return null;
            }
            Net.TheVpc.Upa.Entity entity = GetEntity();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = entity.GetPrimaryFields();
            object[] rawKey = new object[(f).Count];
            for (int i = 0; i < rawKey.Length; i++) {
                Net.TheVpc.Upa.Field field = f[i];
                string name = field.GetName();
                if (record.IsSet(name)) {
                    rawKey[i] = record.GetObject<T>(name);
                } else {
                    return entity.GetBuilder().CreateKey((object[]) null);
                }
            }
            return entity.GetBuilder().CreateKey(rawKey);
        }


        public virtual object KeyToObject(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (key == null) {
                return null;
            }
            return ObjectToRecord(KeyToRecord(key));
        }


        public virtual Net.TheVpc.Upa.Record KeyToRecord(Net.TheVpc.Upa.Key key) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (key == null) {
                return null;
            }
            Net.TheVpc.Upa.Record ur = CreateRecord();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = GetEntity().GetPrimaryFields();
            if (key == null) {
                foreach (Net.TheVpc.Upa.Field aF in primaryFields) {
                    ur.SetObject(aF.GetName(), null);
                }
            } else {
                object[] uk = key.GetValue();
                for (int i = 0; i < (primaryFields).Count; i++) {
                    ur.SetObject(primaryFields[i].GetName(), uk[i]);
                }
            }
            return ur;
        }


        public virtual Net.TheVpc.Upa.Key IdToKey(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (id == null) {
                return null;
            }
            return GetEntity().GetBuilder().GetKey(id);
        }


        public virtual object KeyToId(Net.TheVpc.Upa.Key uk) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (uk == null) {
                return null;
            }
            return GetEntity().GetBuilder().GetId(uk);
        }

        public virtual Net.TheVpc.Upa.Record ObjectToRecord(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return ObjectToRecord(@object, false);
        }

        public virtual object GetMainProperty(object @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Field mf = GetEntity().GetMainField();
            object v = GetProperty(@object, mf.GetName());
            if (v != null && mf.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType && !Net.TheVpc.Upa.Impl.Util.UPAUtils.IsSimpleFieldType(v.GetType())) {
                Net.TheVpc.Upa.Entity t = ((Net.TheVpc.Upa.Types.ManyToOneType) mf.GetDataType()).GetRelationship().GetTargetEntity();
                return t.GetMainFieldValue(v);
            }
            return v;
        }

        public virtual void SetRecordId(Net.TheVpc.Upa.Record record, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> f = GetEntity().GetPrimaryFields();
            if (id == null) {
                foreach (Net.TheVpc.Upa.Field aF in f) {
                    record.Remove(aF.GetName());
                }
                return;
            }
            object[] uk = IdToKey(id).GetValue();
            if ((f).Count > 0) {
                if (uk.Length != (f).Count) {
                    throw new System.Exception("key " + id + " could not denote for entity " + GetEntity().GetName() + " ; got " + uk.Length + " elements instread of " + (f).Count);
                }
                for (int i = 0; i < (f).Count; i++) {
                    record.SetObject(f[i].GetName(), uk[i]);
                }
            }
        }

        public virtual void SetObjectId(object @object, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            SetRecordId(ObjectToRecord(@object, true), id);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ObjectToExpression(object @object, bool ignoreUnspecified, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return RecordToExpression(ObjectToRecord(@object, ignoreUnspecified), alias);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression RecordToExpression(Net.TheVpc.Upa.Record record, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (record == null) {
                return null;
            }
            Net.TheVpc.Upa.Expressions.Expression a = null;
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in record.EntrySet()) {
                string key = (entry).Key;
                object @value = (entry).Value;
                Net.TheVpc.Upa.Field field = GetEntity().GetField(key);
                if (!field.IsUnspecifiedValue(@value)) {
                    Net.TheVpc.Upa.Expressions.Expression e = null;
                    Net.TheVpc.Upa.Expressions.Var p = new Net.TheVpc.Upa.Expressions.Var(Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(alias) ? GetEntity().GetName() : alias);
                    switch(field.GetSearchOperator()) {
                        case Net.TheVpc.Upa.SearchOperator.DEFAULT:
                        case Net.TheVpc.Upa.SearchOperator.EQ:
                            {
                                if (field.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                                    Net.TheVpc.Upa.Types.ManyToOneType et = (Net.TheVpc.Upa.Types.ManyToOneType) field.GetDataType();
                                    Net.TheVpc.Upa.Key foreignKey = et.GetRelationship().GetTargetRole().GetEntity().GetBuilder().ObjectToKey(@value);
                                    Net.TheVpc.Upa.Expressions.Expression b = null;
                                    int i = 0;
                                    foreach (Net.TheVpc.Upa.Field df in et.GetRelationship().GetSourceRole().GetFields()) {
                                        e = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var((Net.TheVpc.Upa.Expressions.Var) p.Copy(), df.GetName()), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(foreignKey.GetObjectAt(i)));
                                        b = b == null ? ((Net.TheVpc.Upa.Expressions.Expression)(b)) : new Net.TheVpc.Upa.Expressions.And(b, e);
                                        i++;
                                    }
                                } else {
                                    e = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                }
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.NE:
                            {
                                e = new Net.TheVpc.Upa.Expressions.Different(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.GT:
                            {
                                e = new Net.TheVpc.Upa.Expressions.GreaterThan(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.GTE:
                            {
                                e = new Net.TheVpc.Upa.Expressions.GreaterEqualThan(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.LT:
                            {
                                e = new Net.TheVpc.Upa.Expressions.LessThan(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.LTE:
                            {
                                e = new Net.TheVpc.Upa.Expressions.LessEqualThan(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.CONTAINS:
                            {
                                e = new Net.TheVpc.Upa.Expressions.Like(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral("%" + @value + "%"));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.STARTS_WITH:
                            {
                                e = new Net.TheVpc.Upa.Expressions.Like(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(@value + "%"));
                                break;
                            }
                        case Net.TheVpc.Upa.SearchOperator.ENDS_WITH:
                            {
                                e = new Net.TheVpc.Upa.Expressions.Like(new Net.TheVpc.Upa.Expressions.Var(p, key), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral("%" + @value));
                                break;
                            }
                    }
                    if (e != null) {
                        a = a == null ? ((Net.TheVpc.Upa.Expressions.Expression)(e)) : new Net.TheVpc.Upa.Expressions.And(a, e);
                    }
                }
            }
            return a;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression IdToExpression(object id, string entityAlias) {
            //        if (id == null) {//TODO TAHA
            //            return null;
            //        }
            //        keyExpression.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
            return new Net.TheVpc.Upa.Expressions.IdExpression(GetEntity(), id, entityAlias);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression ObjectToIdExpression(object entityOrRecord, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entityOrRecord == null) {
                return null;
            }
            Net.TheVpc.Upa.Record r = null;
            if (entityOrRecord is Net.TheVpc.Upa.Record) {
                r = (Net.TheVpc.Upa.Record) entityOrRecord;
            }
            r = ObjectToRecord(entityOrRecord);
            Net.TheVpc.Upa.Key k = RecordToKey(r);
            return KeyToExpression(k, alias);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression KeyToExpression(Net.TheVpc.Upa.Key key, string entityAlias) {
            object id = KeyToId(key);
            return IdToExpression(id, entityAlias);
        }

        public virtual  Net.TheVpc.Upa.Expressions.Expression IdListToExpression<K>(System.Collections.Generic.IList<K> idList, string entityAlias) {
            System.Collections.Generic.IList<object> convertedList = new Net.TheVpc.Upa.Impl.Util.ConvertedList<K , object>(idList, new Net.TheVpc.Upa.Impl.Util.CastConverter<K , object>());
            //        keyEnumerationExpression.setClientProperty(EXPRESSION_SURELY_EXISTS,keys.size() > 0);
            return new Net.TheVpc.Upa.Expressions.IdEnumerationExpression(convertedList, entityAlias == null ? null : new Net.TheVpc.Upa.Expressions.Var(entityAlias));
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression KeyListToExpression(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> keyList, string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<object> list = new Net.TheVpc.Upa.Impl.Util.ConvertedList<Net.TheVpc.Upa.Key , object>(keyList, new Net.TheVpc.Upa.Impl.KeyToIdConverter<object>(GetEntity()));
            return IdListToExpression<object>(list, alias);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R RecordToObject<R>(Net.TheVpc.Upa.Record arg1);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Record ObjectToRecord(object arg1, bool arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetProperty(object arg1, string arg2, object arg3);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object GetProperty(object arg1, string arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Record CreateRecord();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R CreateObject<R>();
    }
}
