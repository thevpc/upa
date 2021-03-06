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
     * Temporal annotation defines how the 'Date' type is handled in store system.
     * By default, date type is mapped accordingly to the most appropriate.
     * For instance java.sal.Date  is mapped to DATE but Timestamp is mapped to TIMESTAMP
     * This annotation makes it possible to get a custom handling
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/21/12 10:28 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class Temporal : System.Attribute {

        /**
             * Defines the Temporal mapping strategy
             * @return TemporalOption
             */
        private Net.TheVpc.Upa.Types.TemporalOption _Value = Net.TheVpc.Upa.Types.TemporalOption.DEFAULT;
        public  Net.TheVpc.Upa.Types.TemporalOption Value{
            get {return _Value;}
            set {_Value=value;}
        }


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
