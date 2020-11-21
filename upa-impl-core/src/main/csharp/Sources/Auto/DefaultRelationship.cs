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
namespace Net.TheVpc.Upa.Impl
{


    public class DefaultRelationship : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Relationship {

        private Net.TheVpc.Upa.RelationshipRole targetRole;

        private Net.TheVpc.Upa.RelationshipRole sourceRole;

        protected internal System.Collections.Generic.IDictionary<string , string> targetToSourceKeyMap;

        protected internal System.Collections.Generic.IDictionary<string , string> sourceToTargetKeyMap;

        protected internal Net.TheVpc.Upa.Types.DataType dataType;

        private Net.TheVpc.Upa.RelationshipType relationType;

        protected internal Net.TheVpc.Upa.Expressions.Expression filter;

        private int tuningMaxInline = 10;

        private bool nullable;

        private Net.TheVpc.Upa.Extensions.HierarchyExtension hierarchyExtension;

        public DefaultRelationship() {
            targetRole = new Net.TheVpc.Upa.Impl.DefaultRelationshipRole();
            targetRole.SetRelationship(this);
            targetRole.SetRelationshipRoleType(Net.TheVpc.Upa.RelationshipRoleType.TARGET);
            sourceRole = new Net.TheVpc.Upa.Impl.DefaultRelationshipRole();
            sourceRole.SetRelationship(this);
            sourceRole.SetRelationshipRoleType(Net.TheVpc.Upa.RelationshipRoleType.SOURCE);
        }


        public override string GetAbsoluteName() {
            return GetName();
        }

        public virtual void SetNullable(bool nullable) {
            this.nullable = nullable;
        }


        public virtual void CommitModelChanged() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity sourceEntity = GetSourceRole().GetEntity();
            Net.TheVpc.Upa.Entity targetEntity = GetTargetRole().GetEntity();
            if (sourceEntity == null || targetEntity == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("InvalidRelationDefinition");
            }
            if (!sourceEntity.GetUserExcludeModifiers().Contains(Net.TheVpc.Upa.EntityModifier.VALIDATE_PERSIST)) {
                sourceEntity.GetModifiers().Add(Net.TheVpc.Upa.EntityModifier.VALIDATE_PERSIST);
            }
            if (!sourceEntity.GetUserExcludeModifiers().Contains(Net.TheVpc.Upa.EntityModifier.VALIDATE_UPDATE)) {
                sourceEntity.GetModifiers().Add(Net.TheVpc.Upa.EntityModifier.VALIDATE_UPDATE);
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> sourceFieldsList = sourceRole.GetFields();
            Net.TheVpc.Upa.Field[] sourceFields = sourceFieldsList.ToArray();
            Net.TheVpc.Upa.KeyType keyType = new Net.TheVpc.Upa.KeyType(targetEntity, filter, false);
            SetDataType(keyType);
            tuningMaxInline = GetPersistenceUnit().GetProperties().GetInt((typeof(Net.TheVpc.Upa.Relationship)).FullName + ".maxInline", 10);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> targetFieldsList = targetEntity.GetPrimaryFields();
            Net.TheVpc.Upa.Field[] targetFields = targetFieldsList.ToArray();
            ;
            // some checks
            if (sourceFields.Length == 0) {
                throw new System.ArgumentException ("No source fields are specified");
            }
            if (targetFields.Length == 0) {
                throw new System.ArgumentException ("Target Entity " + targetEntity.GetName() + " has no primary fields");
            }
            if (sourceFields.Length != targetFields.Length) {
                throw new System.ArgumentException ("source fields and target fields have not the same count");
            }
            sourceEntity.AddDependencyOnEntity(targetEntity.GetName());
            if (dataType == null) {
                dataType = targetEntity.GetDataType();
            }
            if (dataType.IsNullable() != nullable) {
                Net.TheVpc.Upa.Types.DataType trCloned = (Net.TheVpc.Upa.Types.DataType) dataType.Copy();
                trCloned.SetNullable(nullable);
                dataType = trCloned;
            }
            this.sourceToTargetKeyMap = new System.Collections.Generic.Dictionary<string , string>(sourceFields.Length);
            this.targetToSourceKeyMap = new System.Collections.Generic.Dictionary<string , string>(sourceFields.Length);
            //        if ((theSourceTable  instanceof View))
            //            this.type = 0;
            for (int i = 0; i < sourceFields.Length; i++) {
                if (sourceFields[i].GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.TRANSIENT) && this.relationType != Net.TheVpc.Upa.RelationshipType.TRANSIENT) {
                    //Log. System.err.println("Type should be VIEW for " + getName());
                    this.relationType = Net.TheVpc.Upa.RelationshipType.TRANSIENT;
                } else if (sourceFields[i].GetUpdateFormula() != null && this.relationType != Net.TheVpc.Upa.RelationshipType.TRANSIENT && this.relationType != Net.TheVpc.Upa.RelationshipType.SHADOW_ASSOCIATION) {
                    // Log. System.err.println("Type should be either VIEW or SHADOW for " + name);
                    this.relationType = Net.TheVpc.Upa.RelationshipType.SHADOW_ASSOCIATION;
                }
                this.sourceToTargetKeyMap[sourceFields[i].GetName()]=targetFields[i].GetName();
                this.targetToSourceKeyMap[targetFields[i].GetName()]=sourceFields[i].GetName();
                //            targetFields[i].addManyToOneRelation(this);
                ((Net.TheVpc.Upa.Impl.AbstractField) sourceFields[i]).SetEffectiveModifiers(sourceFields[i].GetModifiers().Add(Net.TheVpc.Upa.FieldModifier.FOREIGN));
                ((Net.TheVpc.Upa.Impl.AbstractField) targetFields[i]).SetEffectiveModifiers(targetFields[i].GetModifiers().Add(Net.TheVpc.Upa.FieldModifier.REFERENCED));
                //            if (sourceFields[i].getTitle() == null) {
                //                sourceFields[i].setTitle(targetFields[i].getTitle());
                //            }
                if (sourceFields[i].GetDataType() == null) {
                    Net.TheVpc.Upa.Types.DataType tr = targetFields[i].GetDataType();
                    if (tr.IsNullable() == nullable) {
                        sourceFields[i].SetDataType(tr);
                    } else {
                        Net.TheVpc.Upa.Types.DataType trCloned = (Net.TheVpc.Upa.Types.DataType) tr.Copy();
                        trCloned.SetNullable(nullable);
                        sourceFields[i].SetDataType(trCloned);
                    }
                }
            }
            if (GetSourceRole().GetEntityField() != null) {
                Net.TheVpc.Upa.Field sourceEntityField = GetSourceRole().GetEntityField();
                Net.TheVpc.Upa.Types.DataType dt = sourceEntityField.GetDataType();
                if (dt is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType edt = (Net.TheVpc.Upa.Types.ManyToOneType) dt;
                    edt.SetRelationship(this);
                }
            }
            if (GetTargetRole().GetEntityField() != null) {
                Net.TheVpc.Upa.Field targetEntityField = GetTargetRole().GetEntityField();
                Net.TheVpc.Upa.Types.DataType dt = targetEntityField.GetDataType();
                if (dt is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType edt = (Net.TheVpc.Upa.Types.ManyToOneType) dt;
                    edt.SetRelationship(this);
                }
            }
            this.sourceToTargetKeyMap = Net.TheVpc.Upa.Impl.Util.PlatformUtils.UnmodifiableMap<string, string>(sourceToTargetKeyMap);
            this.targetToSourceKeyMap = Net.TheVpc.Upa.Impl.Util.PlatformUtils.UnmodifiableMap<string, string>(targetToSourceKeyMap);
            SetI18NString(new Net.TheVpc.Upa.Types.I18NString("Relationship").Append(GetName()));
            SetTitle(GetI18NString().Append(".title"));
            SetDescription(GetI18NString().Append(".desc"));
            System.Text.StringBuilder preferredPersistenceName = new System.Text.StringBuilder((GetName()).Length);
            for (int i = 0; i < (GetName()).Length; i++) {
                if (Net.TheVpc.Upa.Expressions.ExpressionHelper.IsIdentifierPart(GetName()[i])) {
                    preferredPersistenceName.Append(GetName()[i]);
                } else {
                    preferredPersistenceName.Append('_');
                }
            }
            SetPersistenceName(preferredPersistenceName.ToString());
            if (GetRelationshipType() == Net.TheVpc.Upa.RelationshipType.COMPOSITION) {
                ((Net.TheVpc.Upa.Impl.DefaultEntity) sourceEntity).SetCompositionRelationship(this);
            }
            targetRole.SetFields(targetFields);
            Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), targetRole, this.GetName() + "_" + targetRole.GetRelationshipRoleType());
            Net.TheVpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), sourceRole, this.GetName() + "_" + sourceRole.GetRelationshipRoleType());
            if ((((GetTargetRole().GetEntity().GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0) || ((GetSourceRole().GetEntity().GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0)) && relationType != Net.TheVpc.Upa.RelationshipType.TRANSIENT) {
                throw new System.ArgumentException (this + " : Relationship Type must be TYPE_VIEW");
            }
            if (((GetTargetRole().GetEntity().GetShield().IsTransient()) || (GetSourceRole().GetEntity().GetShield().IsTransient())) && relationType != Net.TheVpc.Upa.RelationshipType.TRANSIENT) {
                throw new System.ArgumentException (this + " : Relationship Type must be TYPE_VIEW");
            }
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifierstoRemove = Net.TheVpc.Upa.FlagSets.OfType<Net.TheVpc.Upa.FieldModifier>().AddAll(Net.TheVpc.Upa.FieldModifier.PERSIST, Net.TheVpc.Upa.FieldModifier.PERSIST_DEFAULT, Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA, Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE, Net.TheVpc.Upa.FieldModifier.UPDATE, Net.TheVpc.Upa.FieldModifier.UPDATE_DEFAULT, Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA, Net.TheVpc.Upa.FieldModifier.UPDATE_SEQUENCE);
            switch(GetSourceRole().GetRelationshipUpdateType()) {
                case Net.TheVpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        Net.TheVpc.Upa.Field f = GetSourceRole().GetEntityField();
                        if (f != null) {
                            ((Net.TheVpc.Upa.Impl.AbstractField) f).SetEffectiveModifiers(f.GetModifiers().RemoveAll(modifierstoRemove));
                        }
                        break;
                    }
                case Net.TheVpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = GetSourceRole().GetFields();
                        if (fields != null) {
                            foreach (Net.TheVpc.Upa.Field f in fields) {
                                ((Net.TheVpc.Upa.Impl.AbstractField) f).SetEffectiveModifiers(f.GetModifiers().RemoveAll(modifierstoRemove));
                            }
                        }
                        break;
                    }
            }
        }

        public virtual void SetDataType(Net.TheVpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
        }

        public virtual Net.TheVpc.Upa.RelationshipType GetRelationshipType() {
            return relationType;
        }

        public virtual void SetRelationshipType(Net.TheVpc.Upa.RelationshipType relationType) {
            this.relationType = relationType;
        }

        public virtual int Size() {
            return (GetSourceRole().GetFields()).Count;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldNamesMap(bool absolute) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IDictionary<string , string> m = new System.Collections.Generic.Dictionary<string , string>((GetSourceToTargetFieldsMap()).Count);
            if (absolute) {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(sourceToTargetKeyMap)) {
                    m[GetSourceRole().GetEntity().GetField((e).Key).GetName()]=GetTargetRole().GetEntity().GetField((e).Value).GetName();
                }
            } else {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(sourceToTargetKeyMap)) {
                    m[(e).Key]=(e).Value;
                }
            }
            return m;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldNamesMap(bool absolute) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IDictionary<string , string> m = new System.Collections.Generic.Dictionary<string , string>((GetSourceToTargetFieldsMap()).Count);
            if (absolute) {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(targetToSourceKeyMap)) {
                    m[GetTargetRole().GetEntity().GetField((e).Key).GetName()]=GetSourceRole().GetEntity().GetField((e).Value).GetName();
                }
            } else {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(targetToSourceKeyMap)) {
                    m[(e).Key]=(e).Value;
                }
            }
            return m;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldsMap() {
            return sourceToTargetKeyMap;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldsMap() {
            return targetToSourceKeyMap;
        }


        public override bool Equals(object other) {
            if (other == null || !(other is Net.TheVpc.Upa.Impl.DefaultRelationship)) {
                return false;
            } else {
                Net.TheVpc.Upa.Impl.DefaultRelationship o = (Net.TheVpc.Upa.Impl.DefaultRelationship) other;
                return GetPersistenceUnit().GetNamingStrategy().Equals(GetName(), o.GetName());
            }
        }


        public override string ToString() {
            return GetName();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetTargetCondition(Net.TheVpc.Upa.Expressions.Expression sourceCondition, string sourceAlias, string targetAlias) {
            Net.TheVpc.Upa.Field[] sourceFields = GetSourceRole().GetFields().ToArray();
            Net.TheVpc.Upa.Field[] targetFields = GetTargetRole().GetFields().ToArray();
            Net.TheVpc.Upa.Expressions.Var[] lvar = new Net.TheVpc.Upa.Expressions.Var[sourceFields.Length];
            Net.TheVpc.Upa.Expressions.Var[] rvar = new Net.TheVpc.Upa.Expressions.Var[targetFields.Length];
            for (int i = 0; i < lvar.Length; i++) {
                lvar[i] = (sourceAlias == null) ? new Net.TheVpc.Upa.Expressions.Var(sourceFields[i].GetName()) : new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                rvar[i] = (targetAlias == null) ? new Net.TheVpc.Upa.Expressions.Var(targetFields[i].GetName()) : new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(targetAlias), targetFields[i].GetName());
            }
            if (tuningMaxInline > 0) {
                try {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Record> list = GetSourceRole().GetEntity().CreateQuery(new Net.TheVpc.Upa.Expressions.Select().Uplet(lvar, "lvar").Where(sourceCondition)).GetRecordList();
                    int j = 0;
                    Net.TheVpc.Upa.Expressions.IdCollectionExpression inCollection = new Net.TheVpc.Upa.Expressions.IdCollectionExpression(rvar);
                    foreach (Net.TheVpc.Upa.Record r in list) {
                        j++;
                        if (j > tuningMaxInline) {
                            return new Net.TheVpc.Upa.Expressions.InSelection(lvar, new Net.TheVpc.Upa.Expressions.Select().From(GetSourceRole().GetEntity().GetName()).Uplet(lvar).Where(sourceCondition));
                        }
                        inCollection.Add(new Net.TheVpc.Upa.Expressions.Param(null, r.GetSingleResult<T>()));
                    }
                    //inCollection.add(new Litteral(rs.getObject(1)));
                    return inCollection;
                } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                    return new Net.TheVpc.Upa.Expressions.InSelection(rvar, new Net.TheVpc.Upa.Expressions.Select().From(GetSourceRole().GetEntity().GetName()).Uplet(lvar).Where(sourceCondition));
                }
            } else {
                return new Net.TheVpc.Upa.Expressions.InSelection(rvar, new Net.TheVpc.Upa.Expressions.Select().From(GetSourceRole().GetEntity().GetName()).Uplet(lvar).Where(sourceCondition));
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetSourceCondition(Net.TheVpc.Upa.Expressions.Expression targetCondition, string sourceAlias, string targetAlias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //Key Rkey=getTargetTable().getKeyForExpression(targetCondition);
            Net.TheVpc.Upa.Field[] sourceFields = GetSourceRole().GetFields().ToArray();
            Net.TheVpc.Upa.Field[] targetFields = GetTargetRole().GetFields().ToArray();
            if (targetCondition is Net.TheVpc.Upa.Expressions.IdExpression) {
                Net.TheVpc.Upa.Key Rkey = targetRole.GetEntity().GetBuilder().IdToKey(((Net.TheVpc.Upa.Expressions.IdExpression) targetCondition).GetId());
                if (sourceFields.Length == 1) {
                    Net.TheVpc.Upa.Expressions.Var lvar = (sourceAlias == null) ? new Net.TheVpc.Upa.Expressions.Var(sourceFields[0].GetName()) : new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(sourceAlias), sourceFields[0].GetName());
                    return new Net.TheVpc.Upa.Expressions.Equals(lvar, new Net.TheVpc.Upa.Expressions.Literal(Rkey == null ? null : Rkey.GetValue()[0], targetFields[0].GetDataType()));
                } else {
                    Net.TheVpc.Upa.Expressions.Expression a = null;
                    for (int i = 0; i < sourceFields.Length; i++) {
                        Net.TheVpc.Upa.Expressions.Var lvar = (sourceAlias == null) ? new Net.TheVpc.Upa.Expressions.Var(sourceFields[i].GetName()) : new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                        Net.TheVpc.Upa.Expressions.Expression rvar = new Net.TheVpc.Upa.Expressions.Literal(Rkey == null ? null : Rkey.GetObjectAt(i), targetFields[i].GetDataType());
                        Net.TheVpc.Upa.Expressions.Expression e = new Net.TheVpc.Upa.Expressions.Equals(lvar, rvar);
                        a = a == null ? e : a;
                    }
                    return a;
                }
            } else if (tuningMaxInline > 0) {
                Net.TheVpc.Upa.Expressions.Var[] lvar = new Net.TheVpc.Upa.Expressions.Var[sourceFields.Length];
                Net.TheVpc.Upa.Expressions.Var[] rvar = new Net.TheVpc.Upa.Expressions.Var[targetFields.Length];
                for (int i = 0; i < lvar.Length; i++) {
                    lvar[i] = new Net.TheVpc.Upa.Expressions.Var((sourceAlias == null) ? null : new Net.TheVpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                    rvar[i] = new Net.TheVpc.Upa.Expressions.Var((targetAlias == null) ? null : new Net.TheVpc.Upa.Expressions.Var(targetAlias), targetFields[i].GetName());
                }
                try {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Record> list = GetTargetRole().GetEntity().CreateQuery(new Net.TheVpc.Upa.Expressions.Select().Uplet(rvar, "rval").Where(targetCondition)).GetRecordList();
                    int j = 0;
                    Net.TheVpc.Upa.Expressions.IdCollectionExpression inCollection = new Net.TheVpc.Upa.Expressions.IdCollectionExpression(lvar);
                    foreach (Net.TheVpc.Upa.Record r in list) {
                        j++;
                        if (j > tuningMaxInline) {
                            return new Net.TheVpc.Upa.Expressions.InSelection(lvar, new Net.TheVpc.Upa.Expressions.Select().From(GetTargetRole().GetEntity().GetName()).Uplet(rvar).Where(targetCondition));
                        }
                        inCollection.Add(new Net.TheVpc.Upa.Expressions.Param(null, r.GetSingleResult<T>()));
                    }
                    //inCollection.add(new Litteral(rs.getObject(1)));
                    return inCollection;
                } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                    return new Net.TheVpc.Upa.Expressions.InSelection(lvar, new Net.TheVpc.Upa.Expressions.Select().From(GetTargetRole().GetEntity().GetName()).Uplet(rvar).Where(targetCondition));
                }
            } else {
                Net.TheVpc.Upa.Expressions.Var[] lvar = new Net.TheVpc.Upa.Expressions.Var[sourceFields.Length];
                Net.TheVpc.Upa.Expressions.Var[] rvar = new Net.TheVpc.Upa.Expressions.Var[targetFields.Length];
                for (int i = 0; i < lvar.Length; i++) {
                    lvar[i] = new Net.TheVpc.Upa.Expressions.Var((sourceAlias == null) ? null : new Net.TheVpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                    rvar[i] = new Net.TheVpc.Upa.Expressions.Var((targetAlias == null) ? null : new Net.TheVpc.Upa.Expressions.Var(targetAlias), targetFields[i].GetName());
                }
                return new Net.TheVpc.Upa.Expressions.InSelection(lvar, new Net.TheVpc.Upa.Expressions.Select().From(GetTargetRole().GetEntity().GetName()).Uplet(rvar).Where(targetCondition));
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilter() {
            return filter;
        }

        public virtual void SetFilter(Net.TheVpc.Upa.Expressions.Expression filter) {
            this.filter = filter;
        }

        public virtual bool IsTransient() {
            switch(relationType) {
                case Net.TheVpc.Upa.RelationshipType.TRANSIENT:
                    {
                        return true;
                    }
            }
            return false;
        }


        public virtual bool IsFollowLinks() {
            switch(relationType) {
                case Net.TheVpc.Upa.RelationshipType.DEFAULT:
                case Net.TheVpc.Upa.RelationshipType.ASSOCIATION:
                case Net.TheVpc.Upa.RelationshipType.AGGREGATION:
                case Net.TheVpc.Upa.RelationshipType.COMPOSITION:
                case Net.TheVpc.Upa.RelationshipType.SHADOW_ASSOCIATION:
                    {
                        return true;
                    }
            }
            return false;
        }


        public virtual bool IsAskForConfirm() {
            switch(relationType) {
                case Net.TheVpc.Upa.RelationshipType.DEFAULT:
                case Net.TheVpc.Upa.RelationshipType.ASSOCIATION:
                case Net.TheVpc.Upa.RelationshipType.AGGREGATION:
                    {
                        return true;
                    }
            }
            return false;
        }

        public virtual Net.TheVpc.Upa.RelationshipRole GetTargetRole() {
            return targetRole;
        }

        public virtual Net.TheVpc.Upa.RelationshipRole GetSourceRole() {
            return sourceRole;
        }

        public virtual Net.TheVpc.Upa.Entity GetTargetEntity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return targetRole == null ? null : targetRole.GetEntity();
        }

        public virtual Net.TheVpc.Upa.Entity GetSourceEntity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return sourceRole == null ? null : sourceRole.GetEntity();
        }

        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.TheVpc.Upa.Key ExtractKey(Net.TheVpc.Upa.Record sourceRecord) {
            switch(GetSourceRole().GetRelationshipUpdateType()) {
                case Net.TheVpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        object targetEntityVal = sourceRecord.GetObject<T>(GetSourceRole().GetEntityField().GetName());
                        if (targetEntityVal == null) {
                            return null;
                        }
                        Net.TheVpc.Upa.EntityBuilder targetConverter = GetTargetRole().GetEntity().GetBuilder();
                        return targetConverter.ObjectToKey(targetEntityVal);
                    }
                case Net.TheVpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Field> relFields = GetSourceRole().GetFields();
                        System.Collections.Generic.List<object> keys = new System.Collections.Generic.List<object>((relFields).Count);
                        foreach (Net.TheVpc.Upa.Field field in relFields) {
                            object keyPart = sourceRecord.GetObject<T>(field.GetName());
                            if (keyPart == null) {
                                return null;
                            }
                            keys.Add(keyPart);
                        }
                        return GetTargetRole().GetEntity().CreateKey(keys.ToArray());
                    }
            }
            return null;
        }

        public virtual object ExtractIdByEntityField(Net.TheVpc.Upa.Record sourceRecord) {
            object targetEntityVal = sourceRecord.GetObject<T>(GetSourceRole().GetEntityField().GetName());
            if (targetEntityVal == null) {
                return null;
            }
            Net.TheVpc.Upa.EntityBuilder targetConverter = GetTargetRole().GetEntity().GetBuilder();
            return targetConverter.ObjectToId(targetEntityVal);
        }

        public virtual object ExtractIdByForeignFields(Net.TheVpc.Upa.Record sourceRecord) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> relFields = GetSourceRole().GetFields();
            System.Collections.Generic.List<object> keys = new System.Collections.Generic.List<object>((relFields).Count);
            foreach (Net.TheVpc.Upa.Field field in relFields) {
                object keyPart = sourceRecord.GetObject<T>(field.GetName());
                if (keyPart == null) {
                    return null;
                }
                keys.Add(keyPart);
            }
            return GetTargetRole().GetEntity().CreateId(keys.ToArray());
        }

        public virtual object ExtractId(Net.TheVpc.Upa.Record sourceRecord) {
            switch(GetSourceRole().GetRelationshipUpdateType()) {
                case Net.TheVpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        object o = ExtractIdByEntityField(sourceRecord);
                        return o;
                    }
                case Net.TheVpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        return ExtractIdByForeignFields(sourceRecord);
                    }
            }
            return null;
        }

        public virtual Net.TheVpc.Upa.Extensions.HierarchyExtension GetHierarchyExtension() {
            return hierarchyExtension;
        }

        public virtual void SetHierarchyExtension(Net.TheVpc.Upa.Extensions.HierarchyExtension hierarchyExtension) {
            this.hierarchyExtension = hierarchyExtension;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression CreateTargetListExpression(object currentInstance, string alias) {
            if (filter == null) {
                return null;
            }
            System.Collections.Generic.Dictionary<string , object> v = new System.Collections.Generic.Dictionary<string , object>();
            v["this"]=currentInstance;
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(alias)) {
                alias = GetTargetEntity().GetName();
            }
            string alias2 = alias;
            Net.TheVpc.Upa.Expressions.Expression filter2 = GetPersistenceUnit().GetExpressionManager().SimplifyExpression(filter.Copy(), v);
            filter2.Visit(new Net.TheVpc.Upa.Impl.Uql.Util.ThatExpressionReplacer(alias2));
            return filter2;
        }
    }
}
