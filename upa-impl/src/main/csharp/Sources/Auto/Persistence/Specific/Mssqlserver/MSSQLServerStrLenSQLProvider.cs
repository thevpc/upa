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
     * Time: 17:17:34
     * To change this template use Options | File Templates.
     */
    public class MSSQLServerStrLenSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerStrLenSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledStrLen)){

        }

        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            CheckFunctionSignature(1, @params);
            return "len(" + @params[0] + ")";
        }
    }
}
