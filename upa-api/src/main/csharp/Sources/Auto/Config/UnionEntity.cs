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
     * @creationdate 8/29/12 12:27 AM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class UnionEntity : System.Attribute {

        private Net.TheVpc.Upa.Config.UnionEntityEntry[] _Entities;
        public  Net.TheVpc.Upa.Config.UnionEntityEntry[] Entities{
            get {return _Entities;}
            set {_Entities=value;}
        }


        private string[] _Fields;
        public  string[] Fields{
            get {return _Fields;}
            set {_Fields=value;}
        }


        private string _Discriminator;
        public  string Discriminator{
            get {return _Discriminator;}
            set {_Discriminator=value;}
        }


        private System.Type _Spec = typeof(Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition);
        public  System.Type Spec{
            get {return _Spec;}
            set {_Spec=value;}
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
