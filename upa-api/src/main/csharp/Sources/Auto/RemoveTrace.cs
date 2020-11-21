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

    public interface RemoveTrace {

         void AddTrace(string trace);

         void Add(Net.TheVpc.Upa.RelationshipType type, Net.TheVpc.Upa.Entity entity, long count);

         Net.TheVpc.Upa.DeletionTraceElement[] GetTrace(Net.TheVpc.Upa.RelationshipType type);

         Net.TheVpc.Upa.DeletionTraceElement[] GetTrace();

        override string ToString();

         long GetRemoveCount();

         long GetRemoveCount(Net.TheVpc.Upa.RelationshipType type);
    }
}
