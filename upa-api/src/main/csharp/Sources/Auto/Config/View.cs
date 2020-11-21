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
     *
     * Views are compiled queries (mapped as RDBMS Views if supported)
     * but defined as UPQL query expression
     * Here is an example :
     * <pre>
     *     @View(
     * query = "Select o from Product o where o.country='TN'"
     * )
     * public class TunisianProducts {
     * @Id @Sequence
     * private int id;
     * private String name;
     *
     * public int getId() {
     * return id;
     * }
     *
     * public void setId(int id) {
     * this.id = id;
     * }
     *
     * public String getName() {
     * return name;
     * }
     *
     * public void setName(String name) {
     * this.name = name;
     * }
     *
     * }
     *
     * </pre>
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 8:28 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Class)]

    public class View : System.Attribute {

        /**
             * View Query
             * @return UPQL query
             */
        private string _Query = "";
        public  string Query{
            get {return _Query;}
            set {_Query=value;}
        }


        /**
             * View Query defined as ViewEntityExtensionDefinition class.
             * If defined will replace the String query defined in query()
             * @return
             */
        private System.Type _Spec = typeof(Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition);
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
