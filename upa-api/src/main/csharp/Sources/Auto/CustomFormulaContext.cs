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
     * @param field field holding the formula
     * @param id entity id
     * @param executionContext executionContext
     * @return formula evaluated value
     */
    public interface CustomFormulaContext : Net.Vpc.Upa.BaseFormulaContext {

         Net.Vpc.Upa.Field GetField();

         object GetObjectId();
    }
}
