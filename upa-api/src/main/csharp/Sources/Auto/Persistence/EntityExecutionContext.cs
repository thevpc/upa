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



namespace Net.TheVpc.Upa.Persistence
{


    public interface EntityExecutionContext : Net.TheVpc.Upa.Properties {

         Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.TheVpc.Upa.Persistence.UConnection GetConnection();

         Net.TheVpc.Upa.Session GetSession();

         Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

         Net.TheVpc.Upa.Persistence.ContextOperation GetOperation();

        /**
             *
             * @return persist document is getOperation() is ContextOperation.PERSIST
             */
         Net.TheVpc.Upa.Document GetUpdateDocument();

        /**
             *
             * @return update query is getOperation() is ContextOperation.UPDATE
             */
         Net.TheVpc.Upa.UpdateQuery GetUpdateQuery();

         Net.TheVpc.Upa.Entity GetEntity();

         System.Collections.Generic.IDictionary<string , object> GetValues();

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         Net.TheVpc.Upa.Persistence.EntityExecutionContext ResetHints();

        /**
             * add or remove (if value is null) hint
             *
             * @param name
             * @param value
             */
         Net.TheVpc.Upa.Persistence.EntityExecutionContext SetHint(string name, object @value);

        /**
             * merges hints
             *
             * @param hints
             */
         Net.TheVpc.Upa.Persistence.EntityExecutionContext SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         Net.TheVpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager();

         void AddGeneratedValue(string name, Net.TheVpc.Upa.Types.DataType type);

         void RemoveGeneratedValue(Net.TheVpc.Upa.Persistence.Parameter parameter);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> GetGeneratedValues();

         Net.TheVpc.Upa.Persistence.Parameter GetGeneratedValue(string name);
    }
}
