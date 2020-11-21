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


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 1:24 AM To change
     * this template use File | Settings | File Templates.
     */
    public interface PersistenceStore {

         void SetProperties(Net.TheVpc.Upa.Properties parameters);

         bool IsAccessible(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile);

         string GetValidIdentifier(string s);

         void CheckAccessible(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile);

         System.Collections.Generic.ISet<string> GetSupportedDrivers();

         bool IsCreatedStorage() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Persistence.FieldPersister CreatePersistSequenceGenerator(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Persistence.FieldPersister CreateUpdateSequenceGenerator(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CreateStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void DropStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Properties GetProperties();

         Net.TheVpc.Upa.Properties GetStoreParameters();

         Net.TheVpc.Upa.Persistence.ConnectionProfile GetConnectionProfile() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetReadOnly(bool @value);

         bool IsReadOnly();

         Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity e, Net.TheVpc.Upa.Expressions.EntityStatement query, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Expressions.EntityStatement query, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CreateStructure(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsReservedKeyword(string name);

         void SetNativeConstraintsEnabled(bool enable) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsComplexSelectSupported();

         bool IsFromClauseInUpdateStatementSupported();

         bool IsFromClauseInDeleteStatementSupported();

         bool IsReferencingSupported();

         bool IsViewSupported();

         bool IsTopSupported();

         Net.TheVpc.Upa.Persistence.PersistenceNameStrategy GetPersistenceNameStrategy();

         void SetPersistenceNameStrategy(Net.TheVpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy);

         string GetPersistenceName(Net.TheVpc.Upa.UPAObject persistentObject) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         string GetPersistenceName(Net.TheVpc.Upa.UPAObject persistentObject, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         string GetPersistenceName(string name, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.PersistenceState GetPersistenceState(Net.TheVpc.Upa.UPAObject @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsView(Net.TheVpc.Upa.Entity entity);

         void AlterPersistenceUnitAddObject(Net.TheVpc.Upa.UPAObject @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AlterPersistenceUnitRemoveObject(Net.TheVpc.Upa.UPAObject @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AlterPersistenceUnitUpdateObject(Net.TheVpc.Upa.UPAObject oldObject, Net.TheVpc.Upa.UPAObject newObject, System.Collections.Generic.ISet<string> updates) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool CommitStorage() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RevalidateModel() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * create connection
             *
             * @return
             * @throws UPAException
             */
         Net.TheVpc.Upa.Persistence.UConnection CreateConnection() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetIdentityConstraintsEnabled(Net.TheVpc.Upa.Entity entity, bool enable, Net.TheVpc.Upa.Persistence.EntityExecutionContext context);
    }
}
