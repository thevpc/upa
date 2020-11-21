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



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 10:23 PM
     */
    public interface EntityDescriptor {

         string GetName();

         string GetShortName();

         System.Type GetIdType();

         System.Type GetEntityType();

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetModifiers();

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetExcludeModifiers();

         string GetPackagePath();

         string GetListOrder();

         string GetArchivingOrder();

         int GetPosition();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> GetEntityExtensions();

         object GetSource();

         System.Collections.Generic.IList<Net.TheVpc.Upa.FieldDescriptor> GetFieldDescriptors();

         System.Collections.Generic.IList<Net.TheVpc.Upa.IndexDescriptor> GetIndexDescriptors();

         System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipDescriptor> GetRelationshipDescriptors();

         System.Collections.Generic.IDictionary<string , object> GetProperties();
    }
}
