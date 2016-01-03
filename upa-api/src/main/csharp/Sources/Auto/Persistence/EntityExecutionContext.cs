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



namespace Net.Vpc.Upa.Persistence
{


    public interface EntityExecutionContext : Net.Vpc.Upa.Properties {

         void InitPersistenceUnit(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore, Net.Vpc.Upa.Persistence.ContextOperation contextOperation);

         Net.Vpc.Upa.Persistence.ContextOperation GetOperation();

         Net.Vpc.Upa.Entity GetEntity();

         System.Collections.Generic.IDictionary<string , object> GetValues();

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

         Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         void InitEntity(Net.Vpc.Upa.Entity currentEntity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager);

         void AddGeneratedValue(string name, Net.Vpc.Upa.Types.DataType type);

         void RemoveGeneratedValue(Net.Vpc.Upa.Persistence.Parameter parameter);

         System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> GetGeneratedValues();

         Net.Vpc.Upa.Persistence.Parameter GetGeneratedValue(string name);
    }
}
