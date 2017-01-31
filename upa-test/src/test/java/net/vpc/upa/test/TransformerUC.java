package net.vpc.upa.test;

import net.vpc.upa.*;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.config.ManyToOne;
import net.vpc.upa.expressions.*;
import net.vpc.upa.test.util.LogUtils;
import net.vpc.upa.test.util.PUUtils;
import org.junit.Test;

import java.util.HashMap;
import java.util.Map;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class TransformerUC {

    static {
        LogUtils.prepare();
    }

    private static final Logger log = Logger.getLogger(TransformerUC.class.getName());

    @Test
    public void crudMixedDocumentsAndEntities() {
        String puId = getClass().getName();
        log.fine("********************************************");
        log.fine(" " + puId);
        log.fine("********************************************");
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(getClass());
//        pu.scan(null);
        pu.addEntity(Person.class);
        pu.addEntity(Phone.class);
        pu.start();

        Business bo = UPA.makeSessionAware(new Business());
        bo.testQuery2();
    }

    public static class Business {

        public void testQuery() {
            final PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            String query = "(that.phone2.id=2 or that.phone2.id=3) and (that.phone2.id=2 or that.phone2.id=3)";
            final Map<String, Object> vals = new HashMap<String, Object>();
            Person person = new Person();
            Phone phone2 = new Phone();
            phone2.setId(4);
            person.setPhone2(phone2);
            vals.put("that", person);

            Expression e = pu.getExpressionManager().simplifyExpression(query, vals);
            e = pu.getExpressionManager().createEvaluator().evalObject(e, null);
            System.out.println(e);
        }

        public void testQuery2() {
            final PersistenceUnit pu = UPA.getPersistenceGroup().getPersistenceUnit();
            String query = "concat('width:60px;','background:'," +
                    "if   (this.phone2.value like '%UE1') then '{bgcolor1}' " +
                    " elseif (this.phone2.value like '%UE2') then '{bgcolor2}' " +
                    " elseif (this.phone2.value like '%UE3') then '{bgcolor3}' " +
                    " elseif (this.phone2.value like '%UE4') then '{bgcolor4}' " +
                    " elseif (this.phone2.value like '%UE5') then '{bgcolor5}' " +
                    " elseif (this.phone2.value like '%UE6') then '{bgcolor6}' " +
                    " elseif (this.phone2.value like '%UE7') then '{bgcolor7}' " +
                    " elseif (this.phone2.value like '%UE8') then '{bgcolor8}' " +
                    "else '?'" +
                    "end)";
            final Map<String, Object> vals = new HashMap<String, Object>();
            Person person = new Person();
            Phone phone2 = new Phone();
            phone2.setId(4);
            phone2.setValue("19-UE8");
            person.setPhone2(phone2);
            vals.put("this", person);

            ExpressionManager expressionManager = pu.getExpressionManager();
            Expression e = expressionManager.simplifyExpression(query, vals);
            e = expressionManager.createEvaluator().evalObject(e,null);
            System.out.println(e);
        }


    }

    @Ignore
    @net.vpc.upa.config.Entity
    public static class Person {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;

        private String name;

        /**
         * create relation idPhone1
         */
        @ManyToOne(targetEntityType = Phone.class)
        private Integer idPhone1;

        /**
         * create relation phone2 a new field "phone2Id" will be created
         */
        @ManyToOne
        private Phone phone2;

        /**
         * create relation phone3 mapped to idPhone3 updates are considered on
         * idPhone3 (and not phone3)
         */
        @ManyToOne(targetEntityType = Phone.class, mappedTo = "phone3")
        private Integer idPhone3;

        private Phone phone3;

        /**
         * create relation mapped to idPhone4 updates are considered on phone4
         * (and not idPhone4)
         */
        private Integer idPhone4;

        @ManyToOne(mappedTo = "idPhone4")
        private Phone phone4;

        /**
         * create relation without @ManyToOne annotation. a new field "phone5Id"
         * will be created
         */
        private Phone phone5;

        public Integer getId() {
            return id;
        }

        public Phone getPhone5() {
            return phone5;
        }

        public void setPhone5(Phone phone5) {
            this.phone5 = phone5;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public Integer getIdPhone1() {
            return idPhone1;
        }

        public void setIdPhone1(Integer idPhone1) {
            this.idPhone1 = idPhone1;
        }

        public Phone getPhone2() {
            return phone2;
        }

        public void setPhone2(Phone phone2) {
            this.phone2 = phone2;
        }

        public Integer getIdPhone3() {
            return idPhone3;
        }

        public void setIdPhone3(Integer idPhone3) {
            this.idPhone3 = idPhone3;
        }

        public Phone getPhone3() {
            return phone3;
        }

        public void setPhone3(Phone phone3) {
            this.phone3 = phone3;
        }

        public Integer getIdPhone4() {
            return idPhone4;
        }

        public void setIdPhone4(Integer idPhone4) {
            this.idPhone4 = idPhone4;
        }

        public Phone getPhone4() {
            return phone4;
        }

        public void setPhone4(Phone phone4) {
            this.phone4 = phone4;
        }

        @Override
        public String toString() {
            return "Person{" + "id=" + id + ", name=" + name + ", idPhone1=" + idPhone1 + ", phone2=" + phone2 + ", idPhone3=" + idPhone3 + ", phone3=" + phone3 + ", idPhone4=" + idPhone4 + ", phone4=" + phone4 + '}';
        }
    }

    public static class Phone {

        @Id
        @net.vpc.upa.config.Sequence
        private Integer id;
        private String value;

        public Integer getId() {
            return id;
        }

        public void setId(Integer id) {
            this.id = id;
        }

        public String getValue() {
            return value;
        }

        public void setValue(String value) {
            this.value = value;
        }

        @Override
        public String toString() {
            return "Phone{" + "id=" + id + ", value=" + value + '}';
        }
    }
}
