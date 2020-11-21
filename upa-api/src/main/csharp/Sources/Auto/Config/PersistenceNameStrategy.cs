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
     * @creationdate 9/4/12 11:00 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class PersistenceNameStrategy : System.Attribute {

        private string _PersistenceName = Net.TheVpc.Upa.UPA.UNDEFINED_STRING;
        public  string PersistenceName{
            get {return _PersistenceName;}
            set {_PersistenceName=value;}
        }


        private System.Type _Custom = typeof(Net.TheVpc.Upa.Persistence.PersistenceNameStrategy);
        public  System.Type Custom{
            get {return _Custom;}
            set {_Custom=value;}
        }


        private Net.TheVpc.Upa.Config.PersistenceName[] _Names = {  };
        public  Net.TheVpc.Upa.Config.PersistenceName[] Names{
            get {return _Names;}
            set {_Names=value;}
        }


        /**
             * Top level pattern applied for Top Level Object names. This pattern will
             * be applied to Tables and constraints for instance but not to Column
             * names. Note that this naming strategy is applied after any specific
             * strategy defined in names() Pattern can include the following variables
             * <ul>
             * <li> * : replaces the exact value of the name</li>
             * <li> {ObjectName} : replaces the name in the given form</li>
             * <li> {object_name} : replaces the name in the given form</li>
             * </ul>
             *
             * @return Naming pattern for global scope objects
             */
        private string _GlobalPersistenceName = Net.TheVpc.Upa.UPA.UNDEFINED_STRING;
        public  string GlobalPersistenceName{
            get {return _GlobalPersistenceName;}
            set {_GlobalPersistenceName=value;}
        }


        private string _LocalPersistenceName = Net.TheVpc.Upa.UPA.UNDEFINED_STRING;
        public  string LocalPersistenceName{
            get {return _LocalPersistenceName;}
            set {_LocalPersistenceName=value;}
        }


        private string _Escape = Net.TheVpc.Upa.UPA.UNDEFINED_STRING;
        public  string Escape{
            get {return _Escape;}
            set {_Escape=value;}
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
