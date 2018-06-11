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


    /**
     * return and evaluation of the field's "field" value of the entity identified by "id"
     *
     * @param field            field holding the formula
     * @param id               entity id
     * @param executionContext executionContext
     * @return formula evaluated value
     */
    public interface BaseFormulaContext {

         Net.Vpc.Upa.Entity GetEntity();

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit();

         Net.Vpc.Upa.Persistence.UConnection GetConnection();

         Net.Vpc.Upa.Session GetSession();

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore();

         bool IsPersist();

         bool IsUpdate();

        /**
             * @return persist document is getOperation() is ContextOperation.PERSIST
             */
         Net.Vpc.Upa.Document GetUpdateDocument();

        /**
             * @return update query is getOperation() is ContextOperation.UPDATE
             */
         Net.Vpc.Upa.UpdateQuery GetUpdateQuery();

         Net.Vpc.Upa.Persistence.EntityExecutionContext GetExecutionContext();
    }
}
