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
namespace Net.Vpc.Upa.Impl
{


    public class DefaultRelationship : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Relationship {

        private Net.Vpc.Upa.RelationshipRole targetRole;

        private Net.Vpc.Upa.RelationshipRole sourceRole;

        protected internal System.Collections.Generic.IDictionary<string , string> targetToSourceKeyMap;

        protected internal System.Collections.Generic.IDictionary<string , string> sourceToTargetKeyMap;

        protected internal Net.Vpc.Upa.Types.DataType dataType;

        private Net.Vpc.Upa.RelationshipType relationType;

        protected internal Net.Vpc.Upa.Expressions.Expression filter;

        private int tuningMaxInline = 10;

        private bool nullable;

        private Net.Vpc.Upa.Extensions.HierarchyExtension hierarchyExtension;

        public DefaultRelationship() {
            targetRole = new Net.Vpc.Upa.Impl.DefaultRelationshipRole();
            targetRole.SetRelationship(this);
            targetRole.SetRelationshipRoleType(Net.Vpc.Upa.RelationshipRoleType.TARGET);
            sourceRole = new Net.Vpc.Upa.Impl.DefaultRelationshipRole();
            sourceRole.SetRelationship(this);
            sourceRole.SetRelationshipRoleType(Net.Vpc.Upa.RelationshipRoleType.SOURCE);
        }


        public override string GetAbsoluteName() {
            return GetName();
        }

        public virtual void SetNullable(bool nullable) {
            this.nullable = nullable;
        }


        public virtual void CommitModelChanged() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity sourceEntity = GetSourceRole().GetEntity();
            Net.Vpc.Upa.Entity targetEntity = GetTargetRole().GetEntity();
            if (sourceEntity == null || targetEntity == null) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("InvalidRelationDefinition");
            }
            if (!sourceEntity.GetUserExcludeModifiers().Contains(Net.Vpc.Upa.EntityModifier.VALIDATE_INSERT)) {
                sourceEntity.GetModifiers().Add(Net.Vpc.Upa.EntityModifier.VALIDATE_INSERT);
            }
            if (!sourceEntity.GetUserExcludeModifiers().Contains(Net.Vpc.Upa.EntityModifier.VALIDATE_UPDATE)) {
                sourceEntity.GetModifiers().Add(Net.Vpc.Upa.EntityModifier.VALIDATE_UPDATE);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> sourceFieldsList = sourceRole.GetFields();
            Net.Vpc.Upa.Field[] sourceFields = sourceFieldsList.ToArray();
            Net.Vpc.Upa.KeyType keyType = new Net.Vpc.Upa.KeyType(targetEntity, filter, false);
            SetDataType(keyType);
            tuningMaxInline = GetPersistenceUnit().GetProperties().GetInt((typeof(Net.Vpc.Upa.Relationship)).FullName + ".maxInline", 10);
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> targetFieldsList = targetEntity.GetPrimaryFields();
            Net.Vpc.Upa.Field[] targetFields = targetFieldsList.ToArray();
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
                Net.Vpc.Upa.Types.DataType trCloned = (Net.Vpc.Upa.Types.DataType) dataType.Clone();
                trCloned.SetNullable(nullable);
                dataType = trCloned;
            }
            this.sourceToTargetKeyMap = new System.Collections.Generic.Dictionary<string , string>(sourceFields.Length);
            this.targetToSourceKeyMap = new System.Collections.Generic.Dictionary<string , string>(sourceFields.Length);
            //        if ((theSourceTable  instanceof View))
            //            this.type = 0;
            for (int i = 0; i < sourceFields.Length; i++) {
                if (sourceFields[i].GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.TRANSIENT) && this.relationType != Net.Vpc.Upa.RelationshipType.TRANSIENT) {
                    //Log. System.err.println("Type should be VIEW for " + getName());
                    this.relationType = Net.Vpc.Upa.RelationshipType.TRANSIENT;
                } else if (sourceFields[i].GetUpdateFormula() != null && this.relationType != Net.Vpc.Upa.RelationshipType.TRANSIENT && this.relationType != Net.Vpc.Upa.RelationshipType.SHADOW_ASSOCIATION) {
                    // Log. System.err.println("Type should be either VIEW or SHADOW for " + name);
                    this.relationType = Net.Vpc.Upa.RelationshipType.SHADOW_ASSOCIATION;
                }
                this.sourceToTargetKeyMap[sourceFields[i].GetName()]=targetFields[i].GetName();
                this.targetToSourceKeyMap[targetFields[i].GetName()]=sourceFields[i].GetName();
                targetFields[i].AddTargetRelationship(this);
                ((Net.Vpc.Upa.Impl.AbstractField) sourceFields[i]).SetEffectiveModifiers(sourceFields[i].GetModifiers().Add(Net.Vpc.Upa.FieldModifier.FOREIGN));
                ((Net.Vpc.Upa.Impl.AbstractField) targetFields[i]).SetEffectiveModifiers(targetFields[i].GetModifiers().Add(Net.Vpc.Upa.FieldModifier.REFERENCED));
                //            if (sourceFields[i].getTitle() == null) {
                //                sourceFields[i].setTitle(targetFields[i].getTitle());
                //            }
                if (sourceFields[i].GetDataType() == null) {
                    Net.Vpc.Upa.Types.DataType tr = targetFields[i].GetDataType();
                    if (tr.IsNullable() == nullable) {
                        sourceFields[i].SetDataType(tr);
                    } else {
                        Net.Vpc.Upa.Types.DataType trCloned = (Net.Vpc.Upa.Types.DataType) tr.Clone();
                        trCloned.SetNullable(nullable);
                        sourceFields[i].SetDataType(trCloned);
                    }
                }
            }
            if (GetSourceRole().GetEntityField() != null) {
                Net.Vpc.Upa.Field sourceEntityField = GetSourceRole().GetEntityField();
                Net.Vpc.Upa.Types.DataType dt = sourceEntityField.GetDataType();
                if (dt is Net.Vpc.Upa.Types.EntityType) {
                    Net.Vpc.Upa.Types.EntityType edt = (Net.Vpc.Upa.Types.EntityType) dt;
                    edt.SetRelationship(this);
                }
            }
            if (GetTargetRole().GetEntityField() != null) {
                Net.Vpc.Upa.Field targetEntityField = GetTargetRole().GetEntityField();
                Net.Vpc.Upa.Types.DataType dt = targetEntityField.GetDataType();
                if (dt is Net.Vpc.Upa.Types.EntityType) {
                    Net.Vpc.Upa.Types.EntityType edt = (Net.Vpc.Upa.Types.EntityType) dt;
                    edt.SetRelationship(this);
                }
            }
            this.sourceToTargetKeyMap = Net.Vpc.Upa.Impl.Util.PlatformUtils.UnmodifiableMap<string, string>(sourceToTargetKeyMap);
            this.targetToSourceKeyMap = Net.Vpc.Upa.Impl.Util.PlatformUtils.UnmodifiableMap<string, string>(targetToSourceKeyMap);
            SetI18NString(new Net.Vpc.Upa.Types.I18NString("Relationship").Append(GetName()));
            SetTitle(GetI18NString().Append(".title"));
            SetDescription(GetI18NString().Append(".desc"));
            System.Text.StringBuilder preferredPersistenceName = new System.Text.StringBuilder((GetName()).Length);
            for (int i = 0; i < (GetName()).Length; i++) {
                if (Net.Vpc.Upa.Expressions.ExpressionHelper.IsIdentifierPart(GetName()[i])) {
                    preferredPersistenceName.Append(GetName()[i]);
                } else {
                    preferredPersistenceName.Append('_');
                }
            }
            SetPersistenceName(preferredPersistenceName.ToString());
            if (GetRelationshipType() == Net.Vpc.Upa.RelationshipType.COMPOSITION) {
                ((Net.Vpc.Upa.Impl.DefaultEntity) sourceEntity).SetCompositionRelationship(this);
            }
            targetRole.SetFields(targetFields);
            Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), targetRole, this.GetName() + "_" + targetRole.GetRelationshipRoleType());
            Net.Vpc.Upa.Impl.Util.UPAUtils.Prepare(GetPersistenceUnit(), sourceRole, this.GetName() + "_" + sourceRole.GetRelationshipRoleType());
            if ((((GetTargetRole().GetEntity().GetExtensionDefinitions<Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0) || ((GetSourceRole().GetEntity().GetExtensionDefinitions<Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0)) && relationType != Net.Vpc.Upa.RelationshipType.TRANSIENT) {
                throw new System.ArgumentException (this + " : Relationship Type must be TYPE_VIEW");
            }
            if (((GetTargetRole().GetEntity().GetShield().IsTransient()) || (GetSourceRole().GetEntity().GetShield().IsTransient())) && relationType != Net.Vpc.Upa.RelationshipType.TRANSIENT) {
                throw new System.ArgumentException (this + " : Relationship Type must be TYPE_VIEW");
            }
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifierstoRemove = Net.Vpc.Upa.FlagSets.OfType<Net.Vpc.Upa.FieldModifier>().AddAll(Net.Vpc.Upa.FieldModifier.PERSIST, Net.Vpc.Upa.FieldModifier.PERSIST_DEFAULT, Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA, Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE, Net.Vpc.Upa.FieldModifier.UPDATE, Net.Vpc.Upa.FieldModifier.UPDATE_DEFAULT, Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA, Net.Vpc.Upa.FieldModifier.UPDATE_SEQUENCE);
            switch(GetSourceRole().GetRelationshipUpdateType()) {
                case Net.Vpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        Net.Vpc.Upa.Field f = GetSourceRole().GetEntityField();
                        if (f != null) {
                            ((Net.Vpc.Upa.Impl.AbstractField) f).SetEffectiveModifiers(f.GetModifiers().RemoveAll(modifierstoRemove));
                        }
                        break;
                    }
                case Net.Vpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = GetSourceRole().GetFields();
                        if (fields != null) {
                            foreach (Net.Vpc.Upa.Field f in fields) {
                                ((Net.Vpc.Upa.Impl.AbstractField) f).SetEffectiveModifiers(f.GetModifiers().RemoveAll(modifierstoRemove));
                            }
                        }
                        break;
                    }
            }
        }

        public virtual void SetDataType(Net.Vpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
        }

        public virtual Net.Vpc.Upa.RelationshipType GetRelationshipType() {
            return relationType;
        }

        public virtual void SetRelationshipType(Net.Vpc.Upa.RelationshipType relationType) {
            this.relationType = relationType;
        }

        public virtual int Size() {
            return (GetSourceRole().GetFields()).Count;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldNamesMap(bool absolute) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IDictionary<string , string> m = new System.Collections.Generic.Dictionary<string , string>((GetSourceToTargetFieldsMap()).Count);
            if (absolute) {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in sourceToTargetKeyMap) {
                    m[GetSourceRole().GetEntity().GetField((e).Key).GetName()]=GetTargetRole().GetEntity().GetField((e).Value).GetName();
                }
            } else {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in sourceToTargetKeyMap) {
                    m[(e).Key]=(e).Value;
                }
            }
            return m;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldNamesMap(bool absolute) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IDictionary<string , string> m = new System.Collections.Generic.Dictionary<string , string>((GetSourceToTargetFieldsMap()).Count);
            if (absolute) {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in targetToSourceKeyMap) {
                    m[GetTargetRole().GetEntity().GetField((e).Key).GetName()]=GetSourceRole().GetEntity().GetField((e).Value).GetName();
                }
            } else {
                foreach (System.Collections.Generic.KeyValuePair<string , string> e in targetToSourceKeyMap) {
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
            if (other == null || !(other is Net.Vpc.Upa.Impl.DefaultRelationship)) {
                return false;
            } else {
                Net.Vpc.Upa.Impl.DefaultRelationship o = (Net.Vpc.Upa.Impl.DefaultRelationship) other;
                return GetPersistenceUnit().GetNamingStrategy().Equals(GetName(), o.GetName());
            }
        }


        public override string ToString() {
            return GetName();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetTargetCondition(Net.Vpc.Upa.Expressions.Expression sourceCondition, string sourceAlias, string targetAlias) {
            Net.Vpc.Upa.Field[] sourceFields = GetSourceRole().GetFields().ToArray();
            Net.Vpc.Upa.Field[] targetFields = GetTargetRole().GetFields().ToArray();
            Net.Vpc.Upa.Expressions.Var[] lvar = new Net.Vpc.Upa.Expressions.Var[sourceFields.Length];
            Net.Vpc.Upa.Expressions.Var[] rvar = new Net.Vpc.Upa.Expressions.Var[targetFields.Length];
            for (int i = 0; i < lvar.Length; i++) {
                lvar[i] = (sourceAlias == null) ? new Net.Vpc.Upa.Expressions.Var(sourceFields[i].GetName()) : new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                rvar[i] = (targetAlias == null) ? new Net.Vpc.Upa.Expressions.Var(targetFields[i].GetName()) : new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(targetAlias), targetFields[i].GetName());
            }
            if (tuningMaxInline > 0) {
                try {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Record> list = GetSourceRole().GetEntity().CreateQuery(new Net.Vpc.Upa.Expressions.Select().Uplet(lvar, "lvar").Where(sourceCondition)).GetRecordList();
                    int j = 0;
                    Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression inCollection = new Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression(rvar);
                    foreach (Net.Vpc.Upa.Record r in list) {
                        j++;
                        if (j > tuningMaxInline) {
                            return new Net.Vpc.Upa.Expressions.InSelection(lvar, new Net.Vpc.Upa.Expressions.Select().From(GetSourceRole().GetEntity().GetName()).Uplet(lvar).Where(sourceCondition));
                        }
                        inCollection.Add(new Net.Vpc.Upa.Expressions.Param(null, r.GetSingleResult<object>()));
                    }
                    //inCollection.add(new Litteral(rs.getObject(1)));
                    return inCollection;
                } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                    return new Net.Vpc.Upa.Expressions.InSelection(rvar, new Net.Vpc.Upa.Expressions.Select().From(GetSourceRole().GetEntity().GetName()).Uplet(lvar).Where(sourceCondition));
                }
            } else {
                return new Net.Vpc.Upa.Expressions.InSelection(rvar, new Net.Vpc.Upa.Expressions.Select().From(GetSourceRole().GetEntity().GetName()).Uplet(lvar).Where(sourceCondition));
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetSourceCondition(Net.Vpc.Upa.Expressions.Expression targetCondition, string sourceAlias, string targetAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //Key Rkey=getTargetTable().getKeyForExpression(targetCondition);
            Net.Vpc.Upa.Field[] sourceFields = GetSourceRole().GetFields().ToArray();
            Net.Vpc.Upa.Field[] targetFields = GetTargetRole().GetFields().ToArray();
            if (targetCondition is Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression) {
                Net.Vpc.Upa.Key Rkey = targetRole.GetEntity().GetBuilder().IdToKey(((Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression) targetCondition).GetKey());
                if (sourceFields.Length == 1) {
                    Net.Vpc.Upa.Expressions.Var lvar = (sourceAlias == null) ? new Net.Vpc.Upa.Expressions.Var(sourceFields[0].GetName()) : new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(sourceAlias), sourceFields[0].GetName());
                    return new Net.Vpc.Upa.Expressions.Equals(lvar, new Net.Vpc.Upa.Expressions.Literal(Rkey.GetValue()[0], targetFields[0].GetDataType()));
                } else {
                    Net.Vpc.Upa.Expressions.Expression a = null;
                    for (int i = 0; i < sourceFields.Length; i++) {
                        Net.Vpc.Upa.Expressions.Var lvar = (sourceAlias == null) ? new Net.Vpc.Upa.Expressions.Var(sourceFields[i].GetName()) : new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                        Net.Vpc.Upa.Expressions.Expression rvar = new Net.Vpc.Upa.Expressions.Literal(Rkey.GetObjectAt(i), targetFields[i].GetDataType());
                        Net.Vpc.Upa.Expressions.Expression e = new Net.Vpc.Upa.Expressions.Equals(lvar, rvar);
                        a = a == null ? e : a;
                    }
                    return a;
                }
            } else if (tuningMaxInline > 0) {
                Net.Vpc.Upa.Expressions.Var[] lvar = new Net.Vpc.Upa.Expressions.Var[sourceFields.Length];
                Net.Vpc.Upa.Expressions.Var[] rvar = new Net.Vpc.Upa.Expressions.Var[targetFields.Length];
                for (int i = 0; i < lvar.Length; i++) {
                    lvar[i] = new Net.Vpc.Upa.Expressions.Var((sourceAlias == null) ? null : new Net.Vpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                    rvar[i] = new Net.Vpc.Upa.Expressions.Var((targetAlias == null) ? null : new Net.Vpc.Upa.Expressions.Var(targetAlias), targetFields[i].GetName());
                }
                try {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Record> list = GetTargetRole().GetEntity().CreateQuery(new Net.Vpc.Upa.Expressions.Select().Uplet(rvar, "rval").Where(targetCondition)).GetRecordList();
                    int j = 0;
                    Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression inCollection = new Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression(lvar);
                    foreach (Net.Vpc.Upa.Record r in list) {
                        j++;
                        if (j > tuningMaxInline) {
                            return new Net.Vpc.Upa.Expressions.InSelection(lvar, new Net.Vpc.Upa.Expressions.Select().From(GetTargetRole().GetEntity().GetName()).Uplet(rvar).Where(targetCondition));
                        }
                        inCollection.Add(new Net.Vpc.Upa.Expressions.Param(null, r.GetSingleResult<object>()));
                    }
                    //inCollection.add(new Litteral(rs.getObject(1)));
                    return inCollection;
                } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                    return new Net.Vpc.Upa.Expressions.InSelection(lvar, new Net.Vpc.Upa.Expressions.Select().From(GetTargetRole().GetEntity().GetName()).Uplet(rvar).Where(targetCondition));
                }
            } else {
                Net.Vpc.Upa.Expressions.Var[] lvar = new Net.Vpc.Upa.Expressions.Var[sourceFields.Length];
                Net.Vpc.Upa.Expressions.Var[] rvar = new Net.Vpc.Upa.Expressions.Var[targetFields.Length];
                for (int i = 0; i < lvar.Length; i++) {
                    lvar[i] = new Net.Vpc.Upa.Expressions.Var((sourceAlias == null) ? null : new Net.Vpc.Upa.Expressions.Var(sourceAlias), sourceFields[i].GetName());
                    rvar[i] = new Net.Vpc.Upa.Expressions.Var((targetAlias == null) ? null : new Net.Vpc.Upa.Expressions.Var(targetAlias), targetFields[i].GetName());
                }
                return new Net.Vpc.Upa.Expressions.InSelection(lvar, new Net.Vpc.Upa.Expressions.Select().From(GetTargetRole().GetEntity().GetName()).Uplet(rvar).Where(targetCondition));
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilter() {
            return filter;
        }

        public virtual void SetFilter(Net.Vpc.Upa.Expressions.Expression filter) {
            this.filter = filter;
        }

        public virtual bool IsTransient() {
            switch(relationType) {
                case Net.Vpc.Upa.RelationshipType.TRANSIENT:
                    {
                        return true;
                    }
            }
            return false;
        }


        public virtual bool IsFollowLinks() {
            switch(relationType) {
                case Net.Vpc.Upa.RelationshipType.DEFAULT:
                case Net.Vpc.Upa.RelationshipType.ASSOCIATION:
                case Net.Vpc.Upa.RelationshipType.AGGREGATION:
                case Net.Vpc.Upa.RelationshipType.COMPOSITION:
                case Net.Vpc.Upa.RelationshipType.SHADOW_ASSOCIATION:
                    {
                        return true;
                    }
            }
            return false;
        }


        public virtual bool IsAskForConfirm() {
            switch(relationType) {
                case Net.Vpc.Upa.RelationshipType.DEFAULT:
                case Net.Vpc.Upa.RelationshipType.ASSOCIATION:
                case Net.Vpc.Upa.RelationshipType.AGGREGATION:
                    {
                        return true;
                    }
            }
            return false;
        }

        public virtual Net.Vpc.Upa.RelationshipRole GetTargetRole() {
            return targetRole;
        }

        public virtual Net.Vpc.Upa.RelationshipRole GetSourceRole() {
            return sourceRole;
        }

        public virtual Net.Vpc.Upa.Entity GetTargetEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return targetRole.GetEntity();
        }

        public virtual Net.Vpc.Upa.Entity GetSourceEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return sourceRole.GetEntity();
        }

        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.Vpc.Upa.Key GetKey(Net.Vpc.Upa.Record sourceRecord) {
            switch(GetSourceRole().GetRelationshipUpdateType()) {
                case Net.Vpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        object targetEntityVal = sourceRecord.GetObject<object>(GetSourceRole().GetEntityField().GetName());
                        if (targetEntityVal == null) {
                            return null;
                        }
                        Net.Vpc.Upa.EntityBuilder targetConverter = GetTargetRole().GetEntity().GetBuilder();
                        return targetConverter.EntityToKey(targetEntityVal);
                    }
                case Net.Vpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        System.Collections.Generic.IList<Net.Vpc.Upa.Field> relFields = GetSourceRole().GetFields();
                        System.Collections.Generic.List<object> keys = new System.Collections.Generic.List<object>((relFields).Count);
                        foreach (Net.Vpc.Upa.Field field in relFields) {
                            object keyPart = sourceRecord.GetObject<object>(field.GetName());
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

        public virtual Net.Vpc.Upa.Extensions.HierarchyExtension GetHierarchyExtension() {
            return hierarchyExtension;
        }

        public virtual void SetHierarchyExtension(Net.Vpc.Upa.Extensions.HierarchyExtension hierarchyExtension) {
            this.hierarchyExtension = hierarchyExtension;
        }
    }
}
