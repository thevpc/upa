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

         Net.Vpc.Upa.Expressions.Expression GetFilter();

         string GetBaseField();

         string[] GetMappedTo();

         string[] GetSourceFields();

         string GetName();

         Net.Vpc.Upa.RelationshipType GetRelationshipType();
    }
}
