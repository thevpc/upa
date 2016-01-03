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
namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class IndexInfo : Net.Vpc.Upa.IndexDescriptor {

        private string name;

        private System.Collections.Generic.IList<string> fieldsNames = new System.Collections.Generic.List<string>();

        private Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?> unique = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?>();

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

        internal virtual Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?> GetUnique() {
            return unique;
        }

        internal virtual void SetUnique(Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<bool?> unique) {
            this.unique = unique;
        }

        public virtual string[] GetFieldNames() {
            return fieldsNames.ToArray();
        }

        public virtual bool IsUnique() {
            return ((bool?) unique.GetValue(true)).Value;
        }
    }
}
