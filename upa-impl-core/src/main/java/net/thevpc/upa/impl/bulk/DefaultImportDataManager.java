/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk;

import java.util.HashMap;
import java.util.Map;

import net.thevpc.upa.*;
import net.thevpc.upa.impl.util.StringUtils;

import net.thevpc.upa.bulk.DataColumn;
import net.thevpc.upa.bulk.DataReader;
import net.thevpc.upa.bulk.DataRow;
import net.thevpc.upa.bulk.ImportDataConfig;
import net.thevpc.upa.bulk.ImportDataManager;
import net.thevpc.upa.bulk.ImportDataMode;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "todo")
public class DefaultImportDataManager implements ImportDataManager {

    public void importEntity(Entity entity, DataReader dataIterator, ImportDataConfig config) {
        PersistenceUnit pu = entity.getPersistenceUnit();
        if (config == null) {
            config = new ImportDataConfig();
        } else {
            config = config.copy();
        }
        ImportDataConfigHelper h = new ImportDataConfigHelper(config, pu);
        while (dataIterator.hasNext()) {
            DataRow r = dataIterator.readRow();
            Map<String, Object> rowMap = new HashMap<String, Object>();
            DataColumn[] columns = r.getColumns();
            for (int i = 0; i < columns.length; i++) {
                DataColumn dataColumn = columns[i];
                rowMap.put(dataColumn.getName(), r.getValues()[i]);
            }
            syncObject(entity, rowMap, config, h);
        }
    }

    protected Object syncObject(Entity entity, Map<String, Object> row, ImportDataConfig config, ImportDataConfigHelper defaultFinder) {
        Document rec = entity.getBuilder().createDocument();
//        ImportEntityFinder entityFinder = config.getEntityFinder();
        for (Map.Entry<String, Object> entry : row.entrySet()) {
            Field f = entity.findField(entry.getKey());
            if (f != null) {
                Relationship manyToOneRelationship = f.getManyToOneRelationship();
                if (manyToOneRelationship!=null) {
                    Entity master = manyToOneRelationship.getTargetRole().getEntity();
                    Object value = entry.getValue();
                    if (value!= null && (!(value instanceof String) || !StringUtils.isNullOrEmpty(String.valueOf(value))))
                    {
                        ImportDataConfig config2 = config.copy();
                        config2.setMode(ImportDataMode.ADD_UPDATE);

                        Map<String, Object> map = defaultFinder.getImportEntityMapper(master).valueToMap(master, value);
                        Object y = syncObject(master, map, config2, defaultFinder);
                        rec.setObject(f.getName(), y);
                    }
                } else {
                    rec.setObject(f.getName(), ValueParser.parse(entry.getValue(), f.getDataType()));
                }
            }
        }
        Document oldValue = null;
        if (config.getMode() != ImportDataMode.ADD) {
            Object o = defaultFinder.getImportEntityFinder(entity).findEntity(entity, row);
            oldValue = entity.getBuilder().objectToDocument(o, false);
        }
        Object entityValue = null;
        switch (config.getMode()) {
            case ADD_UPDATE: {
                if (oldValue != null) {
                    oldValue.setAll(rec);
                    entity.update(oldValue);
                    entityValue = entity.getBuilder().documentToObject(oldValue);
                } else {
                    entity.persist(rec);
                    entityValue = entity.getBuilder().documentToObject(rec);
                }
                break;
            }
            case UPDATE: {
                if (oldValue != null) {
                    oldValue.setAll(rec);
                    entity.update(oldValue);
                    entityValue = entity.getBuilder().documentToObject(oldValue);
                }
                break;
            }
            case ADD: {
                if (oldValue == null) {
                    entity.persist(rec);
                    entityValue = entity.getBuilder().documentToObject(rec);
                }
                break;
            }
            default: {
                throw new UnsupportedUPAFeatureException("Unsupported");
            }
        }
        return entityValue;
    }
}
