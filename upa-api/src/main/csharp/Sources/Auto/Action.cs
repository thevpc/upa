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
     *
     * @author taha.bensalah@gmail.com
     */
    public interface Action<T> {

        /**
             * Performs the computation.
             * @return a class-dependent value that may represent the results of the
             *         computation. Each class that implements
             *         {@code PrivilegedAction}
             *         should document what (if anything) this value represents.
             * @see UPAContext#invokePrivileged(Action, InvokeContext)
             */
         T Run();
    }
}
