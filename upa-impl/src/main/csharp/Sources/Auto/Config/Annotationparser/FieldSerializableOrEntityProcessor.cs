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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldSerializableOrEntityProcessor : Net.Vpc.Upa.Callbacks.DefinitionListenerAdapter, Net.Vpc.Upa.Callbacks.EntityDefinitionListener, Net.Vpc.Upa.Callbacks.PersistenceUnitListener {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Field field;

        private System.Type relationshipTargetEntityType;

        public FieldSerializableOrEntityProcessor(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Field field) {
            this.persistenceUnit = persistenceUnit;
            this.field = field;
        }

        public virtual void Process() {
            Net.Vpc.Upa.Types.DataType dataType = field.GetDataType();
            if (dataType is Net.Vpc.Upa.Impl.SerializableOrManyToOneType) {
                Net.Vpc.Upa.Impl.SerializableOrManyToOneType master = (Net.Vpc.Upa.Impl.SerializableOrManyToOneType) dataType;
                relationshipTargetEntityType = master.GetEntityType();
                if (persistenceUnit.ContainsEntity(relationshipTargetEntityType)) {
                    Net.Vpc.Upa.Entity tt = persistenceUnit.GetEntity(relationshipTargetEntityType);
                    BindRelation(tt);
                } else {
                    persistenceUnit.AddDefinitionListener(relationshipTargetEntityType, this, true);
                    persistenceUnit.AddPersistenceUnitListener(this);
                }
            }
        }


        public virtual void OnModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.Vpc.Upa.Types.DataType dataType = field.GetDataType();
            if (dataType is Net.Vpc.Upa.Impl.SerializableOrManyToOneType) {
                Net.Vpc.Upa.Impl.SerializableOrManyToOneType masterDatatype = (Net.Vpc.Upa.Impl.SerializableOrManyToOneType) dataType;
                System.Type tt = masterDatatype.GetEntityType();
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsSerializable(tt)) {
                    field.SetDataType(new Net.Vpc.Upa.Types.SerializableType(masterDatatype.GetName(), tt, masterDatatype.IsNullable()));
                    field.SetTypeTransform(null);
                } else {
                    throw new System.ArgumentException ("Type " + tt + " is neither Entity nor Serializable for " + field);
                }
            }
        }


        public override void OnCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
            BindRelation(@event.GetEntity());
        }

        private void BindRelation(Net.Vpc.Upa.Entity masterEntity) {
            Net.Vpc.Upa.Types.DataType dataType = field.GetDataType();
            if (dataType is Net.Vpc.Upa.Impl.SerializableOrManyToOneType) {
                field.SetDataType(new Net.Vpc.Upa.Types.ManyToOneType(dataType.GetName(), dataType.GetPlatformType(), masterEntity.GetName(), true, dataType.IsNullable()));
                field.SetTypeTransform(null);
                field.SetTypeTransform(new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(field.GetDataType()));
                Net.Vpc.Upa.DefaultRelationshipDescriptor relationDescriptor = new Net.Vpc.Upa.DefaultRelationshipDescriptor();
                relationDescriptor.SetBaseField(field.GetName());
                relationDescriptor.SetTargetEntityType(masterEntity.GetEntityType());
                relationDescriptor.SetTargetEntity(masterEntity.GetName());
                relationDescriptor.SetSourceEntityType(field.GetEntity().GetEntityType());
                relationDescriptor.SetSourceEntity(field.GetEntity().GetName());
                field.GetPersistenceUnit().AddRelationship(relationDescriptor);
            }
        }


        public virtual void OnStorageChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnStart(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public override void OnPreDropEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }


        public override void OnDropEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }


        public override void OnPreMoveEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
        }


        public override void OnMoveEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
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


        public virtual void OnClose(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreUpdateFormulas(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnUpdateFormulas(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }
    }
}
