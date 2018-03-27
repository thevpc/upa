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



namespace Net.Vpc.Upa.Impl
{


    /**
    * Created by vpc on 12/20/13.*/
    internal class CaseInsensitiveNamingStrategy : Net.Vpc.Upa.NamingStrategy {

        public virtual string GetUniformValue(string name) {
            //        if (name == null) {
            //            throw new IllegalArgumentException("name should not be null");
            //        }
            return name.ToUpper();
        }

        public virtual bool Equals(string o1, string o2) {
            return o1.Equals(o2,System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
