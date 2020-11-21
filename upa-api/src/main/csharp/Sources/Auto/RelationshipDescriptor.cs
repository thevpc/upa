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
     */
    public interface RelationshipDescriptor {

         int GetHierarchyConfigOrder();

         string GetHierarchyPathSeparator();

         bool IsHierarchy();

         bool IsNullable();

         string GetHierarchyPathField();

         string GetSourceEntity();

         System.Type GetSourceEntityType();

         string GetTargetEntity();

         System.Type GetTargetEntityType();

         Net.TheVpc.Upa.Expressions.Expression GetFilter();

         string GetBaseField();

         string[] GetMappedTo();

         string[] GetSourceFields();

         string GetName();

         Net.TheVpc.Upa.RelationshipType GetRelationshipType();
    }
}
