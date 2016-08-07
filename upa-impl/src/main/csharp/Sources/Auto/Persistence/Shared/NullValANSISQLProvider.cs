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
     * Time: 17:26:10
     * To change this template use Options | File Templates.
     */
    public class NullValANSISQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.ANSIFunctionSQLProvider {

        public NullValANSISQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNullVal)){

        }


        public override string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            if (@params.Length != 1) {
                throw new System.ArgumentException ("bad number of params for function '" + functionName + "' .\n Error near " + functionName + "(" + Net.Vpc.Upa.Impl.Util.StringUtils.Format(@params) + ")");
            }
            return "Null";
        }
    }
}
