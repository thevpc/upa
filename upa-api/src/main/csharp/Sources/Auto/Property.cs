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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class Property {

        private string name;

        private string @value;

        private string typeName;

        private string format;

        public Property(string name, string @value, string type, string format) {
            this.name = name;
            this.@value = @value;
            this.typeName = type;
            this.format = format;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual string GetValue() {
            return @value;
        }

        public virtual string GetTypeName() {
            return typeName;
        }

        public virtual string GetFormat() {
            return format;
        }
    }
}
