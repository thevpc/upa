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



namespace Net.Vpc.Upa.Types
{


    public class ListType : Net.Vpc.Upa.Types.SeriesType {

        protected internal Net.Vpc.Upa.Types.DataType elementType;

        protected internal System.Collections.Generic.IList<object> elements;

        public ListType(string name, System.Collections.Generic.IList<object> collection, Net.Vpc.Upa.Types.DataType modelClass, bool nullable)  : this(name, collection, modelClass, 0, 0, nullable){

        }

        public ListType(string name, System.Collections.Generic.IList<object> collection, Net.Vpc.Upa.Types.DataType modelClass)  : this(name, collection, modelClass, 0, 0, false){

        }

        public ListType(string name, object[] collection, Net.Vpc.Upa.Types.DataType modelClass)  : this(name, new System.Collections.Generic.List<object>(collection), modelClass, 0, 0, false){

        }

        public ListType(string name, System.Collections.Generic.IList<object> collection, Net.Vpc.Upa.Types.DataType elementType, int length, int precision, bool nullable)  : base(name, elementType.GetPlatformType(), length, precision, nullable){

            this.elementType = elementType;
            SetData(collection);
            ReevaluateCachedValues();
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (elementType == null) {
                return;
            }
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = ((GetValues()).Count > 0 ? GetValues()[0] : null);
            }
        }

        public ListType(string name, System.Collections.Generic.IList<object> collection, Net.Vpc.Upa.Types.DataType modelClass, int length, int precision)  : this(name, collection, modelClass, length, precision, false){

        }

        public virtual Net.Vpc.Upa.Types.DataType GetElementType() {
            return elementType;
        }


        public override System.Collections.Generic.IList<object> GetValues() {
            return elements;
        }

        private void SetData(System.Collections.Generic.IList<object> collection) {
            elements = new System.Collections.Generic.List<object>(collection == null ? 1 : (collection).Count);
            if (collection != null) {
                foreach (object s in collection) {
                    if (s != null && !GetPlatformType().IsInstanceOfType(s)) {
                        throw new System.InvalidCastException("Expected " + GetPlatformType() + " but got " + (s.GetType()).FullName);
                    }
                    if (s != null && (typeof(string)).Equals(GetPlatformType())) {
                        int x = (((string) s)).Length;
                        if (scale < x) {
                            scale = x;
                        }
                    }
                    elements.Add(s);
                }
            }
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            elementType.Check(@value, name, description);
        }

        public virtual object GetValueAt(int index) {
            return elements[index];
        }

        public virtual int IndexOf(object key) {
            return elements.IndexOf(key);
        }

        public virtual void Add(object @value) {
            elements.Add(@value);
        }

        public virtual void Insert(int index, object @value) {
            elements.Insert(index, @value);
        }

        public virtual void RemoveAll() {
            elements.Clear();
        }

        public virtual void Remove(object key) {
            elements.Remove(key);
        }

        public virtual void Remove(int index) {
            elements.RemoveAt(index);
        }

        public virtual int Size() {
            return (elements).Count;
        }


        public override object Copy() {
            try {
                Net.Vpc.Upa.Types.ListType l = (Net.Vpc.Upa.Types.ListType) Clone();
                l.elements = new System.Collections.Generic.List<object>(l.elements);
                return l;
            } catch (System.Exception ex) {
                throw new Net.Vpc.Upa.Exceptions.UnexpectedException("Clone Not Supported", ex);
            }
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Types.ListType listType = (Net.Vpc.Upa.Types.ListType) o;
            if (elementType != null ? !elementType.Equals(listType.elementType) : listType.elementType != null) return false;
            return elements != null ? elements.Equals(listType.elements) : listType.elements == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (elementType != null ? elementType.GetHashCode() : 0);
            result = 31 * result + (elements != null ? elements.GetHashCode() : 0);
            return result;
        }


        public override Net.Vpc.Upa.DataTypeInfo GetInfo() {
            Net.Vpc.Upa.DataTypeInfo d = base.GetInfo();
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            d.GetProperties()["elementType"]=System.Convert.ToString(elementType);
            foreach (object o in elements) {
                if ((s).Length > 0) {
                    s.Append(",");
                }
                s.Append(o.ToString());
            }
            d.GetProperties()["values"]=System.Convert.ToString(s);
            return d;
        }
    }
}
