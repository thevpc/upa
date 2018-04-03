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
     * General Use Methof Filter Interface
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface MethodFilter {

        /**
             * return true if the given method is accepted
             * @param method method to test acceptance
             * @return true if the given method is accepted
             */
         bool Accept(System.Reflection.MethodInfo method);
    }
}
