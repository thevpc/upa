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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/24/12 5:43 PM
     */
    public class NativeField {

        private string groupName;

        private string name;

        private Net.Vpc.Upa.Types.DataTypeTransform typeTransform;

        private Net.Vpc.Upa.Field field;

        public NativeField(string name, string groupName, Net.Vpc.Upa.Field field, Net.Vpc.Upa.Types.DataTypeTransform typeChain) {
            this.groupName = groupName;
            this.name = name;
            this.field = field;
            this.typeTransform = typeChain;
            //REMOVE ME
            if (typeChain == null) {
                throw new System.ArgumentException ("Null DataType");
            }
        }

        public virtual string GetGroupName() {
            return groupName;
        }

        public virtual Net.Vpc.Upa.Field GetField() {
            return field;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return typeTransform;
        }


        public override string ToString() {
            return "NativeField{" + "groupName=" + groupName + ", name=" + name + ", typeChain=" + typeTransform + ", field=" + field + '}';
        }
    }
}
