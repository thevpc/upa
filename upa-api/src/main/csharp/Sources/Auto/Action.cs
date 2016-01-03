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
     *
     * @author vpc
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
