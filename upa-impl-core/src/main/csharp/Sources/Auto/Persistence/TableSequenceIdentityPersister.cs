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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class TableSequenceIdentityPersister : Net.TheVpc.Upa.Persistence.FieldPersister {

        private int initialValue = 1;

        private int allocationSize = 50;

        private string format;

        private string group;

        private string name;

        private Net.TheVpc.Upa.Field field;

        public TableSequenceIdentityPersister(Net.TheVpc.Upa.Field field, Net.TheVpc.Upa.Sequence sequence) {
            this.initialValue = sequence == null ? 1 : sequence.GetInitialValue();
            this.allocationSize = (sequence == null) ? 50 : sequence.GetAllocationSize();
            this.name = (sequence == null) ? null : sequence.GetName();
            this.group = (sequence == null) ? null : sequence.GetGroup();
            this.format = (sequence == null) ? null : sequence.GetFormat();
            this.field = field;
            if (this.format == null) {
                this.format = "{#}";
            }
            if (this.group == null) {
                this.group = format;
            }
            if (this.name == null) {
                this.name = field.GetEntity().GetName() + "." + field.GetName();
            }
        }

        public virtual int GetInitialValue() {
            return initialValue;
        }

        public virtual int GetAllocationSize() {
            return allocationSize;
        }

        public virtual string GetFormat() {
            return format;
        }

        public virtual string GetGroup() {
            return group;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.TheVpc.Upa.Field GetField() {
            return field;
        }

        public virtual void BeforePersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            record.Remove(field.GetName());
            record.SetObject(field.GetName(), GetNewValue(field, record, context));
        }

        public virtual void AfterPersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) {
        }

        protected internal virtual object GetNewValue(Net.TheVpc.Upa.Field field, Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            Net.TheVpc.Upa.Entity seq = entity.GetPersistenceUnit().GetEntity(Net.TheVpc.Upa.Impl.PrivateSequence.ENTITY_NAME);
            Net.TheVpc.Upa.Impl.SequenceManager sm = new Net.TheVpc.Upa.Impl.EntitySequenceManager(seq);
            string groupString = Eval(this.group, "{#}", record);
            //        String fieldName = field.getName();
            //        while (true) {
            object nextValue = GetNewValue(sm, groupString, record);
            //            long count = entity.getEntityCount(new Equals(new Var(fieldName), nextValue));
            //            if (count == 0) {
            return nextValue;
        }

        protected internal abstract object GetNewValue(Net.TheVpc.Upa.Impl.SequenceManager sm, string group, Net.TheVpc.Upa.Record record) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        protected internal virtual string Eval(string pattern, object replacement, Net.TheVpc.Upa.Record record) {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.ReplaceNoDollarVars(pattern, new Net.TheVpc.Upa.Impl.Persistence.SequencePatternEvaluator(field, replacement, record));
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (!(o is Net.TheVpc.Upa.Impl.Persistence.TableSequenceIdentityPersister)) {
                return false;
            }
            Net.TheVpc.Upa.Impl.Persistence.TableSequenceIdentityPersister that = (Net.TheVpc.Upa.Impl.Persistence.TableSequenceIdentityPersister) o;
            if (allocationSize != that.allocationSize) {
                return false;
            }
            if (initialValue != that.initialValue) {
                return false;
            }
            if (field != null ? !field.Equals(that.field) : that.field != null) {
                return false;
            }
            if (format != null ? !format.Equals(that.format) : that.format != null) {
                return false;
            }
            if (group != null ? !group.Equals(that.group) : that.group != null) {
                return false;
            }
            if (name != null ? !name.Equals(that.name) : that.name != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            int result = initialValue;
            result = 31 * result + allocationSize;
            result = 31 * result + (format != null ? format.GetHashCode() : 0);
            result = 31 * result + (group != null ? group.GetHashCode() : 0);
            result = 31 * result + (name != null ? name.GetHashCode() : 0);
            result = 31 * result + (field != null ? field.GetHashCode() : 0);
            return result;
        }
    }
}
