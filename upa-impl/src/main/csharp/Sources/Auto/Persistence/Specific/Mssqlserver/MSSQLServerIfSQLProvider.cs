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
    internal class MSSQLServerIfSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerIfSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledIf)){

        }

        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            if (@params.Length < 3 || @params.Length % 2 == 0) {
                return Error("bad number of params", @params);
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder("case");
            for (int i = 0; i < @params.Length; i += 2) {
                string pi = "(" + @params[i] + ")";
                if (i == @params.Length - 1) {
                    sb.Append(" else ").Append(pi).Append(" end");
                } else {
                    string pi1 = "(" + @params[i + 1] + ")";
                    sb.Append(" when ").Append(pi).Append(" then ").Append(pi1);
                }
            }
            return sb.ToString();
        }
    }
}
