/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.ImportDataConfig;
import net.vpc.upa.bulk.ImportEntityFinder;
import net.vpc.upa.bulk.ImportEntityMapper;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class ImportDataConfigHelper {
    private ImportDataConfig config;
    private Map<String,ImportEntityMapper> mappers=new HashMap<String, ImportEntityMapper>();
    private Map<String,ImportEntityFinder> finders=new HashMap<String, ImportEntityFinder>();
    private ImportEntityFinder defaultFinder;
    private ImportEntityMapper defaultMapper;
    
    public ImportDataConfigHelper(ImportDataConfig config, PersistenceUnit pu) {
        this.config = config;
        defaultFinder= pu.getFactory().createObject(ImportEntityFinder.class);
        defaultMapper= pu.getFactory().createObject(ImportEntityMapper.class);
    }
    
    public ImportEntityMapper getImportEntityMapper(Entity e){
        ImportEntityMapper p = mappers.get(e.getName());
        if(p!=null){
            return p;
        }
        for (ImportEntityMapper v : config.getEntityMappers()) {
            if(v.accept(e)){
                p=v;
                break;
            }
        }
        if(p==null){
            p=defaultMapper;
        }
        mappers.put(e.getName(), p);
        return p;
    }
    
    public ImportEntityFinder getImportEntityFinder(Entity e){
        ImportEntityFinder p = finders.get(e.getName());
        if(p!=null){
            return p;
        }
        for (ImportEntityFinder v : config.getEntityFinders()) {
            if(v.accept(e)){
                p=v;
                break;
            }
        }
        if(p==null){
            p=defaultFinder;
        }
        finders.put(e.getName(), p);
        return p;
    }
}
