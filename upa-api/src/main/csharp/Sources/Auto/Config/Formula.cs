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
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class Formula : System.Attribute {

        private string _Value = "";
        public  string Value{
            get {return _Value;}
            set {_Value=value;}
        }


        private System.Type _Custom = typeof(Net.Vpc.Upa.Formula);
        public  System.Type Custom{
            get {return _Custom;}
            set {_Custom=value;}
        }


        private int _FormulaOrder = System.Int32.MinValue;
        public  int FormulaOrder{
            get {return _FormulaOrder;}
            set {_FormulaOrder=value;}
        }


        private Net.Vpc.Upa.FormulaType[] _Type = {  };
        public  Net.Vpc.Upa.FormulaType[] Type{
            get {return _Type;}
            set {_Type=value;}
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
