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
     * @ManyToOne are equivalents to JPA's ManyToOne
     * <p/>
     * Example 1 : countryId defines a FK to Country Entity. No extra field will be created
     * <pre>
     *  public class Client {
     *     @ManyToOne(targetEntityType=Country.class)
     *     int countryId;
     *  }
     * </pre>
     * <p/>
     * <p/>
     * <p/>
     * <p/>
     * Example 2 : country defines a FK to Entity named "Country"
     * <pre>
     *  public class Client {
     *     @ManyToOne(targetEntityType="Country")
     *     int countryId;
     *  }
     * </pre>
     * <p/>
     * <p/>
     * Example 3 : country defines a FK to Country Entity. updates to countryId are ignore and
     * overridden by associated country updates (country is actually readOnly)
     * <pre>
     *  public class Client {
     *     int countryId;
     *     @ManyToOne(mappedTo="countryId")
     *     Country country;
     *  }
     * </pre>
     * <p/>
     * Example 4 : country defines a FK to Country Entity. updates to country are ignore and
     * overridden by associated countryId updates (countryId is actually readOnly)
     * <pre>
     *  public class Client {
     *     @ManyToOne(mappedTo="country")
     *     int countryId;
     *     Country country;
     *  }
     * </pre>
     * <p/>
     * In this example, Country reference is updatable via countryId and not country
     * <p/>
     * <pre>
     *  public class Client {
     *     @ManyToOne
     *     int countryId;
     *     @ManyToOne(mappedBy="countryId")
     *     Country country;
     *  }
     * </pre>
     * @creationdate 8/28/12 10:17 PM
     */
    [System.AttributeUsage(System.AttributeTargets.Method|System.AttributeTargets.Field)]

    public class ManyToOne : System.Attribute {

        private string _Name = "";
        public  string Name{
            get {return _Name;}
            set {_Name=value;}
        }


        /**
             * relation expression
             *
             * @return
             */
        private string _Filter = "";
        public  string Filter{
            get {return _Filter;}
            set {_Filter=value;}
        }


        private string[] _MappedTo = {  };
        public  string[] MappedTo{
            get {return _MappedTo;}
            set {_MappedTo=value;}
        }


        private Net.Vpc.Upa.RelationshipType _Type = Net.Vpc.Upa.RelationshipType.DEFAULT;
        public  Net.Vpc.Upa.RelationshipType Type{
            get {return _Type;}
            set {_Type=value;}
        }


        private string _TargetEntity = "";
        public  string TargetEntity{
            get {return _TargetEntity;}
            set {_TargetEntity=value;}
        }


        private System.Type _TargetEntityType = typeof(void);
        public  System.Type TargetEntityType{
            get {return _TargetEntityType;}
            set {_TargetEntityType=value;}
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
