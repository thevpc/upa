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
     * function TreeAncestor is made available for tree relations
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 8:28 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class Hierarchy : System.Attribute {

        private string _Separator = "/";
        public  string Separator{
            get {return _Separator;}
            set {_Separator=value;}
        }


        private string _Path = "";
        public  string Path{
            get {return _Path;}
            set {_Path=value;}
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
