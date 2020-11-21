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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 17:17:34
     * To change this template use Options | File Templates.
     */
    public class AvgANSISQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.ANSIFunctionSQLProvider {

        public AvgANSISQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            if (@params.Length != 1) {
                throw new System.ArgumentException ("function '" + functionName + "' requieres 1 argument.\n Error near " + functionName + "(" + Net.TheVpc.Upa.Impl.Util.StringUtils.Format(@params) + ")");
            } else {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("Avg(");
                sb.Append(@params[0]);
                sb.Append(")");
                return sb.ToString();
            }
        }
    }
}
