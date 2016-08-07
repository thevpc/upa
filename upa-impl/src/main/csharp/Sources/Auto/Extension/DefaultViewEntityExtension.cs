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
    public class DefaultViewEntityExtension : Net.Vpc.Upa.Impl.Extension.AbstractEntityExtension, Net.Vpc.Upa.Persistence.ViewEntityExtension {

        private Net.Vpc.Upa.Expressions.QueryStatement viewQuery;


        public override void Install(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            base.Install(entity, entityOperationManager, extension);
        }


        public override void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition entitySpec = (Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition) GetDefinition();
            viewQuery = entitySpec.GetQuery(entity);
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers = entity.GetUserModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> excluded = entity.GetUserExcludeModifiers();
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> effectiveModifiers = entity.GetModifiers();
            if (!excluded.Contains(Net.Vpc.Upa.EntityModifier.TRANSIENT)) {
                effectiveModifiers = effectiveModifiers.Add(Net.Vpc.Upa.EntityModifier.TRANSIENT);
            }
            if (!modifiers.Contains(Net.Vpc.Upa.EntityModifier.USER_ID)) {
                effectiveModifiers = effectiveModifiers.Remove(Net.Vpc.Upa.EntityModifier.USER_ID);
            }
            //        if(!modifiers.contains(EntityModifier.GENERATED_ID)){
            //            effectiveModifiers=effectiveModifiers.remove(EntityModifier.GENERATED_ID);
            //        }
            ((Net.Vpc.Upa.Impl.DefaultEntity) entity).SetModifiers(effectiveModifiers);
        }


        public virtual Net.Vpc.Upa.Expressions.QueryStatement GetQuery() {
            return viewQuery;
        }
    }
}
