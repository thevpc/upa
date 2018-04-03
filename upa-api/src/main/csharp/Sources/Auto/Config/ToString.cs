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
     * This annotation defines a StringEncoder class name on the given field
     * This enables mapping any type to a String
     * In the following example, the field description is stored as a json String (varchar)
     * <pre>
     *     @Entity
     *     public class MyEntity{
     *         @ToString(StringEncoderType.JSON)
     *         String description;
     *     }
     * </pre>
     * The Encoder can either be defined as StringEncoderType (using value() )
     * or as Class Name (using custom()). If both are defined, StringEncoder class name
     * is used. If none are defined
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class ToString : System.Attribute {

        /**
             * Pre-defined StringEncoderType. When StringEncoderType.CUSTOM
             * custom() must be defined
             * @return StringEncoderType
             */
        private Net.Vpc.Upa.Config.StringEncoderType _Value = Net.Vpc.Upa.Config.StringEncoderType.DEFAULT;
        public  Net.Vpc.Upa.Config.StringEncoderType Value{
            get {return _Value;}
            set {_Value=value;}
        }


        /**
             * StringEncoder class name.
             * This value must be filled if  value() == StringEncoderType.CUSTOM
             * This value could be filled if value() == StringEncoderType.DEFAULT
             * @return StringEncoder class name
             */
        private string _Custom = "";
        public  string Custom{
            get {return _Custom;}
            set {_Custom=value;}
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
