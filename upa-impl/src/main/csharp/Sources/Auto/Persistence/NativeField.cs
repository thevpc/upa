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

        private int index;

        private bool expanded;

        private string groupName;

        private string fullBinding;

        private string exprString;

        private string name;

        private Net.Vpc.Upa.Types.DataTypeTransform typeTransform;

        private Net.Vpc.Upa.Field field;

        public NativeField(string name, string groupName, string exprString, int index, bool expanded, Net.Vpc.Upa.Field field, Net.Vpc.Upa.Types.DataTypeTransform typeChain) {
            this.groupName = groupName;
            this.expanded = expanded;
            this.index = index;
            this.exprString = exprString;
            this.name = name;
            if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(groupName)) {
                fullBinding = name;
            } else {
                fullBinding = groupName + "." + name;
            }
            this.field = field;
            this.typeTransform = typeChain;
            //REMOVE ME
            if (typeChain == null) {
                throw new System.ArgumentException ("Null DataType");
            }
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual string GetFullBinding() {
            return fullBinding;
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

        public virtual string GetExprString() {
            return exprString;
        }

        public virtual bool IsExpanded() {
            return expanded;
        }
    }
}
