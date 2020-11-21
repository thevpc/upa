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
     * @creationdate 8/28/12 8:37 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class FilterEntity : System.Attribute {

        private System.Type _Extension = typeof(Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition);
        public  System.Type Extension{
            get {return _Extension;}
            set {_Extension=value;}
        }


        private string _Entity = "";
        public  string Entity{
            get {return _Entity;}
            set {_Entity=value;}
        }


        private string _Query = "";
        public  string Query{
            get {return _Query;}
            set {_Query=value;}
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
