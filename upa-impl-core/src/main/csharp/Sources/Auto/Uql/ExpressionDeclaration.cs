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



namespace Net.TheVpc.Upa.Impl.Uql
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/19/12 7:24 PM
     */
    public class ExpressionDeclaration {

        private string name;

        private object referrerName;

        private object referrerParent;

        private Net.TheVpc.Upa.Impl.Uql.DecObjectType referrerType;

        public ExpressionDeclaration(string name, Net.TheVpc.Upa.Impl.Uql.DecObjectType referrerType, object referrerName, object referrerParent) {
            this.name = name;
            this.referrerName = referrerName;
            this.referrerParent = referrerParent;
            this.referrerType = referrerType;
        }

        public virtual object GetReferrerName() {
            return referrerName;
        }

        public virtual void SetReferrerName(object referrerName) {
            this.referrerName = referrerName;
        }

        public virtual object GetReferrerParent() {
            return referrerParent;
        }

        public virtual void SetReferrerParent(object referrerParent) {
            this.referrerParent = referrerParent;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.DecObjectType GetReferrerType() {
            return referrerType;
        }

        public virtual void SetReferrerType(Net.TheVpc.Upa.Impl.Uql.DecObjectType referrerType) {
            this.referrerType = referrerType;
        }

        public virtual string GetValidName() {
            if (name != null) {
                return name;
            }
            if (referrerName != null && referrerName is string) {
                return (string) referrerName;
            }
            return null;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }


        public override string ToString() {
            return "Declaration{" + name + ", referrerType=" + referrerType + ", referrerName=" + referrerName + ", referrerParent=" + referrerParent + '}';
        }
    }
}
