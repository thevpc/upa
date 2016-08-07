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
     */

    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Method|System.AttributeTargets.Field)]
    public class Property : System.Attribute {

        private string _Name;
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        private string _Value;
        public  string Value{
            get {return _Value;}
            set {_Value=value;}
        }


        private string _Type = "";
        public  string Type{
            get {return _Type;}
            set {_Type=value;}
        }


        private string _Format = "";
        public  string Format{
            get {return _Format;}
            set {_Format=value;}
        }

    }
}
