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



namespace Net.Vpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DataColumn : System.ICloneable {

        private int index;

        private string name;

        private System.Collections.Generic.ISet<string> extraNames = new System.Collections.Generic.HashSet<string>();

        private string title;

        private Net.Vpc.Upa.Types.DataType dataType;

        private Net.Vpc.Upa.Bulk.ValueConverter rawValueConverter;

        private Net.Vpc.Upa.Bulk.ValueConverter valueConverter;

        private Net.Vpc.Upa.Bulk.ValueValidator valueValidator;

        private bool trimValue;

        public DataColumn() {
        }

        public DataColumn(int index, string name) {
            this.index = index;
            this.name = name;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual void SetIndex(int index) {
            this.index = index;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateIndex(int index) {
            SetIndex(index);
            return this;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateName(string name) {
            SetName(name);
            return this;
        }

        public virtual string GetTitle() {
            return title;
        }

        public virtual void SetTitle(string title) {
            this.title = title;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateTitle(string title) {
            SetTitle(title);
            return this;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        public virtual void SetDataType(Net.Vpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateDataType(Net.Vpc.Upa.Types.DataType dataType) {
            SetDataType(dataType);
            return this;
        }

        public virtual Net.Vpc.Upa.Bulk.ValueConverter GetValueConverter() {
            return valueConverter;
        }

        public virtual void SetValueConverter(Net.Vpc.Upa.Bulk.ValueConverter valueConverter) {
            this.valueConverter = valueConverter;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateValueConverter(Net.Vpc.Upa.Bulk.ValueConverter valueConverter) {
            SetValueConverter(valueConverter);
            return this;
        }

        public virtual Net.Vpc.Upa.Bulk.ValueValidator GetValueValidator() {
            return valueValidator;
        }

        public virtual void SetValueValidator(Net.Vpc.Upa.Bulk.ValueValidator valueValidator) {
            this.valueValidator = valueValidator;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateValueValidator(Net.Vpc.Upa.Bulk.ValueValidator valueValidator) {
            SetValueValidator(valueValidator);
            return this;
        }

        public virtual Net.Vpc.Upa.Bulk.ValueConverter GetRawValueConverter() {
            return rawValueConverter;
        }

        public virtual void SetRawValueConverter(Net.Vpc.Upa.Bulk.ValueConverter rawValueConverter) {
            this.rawValueConverter = rawValueConverter;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateRawValueConverter(Net.Vpc.Upa.Bulk.ValueConverter rawValueConverter) {
            SetRawValueConverter(rawValueConverter);
            return this;
        }

        public virtual bool IsTrimValue() {
            return trimValue;
        }

        public virtual void SetTrimValue(bool trimValue) {
            this.trimValue = trimValue;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateTrimValue(bool trimValue) {
            SetTrimValue(trimValue);
            return this;
        }

        public virtual System.Collections.Generic.ISet<string> GetExtraNames() {
            return extraNames;
        }

        public virtual void SetExtraNames(System.Collections.Generic.ISet<string> extraNames) {
            this.extraNames = extraNames;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn UpdateExtraNames(System.Collections.Generic.ISet<string> extraNames) {
            SetExtraNames(extraNames);
            return this;
        }


        public virtual object Clone() {
            try {
                Net.Vpc.Upa.Bulk.DataColumn c = (Net.Vpc.Upa.Bulk.DataColumn) base.MemberwiseClone();
                if (extraNames != null) {
                    c.extraNames = new System.Collections.Generic.HashSet<string>(extraNames);
                }
                return c;
            } catch (System.Exception ex) {
                throw new System.ArgumentException ("Missing Cloneable Interface Anchor for " + (GetType()).FullName);
            }
        }


        public override string ToString() {
            return "DataColumn{" + "index=" + index + ", name=" + name + ", title=" + title + '}';
        }
    }
}
