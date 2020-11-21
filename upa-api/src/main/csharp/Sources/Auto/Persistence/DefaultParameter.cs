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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/16/12 7:00 PM
     */
    public class DefaultParameter : Net.TheVpc.Upa.Persistence.Parameter {

        private string name;

        private Net.TheVpc.Upa.Types.DataTypeTransform type;

        private object @value;

        public DefaultParameter(string name, object @value, Net.TheVpc.Upa.Types.DataTypeTransform type) {
            this.name = name;
            this.@value = @value;
            this.type = type;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return type;
        }

        public virtual object GetValue() {
            return @value;
        }

        public virtual void SetValue(object @value) {
            this.@value = @value;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.TheVpc.Upa.Persistence.DefaultParameter that = (Net.TheVpc.Upa.Persistence.DefaultParameter) o;
            if (name != null ? !name.Equals(that.name) : that.name != null) return false;
            if (type != null ? !type.Equals(that.type) : that.type != null) return false;
            return true;
        }


        public override int GetHashCode() {
            int result = name != null ? name.GetHashCode() : 0;
            result = 31 * result + (type != null ? type.GetHashCode() : 0);
            return result;
        }


        public override string ToString() {
            return "Param(" + ((name == null || (name).Length == 0) ? "?" : name) + "=" + @value + "," + type + '}';
        }
    }
}
