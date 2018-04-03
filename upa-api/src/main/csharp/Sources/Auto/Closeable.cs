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
     * Instances implementing this interface should have their "close"
     * method called to cleanup any in use resources (memory, streams,...)
     * Equivalent to Java's standard Closeable interface. Defined for portability reasons
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface Closeable {

        /**
             * Called to close (perform all cleanup code)
             * @throws Exception whenever an error is encountered while closing
             */
         void Close();
    }
}
