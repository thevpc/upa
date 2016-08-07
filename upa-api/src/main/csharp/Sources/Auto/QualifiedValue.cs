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



namespace Net.Vpc.Upa
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/3/12 1:19 AM
     */
    public class QualifiedValue {

        private Net.Vpc.Upa.Entity entityManager;

        private object @value;

        public QualifiedValue(Net.Vpc.Upa.Entity entityManager, object @value) {
            this.entityManager = entityManager;
            this.@value = @value;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entityManager;
        }

        public virtual object GetValue() {
            return @value;
        }
    }
}
