package net.thevpc.upa.test.importexport;

import java.io.File;
import java.io.IOException;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UPA;
import net.thevpc.upa.bulk.*;

import net.thevpc.upa.bulk.*;
import net.thevpc.upa.test.util.PUUtils;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class ExportUC {

    private static final Logger log = Logger.getLogger(ExportUC.class.getName());

    private static Business bo;
    @BeforeClass
    public static void setup() {
        PersistenceUnit pu = PUUtils.createTestPersistenceUnit(ExportUC.class);
        pu.start();
        bo = UPA.makeSessionAware(new Business());
    }

    @Test
    public void process() {
        bo.process();
    }

    public static class Business {

        private Object[][] ALL_ROWS = {
            {1, "Hello", new Date()},
            {2, "Ali", new Date()}
        };

        public void process() {
            try {
                PersistenceUnit pu = UPA.getPersistenceUnit();
                ImportExportManager iem = pu.getImportExportManager();
//                processTextFixedWidth(pu, iem);
                processSheet(pu, iem);
            } catch (Exception ex) {
                java.util.logging.Logger.getLogger(ExportUC.class.getName()).log(Level.SEVERE, null, ex);
            }

        }

        public void processTextFixedWidth(PersistenceUnit pu, ImportExportManager iem) throws IOException {
            TextFixedWidthFormatter p = iem.createTextFixedWidthFormatter(new File("/home/vpc/t.xls"));
            p.getColumns().add(new TextFixedWidthColumn(10).updateTitle("Number").updateSkippedColumns(3));
            p.getColumns().add(new TextFixedWidthColumn(20).updateTitle("String"));
            p.getColumns().add(new TextFixedWidthColumn(15).updateTitle("Date").updateSkippedColumns(2));
            p.setWriteHeader(true);
            p.setSkipRows(3);
            DataWriter g = p.createWriter();
            for (Object[] row : ALL_ROWS) {
                g.writeRow(row);
            }
            g.close();
        }

        public void processSheet(PersistenceUnit pu, ImportExportManager iem) throws IOException {
            SheetFormatter p = iem.createSheetFormatter(new File("/home/vpc/t.xlsx"));
            SheetColumn col1 = new SheetColumn();
            col1.updateTitle("Number");
            col1.updateSkippedColumns(3);
            p.getColumns().add(col1);
            SheetColumn col2 = new SheetColumn();
            col2.updateTitle("String");
            p.getColumns().add(col2);
            SheetColumn col3 = new SheetColumn();
            col3.updateTitle("Date");
            col3.updateSkippedColumns(2);
            p.getColumns().add(col3);
            p.setWriteHeader(true);
            p.setSkipRows(3);
            DataWriter g = p.createWriter();
            for (Object[] row : ALL_ROWS) {
                g.writeRow(row);
            }
            g.close();
        }
    }

    public enum Status {

        VALID,
        INVALID
    }

}
