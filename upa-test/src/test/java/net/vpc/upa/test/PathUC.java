package net.vpc.upa.test;

import java.util.logging.Logger;
import net.vpc.upa.Package;
import net.vpc.upa.*;
import net.vpc.upa.test.util.LogUtils;
import org.junit.Test;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:02 PM
 */
public class PathUC {

    static {
        LogUtils.prepare();
    }
    private static final Logger log = Logger.getLogger(PathUC.class.getName());

    @Test
    public void crudMixedDocumentsAndEntities() {
        log.fine("********************************************");
        log.fine("test Path Entities");
        log.fine("");
        log.fine("insert,update, find, delete");
        log.fine("********************************************");
        PersistenceUnit sm = UPA.getPersistenceUnit();

        Session s = sm.openSession();

        for (Entity entity : sm.getEntities()) {
            System.out.print(entity+" : "+entity.getParent());
        }
        for (Package pck : sm.getPackages()) {
            System.out.print(pck+" : "+pck.getName()+" : "+pck.getPath());
        }
        s.close();

    }
}
