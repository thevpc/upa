/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.android;

import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.thevpc.upa.Properties;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.persistence.Parameter;
import net.thevpc.upa.persistence.QueryResult;
import net.thevpc.upa.impl.persistence.AbstractUConnection;
import net.thevpc.upa.impl.persistence.DefaultQueryResult;
import net.thevpc.upa.impl.persistence.DefaultUConnection;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.TypeMarshaller;
import net.thevpc.upa.types.DataTypeTransform;

/**
 *
 * @author vpc
 */
public class AndroidSqliteConnection extends AbstractUConnection {

    private final String dbname;
    private final int dbversion;
    private final SQLiteOpenHelper h;
    private final SQLiteDatabase db;

    public AndroidSqliteConnection(String dbname, int dbversion, MarshallManager marshallManager, Properties perfProperties) {
        super(dbname + "-" + dbversion, marshallManager, perfProperties);
        this.dbname = dbname;
        this.dbversion = dbversion;
        h = new SQLiteOpenHelper(AndroidContext.getApplication(), dbname, null, dbversion) {
            @Override
            public void onCreate(SQLiteDatabase sqld) {

            }

            @Override
            public void onUpgrade(SQLiteDatabase sqld, int i, int i1) {

            }

        };
        db = h.getWritableDatabase();

    }

    @Override
    public QueryResult executeQueryImpl(String query, String tableDebugString, DataTypeTransform[] types, List<Parameter> queryParameters, boolean updatable) throws Exception {
        if(updatable){
            throw new UPAException("NotSupportedUpdatable");
        }
        NativeStatement s=new AndroidSqliteNativeStatement(db,query,false);
        int mi = 0;
        int index = 1;
        if (queryParameters != null) {
            for (Parameter value : queryParameters) {
                DataTypeTransform transform = value.getTypeTransform();
                TypeMarshaller marshaller = marshallManager.getTypeMarshaller(transform);
                marshaller.write(value.getValue(), index, s);
                index += marshaller.getSize();
                mi++;
            }
        }
        NativeResult resultSet = s.executeQuery();

        if (types == null) {

            int columnCount;
            Class[] colTypes;
            /**
             * @PortabilityHint(target = "C#",name = "replace")
             * columnCount=resultSet.FieldCount; colTypes = new
             * System.Type[columnCount]; for (int i = 0; i < columnCount; i++) {
             * colTypes[i] = resultSet.GetFieldType(i); }
             */
            {
                columnCount = resultSet.getColumnCount();
                colTypes = new Class[columnCount];
                for (int i = 0; i < columnCount; i++) {
                    try {
                        colTypes[i] = Class.forName(resultSet.getColumnClassName(i + 1));
                    } catch (ClassNotFoundException ex) {
                        Logger.getLogger(DefaultUConnection.class.getName()).log(Level.SEVERE, null, ex);
                        colTypes[i] = Object.class;
                    }
                }
            }

            types = new DataTypeTransform[columnCount];
            for (int i = 0; i < types.length; i++) {
                types[i] = IdentityDataTypeTransform.ofType(colTypes[i]);
            }
        }
        TypeMarshaller[] marshallers = new TypeMarshaller[types.length];
        for (int i = 0; i < marshallers.length; i++) {
            marshallers[i] = marshallManager.getTypeMarshaller(types[i]);
        }

//        Log.log(PersistenceUnitManager.DB_PRE_NATIVE_QUERY_LOG,"[BEFORE] "+currentQueryInfo+" :=" + currentQuery);
        return new DefaultQueryResult(nameDebugString + tableDebugString, query, resultSet, marshallers, types);
    }

    @Override
    public int executeNonQueryImpl(String query, List<Parameter> queryParameters, List<Parameter> generatedKeys) throws Exception {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected void closePlatformConnection() throws Exception {
//        db.close();
    }

    @Override
    public Object getMetadataAccessibleConnection() throws UPAException {
        return db;
    }

    @Override
    public Object getPlatformConnection() throws UPAException {
        return db;
    }

    @Override
    public void beginTransaction() {
        db.beginTransaction();
    }

    @Override
    public void commitTransaction() {
        db.setTransactionSuccessful();
        db.endTransaction();
    }

    @Override
    public void rollbackTransaction() {
        db.endTransaction();
    }

}
