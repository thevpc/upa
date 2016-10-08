/*
 * To change this license header, choose License Headers in Project Properties.
 *
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
 * @author taha.bensalah@gmail.com
 */
public class UQLExpressionUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(EnumUC.class.getName());

    @Test
    public void crudMixedRecordsAndEntities() {
        QLExpressionParser p = UPA.getBootstrap().getFactory().createObject(QLExpressionParser.class);
        String q="Select u from ApblTeam u where u.session.status != :status and  ( " +
                "exists ((Select m from ApblTeamMember m where m.teamId=u.id and m.student.userId=:userId)) " +
                "or exists ((Select m from ApblCoaching m where m.teamId=u.id and m.teacher.userId=:userId)) " +
                "or exists ((Select m from ApblProject m where m.ownerId=:userId))" +
                "or u.ownerId=:userId " +
                ")";
        Expression e = p.parse(q);
//        Expression e = p.parse("select * from autres where EMAIL<>null and NOT EMAIL like '*1*'");
//        Expression e = p.parse("select * from T where 1=1 and not(1)");
        System.out.println(e);
    }

}
