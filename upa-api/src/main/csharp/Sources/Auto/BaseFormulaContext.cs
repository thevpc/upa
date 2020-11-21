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
     * return and evaluation of the field's "field" value of the entity identified by "id"
     *
     * @param field            field holding the formula
     * @param id               entity id
     * @param executionContext executionContext
     * @return formula evaluated value
     */
    public interface BaseFormulaContext {

         Net.TheVpc.Upa.Entity GetEntity();

         Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.TheVpc.Upa.Persistence.UConnection GetConnection();

         Net.TheVpc.Upa.Session GetSession();

         Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

         bool IsPersist();

         bool IsUpdate();

        /**
             * @return persist document is getOperation() is ContextOperation.PERSIST
             */
         Net.TheVpc.Upa.Document GetUpdateDocument();

        /**
             * @return update query is getOperation() is ContextOperation.UPDATE
             */
         Net.TheVpc.Upa.UpdateQuery GetUpdateQuery();

         Net.TheVpc.Upa.Persistence.EntityExecutionContext GetExecutionContext();
    }
}
