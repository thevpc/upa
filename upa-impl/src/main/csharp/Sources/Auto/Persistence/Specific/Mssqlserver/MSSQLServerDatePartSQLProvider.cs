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
    internal class MSSQLServerDatePartSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerDatePartSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDatePart)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            CheckFunctionSignature(new string[] { "format", "count" }, @params);
            string format = @params[0];
            string date = "(" + @params[1] + ")";
            if ("date_time".Equals(format)) {
                return "convert(char(19)," + date + ",120)";
            } else if ("time".Equals(format)) {
                return "convert(char(8)," + date + ",8)";
            } else if ("date".Equals(format)) {
                return "convert(char(10)," + date + ",120)";
            } else if ("year".Equals(format)) {
                return "year(" + date + ")";
            } else if ("day_of_month".Equals(format)) {
                return "day(" + date + ")";
            } else if ("day_of_year".Equals(format)) {
                return "datepart(dayofyear," + date + ")";
            } else if ("day_of_week".Equals(format)) {
                return "datepart(weekday," + date + ")";
            } else if ("day_of_week_name".Equals(format)) {
                return "datename(weekday," + date + ")";
            } else if ("month".Equals(format)) {
                return "month(" + date + ")";
            } else if ("month_name".Equals(format)) {
                return "datename(month," + date + ")";
            } else if ("hour".Equals(format)) {
                return "datepart(hour," + date + ")";
            } else if ("minute".Equals(format)) {
                return "datepart(minute," + date + ")";
            } else if ("second".Equals(format)) {
                return "datepart(second," + date + ")";
            }
            throw new System.Exception("Adapter : incorrect format '" + format + "' for function 'datepart'");
        }
    }
}
