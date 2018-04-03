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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface RelationshipRole : Net.Vpc.Upa.UPAObject {

         Net.Vpc.Upa.Relationship GetRelationship();

         Net.Vpc.Upa.RelationshipUpdateType GetRelationshipUpdateType();

         Net.Vpc.Upa.RelationshipRoleType GetRelationshipRoleType();

         Net.Vpc.Upa.Entity GetEntity();

         void SetEntity(Net.Vpc.Upa.Entity entity);

         int IndexOf(string fieldName);

         Net.Vpc.Upa.Field GetField(int i);

         Net.Vpc.Upa.Field GetEntityField();

         System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetFields();

         void SetFields(Net.Vpc.Upa.Field[] fields);

         void SetEntityField(Net.Vpc.Upa.Field field);

         void SetRelationship(Net.Vpc.Upa.Relationship relation);

         void SetRelationshipRoleType(Net.Vpc.Upa.RelationshipRoleType relationRoteType);

         void SetRelationshipUpdateType(Net.Vpc.Upa.RelationshipUpdateType relationUpdateType);
    }
}
