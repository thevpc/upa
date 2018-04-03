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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 7:22 PM
     * To change this template use File | Settings | File Templates.
     */
    public class FieldImplTypeFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private System.Type type;

        public FieldImplTypeFilter(System.Type type) {
            this.type = type;
        }


        public override bool AcceptDynamic() {
            return typeof(Net.Vpc.Upa.DynamicField).IsAssignableFrom(type);
        }


        public override bool Accept(Net.Vpc.Upa.Field f) {
            return type.IsAssignableFrom(f.GetType());
        }
    }
}
