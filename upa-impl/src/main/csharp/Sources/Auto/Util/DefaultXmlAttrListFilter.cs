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
     * @author vpc
     */
    public class DefaultXmlAttrListFilter : Net.Vpc.Upa.Impl.Util.XmlAttrListFilter {

        private readonly System.Collections.Generic.ISet<string> names = new System.Collections.Generic.HashSet<string>();

        public DefaultXmlAttrListFilter(params string [] names) {
            foreach (string name in names) {
                this.names.Add(CheckUniformName(name));
            }
        }


        public virtual string AcceptAndConvert(string s) {
            string n = Net.Vpc.Upa.Impl.Util.XMLUtils.UniformName(s);
            if (names.Contains(n)) {
                return n;
            }
            return null;
        }

        private string CheckUniformName(string s) {
            if (!s.Equals(Net.Vpc.Upa.Impl.Util.XMLUtils.UniformName(s))) {
                throw new System.ArgumentException ("Expected Uniform Name " + s + " ==> " + Net.Vpc.Upa.Impl.Util.XMLUtils.UniformName(s));
            }
            return s;
        }
    }
}
