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

    public class Index : System.Attribute {

        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string[] _Fields = {  };
        public  string[] Fields{
            get {return _Fields;}
            set {_Fields=value;}
        }


        private bool _Unique = false;
        public  bool Unique{
            get {return _Unique;}
            set {_Unique=value;}
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
