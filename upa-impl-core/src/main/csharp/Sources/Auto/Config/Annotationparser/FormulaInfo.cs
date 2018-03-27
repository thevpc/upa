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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:47 AM
     */
    internal class FormulaInfo {

        public string expression;

        public System.Type type;

        public int? order;

        public Net.Vpc.Upa.FormulaType formulaType;

        public bool specified = false;

        public int configOrder = System.Int32.MinValue;

        public virtual void MergeFormula(Net.Vpc.Upa.Config.Decoration gid) {
            if (gid.GetConfig().GetOrder() >= configOrder) {
                specified = true;
                if (gid.GetInt("formulaOrder") != System.Int32.MinValue) {
                    order = gid.GetInt("formulaOrder");
                }
                if ((gid.GetString("value")).Length > 0) {
                    expression = gid.GetString("value");
                    type = null;
                }
                if (!gid.GetType("custom").Equals(typeof(object)) && !gid.GetType("custom").Equals(typeof(Net.Vpc.Upa.Formula))) {
                    expression = null;
                    type = gid.GetType("custom");
                }
                configOrder = gid.GetConfig().GetOrder();
            }
        }
    }
}
