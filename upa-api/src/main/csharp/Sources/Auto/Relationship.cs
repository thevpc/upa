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


    public interface Relationship : Net.TheVpc.Upa.UPAObject {

         void CommitModelChanged() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetRelationshipType(Net.TheVpc.Upa.RelationshipType dataType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetDataType(Net.TheVpc.Upa.Types.DataType dataType) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetNullable(bool nullable) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.RelationshipType GetRelationshipType() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int Size() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Types.DataType GetDataType() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldNamesMap(bool absolute) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldNamesMap(bool absolute) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldsMap() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldsMap() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetTargetCondition(Net.TheVpc.Upa.Expressions.Expression sourceCondition, string sourceAlias, string targetAlias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetSourceCondition(Net.TheVpc.Upa.Expressions.Expression targetCondition, string sourceAlias, string targetAlias) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Expressions.Expression GetFilter() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetFilter(Net.TheVpc.Upa.Expressions.Expression filter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsTransient() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity GetTargetEntity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Entity GetSourceEntity() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.RelationshipRole GetTargetRole() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.RelationshipRole GetSourceRole() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsFollowLinks();

         bool IsAskForConfirm();

         Net.TheVpc.Upa.Key ExtractKey(Net.TheVpc.Upa.Document sourceDocument);

         object ExtractId(Net.TheVpc.Upa.Document sourceDocument);

         object ExtractIdByEntityField(Net.TheVpc.Upa.Document sourceDocument);

         object ExtractIdByForeignFields(Net.TheVpc.Upa.Document sourceDocument);

         Net.TheVpc.Upa.Extensions.HierarchyExtension GetHierarchyExtension();

         void SetHierarchyExtension(Net.TheVpc.Upa.Extensions.HierarchyExtension extension);

         Net.TheVpc.Upa.Expressions.Expression CreateTargetListExpression(object currentInstance, string alias);

         Net.TheVpc.Upa.RelationshipInfo GetInfo();
    }
}
