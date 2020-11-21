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
     * Time: 7:22 PM
     * To change this template use File | Settings | File Templates.
     */
    public class FieldDataTypeFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        private System.Type type;

        private bool dynamic;

        public FieldDataTypeFilter(System.Type type, bool dynamic) {
            this.type = type;
            this.dynamic = dynamic;
        }


        public override bool AcceptDynamic() {
            return dynamic;
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) {
            return type.IsAssignableFrom(f.GetDataType().GetType());
        }
    }
}
