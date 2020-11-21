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
     * Key is an abstract definition of any identifier on any entity. Keys can be composed.
     * Thus Key is defined as an Array of Objects and should be manipulated as such even though Identifier would be single, non composed value.
     * When Entity defines a single field as Identifier, Key represents an Array of One Single Element.
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface Key {

        /**
             * Update all Key values. <code>value</value> cannot be null and cannot contain null values
             *
             * @param value new values
             */
         void SetValue(object[] @value);

        /**
             * an array of key values. The returned array cannot be null and cannot contain null values
             *
             * @return an array of key values
             */
         object[] GetValue();

        /**
             * Key as single value
             *
             * @return single instance as Object
             * @throws RuntimeException if multi-dimensional key
             */
         object GetObject();

        /**
             * Key as single String value
             *
             * @return single instance as String
             * @throws RuntimeException if multi-dimensional key
             */
         string GetString();

        /**
             * Key as single int value
             *
             * @return single instance as int
             * @throws RuntimeException if multi-dimensional key
             */
         int GetInt();

        /**
             * Key as single long value
             *
             * @return single instance as long
             * @throws RuntimeException if multi-dimensional key
             */
         long GetLong();

        /**
             * Key as single date value
             *
             * @return single instance as date
             * @throws RuntimeException if multi-dimensional key
             */
         Net.TheVpc.Upa.Types.Temporal GetDate();

        /**
             * Key portion at <code>index</code> position as string value
             *
             * @param index position
             * @return Key portion at <code>index</code> position as string value
             * @throws RuntimeException if invalid <code>index</code>
             */
         string GetStringAt(int index);

        /**
             * Key portion at <code>index</code> position as Object value
             *
             * @param index position
             * @return Key portion at <code>index</code> position as Object value
             * @throws RuntimeException if invalid <code>index</code>
             */
         object GetObjectAt(int index);

        /**
             * Key portion at <code>index</code> position as int value
             *
             * @param index position
             * @return Key portion at <code>index</code> position as int value
             * @throws RuntimeException if invalid <code>index</code>
             */
         int GetIntAt(int index);

        /**
             * Key portion at <code>index</code> position as long value
             *
             * @param index position
             * @return Key portion at <code>index</code> position as long value
             * @throws RuntimeException if invalid <code>index</code>
             */
         long GetLongAt(int index);

        /**
             * Key portion at <code>index</code> position as date value
             *
             * @param index position
             * @return Key portion at <code>index</code> position as date value
             * @throws RuntimeException if invalid <code>index</code>
             */
         Net.TheVpc.Upa.Types.Temporal GetDateAt(int index);
    }
}
