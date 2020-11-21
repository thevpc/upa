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



namespace Net.TheVpc.Upa.Extensions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 8:28 PM
     */
    public interface HierarchyExtension : Net.TheVpc.Upa.Extensions.RelationshipExtensionDefinition {

         void SetHierarchyPathSeparator(string hierarchySeparator);

         string GetHierarchyPathSeparator();

         string GetHierarchyPathField();

         void SetHierarchyPathField(string hierarchyPathField);

         bool IsParent(object parentId, object childId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsEqualOrIsParent(object parentId, object childId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Relationship GetTreeRelationship() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression CreateFindRootsExpression(string alias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression CreateFindDeepChildrenExpression(string expression, object id, bool includeId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression CreateFindImmediateChildrenExpression(string alias, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression CreateFindEntityByMainPathExpression(string mainFieldPath, string entityAlias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression CreateFindEntityByIdPathExpression(object[] idPath, string entityAlias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression CreateFindEntityByKeyPathExpression(Net.TheVpc.Upa.Key[] keyPath, string entityAlias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object FindEntityByMainPath(string mainFieldPath) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object FindEntityByIdPath(object[] idPath) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object FindEntityByKeyPath(Net.TheVpc.Upa.Key[] keyPath) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> FindRootsEntityList<T>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> FindDeepChildrenEntityList<T>(object id, bool includeId) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> FindImmediateChildrenEntityList<T>(object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
