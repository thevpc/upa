/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.uql;

import java.util.logging.Logger;
import net.vpc.upa.QLExpressionParser;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.test.EnumUC;
import net.vpc.upa.test.util.LogUtils;
import org.junit.Test;

/**
 *
 * @author vpc
 */
public class UQLExpressionUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(EnumUC.class.getName());

    @Test
    public void crudMixedRecordsAndEntities() {
        QLExpressionParser p = UPA.getBootstrapFactory().createObject(QLExpressionParser.class);
        Expression e = p.parse("select * from autres where EMAIL<>null and NOT EMAIL like '*1*'");
//        Expression e = p.parse("select * from T where 1=1 and not(1)");
        System.out.println(e);
    }

}
