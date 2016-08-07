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



namespace Net.Vpc.Upa.Types
{


    public class StructType : Net.Vpc.Upa.Types.DefaultDataType {

        public static readonly object OLD_VALUE = new object();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Types.DataType> elementsMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Types.DataType>();

        private System.Collections.Generic.IList<string> elementsList = new System.Collections.Generic.List<string>();

        public StructType(string name, System.Type clazz, string[] fieldNames, Net.Vpc.Upa.Types.DataType[] datatypes, bool nullable)  : base(name, clazz, datatypes.Length, 0, nullable){

            if (fieldNames.Length != datatypes.Length) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException();
            }
            for (int i = 0; i < fieldNames.Length; i++) {
                if (elementsMap.ContainsKey(fieldNames[i])) {
                    throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException();
                }
                elementsMap[fieldNames[i]]=datatypes[i];
                elementsList.Add(fieldNames[i]);
            }
        }

        public virtual Net.Vpc.Upa.Types.DataType GetItemDataTypeAt(int index) {
            return Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Types.DataType>(elementsMap,elementsList[index]);
        }

        public virtual string GetItemNameAt(int index) {
            return elementsList[index];
        }

        public virtual int IndexOf(string name) {
            return elementsList.IndexOf(name);
        }

        public virtual int GetItemsCount() {
            return (elementsList).Count;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            object[] val = GetArrayForObject(@value);
            int max = (elementsList).Count;
            if (@value != null) {
                for (int i = 0; i < max; i++) {
                    if (!OLD_VALUE.Equals(val[i])) {
                        GetItemDataTypeAt(i).Check(val[i], null, null);
                    }
                }
            } else {
            }
        }

        public virtual object GetItemValueAt(int index, object @value) {
            return @value == null ? null : ((object[]) @value)[index];
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetItemValuesMap(System.Collections.Generic.IDictionary<string , object> map, object @value) {
            if (map == null) {
                map = new System.Collections.Generic.Dictionary<string , object>();
            }
            int max = GetItemsCount();
            if (@value != null) {
                for (int i = 0; i < max; i++) {
                    map[GetItemNameAt(i)]=GetItemValueAt(i, @value);
                }
            } else {
                for (int i = 0; i < max; i++) {
                    map[GetItemNameAt(i)]=null;
                }
            }
            return map;
        }

        public virtual object GetItemValue(string fieldName, object @value) {
            return GetItemValueAt(IndexOf(fieldName), @value);
        }

        public virtual object GetObjectForArray(object[] @value) {
            return @value;
        }

        public virtual object[] GetArrayForObject(object @value) {
            return (object[]) @value;
        }
    }
}
