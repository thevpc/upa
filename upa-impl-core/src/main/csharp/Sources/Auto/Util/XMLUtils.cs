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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class XMLUtils {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.XMLUtils)).FullName);

        public static System.Collections.Generic.IDictionary<string , string> GetAttributes(System.Xml.XmlElement e, Net.Vpc.Upa.Impl.Util.XmlAttrListFilter names) {
            System.Collections.Generic.IDictionary<string , string> values = new System.Collections.Generic.Dictionary<string , string>();
            
            return values;
        }

        public static string UniformName(string s) {
            return s.ToLower();
        }

        public static bool EqualsUniform(string s1, string s2) {
            return UniformName(s1).Equals(UniformName(s2));
        }
    }
}
