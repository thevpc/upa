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
     * Listener for closable objects
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/23/12 12:15 PM
     */
    public interface CloseListener {

        /**
             * called before source is being closed
             * @param source object to be closed
             */
         void BeforeClose(object source);

        /**
             * called after the source has been closed
             * @param source object closed
             */
         void AfterClose(object source);
    }
}
