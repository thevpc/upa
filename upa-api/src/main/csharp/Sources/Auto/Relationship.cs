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



namespace Net.Vpc.Upa
{


    public interface Relationship : Net.Vpc.Upa.UPAObject {

         void CommitModelChanged() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetRelationshipType(Net.Vpc.Upa.RelationshipType dataType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetDataType(Net.Vpc.Upa.Types.DataType dataType) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetNullable(bool nullable) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RelationshipType GetRelationshipType() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int Size() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Types.DataType GetDataType() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldNamesMap(bool absolute) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldNamesMap(bool absolute) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetSourceToTargetFieldsMap() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , string> GetTargetToSourceFieldsMap() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetTargetCondition(Net.Vpc.Upa.Expressions.Expression sourceCondition, string sourceAlias, string targetAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetSourceCondition(Net.Vpc.Upa.Expressions.Expression targetCondition, string sourceAlias, string targetAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression GetFilter() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetFilter(Net.Vpc.Upa.Expressions.Expression filter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsTransient() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetTargetEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Entity GetSourceEntity() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RelationshipRole GetTargetRole() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.RelationshipRole GetSourceRole() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsFollowLinks();

         bool IsAskForConfirm();

         Net.Vpc.Upa.Key ExtractKey(Net.Vpc.Upa.Document sourceDocument);

         object ExtractId(Net.Vpc.Upa.Document sourceDocument);

         object ExtractIdByEntityField(Net.Vpc.Upa.Document sourceDocument);

         object ExtractIdByForeignFields(Net.Vpc.Upa.Document sourceDocument);

         Net.Vpc.Upa.Extensions.HierarchyExtension GetHierarchyExtension();

         void SetHierarchyExtension(Net.Vpc.Upa.Extensions.HierarchyExtension extension);

         Net.Vpc.Upa.Expressions.Expression CreateTargetListExpression(object currentInstance, string alias);

         Net.Vpc.Upa.RelationshipInfo GetInfo();
    }
}
