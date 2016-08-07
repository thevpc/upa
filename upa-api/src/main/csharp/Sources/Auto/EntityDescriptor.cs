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



namespace Net.Vpc.Upa
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

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetModifiers();

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetExcludeModifiers();

         string GetPackagePath();

         string GetListOrder();

         string GetArchivingOrder();

         int GetPosition();

         System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> GetEntityExtensions();

         object GetSource();

         System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> GetFieldDescriptors();

         System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> GetIndexDescriptors();

         System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> GetRelationshipDescriptors();

         System.Collections.Generic.IDictionary<string , object> GetProperties();
    }
}
