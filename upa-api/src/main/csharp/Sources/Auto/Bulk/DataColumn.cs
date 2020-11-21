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



namespace Net.TheVpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DataColumn : System.ICloneable {

        private int index;

        private string name;

        private System.Collections.Generic.ISet<string> extraNames = new System.Collections.Generic.HashSet<string>();

        private string title;

        private Net.TheVpc.Upa.Types.DataType dataType;

        private Net.TheVpc.Upa.Bulk.ValueConverter rawValueConverter;

        private Net.TheVpc.Upa.Bulk.ValueConverter valueConverter;

        private Net.TheVpc.Upa.Bulk.ValueValidator valueValidator;

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

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateIndex(int index) {
            SetIndex(index);
            return this;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateName(string name) {
            SetName(name);
            return this;
        }

        public virtual string GetTitle() {
            return title;
        }

        public virtual void SetTitle(string title) {
            this.title = title;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateTitle(string title) {
            SetTitle(title);
            return this;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        public virtual void SetDataType(Net.TheVpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateDataType(Net.TheVpc.Upa.Types.DataType dataType) {
            SetDataType(dataType);
            return this;
        }

        public virtual Net.TheVpc.Upa.Bulk.ValueConverter GetValueConverter() {
            return valueConverter;
        }

        public virtual void SetValueConverter(Net.TheVpc.Upa.Bulk.ValueConverter valueConverter) {
            this.valueConverter = valueConverter;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateValueConverter(Net.TheVpc.Upa.Bulk.ValueConverter valueConverter) {
            SetValueConverter(valueConverter);
            return this;
        }

        public virtual Net.TheVpc.Upa.Bulk.ValueValidator GetValueValidator() {
            return valueValidator;
        }

        public virtual void SetValueValidator(Net.TheVpc.Upa.Bulk.ValueValidator valueValidator) {
            this.valueValidator = valueValidator;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateValueValidator(Net.TheVpc.Upa.Bulk.ValueValidator valueValidator) {
            SetValueValidator(valueValidator);
            return this;
        }

        public virtual Net.TheVpc.Upa.Bulk.ValueConverter GetRawValueConverter() {
            return rawValueConverter;
        }

        public virtual void SetRawValueConverter(Net.TheVpc.Upa.Bulk.ValueConverter rawValueConverter) {
            this.rawValueConverter = rawValueConverter;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateRawValueConverter(Net.TheVpc.Upa.Bulk.ValueConverter rawValueConverter) {
            SetRawValueConverter(rawValueConverter);
            return this;
        }

        public virtual bool IsTrimValue() {
            return trimValue;
        }

        public virtual void SetTrimValue(bool trimValue) {
            this.trimValue = trimValue;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateTrimValue(bool trimValue) {
            SetTrimValue(trimValue);
            return this;
        }

        public virtual System.Collections.Generic.ISet<string> GetExtraNames() {
            return extraNames;
        }

        public virtual void SetExtraNames(System.Collections.Generic.ISet<string> extraNames) {
            this.extraNames = extraNames;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateExtraNames(System.Collections.Generic.ISet<string> extraNames) {
            SetExtraNames(extraNames);
            return this;
        }

        public virtual object Copy() {
            try {
                Net.TheVpc.Upa.Bulk.DataColumn c = (Net.TheVpc.Upa.Bulk.DataColumn) base.MemberwiseClone();
                if (extraNames != null) {
                    c.extraNames = new System.Collections.Generic.HashSet<string>(extraNames);
                }
                return c;
            } catch (System.Exception ex) {
                throw new Net.TheVpc.Upa.Exceptions.UnexpectedException("Missing Cloneable Interface Anchor for " + (GetType()).FullName, ex);
            }
        }


        public override string ToString() {
            return "DataColumn{" + "index=" + index + ", name=" + name + ", title=" + title + '}';
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
