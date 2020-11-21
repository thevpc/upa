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
namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class RelationshipDescriptorProcessor : Net.TheVpc.Upa.Callbacks.EntityDefinitionListener, Net.TheVpc.Upa.Callbacks.FieldDefinitionListener, Net.TheVpc.Upa.Callbacks.PersistenceUnitListener {

        internal Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        internal Net.TheVpc.Upa.RelationshipDescriptor relationDescriptor;

        internal Net.TheVpc.Upa.Entity sourceEntity;

        internal Net.TheVpc.Upa.Entity targetEntity;

        internal Net.TheVpc.Upa.Relationship relation;

        internal Net.TheVpc.Upa.Field manyToOneField = null;

        internal Net.TheVpc.Upa.RelationshipUpdateType sourceUpdateType;

        internal System.Collections.Generic.IList<string> sourceFieldNames;

        internal bool nullable;

        internal Net.TheVpc.Upa.Expressions.Expression filter;

        public RelationshipDescriptorProcessor(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.RelationshipDescriptor relationInfo) {
            this.persistenceUnit = persistenceUnit;
            this.relationDescriptor = relationInfo;
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(relationDescriptor.GetTargetEntity()) && relationDescriptor.GetTargetEntityType() == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("NoneOfTargetEntityAndTargetEntityTypeDefined");
            }
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(relationDescriptor.GetSourceEntity()) && relationDescriptor.GetSourceEntityType() == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("NoneOfSourceEntityAndSourceEntityTypeDefined");
            }
        }

        public virtual void Process() {
            if (!ProcessRelation(false)) {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(relationDescriptor.GetSourceEntity())) {
                    persistenceUnit.AddDefinitionListener(relationDescriptor.GetSourceEntity(), this, true);
                }
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(relationDescriptor.GetTargetEntity())) {
                    persistenceUnit.AddDefinitionListener(relationDescriptor.GetTargetEntity(), this, true);
                }
                if (relationDescriptor.GetSourceEntityType() != null) {
                    persistenceUnit.AddDefinitionListener(relationDescriptor.GetSourceEntityType(), this, true);
                }
                if (relationDescriptor.GetTargetEntityType() != null) {
                    persistenceUnit.AddDefinitionListener(relationDescriptor.GetTargetEntityType(), this, true);
                }
                persistenceUnit.AddPersistenceUnitListener(this);
            }
        }

        public virtual void OnModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            if (!Build(true)) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("UnknownError");
            }
        }

        public virtual void OnCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
            Net.TheVpc.Upa.Entity e = @event.GetEntity();
            if (IsDetailOrMasterEntity(e)) {
                ProcessRelation(false);
            }
        }

        protected internal virtual bool IsDetailOrMasterEntity(Net.TheVpc.Upa.Entity e) {
            string n = e.GetName();
            System.Type t = e.GetEntityType();
            if (n.Equals(relationDescriptor.GetSourceEntity()) || t.Equals(relationDescriptor.GetSourceEntityType())) {
                return true;
            }
            if (n.Equals(relationDescriptor.GetTargetEntity()) || t.Equals(relationDescriptor.GetTargetEntityType())) {
                return true;
            }
            return false;
        }

        public virtual void OnCreateField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //            if (event.getField().getAbsoluteName().equals("User.id")) {
            //                System.out.println("Here");
            //            }
            Net.TheVpc.Upa.Entity entity = @event.GetEntity();
            if (IsDetailOrMasterEntity(entity)) {
                ProcessRelation(false);
            }
        }

        private bool Build(bool throwErrors) {
            if (sourceEntity == null) {
                if (relationDescriptor.GetSourceEntity() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetSourceEntity())) {
                        sourceEntity = persistenceUnit.GetEntity(relationDescriptor.GetSourceEntity());
                    }
                }
            }
            if (sourceEntity == null) {
                if (relationDescriptor.GetSourceEntityType() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetSourceEntityType())) {
                        sourceEntity = persistenceUnit.GetEntity(relationDescriptor.GetSourceEntityType());
                    }
                }
            }
            if (targetEntity == null) {
                if (relationDescriptor.GetTargetEntity() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetTargetEntity())) {
                        targetEntity = persistenceUnit.GetEntity(relationDescriptor.GetTargetEntity());
                    }
                }
            }
            if (targetEntity == null) {
                if (relationDescriptor.GetTargetEntityType() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetTargetEntityType())) {
                        targetEntity = persistenceUnit.GetEntity(relationDescriptor.GetTargetEntityType());
                    }
                }
            }
            if (sourceEntity == null) {
                if (throwErrors) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("InvalidRelationEntityNotFound", relationDescriptor.GetSourceEntityType());
                } else {
                    return false;
                }
            }
            if (targetEntity == null) {
                if (throwErrors) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("InvalidRelationEntityNotFound", relationDescriptor.GetTargetEntityType());
                } else {
                    return false;
                }
            }
            sourceUpdateType = Net.TheVpc.Upa.RelationshipUpdateType.FLAT;
            sourceFieldNames = new System.Collections.Generic.List<string>();
            if (relationDescriptor.GetBaseField() == null) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(sourceFieldNames, new System.Collections.Generic.List<string>(relationDescriptor.GetSourceFields()));
                if (relationDescriptor.GetMappedTo() != null && relationDescriptor.GetMappedTo().Length > 0) {
                    if (relationDescriptor.GetMappedTo().Length > 1) {
                        throw new System.ArgumentException ("mappedTo cannot only apply to single Entity Field");
                    }
                    manyToOneField = sourceEntity.GetField(relationDescriptor.GetMappedTo()[0]);
                }
            } else {
                Net.TheVpc.Upa.Field baseField = sourceEntity.GetField(relationDescriptor.GetBaseField());
                Net.TheVpc.Upa.Types.DataType baseFieldType = baseField.GetDataType();
                if (baseFieldType is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType et = (Net.TheVpc.Upa.Types.ManyToOneType) baseFieldType;
                    if (et.GetTargetEntityName() == null || (et.GetTargetEntityName().Length==0)) {
                        et.SetTargetEntityName(targetEntity.GetName());
                    }
                    sourceUpdateType = Net.TheVpc.Upa.RelationshipUpdateType.COMPOSED;
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Field> masterPK = targetEntity.GetPrimaryFields();
                    if (relationDescriptor.GetMappedTo() == null || relationDescriptor.GetMappedTo().Length == 0) {
                        if ((masterPK.Count==0)) {
                            if (throwErrors) {
                                throw new Net.TheVpc.Upa.Exceptions.UPAException("PrimaryFieldsNotFoundException", targetEntity.GetName());
                            } else {
                                return false;
                            }
                        } else {
                            foreach (Net.TheVpc.Upa.Field masterField in masterPK) {
                                string f = masterField.GetName();
                                if ((f).Length == 1) {
                                    f = f.ToUpper();
                                } else if ((f).Length > 1) {
                                    f = f.Substring(0, 1).ToUpper() + f.Substring(1);
                                }
                                string extraName = baseField.GetName() + f;
                                sourceFieldNames.Add(extraName);
                            }
                        }
                    } else {
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(sourceFieldNames, new System.Collections.Generic.List<string>(relationDescriptor.GetMappedTo()));
                    }
                    if ((sourceFieldNames).Count != (masterPK).Count) {
                        if (throwErrors) {
                            throw new System.ArgumentException ("Incorrect parameters");
                        } else {
                            return false;
                        }
                    }
                    if ((sourceFieldNames.Count==0)) {
                        if (throwErrors) {
                            throw new System.ArgumentException ("Incorrect parameters");
                        } else {
                            return false;
                        }
                    }
                    for (int i = 0; i < (sourceFieldNames).Count; i++) {
                        string extraName = sourceFieldNames[i];
                        Net.TheVpc.Upa.Field idField = sourceEntity.FindField(extraName);
                        if (idField == null) {
                            Net.TheVpc.Upa.Types.DataType dt = (Net.TheVpc.Upa.Types.DataType) masterPK[i].GetDataType().Copy();
                            bool nullable = baseFieldType.IsNullable();
                            dt.SetNullable(nullable);
                            idField = sourceEntity.AddField(extraName, "system", Net.TheVpc.Upa.FlagSets.Of<E>(Net.TheVpc.Upa.UserFieldModifier.SYSTEM), Net.TheVpc.Upa.FlagSets.Of<E>(Net.TheVpc.Upa.UserFieldModifier.UPDATE), null, dt, -1);
                            idField.SetAccessLevel(Net.TheVpc.Upa.AccessLevel.PRIVATE);
                        } else {
                            idField.SetUserExcludeModifiers(idField.GetUserExcludeModifiers().Add(Net.TheVpc.Upa.UserFieldModifier.UPDATE));
                        }
                    }
                    manyToOneField = baseField;
                } else {
                    sourceFieldNames.Add(baseField.GetName());
                    if (relationDescriptor.GetMappedTo() != null && relationDescriptor.GetMappedTo().Length > 0) {
                        if (relationDescriptor.GetMappedTo().Length > 1) {
                            throw new System.ArgumentException ("mappedTo cannot only apply to single Entity Field");
                        }
                        manyToOneField = sourceEntity.GetField(relationDescriptor.GetMappedTo()[0]);
                    }
                }
            }
            nullable = true;
            //TODO FIX ME
            for (int i = 0; i < (sourceFieldNames).Count; i++) {
                Net.TheVpc.Upa.Field slaveField = sourceEntity.GetField(sourceFieldNames[i]);
                Net.TheVpc.Upa.Types.DataType dataType = slaveField.GetDataType();
                if (dataType == null) {
                    //inherit master DataType
                    if ((targetEntity.GetPrimaryFields()).Count > i) {
                        Net.TheVpc.Upa.Types.DataType d = targetEntity.GetPrimaryFields()[i].GetDataType();
                        d = (Net.TheVpc.Upa.Types.DataType) d.Copy();
                        d.SetNullable(nullable);
                        slaveField.SetDataType(d);
                        //reset transform!
                        slaveField.SetTypeTransform(null);
                    } else {
                        throw new System.ArgumentException ("Invalid Relation");
                    }
                }
            }
            filter = relationDescriptor.GetFilter();
            //        if (baseFieldType instanceof ManyToOneType) {
            //            manyToOneField = baseField;
            //        } else if (sourceFieldNames.size() == 1) {
            //            DataType slaveType = slaveField.getDataType();
            //            if (slaveType instanceof ManyToOneType) {
            //                manyToOneField = slaveField;
            //            }
            //        }
            return true;
        }

        public virtual bool ProcessImmediate() {
            return ProcessRelation(false);
        }

        private bool ProcessRelation(bool throwErrors) {
            if (!Build(throwErrors)) {
                return false;
            }
            Net.TheVpc.Upa.PersistenceUnit pu = sourceEntity.GetPersistenceUnit();
            if (relation == null) {
                Net.TheVpc.Upa.DefaultRelationshipDescriptor rd = new Net.TheVpc.Upa.DefaultRelationshipDescriptor();
                rd.SetName(relationDescriptor.GetName());
                rd.SetBaseField(relationDescriptor.GetBaseField());
                rd.SetRelationshipType(relationDescriptor.GetRelationshipType());
                rd.SetSourceEntity(sourceEntity.GetName());
                rd.SetTargetEntity(targetEntity.GetName());
                rd.SetSourceFields(sourceFieldNames.ToArray());
                rd.SetFilter(relationDescriptor.GetFilter());
                rd.SetHierarchy(relationDescriptor.IsHierarchy());
                rd.SetHierarchyPathField(relationDescriptor.GetHierarchyPathField());
                rd.SetHierarchyPathSeparator(relationDescriptor.GetHierarchyPathSeparator());
                rd.SetNullable(relationDescriptor.IsNullable());
                relation = ((Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) pu).AddRelationshipImmediate(rd);
            } else {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(relationDescriptor.GetName())) {
                    relation.SetName(relationDescriptor.GetName());
                }
                relation.SetRelationshipType(relationDescriptor.GetRelationshipType() == default(Net.TheVpc.Upa.RelationshipType) ? Net.TheVpc.Upa.RelationshipType.DEFAULT : relationDescriptor.GetRelationshipType());
                relation.GetSourceRole().SetEntityField(manyToOneField);
                relation.GetSourceRole().SetRelationshipUpdateType(sourceUpdateType);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> slaveFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
                foreach (string n in sourceFieldNames) {
                    Net.TheVpc.Upa.Field f = sourceEntity.GetField(n);
                    slaveFields.Add(f);
                }
                relation.GetSourceRole().SetFields(slaveFields.ToArray());
                relation.GetTargetRole().SetEntityField(null);
                relation.GetTargetRole().SetRelationshipUpdateType(Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.RelationshipUpdateType>(typeof(Net.TheVpc.Upa.RelationshipUpdateType)));
                relation.SetFilter(filter);
                relation.SetNullable(nullable);
            }
            return true;
        }

        public virtual void OnStorageChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }

        public virtual void OnStart(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }

        public virtual void OnClose(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }

        public virtual void OnDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }

        public virtual void OnMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }

        public virtual void OnDropField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }

        public virtual void OnMoveField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreCreateField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreDropField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreMoveField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreStorageChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreStart(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreClear(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnClear(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreReset(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnReset(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreClose(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnInitEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreInitEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.RelationshipDescriptor GetRelationDescriptor() {
            return relationDescriptor;
        }

        public virtual Net.TheVpc.Upa.Entity GetSourceEntity() {
            return sourceEntity;
        }

        public virtual Net.TheVpc.Upa.Entity GetTargetEntity() {
            return targetEntity;
        }

        public virtual Net.TheVpc.Upa.Relationship GetRelation() {
            return relation;
        }

        public virtual Net.TheVpc.Upa.Field GetManyToOneField() {
            return manyToOneField;
        }

        public virtual Net.TheVpc.Upa.RelationshipUpdateType GetSourceUpdateType() {
            return sourceUpdateType;
        }

        public virtual System.Collections.Generic.IList<string> GetSourceFieldNames() {
            return sourceFieldNames;
        }

        public virtual bool IsNullable() {
            return nullable;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilter() {
            return filter;
        }
    }
}
