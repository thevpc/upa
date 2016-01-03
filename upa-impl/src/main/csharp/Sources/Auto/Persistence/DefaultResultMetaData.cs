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
     * @creationdate 9/1/12 12:42 AM
     */
    public class DefaultResultMetaData : Net.Vpc.Upa.Persistence.ResultMetaData {

        private System.Collections.Generic.IList<string> fieldNames = new System.Collections.Generic.List<string>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Types.DataTypeTransform> fieldTypes = new System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransform>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();

        public virtual void AddField(string name, Net.Vpc.Upa.Types.DataTypeTransform type, Net.Vpc.Upa.Field field) {
            fieldNames.Add(name);
            fieldTypes.Add(type);
            fields.Add(field);
        }


        public virtual int GetFieldsCount() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (fields).Count;
        }


        public virtual string GetFieldName(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return fieldNames[index];
        }


        public virtual Net.Vpc.Upa.Types.DataType GetFieldType(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return fieldTypes[index].GetSourceType();
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform GetFieldTransform(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return fieldTypes[index];
        }


        public virtual Net.Vpc.Upa.Field GetField(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return fields[index];
        }


        public virtual Net.Vpc.Upa.Entity GetEntity(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Field f = GetField(index);
            return f == null ? null : f.GetEntity();
        }
    }
}
