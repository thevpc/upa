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



namespace Net.TheVpc.Upa.Config
{


    /**
     * Disables automatic (scan time) registry of components
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/4/12 11:00 PM
     */

    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Field|System.AttributeTargets.Method)]
    public class Ignore : System.Attribute {

        /**
             * annotation config defines how this annotation must be handled
             *
             * @return annotation configuration
             */
        private Net.TheVpc.Upa.Config.ItemConfig _Config = new Net.TheVpc.Upa.Config.ItemConfig();
        public  Net.TheVpc.Upa.Config.ItemConfig Config{
            get {return _Config;}
            set {_Config=value;}
        }

    }
}
