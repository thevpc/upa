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



namespace Net.Vpc.Upa.Impl.Transform
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultPasswordStrategy : Net.Vpc.Upa.PasswordStrategy {

        private string digest;

        private bool fixedSize;

        private int maxSize;

        public static readonly Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy MD5 = new Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy("MD5", true, 32);

        public static readonly Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy SHA1 = new Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy("SHA1", true, 20);

        public static readonly Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy SHA256 = new Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy("SHA-256", true, 64);

        public DefaultPasswordStrategy(string digest, bool fixedSize, int maxSize) {
            this.digest = digest;
            this.fixedSize = fixedSize;
            this.maxSize = maxSize;
        }

        public virtual string Encode(string @value) {
            try {
                if (@value == null) {
                    return null;
                }
                // first of all convert this object to String
                byte[] bytesOfMessage = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(@value);
                byte[] hash = null;
                return Net.Vpc.Upa.Impl.Util.StringUtils.ToHexString(hash);
            } catch (System.Exception ex) {
                throw new System.Exception("RuntimeException", ex);
            }
        }


        public override string ToString() {
            return System.Convert.ToString(digest);
        }

        public virtual bool IsFixedSize() {
            return fixedSize;
        }

        public virtual int GetMaxSize() {
            return maxSize;
        }
    }
}
