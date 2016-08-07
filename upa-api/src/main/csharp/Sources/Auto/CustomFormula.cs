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



namespace Net.Vpc.Upa
{


    /**
     * Custom Formula is a general purpose Formula definition
     * @see {@link net.vpc.upa.Formula}
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface CustomFormula : Net.Vpc.Upa.Formula {

        /**
             * return and evaluation of the field's "field" value of the entity identified by "id"
             * @param field field holding the formula
             * @param id entity id
             * @param executionContext executionContext
             * @return formula evaluated value
             */
         object GetValue(Net.Vpc.Upa.Field field, object id, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext);
    }
}
