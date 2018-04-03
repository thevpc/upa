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
     * Cannot not have multiple @Password in the same chain
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    [System.AttributeUsage(System.AttributeTargets.Class|System.AttributeTargets.Field|System.AttributeTargets.Method)]

    public class Password : System.Attribute {

        /**
             * cypher method
             *
             * @return
             */
        private Net.Vpc.Upa.PasswordStrategyType _StrategyType = Net.Vpc.Upa.PasswordStrategyType.DEFAULT;
        public  Net.Vpc.Upa.PasswordStrategyType StrategyType{
            get {return _StrategyType;}
            set {_StrategyType=value;}
        }


        /**
             * When a field with
             * <pre>Password</pre> annotation has this cypherValue value, password will
             * not be updated to persistence model (value will not be hashed again).
             * This value is garanteed to be retrieved from persistence model when even
             * the entity is loaded.
             *
             * @return cypher value
             */
        private string _CipherValue = "****";
        public  string CipherValue{
            get {return _CipherValue;}
            set {_CipherValue=value;}
        }


        private string _CipherValueType = "";
        public  string CipherValueType{
            get {return _CipherValueType;}
            set {_CipherValueType=value;}
        }


        private string _CipherValueFormat = "";
        public  string CipherValueFormat{
            get {return _CipherValueFormat;}
            set {_CipherValueFormat=value;}
        }


        private string _CustomStrategy = "";
        public  string CustomStrategy{
            get {return _CustomStrategy;}
            set {_CustomStrategy=value;}
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
