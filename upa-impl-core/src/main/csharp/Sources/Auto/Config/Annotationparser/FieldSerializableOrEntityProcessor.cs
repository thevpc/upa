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



namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldSerializableOrEntityProcessor : Net.TheVpc.Upa.Callbacks.DefinitionListenerAdapter, Net.TheVpc.Upa.Callbacks.EntityDefinitionListener, Net.TheVpc.Upa.Callbacks.PersistenceUnitListener {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Field field;

        private System.Type relationshipTargetEntityType;

        public FieldSerializableOrEntityProcessor(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Field field) {
            this.persistenceUnit = persistenceUnit;
            this.field = field;
        }

        public virtual void Process() {
            Net.TheVpc.Upa.Types.DataType dataType = field.GetDataType();
            if (dataType is Net.TheVpc.Upa.Impl.SerializableOrManyToOneType) {
                Net.TheVpc.Upa.Impl.SerializableOrManyToOneType master = (Net.TheVpc.Upa.Impl.SerializableOrManyToOneType) dataType;
                relationshipTargetEntityType = master.GetEntityType();
                if (persistenceUnit.ContainsEntity(relationshipTargetEntityType)) {
                    Net.TheVpc.Upa.Entity tt = persistenceUnit.GetEntity(relationshipTargetEntityType);
                    BindRelation(tt);
                } else {
                    persistenceUnit.AddDefinitionListener(relationshipTargetEntityType, this, true);
                    persistenceUnit.AddPersistenceUnitListener(this);
                }
            }
        }


        public virtual void OnModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.Types.DataType dataType = field.GetDataType();
            if (dataType is Net.TheVpc.Upa.Impl.SerializableOrManyToOneType) {
                Net.TheVpc.Upa.Impl.SerializableOrManyToOneType masterDatatype = (Net.TheVpc.Upa.Impl.SerializableOrManyToOneType) dataType;
                System.Type tt = masterDatatype.GetEntityType();
                if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsSerializable(tt)) {
                    field.SetDataType(new Net.TheVpc.Upa.Types.SerializableType(masterDatatype.GetName(), tt, masterDatatype.IsNullable()));
                    field.SetTypeTransform(null);
                } else {
                    throw new System.ArgumentException ("Type " + tt + " is neither Entity nor Serializable for " + field);
                }
            }
        }


        public override void OnCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
            BindRelation(@event.GetEntity());
        }

        private void BindRelation(Net.TheVpc.Upa.Entity masterEntity) {
            Net.TheVpc.Upa.Types.DataType dataType = field.GetDataType();
            if (dataType is Net.TheVpc.Upa.Impl.SerializableOrManyToOneType) {
                field.SetDataType(new Net.TheVpc.Upa.Types.ManyToOneType(dataType.GetName(), dataType.GetPlatformType(), masterEntity.GetName(), true, dataType.IsNullable()));
                field.SetTypeTransform(null);
                field.SetTypeTransform(new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(field.GetDataType()));
                Net.TheVpc.Upa.DefaultRelationshipDescriptor relationDescriptor = new Net.TheVpc.Upa.DefaultRelationshipDescriptor();
                relationDescriptor.SetBaseField(field.GetName());
                relationDescriptor.SetTargetEntityType(masterEntity.GetEntityType());
                relationDescriptor.SetTargetEntity(masterEntity.GetName());
                relationDescriptor.SetSourceEntityType(field.GetEntity().GetEntityType());
                relationDescriptor.SetSourceEntity(field.GetEntity().GetName());
                field.GetPersistenceUnit().AddRelationship(relationDescriptor);
            }
        }


        public virtual void OnStorageChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnStart(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public override void OnPreDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public override void OnDropEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public override void OnPreMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
        }


        public override void OnMoveEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
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


        public virtual void OnClose(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnPreUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }


        public virtual void OnUpdateFormulas(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
        }
    }
}
