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

    public interface RemoveTrace {

         void AddTrace(string trace);

         void Add(Net.Vpc.Upa.RelationshipType type, Net.Vpc.Upa.Entity entity, long count);

         Net.Vpc.Upa.DeletionTraceElement[] GetTrace(Net.Vpc.Upa.RelationshipType type);

         Net.Vpc.Upa.DeletionTraceElement[] GetTrace();

        override string ToString();

         long GetRemoveCount();

         long GetRemoveCount(Net.Vpc.Upa.RelationshipType type);
    }
}
