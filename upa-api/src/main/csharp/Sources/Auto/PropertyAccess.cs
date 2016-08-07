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
     * corresponds to the JPA
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @Id
     * @creationdate 8/28/12 10:17 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class PropertyAccess : System.Attribute {

        private Net.Vpc.Upa.PropertyAccessType _Value = Net.Vpc.Upa.PropertyAccessType.PROPERTY;
        public  Net.Vpc.Upa.PropertyAccessType Value{
            get {return _Value;}
            set {_Value=value;}
        }


        /**
             * annotation config defines how this annotation must be handled
             *
             * @return annotation configuration
             */
        private Net.Vpc.Upa.Config.Config _Config = new Net.Vpc.Upa.Config.Config();
        public  Net.Vpc.Upa.Config.Config Config{
            get {return _Config;}
            set {_Config=value;}
        }

    }
}
