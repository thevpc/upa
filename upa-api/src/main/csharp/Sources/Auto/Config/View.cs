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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 8:28 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class View : System.Attribute {

        private string _Query = "";
        public  string Query{
            get {return _Query;}
            set {_Query=value;}
        }


        private System.Type _Spec = typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition);
        public  System.Type Spec{
            get {return _Spec;}
            set {_Spec=value;}
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
