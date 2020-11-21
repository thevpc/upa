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



namespace Net.TheVpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ObjectRegistrationModel {

         bool ContainsPackage(Net.TheVpc.Upa.Package item, Net.TheVpc.Upa.Package parent) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(Net.TheVpc.Upa.Entity item, Net.TheVpc.Upa.Package parent) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsField(Net.TheVpc.Upa.Field item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsIndex(Net.TheVpc.Upa.Index item, Net.TheVpc.Upa.Entity parent) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsRelationship(Net.TheVpc.Upa.Relationship item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsSection(Net.TheVpc.Upa.Section item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RegisterPackage(Net.TheVpc.Upa.Package item, Net.TheVpc.Upa.Package parent) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RegisterEntity(Net.TheVpc.Upa.Entity item, Net.TheVpc.Upa.Package parent) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RegisterSection(Net.TheVpc.Upa.Section item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RegisterField(Net.TheVpc.Upa.Field item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RegisterIndex(Net.TheVpc.Upa.Index item, Net.TheVpc.Upa.Entity parent) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RegisterRelationship(Net.TheVpc.Upa.Relationship item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void UnregisterPackage(Net.TheVpc.Upa.Package item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void UnregisterEntity(Net.TheVpc.Upa.Entity item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void UnregisterSection(Net.TheVpc.Upa.Section item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void UnregisterField(Net.TheVpc.Upa.Field item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void UnregisterIndex(Net.TheVpc.Upa.Index item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void UnregisterRelation(Net.TheVpc.Upa.Relationship item) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Index GetIndex(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity GetEntity(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Relationship GetRelationship(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Relationship FindRelationship(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity FindEntity(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity FindEntity(System.Type name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> FindEntities(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> GetEntities() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Package> GetPackages() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetRelationships() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity GetEntity(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity GetEntityByIdType(System.Type idType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(string entityName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsEntity(System.Type entityType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Index> GetIndexes(string entityName) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
