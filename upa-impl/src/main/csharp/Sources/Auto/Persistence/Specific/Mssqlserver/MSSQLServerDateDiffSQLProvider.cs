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
    internal class MSSQLServerDateDiffSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerDateDiffSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            CheckFunctionSignature(new string[] { "format", "start_date", "end_date" }, @params);
            string format = @params[0];
            string date1 = @params[1];
            string date2 = @params[2];
            if ("week".Equals(format)) {
            } else if ("day".Equals(format)) {
            } else if ("year".Equals(format)) {
            } else if ("day_of_year".Equals(format)) {
                format = "dayofyear";
            } else if ("month".Equals(format)) {
            } else if ("hour".Equals(format)) {
            } else if ("minute".Equals(format)) {
            } else if ("second".Equals(format)) {
            } else if ("millisecond".Equals(format)) {
            } else {
                throw new System.Exception("Adapter : incorrect format '" + format + "' for function 'datediff'");
            }
            return "datediff(" + format + ",(" + date1 + "),(" + date2 + "))";
        }
    }
}
