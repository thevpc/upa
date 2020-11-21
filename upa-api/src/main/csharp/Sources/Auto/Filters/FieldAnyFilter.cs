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



namespace Net.TheVpc.Upa.Filters
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 7:29 PM
     * To change this template use File | Settings | File Templates.
     */
    public class FieldAnyFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        public FieldAnyFilter() {
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) {
            return true;
        }


        public override bool AcceptDynamic() {
            return true;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            return true;
        }


        public override int GetHashCode() {
            return 732;
        }


        public override string ToString() {
            return "true";
        }
    }
}
