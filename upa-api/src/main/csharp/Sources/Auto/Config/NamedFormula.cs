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
     */
    [System.AttributeUsage(System.AttributeTargets.Method)]

    public class NamedFormula : System.Attribute {

        /**
             * if defined will consider named Custom formula registered in PersistenceUnit
             */
        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
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
