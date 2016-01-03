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
    public class MSSQLServerConcatSQLProvider : Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerFunctionSQLProvider {

        public MSSQLServerConcatSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            if (@params.Length < 2) {
                return Error("requieres at least 2 arguments", @params);
            } else {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("(");
                for (int i = 0; i < @params.Length; i++) {
                    if (i > 0) {
                        sb.Append('+');
                    }
                    sb.Append("convert(varchar(8000),").Append("(").Append(@params[i]).Append(")").Append(",120)");
                }
                sb.Append(")");
                return sb.ToString();
            }
        }
    }
}
