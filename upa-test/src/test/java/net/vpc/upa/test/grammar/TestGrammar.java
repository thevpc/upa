/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.test.grammar;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.parser.syntax.ParseException;
import net.vpc.upa.impl.uql.parser.syntax.UQLParser;
import org.junit.Test;

import java.io.StringReader;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class TestGrammar {

    @Test
    public void testGrammar() throws ParseException {
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
        testUQL("Select distinct r.`right` x from ProfileRight r inner join UserProfile p on r.profileId=p.id where p.profileId=:userId and p.meetingId=:meetingId");
        System.out.println("Okkay");
    }

    private void testUQL(String uql) {
        System.out.println("testing : "+uql);
        UQLParser p = new UQLParser(new StringReader(uql));
        Expression s = p.Any();
        System.out.println("found   : "+s);
        System.out.println();
    }
}
