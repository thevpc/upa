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
     * corresponds to the JPA
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @Id
     * @creationdate 8/28/12 10:17 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class PersistenceName : System.Attribute {

        private string _Object = "";
        public  string Object{
            get {return _Object;}
            set {_Object=value;}
        }


        private Net.Vpc.Upa.Config.PersistenceNameType _PersistenceNameType;
        public  Net.Vpc.Upa.Config.PersistenceNameType PersistenceNameType{
            get {return _PersistenceNameType;}
            set {_PersistenceNameType=value;}
        }


        private string _CustomType = "";
        public  string CustomType{
            get {return _CustomType;}
            set {_CustomType=value;}
        }


        private string _Value = "";
        public  string Value{
            get {return _Value;}
            set {_Value=value;}
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
