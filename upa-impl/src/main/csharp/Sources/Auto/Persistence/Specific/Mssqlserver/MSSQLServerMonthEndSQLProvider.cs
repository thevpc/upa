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
    internal class MSSQLServerMonthEndSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerMonthEndSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMonthEnd)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            string date = "getDate()";
            string count = "0";
            if (@params.Length == 0) {
            } else if (@params.Length == 1) {
                count = "(" + @params[0] + ")";
            } else if (@params.Length == 2) {
                date = "(" + @params[0] + ")";
                count = "(" + @params[0] + ")";
            } else {
                CheckFunctionSignature(new string[] { "date", "diffCount" }, @params);
            }
            count = "(" + count + ")+1";
            return "dateadd(day,0-datepart(day,dateadd(month," + count + "," + date + ")),dateadd(month," + count + "," + date + "))";
        }
    }
}
