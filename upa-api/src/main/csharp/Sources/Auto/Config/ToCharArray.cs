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



namespace Net.Vpc.Upa.Config
{


    /**
     * This annotation defines a CharArrayEncoder class name on the given field
     * This enables mapping any type to a char[]
     *
     * In the following example, the field description is stored as char array
     * <pre>
     *     @Entity
     *     public class MyEntity{
     *         @ToCharArray
     *         String description;
     *     }
     * </pre>
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class ToCharArray : System.Attribute {

        /**
             * CharArrayEncoder class name
             * @return ByteArrayEncoder class name
             */
        private string _Value = "";
        public  string Value{
            get {return _Value;}
            set {_Value=value;}
        }


        /**
             * annotation config defines how this annotation must be handled
             *
             * @return annotation configuration
             */
        private Net.Vpc.Upa.Config.ItemConfig _Config = new Net.Vpc.Upa.Config.ItemConfig();
        public  Net.Vpc.Upa.Config.ItemConfig Config{
            get {return _Config;}
            set {_Config=value;}
        }

    }
}
