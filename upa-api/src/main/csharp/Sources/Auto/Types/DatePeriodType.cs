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


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 29 avr. 2003
     * Time: 10:38:06
     * To change this template use Options | File Templates.
     */
    public class DatePeriodType : Net.Vpc.Upa.Types.TemporalType, Net.Vpc.Upa.CompoundDataType {

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
            if (periodTypeName == null) {
                periodTypeName = "type";
            }
            SetDefaultNonNullValue(new Net.Vpc.Upa.Types.DatePeriod((((int?) countDataType.GetDefaultNonNullValue())).Value, Net.Vpc.Upa.Types.PeriodOption.DAY));
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


        public override Net.Vpc.Upa.Types.Temporal ValidateDate(Net.Vpc.Upa.Types.Temporal date) {
            return date;
        }


        public virtual Net.Vpc.Upa.FieldDescriptor[] GetComposingFields(Net.Vpc.Upa.FieldDescriptor fieldDescriptor) {
            string[] names = new string[] { fieldDescriptor.GetName() + char.ToUpper(countName[0]) + countName.Substring(1), fieldDescriptor.GetName() + char.ToUpper(periodTypeName[0]) + periodTypeName.Substring(1) };
            if (fieldDescriptor.GetPersistFormula() != null) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unsupported composing Persist Formula");
            }
            if (fieldDescriptor.GetUpdateFormula() != null) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unsupported composing Update Formula");
            }
            if (fieldDescriptor.GetSelectFormula() != null) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unsupported composing Select Formula");
            }
            Net.Vpc.Upa.FieldDescriptor[] fieldDescriptors = new Net.Vpc.Upa.FieldDescriptor[names.Length];
            object[] def = GetPrimitiveValues(fieldDescriptor.GetDefaultObject());
            object[] uns = GetPrimitiveValues(fieldDescriptor.GetUnspecifiedObject());
            for (int i = 0; i < fieldDescriptors.Length; i++) {
                Net.Vpc.Upa.DefaultFieldDescriptor d = new Net.Vpc.Upa.DefaultFieldDescriptor();
                d.SetReadAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE);
                d.SetDataType(i == 0 ? Net.Vpc.Upa.Types.TypesFactory.INT : Net.Vpc.Upa.Types.TypesFactory.INT);
                d.SetDefaultObject(def == null ? null : def[i]);
                d.SetUnspecifiedObject(uns == null ? null : uns[i]);
                d.SetPersistAccessLevel(fieldDescriptor.GetPersistAccessLevel());
                d.SetUserFieldModifiers(Net.Vpc.Upa.FlagSets.Of<Net.Vpc.Upa.UserFieldModifier>(Net.Vpc.Upa.UserFieldModifier.SYSTEM));
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
    }
}
