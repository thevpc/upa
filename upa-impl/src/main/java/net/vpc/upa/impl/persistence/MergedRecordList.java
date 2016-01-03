package net.vpc.upa.impl.persistence;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeListener;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:41 AM To change
 * this template use File | Settings | File Templates.
 */
public class MergedRecordList extends QueryResultIteratorList<Record> {

    private int columns;
    private ObjectFactory factory;
    private String[] names;
    Map<String, Integer> nameToIndex = new HashMap<String, Integer>();
    private PropertyChangeListener currentPropertyChangeListener = null;
    private Record currentRecord = null;

    public MergedRecordList(NativeSQL nativeSQL, PersistenceUnit persistenceUnit) throws SQLException, UPAException {
        super(nativeSQL);
        factory = persistenceUnit.getFactory();
        NativeField[] fields = getNativeSQL().getFields();
        names = new String[fields.length];
        for (int i = 0; i < fields.length; i++) {
            names[i] = fields[i].getName();
            nameToIndex.put(fields[i].getName(), i);
        }
        columns = names.length;
    }

    private void resetListeners(){
      if(currentRecord!=null){
          currentRecord.removePropertyChangeListener(currentPropertyChangeListener);
          currentRecord=null;
          currentPropertyChangeListener=null;
      }  
    }
    
    @Override
    public Record parse(QueryResult result) {
        if (getNativeSQL().isUpdatable()) {
            resetListeners();
            Record record = factory.createObject(Record.class);
            for (int i = 0; i < columns; i++) {
                record.setObject(names[i], result.read(i));
            }
            record.addPropertyChangeListener(currentPropertyChangeListener= new QueryResultUpdaterPropertyChangeListener(this, result));
            currentRecord=record;
            return record;
        } else {
            Record record = factory.createObject(Record.class);
            for (int i = 0; i < columns; i++) {
                record.setObject(names[i], result.read(i));
            }
            return record;
        }
    }

    @PortabilityHint(target = "C#",name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        resetListeners();
    }

}
