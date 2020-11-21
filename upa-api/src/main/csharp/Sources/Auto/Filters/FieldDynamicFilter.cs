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
     * Created by vpc on 1/4/14.
     */
    internal class FieldDynamicFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        public FieldDynamicFilter() {
        }


        public override bool AcceptDynamic() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return true;
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (f is Net.TheVpc.Upa.DynamicField);
        }


        public override string ToString() {
            return "dynamic";
        }
    }
}
