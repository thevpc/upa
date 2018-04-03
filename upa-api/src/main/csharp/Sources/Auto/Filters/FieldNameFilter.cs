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



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/25/12 11:54 AM
     */
    public class FieldNameFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private System.Collections.Generic.HashSet<string> acceptedFields = new System.Collections.Generic.HashSet<string>();

        private System.Collections.Generic.HashSet<string> nonAcceptedFields;

        private bool absoluteNames;

        private bool acceptDynamic;

        public FieldNameFilter(params string [] acceptedFields) {
            this.acceptedFields = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(acceptedFields));
        }

        public FieldNameFilter(System.Collections.Generic.ICollection<string> acceptedFields) {
            this.acceptedFields = new System.Collections.Generic.HashSet<string>(acceptedFields);
        }


        public override bool Accept(Net.Vpc.Upa.Field field) {
            string f = GetFieldName(field);
            return !((acceptedFields != null && !acceptedFields.Contains(f)) || (nonAcceptedFields != null && nonAcceptedFields.Contains(f)));
        }

        private string GetFieldName(Net.Vpc.Upa.Field field) {
            return (absoluteNames) ? field.GetAbsoluteName() : field.GetName();
        }


        public override bool AcceptDynamic() {
            return acceptDynamic;
        }

        public virtual bool IsAcceptDynamic() {
            return acceptDynamic;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetAcceptDynamic(bool acceptDynamic) {
            this.acceptDynamic = acceptDynamic;
            return this;
        }

        public virtual bool IsAbsoluteNames() {
            return absoluteNames;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetAbsoluteNames(bool absoluteNames) {
            this.absoluteNames = absoluteNames;
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetAccepted(params string [] f) {
            if (acceptedFields == null) {
                acceptedFields = new System.Collections.Generic.HashSet<string>();
            }
            foreach (string s in f) {
                if (s != null) {
                    acceptedFields.Add(s);
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetAccepted(params Net.Vpc.Upa.Field [] f) {
            if (acceptedFields == null) {
                acceptedFields = new System.Collections.Generic.HashSet<string>();
            }
            foreach (Net.Vpc.Upa.Field s in f) {
                if (s != null) {
                    acceptedFields.Add(GetFieldName(s));
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetAccepted(System.Collections.Generic.ICollection<string> f) {
            if (acceptedFields == null) {
                acceptedFields = new System.Collections.Generic.HashSet<string>();
            }
            foreach (string ff in f) {
                acceptedFields.Add(ff);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetRejected(params string [] f) {
            if (acceptedFields == null) {
                nonAcceptedFields = new System.Collections.Generic.HashSet<string>();
            }
            foreach (string s in f) {
                if (s != null) {
                    nonAcceptedFields.Add(s);
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldNameFilter SetRejected(System.Collections.Generic.ICollection<string> f) {
            if (acceptedFields == null) {
                nonAcceptedFields = new System.Collections.Generic.HashSet<string>();
            }
            foreach (string s in f) {
                if (s != null) {
                    nonAcceptedFields.Add(s);
                }
            }
            return this;
        }


        public override string ToString() {
            return (GetType()).Name + "(" + acceptedFields + ", ! " + nonAcceptedFields + ")";
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Filters.FieldNameFilter that = (Net.Vpc.Upa.Filters.FieldNameFilter) o;
            if (absoluteNames != that.absoluteNames) return false;
            if (acceptDynamic != that.acceptDynamic) return false;
            if (acceptedFields != null ? !acceptedFields.Equals(that.acceptedFields) : that.acceptedFields != null) return false;
            if (nonAcceptedFields != null ? !nonAcceptedFields.Equals(that.nonAcceptedFields) : that.nonAcceptedFields != null) return false;
            return true;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (acceptedFields != null ? acceptedFields.GetHashCode() : 0);
            result = 31 * result + (nonAcceptedFields != null ? nonAcceptedFields.GetHashCode() : 0);
            result = 31 * result + (absoluteNames ? 1 : 0);
            result = 31 * result + (acceptDynamic ? 1 : 0);
            return result;
        }
    }
}
