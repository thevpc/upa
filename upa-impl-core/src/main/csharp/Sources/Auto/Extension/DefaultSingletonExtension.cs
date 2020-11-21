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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 12:39 AM
     */
    public class DefaultSingletonExtension : Net.TheVpc.Upa.Impl.Extension.AbstractEntityExtension, Net.TheVpc.Upa.Persistence.SingletonExtension {


        public override void Install(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            base.Install(entity, entityOperationManager, extension);
        }


        public override void CommitModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = GetEntity();
            if ((entity.GetPrimaryFields().Count==0)) {
                Net.TheVpc.Upa.Field field = entity.AddField("SGLcode", null, Net.TheVpc.Upa.FlagSets.Of<E>(Net.TheVpc.Upa.UserFieldModifier.ID), null, 0, new Net.TheVpc.Upa.Types.IntType(0, 0, false, false), -1);
                field.SetAccessLevel(Net.TheVpc.Upa.AccessLevel.PRIVATE);
                field.SetPersistFormula(new Net.TheVpc.Upa.Sequence(Net.TheVpc.Upa.SequenceStrategy.AUTO));
            }
            if (!entity.GetUserExcludeModifiers().Contains(Net.TheVpc.Upa.EntityModifier.NAVIGATE)) {
                entity.GetModifiers().Add(Net.TheVpc.Upa.EntityModifier.NAVIGATE);
            }
        }


        public virtual bool IsAutoCreate() {
            Net.TheVpc.Upa.Extensions.SingletonExtensionDefinition entitySpec = (Net.TheVpc.Upa.Extensions.SingletonExtensionDefinition) GetDefinition();
            return entitySpec.IsAutoCreate();
        }
    }
}
