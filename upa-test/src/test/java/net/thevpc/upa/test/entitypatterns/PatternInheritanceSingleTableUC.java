package net.thevpc.upa.test.entitypatterns;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.*;
import net.thevpc.upa.config.*;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PatternInheritanceSingleTableUC {

    private static final java.util.logging.Logger log = java.util.logging.Logger.getLogger(PatternInheritanceSingleTableUC.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(PatternInheritanceSingleTableUC.class);
        pu.addEntity(Engin.class);
        pu.addEntity(Car.class);
        pu.addEntity(Plane.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
        bo.init();
    }

    public static class Car extends Engin {

        @Summary
        private int wheels;

        public Car() {
        }

        public Car(String name, int wheels) {
            super(name);
            this.wheels = wheels;
        }

        public int getWheels() {
            return wheels;
        }

        public void setWheels(int wheels) {
            this.wheels = wheels;
        }

    }

    @Entity
    public static class Plane extends Engin {

        @Summary
        private int altitude;

        public Plane() {
        }

        public Plane(String name, int altitude) {
            super(name);
            this.altitude = altitude;
        }

        public int getAltitude() {
            return altitude;
        }

        public void setAltitude(int altitude) {
            this.altitude = altitude;
        }

    }

    @Entity
    public static class Engin {

        @Id
        @Sequence
        private int id;
        @Main
        private String name;

        public Engin() {
        }

        public Engin(String name) {
            this.name = name;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public int getId() {
            return id;
        }

        public Engin setId(int id) {
            this.id = id;
            return this;
        }
    }

    @Test
    public void testMe() {
        bo.testMe();
    }

    public static class Business {

        public void init() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.clear(Engin.class, null);
            pu.clear(Car.class, null);
            pu.clear(Plane.class, null);
        }

        public void testMe() {
            PersistenceUnit pu = UPA.getPersistenceUnit();
            pu.persist(new Engin("Engin1"));
            pu.persist(new Car("Car1", 4));
            pu.persist(new Plane("Plane1", 1000));

            System.out.println("Engins");
            for (Engin object : pu.<Engin>findAll(Engin.class)) {
                System.out.println("\t" + object);
            }

            System.out.println("Cars");
            for (Car object : pu.<Car>findAll(Car.class)) {
                System.out.println("\t" + object);
            }

            System.out.println("Planes");
            for (Plane object : pu.<Plane>findAll(Plane.class)) {
                System.out.println("\t" + object);
            }

        }

    }
}
