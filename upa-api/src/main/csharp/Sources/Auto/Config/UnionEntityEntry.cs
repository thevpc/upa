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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/31/12 12:24 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class UnionEntityEntry : System.Attribute {

        private string _Entity;
        public  string Entity{
            get {return _Entity;}
            set {_Entity=value;}
        }


        private string[] _Fields;
        public  string[] Fields{
            get {return _Fields;}
            set {_Fields=value;}
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
