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



namespace Net.Vpc.Upa.Impl.Persistence.Result
{


    /**
    * Created by vpc on 1/4/14.*/
    internal class FieldInfo {

        public Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo;

        public int dbIndex;

        public bool update;

        public System.Collections.Generic.ISet<int?> indexesToUpdate = new System.Collections.Generic.HashSet<int?>();

        public string name;

        public Net.Vpc.Upa.Impl.Persistence.NativeField nativeField;

        public string setterMethodName;

        public Net.Vpc.Upa.Field field;

        public Net.Vpc.Upa.Entity referencedEntity;


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (nativeField != null) {
                sb.Append(nativeField.ToString());
            } else {
                sb.Append(name);
            }
            sb.Append("@").Append(dbIndex);
            return sb.ToString();
        }
    }
}
