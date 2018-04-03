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



namespace Net.Vpc.Upa.Types
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/29/12 1:45 AM
     */
    public class StringTypeCharRewriter : Net.Vpc.Upa.Types.TypeValueRewriter {

        protected internal string from;

        protected internal string to;

        public StringTypeCharRewriter(string from, string to) {
            this.from = from;
            this.to = to;
            if (from == null || to == null || (from).Length == 0 || (from).Length != (to).Length) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException();
            }
        }

        public virtual string GetFrom() {
            return from;
        }

        public virtual string GetTo() {
            return to;
        }


        public virtual object RewriteValue(object typeValue, string name, string description, Net.Vpc.Upa.Types.DataType type) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            if (typeValue != null && typeValue is string) {
                char[] c = ((string) typeValue).ToCharArray();
                bool updated = false;
                for (int i = 0; i < c.Length; i++) {
                    int j = from.IndexOf(c[i]);
                    if (j >= 0) {
                        c[i] = to[j];
                        updated = true;
                    }
                }
                return updated ? ((object)(new string(c))) : typeValue;
            }
            return typeValue;
        }
    }
}
