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



namespace Net.TheVpc.Upa.Extensions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/31/12 1:24 PM
     */
    public class DefaultUnionEntityExtensionDefinition : Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition {

        private Net.TheVpc.Upa.Extensions.UnionQueryInfo info;

        public DefaultUnionEntityExtensionDefinition(Net.TheVpc.Upa.Extensions.UnionQueryInfo info) {
            this.info = info;
        }


        public virtual Net.TheVpc.Upa.Extensions.UnionQueryInfo GetQueryInfo(Net.TheVpc.Upa.Entity entity) {
            return info;
        }
    }
}
