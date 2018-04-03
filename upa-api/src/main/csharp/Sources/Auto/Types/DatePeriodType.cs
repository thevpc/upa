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


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 29 avr. 2003
     * Time: 10:38:06
     * To change this template use Options | File Templates.
     */
    public class DatePeriodType : Net.Vpc.Upa.Types.DefaultDataType, Net.Vpc.Upa.CompoundDataType {

        private string countName;

        private string periodTypeName;

        private Net.Vpc.Upa.Types.NumberType countDataType;

        private Net.Vpc.Upa.Types.EnumType periodTypeDataType;

        public DatePeriodType(string name, string countName, string periodTypeName, bool nullable)  : this(name, countName, periodTypeName, new Net.Vpc.Upa.Types.IntType("PERIOD", 0, null, nullable, false)){

        }

        public DatePeriodType(string name, string countName, string periodTypeName, Net.Vpc.Upa.Types.NumberType countDataType)  : base(name, typeof(Net.Vpc.Upa.Types.DatePeriod), countDataType.IsNullable()){

            this.countName = countName;
            this.periodTypeName = periodTypeName;
            this.countDataType = countDataType;
            this.periodTypeDataType = new Net.Vpc.Upa.Types.EnumType(typeof(Net.Vpc.Upa.Types.PeriodOption), countDataType.IsNullable());
            if (this.countName == null) {
                this.countName = "count";
            }
            if (this.periodTypeName == null) {
                this.periodTypeName = "type";
            }
            ReevaluateCachedValues();
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            //        Integer defaultNonNullValue = (Integer) countDataType.getDefaultValue();
            if (!defaultValueUserDefined && !IsNullable()) {
                //            defaultValue=(new DatePeriod(defaultNonNullValue == null ? 0 : defaultNonNullValue.intValue(), PeriodOption.DAY));
                defaultValue = (new Net.Vpc.Upa.Types.DatePeriod(0, Net.Vpc.Upa.Types.PeriodOption.DAY));
            }
        }

        public virtual string GetCountName() {
            return countName;
        }

        public virtual string GetPeriodTypeName() {
            return periodTypeName;
        }

        public virtual Net.Vpc.Upa.Types.EnumType GetPeriodTypeDataType() {
            return periodTypeDataType;
        }

        public virtual Net.Vpc.Upa.Types.NumberType GetCountDataType() {
            return countDataType;
        }


        public virtual Net.Vpc.Upa.FieldDescriptor[] GetComposingFields(Net.Vpc.Upa.FieldDescriptor fieldDescriptor) {
            string[] names = new string[] { fieldDescriptor.GetName() + char.ToUpper(countName[0]) + countName.Substring(1), fieldDescriptor.GetName() + char.ToUpper(periodTypeName[0]) + periodTypeName.Substring(1) };
            if (fieldDescriptor.GetPersistFormula() != null) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported composing Persist Formula");
            }
            if (fieldDescriptor.GetUpdateFormula() != null) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported composing Update Formula");
            }
            if (fieldDescriptor.GetSelectFormula() != null) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported composing Select Formula");
            }
            Net.Vpc.Upa.FieldDescriptor[] fieldDescriptors = new Net.Vpc.Upa.FieldDescriptor[names.Length];
            object[] def = GetPrimitiveValues(fieldDescriptor.GetDefaultObject());
            object[] uns = GetPrimitiveValues(fieldDescriptor.GetUnspecifiedObject());
            for (int i = 0; i < fieldDescriptors.Length; i++) {
                Net.Vpc.Upa.DefaultFieldDescriptor d = new Net.Vpc.Upa.DefaultFieldDescriptor();
                d.SetReadProtectionLevel(Net.Vpc.Upa.ProtectionLevel.PRIVATE);
                d.SetDataType(i == 0 ? Net.Vpc.Upa.Types.TypesFactory.INT : Net.Vpc.Upa.Types.TypesFactory.INT);
                d.SetDefaultObject(def == null ? null : def[i]);
                d.SetUnspecifiedObject(uns == null ? null : uns[i]);
                d.SetPersistAccessLevel(fieldDescriptor.GetPersistAccessLevel());
                d.SetModifiers(Net.Vpc.Upa.FlagSets.Of<>(Net.Vpc.Upa.UserFieldModifier.SYSTEM));
                d.SetUpdateAccessLevel(fieldDescriptor.GetPersistAccessLevel());
                fieldDescriptors[i] = d;
            }
            return fieldDescriptors;
        }

        public virtual object[] GetPrimitiveValues(object @object) {
            if (@object == null) {
                return null;
            }
            Net.Vpc.Upa.Types.DatePeriod datePeriod = (Net.Vpc.Upa.Types.DatePeriod) @object;
            return new object[] { datePeriod.GetCount(), ((int)datePeriod.GetPeriodType()) };
        }

        public virtual object GetCompoundValue(object[] values) {
            if (values != null && values[0] != null && values[1] != null) {
                int c = (((int?) values[0])).Value;
                int p = (((int?) values[1])).Value;
                return new Net.Vpc.Upa.Types.DatePeriod(c, ((Net.Vpc.Upa.Types.PeriodOption[])System.Enum.GetValues(typeof(Net.Vpc.Upa.Types.PeriodOption)))[p]);
            }
            return null;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Types.DatePeriodType that = (Net.Vpc.Upa.Types.DatePeriodType) o;
            if (countName != null ? !countName.Equals(that.countName) : that.countName != null) return false;
            if (periodTypeName != null ? !periodTypeName.Equals(that.periodTypeName) : that.periodTypeName != null) return false;
            if (countDataType != null ? !countDataType.Equals(that.countDataType) : that.countDataType != null) return false;
            return periodTypeDataType != null ? periodTypeDataType.Equals(that.periodTypeDataType) : that.periodTypeDataType == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (countName != null ? countName.GetHashCode() : 0);
            result = 31 * result + (periodTypeName != null ? periodTypeName.GetHashCode() : 0);
            result = 31 * result + (countDataType != null ? countDataType.GetHashCode() : 0);
            result = 31 * result + (periodTypeDataType != null ? periodTypeDataType.GetHashCode() : 0);
            return result;
        }
    }
}
