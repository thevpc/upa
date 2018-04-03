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
     * Created by vpc on 1/4/14.
     */
    internal class FieldDynamicFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        public FieldDynamicFilter() {
        }


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return true;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (f is Net.Vpc.Upa.DynamicField);
        }


        public override string ToString() {
            return "dynamic";
        }
    }
}
