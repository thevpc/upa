/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 8:28 PM
     */
    public interface EntityExtension {

         Net.TheVpc.Upa.Extensions.EntityExtensionDefinition GetDefinition();

         void Install(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition definition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CommitModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
