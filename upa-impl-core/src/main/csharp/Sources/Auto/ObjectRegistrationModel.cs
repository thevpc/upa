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



namespace Net.Vpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ObjectRegistrationModel {

         bool ContainsPackage(Net.Vpc.Upa.Package item, Net.Vpc.Upa.Package parent) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(Net.Vpc.Upa.Entity item, Net.Vpc.Upa.Package parent) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsField(Net.Vpc.Upa.Field item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsIndex(Net.Vpc.Upa.Index item, Net.Vpc.Upa.Entity parent) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsRelationship(Net.Vpc.Upa.Relationship item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsSection(Net.Vpc.Upa.Section item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RegisterPackage(Net.Vpc.Upa.Package item, Net.Vpc.Upa.Package parent) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RegisterEntity(Net.Vpc.Upa.Entity item, Net.Vpc.Upa.Package parent) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RegisterSection(Net.Vpc.Upa.Section item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RegisterField(Net.Vpc.Upa.Field item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RegisterIndex(Net.Vpc.Upa.Index item, Net.Vpc.Upa.Entity parent) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RegisterRelationship(Net.Vpc.Upa.Relationship item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnregisterPackage(Net.Vpc.Upa.Package item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnregisterEntity(Net.Vpc.Upa.Entity item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnregisterSection(Net.Vpc.Upa.Section item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnregisterField(Net.Vpc.Upa.Field item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnregisterIndex(Net.Vpc.Upa.Index item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void UnregisterRelation(Net.Vpc.Upa.Relationship item) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Index GetIndex(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetEntity(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Relationship GetRelationship(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Relationship FindRelationship(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity FindEntity(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity FindEntity(System.Type name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> FindEntities(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Entity> GetEntities() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Package> GetPackages() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetEntityByIdType(System.Type idType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(System.Type entityType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Index> GetIndexes(string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
