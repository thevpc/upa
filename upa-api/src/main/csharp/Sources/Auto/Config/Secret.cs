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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class Secret : System.Attribute {

        /**
             * cypher method
             *
             * @return
             */
        private string _Algorithm = "";
        public  string Algorithm{
            get {return _Algorithm;}
            set {_Algorithm=value;}
        }


        private string _Key = "";
        public  string Key{
            get {return _Key;}
            set {_Key=value;}
        }


        private string _ReverseKey = "";
        public  string ReverseKey{
            get {return _ReverseKey;}
            set {_ReverseKey=value;}
        }


        private int _Max = 255;
        public  int Max{
            get {return _Max;}
            set {_Max=value;}
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
