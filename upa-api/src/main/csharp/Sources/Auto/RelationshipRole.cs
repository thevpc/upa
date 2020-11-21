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
    public interface RelationshipRole : Net.TheVpc.Upa.UPAObject {

         Net.TheVpc.Upa.Relationship GetRelationship();

         Net.TheVpc.Upa.RelationshipUpdateType GetRelationshipUpdateType();

         Net.TheVpc.Upa.RelationshipRoleType GetRelationshipRoleType();

         Net.TheVpc.Upa.Entity GetEntity();

         void SetEntity(Net.TheVpc.Upa.Entity entity);

         int IndexOf(string fieldName);

         Net.TheVpc.Upa.Field GetField(int i);

         Net.TheVpc.Upa.Field GetEntityField();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetFields();

         void SetFields(Net.TheVpc.Upa.Field[] fields);

         void SetEntityField(Net.TheVpc.Upa.Field field);

         void SetRelationship(Net.TheVpc.Upa.Relationship relation);

         void SetRelationshipRoleType(Net.TheVpc.Upa.RelationshipRoleType relationRoteType);

         void SetRelationshipUpdateType(Net.TheVpc.Upa.RelationshipUpdateType relationUpdateType);
    }
}
