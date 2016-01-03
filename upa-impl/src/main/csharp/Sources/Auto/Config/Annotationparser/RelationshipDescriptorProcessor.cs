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
namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class RelationshipDescriptorProcessor : Net.Vpc.Upa.Callbacks.EntityDefinitionListener, Net.Vpc.Upa.Callbacks.FieldDefinitionListener, Net.Vpc.Upa.Callbacks.PersistenceUnitListener {

        internal Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        internal Net.Vpc.Upa.RelationshipDescriptor relationDescriptor;

        internal Net.Vpc.Upa.Entity detailEntity;

        internal Net.Vpc.Upa.Entity masterEntity;

        internal Net.Vpc.Upa.Relationship relation;

        internal Net.Vpc.Upa.Field manyToOneField = null;

        internal Net.Vpc.Upa.RelationshipUpdateType detailUpdateType;

        internal System.Collections.Generic.IList<string> detailFieldNames;

        internal bool nullable;

        internal Net.Vpc.Upa.Expressions.Expression filter;

        public RelationshipDescriptorProcessor(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.RelationshipDescriptor relationInfo) {
            this.persistenceUnit = persistenceUnit;
            this.relationDescriptor = relationInfo;
        }

        public virtual void Process() {
            if (!ProcessRelation(false)) {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(relationDescriptor.GetSourceEntity())) {
                    persistenceUnit.AddDefinitionListener(relationDescriptor.GetSourceEntity(), this, true);
                }
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(relationDescriptor.GetTargetEntity())) {
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

        public virtual void OnModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            if (!Build(true)) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("UnknownError");
            }
        }

        public virtual void OnCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
            Net.Vpc.Upa.Entity e = @event.GetEntity();
            if (IsDetailOrMasterEntity(e)) {
                ProcessRelation(false);
            }
        }

        protected internal virtual bool IsDetailOrMasterEntity(Net.Vpc.Upa.Entity e) {
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

        public virtual void OnCreateField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //            if (event.getField().getAbsoluteName().equals("User.id")) {
            //                System.out.println("Here");
            //            }
            Net.Vpc.Upa.Entity entity = @event.GetEntity();
            if (IsDetailOrMasterEntity(entity)) {
                ProcessRelation(false);
            }
        }

        private bool Build(bool throwErrors) {
            if (detailEntity == null) {
                if (relationDescriptor.GetSourceEntity() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetSourceEntity())) {
                        detailEntity = persistenceUnit.GetEntity(relationDescriptor.GetSourceEntity());
                    }
                }
            }
            if (detailEntity == null) {
                if (relationDescriptor.GetSourceEntityType() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetSourceEntityType())) {
                        detailEntity = persistenceUnit.GetEntity(relationDescriptor.GetSourceEntityType());
                    }
                }
            }
            if (masterEntity == null) {
                if (relationDescriptor.GetTargetEntity() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetTargetEntity())) {
                        masterEntity = persistenceUnit.GetEntity(relationDescriptor.GetTargetEntity());
                    }
                }
            }
            if (masterEntity == null) {
                if (relationDescriptor.GetTargetEntityType() != null) {
                    if (persistenceUnit.ContainsEntity(relationDescriptor.GetTargetEntityType())) {
                        masterEntity = persistenceUnit.GetEntity(relationDescriptor.GetTargetEntityType());
                    }
                }
            }
            if (detailEntity == null) {
                if (throwErrors) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("InvalidRelationEntityNotFound", relationDescriptor.GetSourceEntityType());
                } else {
                    return false;
                }
            }
            if (masterEntity == null) {
                if (throwErrors) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("InvalidRelationEntityNotFound", relationDescriptor.GetTargetEntityType());
                } else {
                    return false;
                }
            }
            detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.FLAT;
            detailFieldNames = new System.Collections.Generic.List<string>();
            if (relationDescriptor.GetBaseField() == null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(detailFieldNames, new System.Collections.Generic.List<string>(relationDescriptor.GetSourceFields()));
                if (relationDescriptor.GetMappedTo() != null && relationDescriptor.GetMappedTo().Length > 0) {
                    if (relationDescriptor.GetMappedTo().Length > 1) {
                        throw new System.ArgumentException ("mappedTo cannot only apply to single Entity Field");
                    }
                    manyToOneField = detailEntity.GetField(relationDescriptor.GetMappedTo()[0]);
                }
            } else {
                Net.Vpc.Upa.Field baseField = detailEntity.GetField(relationDescriptor.GetBaseField());
                Net.Vpc.Upa.Types.DataType baseFieldType = baseField.GetDataType();
                if (baseFieldType is Net.Vpc.Upa.Types.EntityType) {
                    Net.Vpc.Upa.Types.EntityType et = (Net.Vpc.Upa.Types.EntityType) baseFieldType;
                    if (et.GetReferencedEntityName() == null || et.GetReferencedEntityName().Length==0) {
                        et.SetReferencedEntityName(masterEntity.GetName());
                    }
                    detailUpdateType = Net.Vpc.Upa.RelationshipUpdateType.COMPOSED;
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> masterPK = masterEntity.GetPrimaryFields();
                    if (relationDescriptor.GetMappedTo() == null || relationDescriptor.GetMappedTo().Length == 0) {
                        if ((masterPK.Count==0)) {
                            if (throwErrors) {
                                throw new Net.Vpc.Upa.Exceptions.UPAException("PrimaryFieldsNotFoundException", masterEntity.GetName());
                            } else {
                                return false;
                            }
                        } else {
                            foreach (Net.Vpc.Upa.Field masterField in masterPK) {
                                string f = masterField.GetName();
                                if ((f).Length == 1) {
                                    f = f.ToUpper();
                                } else if ((f).Length > 1) {
                                    f = f.Substring(0, 1).ToUpper() + f.Substring(1);
                                }
                                string extraName = baseField.GetName() + f;
                                detailFieldNames.Add(extraName);
                            }
                        }
                    } else {
                        Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(detailFieldNames, new System.Collections.Generic.List<string>(relationDescriptor.GetMappedTo()));
                    }
                    if ((detailFieldNames).Count != (masterPK).Count) {
                        if (throwErrors) {
                            throw new System.ArgumentException ("Incorrect parameters");
                        } else {
                            return false;
                        }
                    }
                    if ((detailFieldNames.Count==0)) {
                        if (throwErrors) {
                            throw new System.ArgumentException ("Incorrect parameters");
                        } else {
                            return false;
                        }
                    }
                    for (int i = 0; i < (detailFieldNames).Count; i++) {
                        string extraName = detailFieldNames[i];
                        Net.Vpc.Upa.Field idField = detailEntity.FindField(extraName);
                        if (idField == null) {
                            Net.Vpc.Upa.Types.DataType dt = (Net.Vpc.Upa.Types.DataType) masterPK[i].GetDataType().Clone();
                            bool nullable = baseFieldType.IsNullable();
                            dt.SetNullable(nullable);
                            idField = detailEntity.AddField(extraName, "system", Net.Vpc.Upa.FlagSets.Of<Net.Vpc.Upa.UserFieldModifier>(Net.Vpc.Upa.UserFieldModifier.SYSTEM), Net.Vpc.Upa.FlagSets.Of<Net.Vpc.Upa.UserFieldModifier>(Net.Vpc.Upa.UserFieldModifier.UPDATE), null, dt, -1);
                            idField.SetAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE);
                        } else {
                            idField.SetUserExcludeModifiers(idField.GetUserExcludeModifiers().Add(Net.Vpc.Upa.UserFieldModifier.UPDATE));
                        }
                    }
                    manyToOneField = baseField;
                } else {
                    detailFieldNames.Add(baseField.GetName());
                    if (relationDescriptor.GetMappedTo() != null && relationDescriptor.GetMappedTo().Length > 0) {
                        if (relationDescriptor.GetMappedTo().Length > 1) {
                            throw new System.ArgumentException ("mappedTo cannot only apply to single Entity Field");
                        }
                        manyToOneField = detailEntity.GetField(relationDescriptor.GetMappedTo()[0]);
                    }
                }
            }
            nullable = true;
            //TODO FIX ME
            for (int i = 0; i < (detailFieldNames).Count; i++) {
                Net.Vpc.Upa.Field slaveField = detailEntity.GetField(detailFieldNames[i]);
                Net.Vpc.Upa.Types.DataType dataType = slaveField.GetDataType();
                if (dataType == null) {
                    //inherit master DataType
                    if ((masterEntity.GetPrimaryFields()).Count > i) {
                        Net.Vpc.Upa.Types.DataType d = masterEntity.GetPrimaryFields()[i].GetDataType();
                        d = (Net.Vpc.Upa.Types.DataType) d.Clone();
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
            //        if (baseFieldType instanceof EntityType) {
            //            manyToOneField = baseField;
            //        } else if (detailFieldNames.size() == 1) {
            //            DataType slaveType = slaveField.getDataType();
            //            if (slaveType instanceof EntityType) {
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
            Net.Vpc.Upa.PersistenceUnit pu = detailEntity.GetPersistenceUnit();
            if (relation == null) {
                Net.Vpc.Upa.DefaultRelationshipDescriptor rd = new Net.Vpc.Upa.DefaultRelationshipDescriptor();
                rd.SetName(relationDescriptor.GetName());
                rd.SetBaseField(relationDescriptor.GetBaseField());
                rd.SetRelationshipType(relationDescriptor.GetRelationshipType());
                rd.SetSourceEntity(detailEntity.GetName());
                rd.SetTargetEntity(masterEntity.GetName());
                rd.SetSourceFields(detailFieldNames.ToArray());
                rd.SetFilter(relationDescriptor.GetFilter());
                rd.SetHierarchy(relationDescriptor.IsHierarchy());
                rd.SetHierarchyPathField(relationDescriptor.GetHierarchyPathField());
                rd.SetHierarchyPathSeparator(relationDescriptor.GetHierarchyPathSeparator());
                rd.SetNullable(relationDescriptor.IsNullable());
                relation = ((Net.Vpc.Upa.Impl.DefaultPersistenceUnit) pu).AddRelationshipImmediate(rd);
            } else {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(relationDescriptor.GetName())) {
                    relation.SetName(relationDescriptor.GetName());
                }
                relation.SetRelationshipType(relationDescriptor.GetRelationshipType() == null ? Net.Vpc.Upa.RelationshipType.DEFAULT : relationDescriptor.GetRelationshipType());
                relation.GetSourceRole().SetEntityField(manyToOneField);
                relation.GetSourceRole().SetRelationshipUpdateType(detailUpdateType);
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> slaveFields = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
                foreach (string n in detailFieldNames) {
                    Net.Vpc.Upa.Field f = detailEntity.GetField(n);
                    slaveFields.Add(f);
                }
                relation.GetSourceRole().SetFields(slaveFields.ToArray());
                relation.GetTargetRole().SetEntityField(null);
                relation.GetTargetRole().SetRelationshipUpdateType(Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.RelationshipUpdateType>(typeof(Net.Vpc.Upa.RelationshipUpdateType)));
                relation.SetFilter(filter);
                relation.SetNullable(nullable);
            }
            return true;
        }

        public virtual void OnStorageChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }

        public virtual void OnStart(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }

        public virtual void OnClose(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }

        public virtual void OnDropEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }

        public virtual void OnMoveEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }

        public virtual void OnDropField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual void OnMoveField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreDropEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreMoveEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }


        public virtual void OnPreCreateField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreDropField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreMoveField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }


        public virtual void OnPreModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreStorageChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreStart(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreClear(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnClear(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreReset(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnReset(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreClose(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }
    }
}
