/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.syntax;

import net.vpc.upa.QLExpressionParser;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.upql.parser.syntax.ParseException;
import net.vpc.upa.impl.upql.parser.syntax.UPQLParser;
import org.junit.Assert;
import org.junit.Test;

import java.io.StringReader;
import net.vpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SyntaxGrammarUC {

    @BeforeClass
    public static void setup() {
        PUUtils.configure();
    }

    @Test
    public void testGrammar() throws ParseException {
        testUPQL("if this.vesselRatio=0 then false elseif this.vesselRatio>this.tcvShore and this.vesselRatio<this.tcvSail then true else false end");
        testUPQL("this.quality>=0");
        testUPQL("if this.quality=true then this.tcvLoad elseif 0>1 then 5 else 0 end");
        testUPQL("Coalesce((Select sum(x.priceTaxFree) From InvoiceDetail x where x.invoiceId=this.invoiceId),0)");
        testUPQL("Coalesce((3),0)");
        testUPQL("Select sum(x.priceTaxFree) From InvoiceDetail x where x.invoiceId=this.invoiceId");
        testUPQL("(Select sum(x.priceTaxFree) From InvoiceDetail x where x.invoiceId=this.invoiceId)");
        testUPQL("(Select * From InvoiceDetail x where x.invoiceId=this.invoiceId)");
        testUPQL("Select o from User o where o.login=:login");
        testUPQL("Select  PRODUCT_FAMILY.ID ID,PRODUCT_FAMILY.NAME NAME,PRODUCT_FAMILY.DESCRIPTION DESCRIPTION,UPA1.ID ID,UPA1.NAME NAME,UPA1.DESCRIPTION DESCRIPTION,UPA2.ID ID,UPA2.NAME NAME,UPA2.DESCRIPTION DESCRIPTION,UPA2.TREE_ENTITY_PATH TREE_ENTITY_PATH,UPA1.TREE_ENTITY_PATH TREE_ENTITY_PATH,PRODUCT_FAMILY.TREE_ENTITY_PATH TREE_ENTITY_PATH From T_PRODUCT_FAMILY PRODUCT_FAMILY Left Join T_PRODUCT_FAMILY UPA1 On (PRODUCT_FAMILY.PARENT_ID = UPA1.ID) Left Join T_PRODUCT_FAMILY UPA2 On (UPA1.PARENT_ID = UPA2.ID) Where ((PRODUCT_FAMILY.NAME = 'Chaussures') And (PRODUCT_FAMILY.PARENT_ID = NULL))");
        testUPQL(
                "Select * from SupplierProduct where SupplierProduct.productId in (select p.id from Product p where p.meetingId =-1) "
                + " and ((SupplierProduct.supplierId =-1)  )");

        testUPQL("Select `Select`.rr from `Update Thing`");
        testUPQL("Select  PRODUCT_FAMILY.ID ID Where PRODUCT_FAMILY.NAME = 'Chaussures' And PRODUCT_FAMILY.PARENT_ID = NULL");
        testUPQL("select a.b.c d, concat(a,b), max(15), if a then b else c end hammadi from me titi inner join  f g on y where x");
        testUPQL("sum(x.priceTaxFree)");
        testUPQL("datepart(year,currentDate())");
        testUPQL("Select sum(x.priceTaxFree * min(x.id) * concat(2,x.id)) From InvoiceDetail x where x.invoiceId=this.invoiceId");
        testUPQL("1");
        testUPQL("select max(15)");
        testUPQL("Select r.`right` x from ProfileRight r inner join UserProfile p on r.profileId=p.id where p.profileId=:userId and p.meetingId=:meetingId");
        testUPQL("Select distinct r.`right` x from ProfileRight r inner join UserProfile p on r.profileId=p.id where p.profileId=:userId and p.meetingId=:meetingId");
        testUPQL("\"Select x from AcademicCourseType x where exists((Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in ((Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false)) and u.enableCourseFeedback=true))\"");
        testUPQL("Select x from AcademicCourseType x where exists(Select u from AcademicCourseAssignment)");
        testUPQL("Select x from AcademicCourseType x where exists((Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in ((Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false)) and u.enableCourseFeedback=true))");
        testUPQL("Select x from AcademicCourseType x where exists((Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in (Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false) and u.enableCourseFeedback=true))");
        testUPQL("Select x from AcademicCourseType x where exists(Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in (Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false) and u.enableCourseFeedback=true)");

        testUPQL("Select u from ApblTeam u where "
                + "1=2 or existss ((Select m from ApblTeamMember m where m.teamId=u.id and m.student.userId=:userId)) "
        );

    }

    private void testUPQL(String upql) {
        System.out.println("testing : " + upql);
        UPQLParser p = new UPQLParser(new StringReader(upql));
        Expression s = p.Any();
        System.out.println("Test 1 PASSED   : " + s);

        QLExpressionParser p2 = UPA.getBootstrap().getFactory().createObject(QLExpressionParser.class);
        s = p2.parse(upql);
        System.out.println("Test 2 PASSED   : " + s);

        //just check if SQL parsing passes
        Assert.assertTrue(true);
    }
}
