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



using System.Linq;
namespace Net.Vpc.Upa.Filters
{


    public abstract class AbstractFieldFilter : Net.Vpc.Upa.Filters.RichFieldFilter {

        public abstract bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        public abstract bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        public static Net.Vpc.Upa.Filters.AbstractFieldFilter ToAbstractFieldFilter(Net.Vpc.Upa.Filters.FieldFilter filter) {
            if (filter == null) {
                return new Net.Vpc.Upa.Filters.FieldAnyFilter();
            } else if (filter is Net.Vpc.Upa.Filters.AbstractFieldFilter) {
                return (Net.Vpc.Upa.Filters.AbstractFieldFilter) filter;
            } else {
                return new Net.Vpc.Upa.Filters.FieldFilterAdapter(filter);
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Field> Filter(System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> v = new System.Collections.Generic.List<Net.Vpc.Upa.Field>((fields).Count);
            foreach (Net.Vpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add(field);
                }
            }
            return v;
        }

        public virtual Net.Vpc.Upa.Field[] Filter(Net.Vpc.Upa.Field[] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> v = new System.Collections.Generic.List<Net.Vpc.Upa.Field>(fields.Length);
            foreach (Net.Vpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add(field);
                }
            }
            return v.ToArray();
        }

        public virtual Net.Vpc.Upa.PrimitiveField[] Filter(Net.Vpc.Upa.PrimitiveField[] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>(fields.Length);
            foreach (Net.Vpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add((Net.Vpc.Upa.PrimitiveField) field);
                }
            }
            return v.ToArray();
        }

        public virtual Net.Vpc.Upa.CompoundField[] Filter(Net.Vpc.Upa.CompoundField[] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.CompoundField> v = new System.Collections.Generic.List<Net.Vpc.Upa.CompoundField>(fields.Length);
            foreach (Net.Vpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add((Net.Vpc.Upa.CompoundField) field);
                }
            }
            return v.ToArray();
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            return true;
        }


        public override int GetHashCode() {
            return 731;
        }


        public virtual Net.Vpc.Upa.Filters.RichFieldFilter And(Net.Vpc.Upa.Filters.FieldFilter filter) {
            return Net.Vpc.Upa.Filters.FieldAndFilter.And(this, filter);
        }


        public virtual Net.Vpc.Upa.Filters.RichFieldFilter AndNot(Net.Vpc.Upa.Filters.FieldFilter filter) {
            return Net.Vpc.Upa.Filters.FieldAndFilter.And(this, Net.Vpc.Upa.Filters.FieldFilters.As(filter).Negate());
        }


        public virtual Net.Vpc.Upa.Filters.RichFieldFilter Or(Net.Vpc.Upa.Filters.FieldFilter filter) {
            return Net.Vpc.Upa.Filters.FieldOrFilter.Or(this, filter);
        }


        public virtual Net.Vpc.Upa.Filters.RichFieldFilter OrNot(Net.Vpc.Upa.Filters.FieldFilter filter) {
            return Net.Vpc.Upa.Filters.FieldOrFilter.Or(this, Net.Vpc.Upa.Filters.FieldFilters.As(filter).Negate());
        }


        public virtual Net.Vpc.Upa.Filters.RichFieldFilter Negate() {
            return new Net.Vpc.Upa.Filters.FieldReverseFilter(this);
        }
    }
}
