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



namespace Net.TheVpc.Upa.Impl.Util
{

    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/5/13 9:59 PM*/
    public class CacheException : System.Exception {

        private System.Exception error;

        public virtual System.Exception GetError() {
            return error;
        }

        public CacheException(string msg)  : this(msg, null){

        }

        public CacheException(System.Exception error)  : this((error).Message, error){

        }

        public CacheException(string msg, System.Exception error)  : base(msg){

        }
    }
}
