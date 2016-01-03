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



namespace Net.Vpc.Upa.Config
{


    /**
     * corresponds to the JPA @Id
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 10:17 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class Id : System.Attribute {

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
