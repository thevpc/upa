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
namespace Net.TheVpc.Upa.Filters
{


    public abstract class AbstractFieldFilter : Net.TheVpc.Upa.Filters.RichFieldFilter {

        public abstract bool AcceptDynamic() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        public abstract bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        public static Net.TheVpc.Upa.Filters.AbstractFieldFilter ToAbstractFieldFilter(Net.TheVpc.Upa.Filters.FieldFilter filter) {
            if (filter == null) {
                return new Net.TheVpc.Upa.Filters.FieldAnyFilter();
            } else if (filter is Net.TheVpc.Upa.Filters.AbstractFieldFilter) {
                return (Net.TheVpc.Upa.Filters.AbstractFieldFilter) filter;
            } else {
                return new Net.TheVpc.Upa.Filters.FieldFilterAdapter(filter);
            }
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Field> Filter(System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> v = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>((fields).Count);
            foreach (Net.TheVpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add(field);
                }
            }
            return v;
        }

        public virtual Net.TheVpc.Upa.Field[] Filter(Net.TheVpc.Upa.Field[] fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> v = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(fields.Length);
            foreach (Net.TheVpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add(field);
                }
            }
            return v.ToArray();
        }

        public virtual Net.TheVpc.Upa.PrimitiveField[] Filter(Net.TheVpc.Upa.PrimitiveField[] fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField> v = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>(fields.Length);
            foreach (Net.TheVpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add((Net.TheVpc.Upa.PrimitiveField) field);
                }
            }
            return v.ToArray();
        }

        public virtual Net.TheVpc.Upa.CompoundField[] Filter(Net.TheVpc.Upa.CompoundField[] fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.TheVpc.Upa.CompoundField> v = new System.Collections.Generic.List<Net.TheVpc.Upa.CompoundField>(fields.Length);
            foreach (Net.TheVpc.Upa.Field field in fields) {
                if (Accept(field)) {
                    v.Add((Net.TheVpc.Upa.CompoundField) field);
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


        public virtual Net.TheVpc.Upa.Filters.RichFieldFilter And(Net.TheVpc.Upa.Filters.FieldFilter filter) {
            return Net.TheVpc.Upa.Filters.FieldAndFilter.And(this, filter);
        }


        public virtual Net.TheVpc.Upa.Filters.RichFieldFilter AndNot(Net.TheVpc.Upa.Filters.FieldFilter filter) {
            return Net.TheVpc.Upa.Filters.FieldAndFilter.And(this, Net.TheVpc.Upa.Filters.FieldFilters.As(filter).Negate());
        }


        public virtual Net.TheVpc.Upa.Filters.RichFieldFilter Or(Net.TheVpc.Upa.Filters.FieldFilter filter) {
            return Net.TheVpc.Upa.Filters.FieldOrFilter.Or(this, filter);
        }


        public virtual Net.TheVpc.Upa.Filters.RichFieldFilter OrNot(Net.TheVpc.Upa.Filters.FieldFilter filter) {
            return Net.TheVpc.Upa.Filters.FieldOrFilter.Or(this, Net.TheVpc.Upa.Filters.FieldFilters.As(filter).Negate());
        }


        public virtual Net.TheVpc.Upa.Filters.RichFieldFilter Negate() {
            return new Net.TheVpc.Upa.Filters.FieldReverseFilter(this);
        }
    }
}
