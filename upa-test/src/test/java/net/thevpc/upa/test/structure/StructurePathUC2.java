package net.thevpc.upa.test.structure;

import java.io.PrintStream;
import java.util.Arrays;
import java.util.List;

import net.thevpc.upa.config.Entity;
import net.thevpc.upa.Package;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.logging.Logger;
import net.thevpc.upa.CompoundField;
import net.thevpc.upa.Field;
import net.thevpc.upa.Section;
import net.thevpc.upa.config.Path;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class StructurePathUC2 {

    private static final Logger log = Logger.getLogger(StructurePathUC2.class.getName());

    private static Business bo;

    @BeforeClass
    public static void setup() {
        PUUtils.reset();
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(StructurePathUC2.class);
        //pu.addEntity(Data.class);
        pu.scan(UPA.getContext().getFactory().createClassScanSource(new Class[]{Item.class, ItemExt.class}), null, true);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() {
        bo.process();

    }

    public static class Business {

        public void process() {
            PersistenceUnit sm = UPA.getPersistenceUnit();
            List<net.thevpc.upa.Entity> y = sm.getEntities();
            print(sm.getDefaultPackage(),0,System.out);
        }

        private String buildPrefix(int level) {
            char[] prefixChars = new char[level];
            Arrays.fill(prefixChars, ' ');
            return new String(prefixChars);
        }

        private void print(Package a, int level, PrintStream out) {
            String prefixChars = buildPrefix(level);
            out.print(prefixChars);
            out.println("[Package] " + a.getName()+ " ("+a.getPath()+") "+a.getPreferredPosition());
            for (Package sp : a.getPackages(false)) {
                print(sp, level + 1, out);
            }
            for (net.thevpc.upa.Entity sp : a.getEntities(false)) {
                print(sp, level + 1, out);
            }
        }

        private void print(net.thevpc.upa.Entity a, int level, PrintStream out) {
            String prefixChars = buildPrefix(level);
            out.print(prefixChars);
            out.println("[Entity] " + a.getName()+" "+a.getPreferredPosition());
            for (Section sp : a.getSections(false)) {
                print(sp, level + 1, out);
            }
            for (Field sp : a.getFields(false)) {
                print(sp, level + 1, out);
            }
        }

        private void print(Section a, int level, PrintStream out) {
            String prefixChars = buildPrefix(level);
            out.print(prefixChars);
            out.println("[Section] " + a.getName()+ " ("+a.getPath()+") "+a.getPreferredPosition());
            for (Section sp : a.getSections(false)) {
                print(sp, level + 1, out);
            }
            for (Field sp : a.getFields(false)) {
                print(sp, level + 1, out);
            }
        }

        private void print(Field a, int level, PrintStream out) {
            String prefixChars = buildPrefix(level);
            out.print(prefixChars);
            out.println("[Field] " + a.getName()+" "+a.getPreferredPosition());
            if (a instanceof CompoundField) {
                CompoundField cf = (CompoundField) a;
                for (Field sp : cf.getFields()) {
                    print(sp, level + 1, out);
                }
            }
        }
    }

    @Entity
    public static class Item {

        @Path(value = "Section1", position = 3)
        private String field1;
        private String field2;
        @Path(value = "Section2", position = 1)
        private String field3;
        private String field4;
    }

    @Entity(entityType = Item.class)
    public static class ItemExt {

        @Path(value = "Section3", position = 2)
        private String field5;
    }
}
