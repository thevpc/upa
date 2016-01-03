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



namespace Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 17:26:10
     * To change this template use Options | File Templates.
     */
    internal class MSSQLServerDecodeSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerDecodeSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDecode)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            if (@params.Length < 3 || @params.Length % 2 == 0) {
                return Error("bad number of params", @params);
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder("case");
            sb.Append("(").Append(@params[0]).Append(")");
            for (int i = 1; i < @params.Length; i += 2) {
                if (i == @params.Length - 1) {
                    sb.Append(" else ").Append("(").Append(@params[i]).Append(")").Append(" end");
                } else {
                    sb.Append(" when ").Append("(").Append(@params[i]).Append(")").Append(" then ").Append("(").Append(@params[i + 1]).Append(")");
                }
            }
            return sb.ToString();
        }
    }
}
