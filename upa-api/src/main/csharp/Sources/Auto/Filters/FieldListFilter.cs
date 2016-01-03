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



namespace Net.Vpc.Upa.Filters
{


    public class FieldListFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private System.Collections.Generic.HashSet<Net.Vpc.Upa.Field> acceptedFields;

        private System.Collections.Generic.HashSet<Net.Vpc.Upa.Field> nonAcceptedFields;

        private bool acceptDynamic;

        public FieldListFilter() {
        }

        public FieldListFilter(params Net.Vpc.Upa.Field [] accepted) {
            SetAccepted(accepted);
        }

        public FieldListFilter(System.Collections.Generic.IList<Net.Vpc.Upa.Field> accepted) {
            SetAccepted(accepted);
        }

        public override bool Accept(Net.Vpc.Upa.Field f) {
            return !((acceptedFields != null && !acceptedFields.Contains(f)) || (nonAcceptedFields != null && nonAcceptedFields.Contains(f)));
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetAccepted(Net.Vpc.Upa.PrimitiveField[] f) {
            System.Collections.Generic.ICollection<Net.Vpc.Upa.Field> a = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            foreach (Net.Vpc.Upa.PrimitiveField primitiveField in f) {
                a.Add(primitiveField);
            }
            //a.addAll(Arrays.asList(f));
            return SetAccepted(a);
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetAccepted(Net.Vpc.Upa.Field[] f) {
            return SetAccepted(new System.Collections.Generic.List<Net.Vpc.Upa.Field>(f));
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetAccepted(System.Collections.Generic.ICollection<Net.Vpc.Upa.Field> f) {
            if (f != null) {
                foreach (Net.Vpc.Upa.Field ff in f) {
                    SetAccepted(ff);
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetRejected(Net.Vpc.Upa.PrimitiveField[] f) {
            System.Collections.Generic.ICollection<Net.Vpc.Upa.Field> a = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            foreach (Net.Vpc.Upa.PrimitiveField primitiveField in f) {
                a.Add(primitiveField);
            }
            return SetRejected(a);
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter Reject(Net.Vpc.Upa.Field[] f) {
            return SetRejected(new System.Collections.Generic.List<Net.Vpc.Upa.Field>(f));
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetRejected(System.Collections.Generic.ICollection<Net.Vpc.Upa.Field> f) {
            if (f != null) {
                foreach (Net.Vpc.Upa.Field ff in f) {
                    SetRejected(ff);
                }
            }
            return this;
        }


        public override string ToString() {
            return "FieldFilter(" + acceptedFields + ", ! " + nonAcceptedFields + ")";
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetAccepted(Net.Vpc.Upa.Field f) {
            if (f != null) {
                if (f is Net.Vpc.Upa.DynamicField) {
                    acceptDynamic = true;
                }
                if (acceptedFields == null) {
                    acceptedFields = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();
                }
                acceptedFields.Add(f);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetRejected(Net.Vpc.Upa.Field f) {
            if (f != null) {
                if (f is Net.Vpc.Upa.DynamicField) {
                    acceptDynamic = true;
                }
                if (nonAcceptedFields == null) {
                    nonAcceptedFields = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();
                }
                nonAcceptedFields.Add(f);
            }
            return this;
        }

        public virtual bool IsAcceptDynamic() {
            return acceptDynamic;
        }

        public virtual Net.Vpc.Upa.Filters.FieldListFilter SetAcceptDynamic(bool acceptDynamic) {
            this.acceptDynamic = acceptDynamic;
            return this;
        }


        public override bool AcceptDynamic() {
            return acceptDynamic;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Filters.FieldListFilter that = (Net.Vpc.Upa.Filters.FieldListFilter) o;
            if (acceptDynamic != that.acceptDynamic) return false;
            if (acceptedFields != null ? !acceptedFields.Equals(that.acceptedFields) : that.acceptedFields != null) return false;
            if (nonAcceptedFields != null ? !nonAcceptedFields.Equals(that.nonAcceptedFields) : that.nonAcceptedFields != null) return false;
            return true;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (acceptedFields != null ? acceptedFields.GetHashCode() : 0);
            result = 31 * result + (nonAcceptedFields != null ? nonAcceptedFields.GetHashCode() : 0);
            result = 31 * result + (acceptDynamic ? 1 : 0);
            return result;
        }
    }
}
