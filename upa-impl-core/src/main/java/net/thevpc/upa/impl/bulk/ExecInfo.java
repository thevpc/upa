package net.thevpc.upa.impl.bulk;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.impl.util.CacheSet;
import net.thevpc.upa.Entity;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.bulk.ImportPersistenceUnitListener;
import net.thevpc.upa.filters.EntityFilter;

import java.util.*;

/**
 * @author taha.bensalah@gmail.com on 7/6/16.
 */
@PortabilityHint(target = "C#",name = "suppress")
class ExecInfo {

    EntityFilter filter;
    ImportPersistenceUnitListener listener;
    PersistenceUnit source;
    PersistenceUnit target;
    boolean deleteExisting;
    SyncStat globalStat = new SyncStat();
    Map<String, SyncStat> stats = new TreeMap<String, SyncStat>();
    List<Entity> entities;
    Set<String> finishedProcessingEntityNames = new HashSet<String>();
    CacheSet<IdCache> idCaches = new CacheSet<IdCache>(1000);

    public SyncStat getStat(String entityName) {
        SyncStat s = stats.get(entityName);
        if (s == null) {
            s = new SyncStat();
            stats.put(entityName, s);
        }
        return s;
    }
}
