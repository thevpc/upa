package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMonthEnd;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyMonthEndSQLProvider extends DerbyFunctionSQLProvider {
    public DerbyMonthEndSQLProvider() {
        super(CompiledMonthEnd.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        String date = "CURRENT_DATE";
        String count = "0";
        if (params.length == 0) {
            //
        } else if (params.length == 1) {
            count = "("+params[0]+")";
        } else if (params.length == 2) {
            date = "("+params[0]+")";
            count = params[0];
        } else {
            checkFunctionSignature(new String[]{"date", "diffCount"}, params);
        }

        String datePlusMonths = "{fn TIMESTAMPADD(SQL_TSI_MONTH,(" + count + "+1) +" + date + ")}";
        String dateMinusDate = "{fn TIMESTAMPADD(SQL_TSI_DAY,(0-1)+" + datePlusMonths + ")}";
        return dateMinusDate;
    }
}
