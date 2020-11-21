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



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class IndexInfo : Net.TheVpc.Upa.IndexDescriptor {

        private string name;

        private System.Collections.Generic.IList<string> fieldsNames = new System.Collections.Generic.List<string>();

        private Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?> unique = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?>();

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual System.Collections.Generic.IList<string> GetFieldsNames() {
            return fieldsNames;
        }

        public virtual void SetFieldsNames(System.Collections.Generic.IList<string> fieldsNames) {
            this.fieldsNames = fieldsNames;
        }

        internal virtual Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?> GetUnique() {
            return unique;
        }

        internal virtual void SetUnique(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?> unique) {
            this.unique = unique;
        }

        public virtual string[] GetFieldNames() {
            return fieldsNames.ToArray();
        }

        public virtual bool IsUnique() {
            return ((bool?) unique.GetValue(new System.Nullable<bool>(true))).Value;
        }
    }
}
