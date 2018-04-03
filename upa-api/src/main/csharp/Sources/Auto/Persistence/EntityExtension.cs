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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 8:28 PM
     */
    public interface EntityExtension {

         Net.Vpc.Upa.Extensions.EntityExtensionDefinition GetDefinition();

         void Install(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.Vpc.Upa.Extensions.EntityExtensionDefinition definition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
