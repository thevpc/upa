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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 12:39 AM
     */
    public class DefaultSingletonExtension : Net.Vpc.Upa.Impl.Extension.AbstractEntityExtension, Net.Vpc.Upa.Persistence.SingletonExtension {


        public override void Install(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            base.Install(entity, entityOperationManager, extension);
        }


        public override void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            if ((entity.GetPrimaryFields().Count==0)) {
                Net.Vpc.Upa.Field field = entity.AddField("SGLcode", null, Net.Vpc.Upa.FlagSets.Of<Net.Vpc.Upa.UserFieldModifier>(Net.Vpc.Upa.UserFieldModifier.ID), null, 0, new Net.Vpc.Upa.Types.IntType(0, 0, false, false), -1);
                field.SetAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE);
                field.SetInsertFormula(new Net.Vpc.Upa.Sequence(Net.Vpc.Upa.SequenceStrategy.AUTO));
            }
            if (!entity.GetUserExcludeModifiers().Contains(Net.Vpc.Upa.EntityModifier.NAVIGATE)) {
                entity.GetModifiers().Add(Net.Vpc.Upa.EntityModifier.NAVIGATE);
            }
        }


        public virtual bool IsAutoCreate() {
            Net.Vpc.Upa.Extensions.SingletonExtensionDefinition entitySpec = (Net.Vpc.Upa.Extensions.SingletonExtensionDefinition) GetDefinition();
            return entitySpec.IsAutoCreate();
        }
    }
}
