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


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 1:24 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface PersistenceStore {

         void SetProperties(Net.Vpc.Upa.Properties parameters);

         bool IsAccessible(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile);

         string GetValidIdentifier(string s);

         void CheckAccessible(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile);

         System.Collections.Generic.ISet<string> GetSupportedDrivers();

         bool IsCreatedStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.FieldPersister CreatePersistSequenceGenerator(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.FieldPersister CreateUpdateSequenceGenerator(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CreateStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void DropStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Properties GetProperties();

         Net.Vpc.Upa.Properties GetStoreParameters();

         Net.Vpc.Upa.Persistence.ConnectionProfile GetConnectionProfile() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetReadOnly(bool @value);

         bool IsReadOnly();

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CreateStructure(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsReservedKeyword(string name);

         void SetNativeConstraintsEnabled(bool enable) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsComplexSelectSupported();

         bool IsFromClauseInUpdateStatementSupported();

         bool IsFromClauseInDeleteStatementSupported();

         bool IsReferencingSupported();

         bool IsViewSupported();

         bool IsTopSupported();

         Net.Vpc.Upa.Persistence.PersistenceNameStrategy GetPersistenceNameStrategy();

         void SetPersistenceNameStrategy(Net.Vpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy);

         string GetPersistenceName(Net.Vpc.Upa.UPAObject persistentObject) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetPersistenceName(Net.Vpc.Upa.UPAObject persistentObject, Net.Vpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetPersistenceName(string name, Net.Vpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceState GetPersistenceState(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsView(Net.Vpc.Upa.Entity entity);

         void AlterPersistenceUnitAddObject(Net.Vpc.Upa.UPAObject @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AlterPersistenceUnitRemoveObject(Net.Vpc.Upa.UPAObject @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AlterPersistenceUnitUpdateObject(Net.Vpc.Upa.UPAObject oldObject, Net.Vpc.Upa.UPAObject newObject, System.Collections.Generic.ISet<string> updates) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool CommitStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RevalidateModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * create connection
             *
             * @return
             * @throws UPAException
             */
         Net.Vpc.Upa.Persistence.UConnection CreateConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetIdentityConstraintsEnabled(Net.Vpc.Upa.Entity entity, bool enable, Net.Vpc.Upa.Persistence.EntityExecutionContext context);
    }
}
