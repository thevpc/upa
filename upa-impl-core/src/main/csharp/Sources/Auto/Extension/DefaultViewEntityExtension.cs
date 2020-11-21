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
    public class DefaultViewEntityExtension : Net.TheVpc.Upa.Impl.Extension.AbstractEntityExtension, Net.TheVpc.Upa.Persistence.ViewEntityExtension {

        private Net.TheVpc.Upa.Expressions.QueryStatement viewQuery;


        public override void Install(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            base.Install(entity, entityOperationManager, extension);
        }


        public override void CommitModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = GetEntity();
            Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition entitySpec = (Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition) GetDefinition();
            viewQuery = entitySpec.GetQuery(entity);
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers = entity.GetUserModifiers();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> excluded = entity.GetUserExcludeModifiers();
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> effectiveModifiers = entity.GetModifiers();
            if (!excluded.Contains(Net.TheVpc.Upa.EntityModifier.TRANSIENT)) {
                effectiveModifiers = effectiveModifiers.Add(Net.TheVpc.Upa.EntityModifier.TRANSIENT);
            }
            if (!modifiers.Contains(Net.TheVpc.Upa.EntityModifier.USER_ID)) {
                effectiveModifiers = effectiveModifiers.Remove(Net.TheVpc.Upa.EntityModifier.USER_ID);
            }
            //        if(!modifiers.contains(EntityModifier.GENERATED_ID)){
            //            effectiveModifiers=effectiveModifiers.remove(EntityModifier.GENERATED_ID);
            //        }
            ((Net.TheVpc.Upa.Impl.DefaultEntity) entity).SetModifiers(effectiveModifiers);
        }


        public virtual Net.TheVpc.Upa.Expressions.QueryStatement GetQuery() {
            return viewQuery;
        }
    }
}
