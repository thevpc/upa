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



namespace Net.Vpc.Upa.Persistence
{


    public interface EntityExecutionContext : Net.Vpc.Upa.Properties {

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.Vpc.Upa.Persistence.UConnection GetConnection();

         Net.Vpc.Upa.Session GetSession();

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

         Net.Vpc.Upa.Persistence.ContextOperation GetOperation();

        /**
             *
             * @return persist document is getOperation() is ContextOperation.PERSIST
             */
         Net.Vpc.Upa.Document GetUpdateDocument();

        /**
             *
             * @return update query is getOperation() is ContextOperation.UPDATE
             */
         Net.Vpc.Upa.UpdateQuery GetUpdateQuery();

         Net.Vpc.Upa.Entity GetEntity();

         System.Collections.Generic.IDictionary<string , object> GetValues();

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         Net.Vpc.Upa.Persistence.EntityExecutionContext ResetHints();

        /**
             * add or remove (if value is null) hint
             *
             * @param name
             * @param value
             */
         Net.Vpc.Upa.Persistence.EntityExecutionContext SetHint(string name, object @value);

        /**
             * merges hints
             *
             * @param hints
             */
         Net.Vpc.Upa.Persistence.EntityExecutionContext SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         void AddGeneratedValue(string name, Net.Vpc.Upa.Types.DataType type);

         void RemoveGeneratedValue(Net.Vpc.Upa.Persistence.Parameter parameter);

         System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> GetGeneratedValues();

         Net.Vpc.Upa.Persistence.Parameter GetGeneratedValue(string name);
    }
}
