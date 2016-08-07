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
     * Created by vpc on 6/2/16.
     */
    public class NamedId {

        private object id;

        private string name;

        public NamedId() {
        }

        public NamedId(object id, string name) {
            this.id = id;
            this.name = name;
        }

        public virtual object GetId() {
            return id;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetId(object id) {
            this.id = id;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (!(o is Net.Vpc.Upa.NamedId)) return false;
            Net.Vpc.Upa.NamedId namedId = (Net.Vpc.Upa.NamedId) o;
            if (id != null ? !id.Equals(namedId.id) : namedId.id != null) return false;
            return !(name != null ? !name.Equals(namedId.name) : namedId.name != null);
        }


        public override int GetHashCode() {
            int result = id != null ? id.GetHashCode() : 0;
            result = 31 * result + (name != null ? name.GetHashCode() : 0);
            return result;
        }


        public override string ToString() {
            return "{" + "id=" + id + ", name='" + name + '\'' + '}';
        }
    }
}
