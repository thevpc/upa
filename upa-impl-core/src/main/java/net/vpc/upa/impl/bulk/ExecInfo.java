package net.vpc.upa.impl.bulk;

import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.ImportPersistenceUnitListener;
import net.vpc.upa.filters.EntityFilter;
import net.vpc.upa.impl.util.CacheSet;

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
