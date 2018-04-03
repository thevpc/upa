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



namespace Net.Vpc.Upa.Extensions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/31/12 1:24 PM
     */
    public class DefaultUnionEntityExtensionDefinition : Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition {

        private Net.Vpc.Upa.Extensions.UnionQueryInfo info;

        public DefaultUnionEntityExtensionDefinition(Net.Vpc.Upa.Extensions.UnionQueryInfo info) {
            this.info = info;
        }


        public virtual Net.Vpc.Upa.Extensions.UnionQueryInfo GetQueryInfo(Net.Vpc.Upa.Entity entity) {
            return info;
        }
    }
}
