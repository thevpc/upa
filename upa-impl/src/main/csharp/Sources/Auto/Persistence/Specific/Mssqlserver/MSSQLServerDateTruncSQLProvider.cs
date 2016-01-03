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
    internal class MSSQLServerDateTruncSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerDateTruncSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDateTrunc)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            CheckFunctionSignature(new string[] { "format", "date" }, @params);
            string format = @params[0];
            string date1 = "(" + @params[1] + ")";
            //TODO
            if ("date".Equals(format)) {
                return "trunc(" + date1 + ",'HH')";
            } else if ("hour".Equals(format)) {
                return "trunc(" + date1 + ",'HH')";
            } else if ("month".Equals(format)) {
                return "trunc(" + date1 + ",'MM')";
            } else if ("year".Equals(format)) {
                return "trunc(" + date1 + ",'YY')";
            }
            //        if("date_time".equals(format)){
            //            return "convert(char(19),"+date+",120)";
            //        }else if("time".equals(format)){
            //            return "convert(char(8),"+date+",8)";
            //        }else if("date".equals(format)){
            //            return "convert(char(10),"+date+",120)";
            //        }else if("year".equals(format)){
            //            return "year("+date+")";
            //        }else if("day_of_month".equals(format)){
            //            return "day("+date+")";
            //        }else if("day_of_year".equals(format)){
            //            return "datepart(dayofyear,"+date+")";
            //        }else if("day_of_week".equals(format)){
            //            return "datepart(weekday,"+date+")";
            //        }else if("day_of_week_name".equals(format)){
            //            return "datename(weekday,"+date+")";
            //        }else if("month".equals(format)){
            //            return "month("+date+")";
            //        }else if("month_name".equals(format)){
            //            return "datename(month,"+date+")";
            //        }else if("hour".equals(format)){
            //            return "datepart(hour,"+date+")";
            //        }else if("minute".equals(format)){
            //            return "datepart(minute,"+date+")";
            //        }else if("second".equals(format)){
            //            return "datepart(second,"+date+")";
            //        }
            throw new System.Exception("Adapter : incorrect format '" + format + "' for function 'datepart'");
        }
    }
}
