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
    public class EqualsStringFilter : Net.Vpc.Upa.Impl.Util.ObjectFilter<string> {

        private string @base;

        private bool nullIsEmpty;

        private bool ignoreCase;

        public EqualsStringFilter(string @base, bool nullIsEmpty, bool ignoreCase) {
            this.@base = @base;
            this.nullIsEmpty = nullIsEmpty;
            this.ignoreCase = ignoreCase;
        }

        public virtual bool Accept(string s) {
            string base0 = @base;
            if (nullIsEmpty) {
                if (base0 == null) {
                    base0 = "";
                }
                if (s == null) {
                    s = "";
                }
            }
            if (ignoreCase) {
                if (base0 != null) {
                    base0 = base0.ToLower();
                }
                if (s != null) {
                    s = s.ToLower();
                }
            }
            return (base0 == null && s == null) || (base0 != null && base0.Equals(s));
        }
    }
}
