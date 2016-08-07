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

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         Net.Vpc.Upa.Persistence.EntityExecutionContext ResetHints();

        /**
             * add or remove (if value is null) hint
             * @param name
             * @param value
             */
         Net.Vpc.Upa.Persistence.EntityExecutionContext SetHint(string name, object @value);

        /**
             * merges hints
             * @param hints
             */
         Net.Vpc.Upa.Persistence.EntityExecutionContext SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.Vpc.Upa.Persistence.UConnection GetConnection();

         Net.Vpc.Upa.Session GetSession();

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

         Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         void InitEntity(Net.Vpc.Upa.Entity currentEntity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager);

         void AddGeneratedValue(string name, Net.Vpc.Upa.Types.DataType type);

         void RemoveGeneratedValue(Net.Vpc.Upa.Persistence.Parameter parameter);

         System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> GetGeneratedValues();

         Net.Vpc.Upa.Persistence.Parameter GetGeneratedValue(string name);
    }
}
