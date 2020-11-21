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
     * CustomMultiFormula is guaranteed to be invoked once per pass even if equal instances are passed to multiple fields,
     * only one instance will be invoked for all fields (for the same pass).
     * The same CustomMultiFormula instance may be invoked multiple times in distinct passes
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface CustomMultiFormula : Net.TheVpc.Upa.Formula {

         void UpdateFormulas(Net.TheVpc.Upa.CustomMultiFormulaContext context);
    }
}
