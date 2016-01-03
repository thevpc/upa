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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 17:17:34
     * To change this template use Options | File Templates.
     */
    public class CoalesceANSISQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.ANSIFunctionSQLProvider {

        public CoalesceANSISQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            if (@params.Length < 1) {
                throw new System.ArgumentException ("function '" + functionName + "' requieres at least 1 argument.\n Error near " + functionName + "(" + Net.Vpc.Upa.Impl.Util.Strings.Format(@params) + ")");
            } else {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("Coalesce(");
                for (int i = 0; i < @params.Length; i++) {
                    if (i > 0) {
                        sb.Append(',');
                    }
                    sb.Append("(");
                    sb.Append(@params[i]);
                    sb.Append(")");
                }
                sb.Append(")");
                return sb.ToString();
            }
        }
    }
}
