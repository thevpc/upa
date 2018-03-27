/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.syntax;

import net.vpc.upa.QLExpressionParser;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.parser.syntax.ParseException;
import net.vpc.upa.impl.uql.parser.syntax.UQLParser;
import org.junit.Assert;
import org.junit.Test;

import java.io.StringReader;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class TestGrammar {

    @Test
    public void testGrammar() throws ParseException {
//        testUQL("if this.vesselRatio=0 then false elseif this.vesselRatio>this.tcvShore and this.vesselRatio<this.tcvSail then true else false end");
        testUQL("this.quality>=0");
//        testUQL("if this.quality=true then this.tcvLoad elseif 0>1 then 5 else 0 end");
//        testUQL("Coalesce((Select sum(x.priceTaxFree) From InvoiceDetail x where x.invoiceId=this.invoiceId),0)");
//        testUQL("Coalesce((3),0)");
//        testUQL("Select sum(x.priceTaxFree) From InvoiceDetail x where x.invoiceId=this.invoiceId");
//        testUQL("(Select sum(x.priceTaxFree) From InvoiceDetail x where x.invoiceId=this.invoiceId)");
//        testUQL("(Select * From InvoiceDetail x where x.invoiceId=this.invoiceId)");
//        testUQL("Select o from User o where o.login=:login");
//        testUQL("Select  PRODUCT_FAMILY.ID ID,PRODUCT_FAMILY.NAME NAME,PRODUCT_FAMILY.DESCRIPTION DESCRIPTION,UPA1.ID ID,UPA1.NAME NAME,UPA1.DESCRIPTION DESCRIPTION,UPA2.ID ID,UPA2.NAME NAME,UPA2.DESCRIPTION DESCRIPTION,UPA2.TREE_ENTITY_PATH TREE_ENTITY_PATH,UPA1.TREE_ENTITY_PATH TREE_ENTITY_PATH,PRODUCT_FAMILY.TREE_ENTITY_PATH TREE_ENTITY_PATH From T_PRODUCT_FAMILY PRODUCT_FAMILY Left Join T_PRODUCT_FAMILY UPA1 On (PRODUCT_FAMILY.PARENT_ID = UPA1.ID) Left Join T_PRODUCT_FAMILY UPA2 On (UPA1.PARENT_ID = UPA2.ID) Where ((PRODUCT_FAMILY.NAME = 'Chaussures') And (PRODUCT_FAMILY.PARENT_ID = NULL))");
//        testUQL(
//                "Select * from SupplierProduct where SupplierProduct.productId in (select p.id from Product p where p.meetingId =-1) "
//                + " and ((SupplierProduct.supplierId =-1)  )");
//
//        testUQL("Select `Select`.rr from `Update Thing`");
//        testUQL("Select  PRODUCT_FAMILY.ID ID Where PRODUCT_FAMILY.NAME = 'Chaussures' And PRODUCT_FAMILY.PARENT_ID = NULL");
//        testUQL("select a.b.c d, concat(a,b), max(15), if a then b else c end hammadi from me titi inner join  f g on y where x");
//        testUQL("sum(x.priceTaxFree)");
//        testUQL("datepart(year,currentDate())");
//        testUQL("Select sum(x.priceTaxFree * min(x.id) * concat(2,x.id)) From InvoiceDetail x where x.invoiceId=this.invoiceId");
//        testUQL("1");
//        testUQL("select max(15)");
//        testUQL("Select r.`right` x from ProfileRight r inner join UserProfile p on r.profileId=p.id where p.profileId=:userId and p.meetingId=:meetingId");
//        testUQL("Select distinct r.`right` x from ProfileRight r inner join UserProfile p on r.profileId=p.id where p.profileId=:userId and p.meetingId=:meetingId");
//        testUQL("\"Select x from AcademicCourseType x where exists((Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in ((Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false)) and u.enableCourseFeedback=true))\"");
//        testUQL("Select x from AcademicCourseType x where exists(Select u from AcademicCourseAssignment)");
//        testUQL("Select x from AcademicCourseType x where exists((Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in ((Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false)) and u.enableCourseFeedback=true))");
//        testUQL("Select x from AcademicCourseType x where exists((Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in (Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false) and u.enableCourseFeedback=true))");
//        testUQL("Select x from AcademicCourseType x where exists(Select u from AcademicCourseAssignment u  where u.teacherId=:teacherId  and  u.courseTypeId=x.id  and u.id in (Select f.courseId from AcademicFeedback f where 1=1  and f.archived=false) and u.enableCourseFeedback=true)");
//
//        testUQL("Select u from ApblTeam u where " +
//                "1=2 or existss ((Select m from ApblTeamMember m where m.teamId=u.id and m.student.userId=:userId)) "
//                );

    }

    private void testUQL(String uql) {
        System.out.println("testing : "+uql);
        UQLParser p = new UQLParser(new StringReader(uql));
        Expression s = p.Any();
        System.out.println("Test 1 PASSED   : "+s);

        QLExpressionParser p2 = UPA.getBootstrap().getFactory().createObject(QLExpressionParser.class);
        s = p2.parse(uql);
        System.out.println("Test 2 PASSED   : "+s);

        //just check if SQL parsing passes
        Assert.assertTrue(true);
    }
}
