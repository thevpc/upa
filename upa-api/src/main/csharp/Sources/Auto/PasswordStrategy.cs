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
     * Password Strategy define a simple way
     * to have a hashed field value handled transparently by the framework
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface PasswordStrategy {

        /**
             * generate a hashed string from the given value
             *
             * @param value value to hash
             * @return a hash string
             */
         string Encode(string @value);

        /**
             * @return true if this instance creates always a string of a fixed length
             * regardless of what the input value is
             */
         bool IsFixedSize();

        /**
             * returns max number of characters needed for storing ANY value
             * encode function must be guaranteed to return a string of max length defined by THIS method.
             *
             * @return max number of characters needed for storing ANY value.
             */
         int GetMaxSize();
    }
}
