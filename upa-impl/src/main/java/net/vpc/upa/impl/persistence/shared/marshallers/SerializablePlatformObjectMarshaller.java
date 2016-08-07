package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.util.IOUtils;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/ //    protected class JavaObjectWrapper
//            implements DataWrapper {
//
//        public Object get(int index, ResultSet resultSet)
//                throws SQLException {
//            return resultSet.getObject(index);
//        }
//
//        public String litteral(Object object){
//            DataWrapper wrapper=getWrapper(object.getClass());
//            if(wrapper!=null && wrapper.getClass() !=getClass()){
//                return wrapper.litteral(object);
//            }
//            throw new RuntimeException("litteral not supported for Objects");
//        }
//
//        public void set(Object object, int i, PreparedStatement preparedStatement)
//                throws SQLException {
//            preparedStatement.setObject(i,object);
//        }
//
//        public boolean isLitteralSupported() {
//            return false;
//        }
//
//        public JavaObjectWrapper() {
//        }
//    }
public class SerializablePlatformObjectMarshaller
        extends SimpleTypeMarshaller {

    public SerializablePlatformObjectMarshaller() {
    }

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            byte[] b = resultSet.getBytes(index);
            if (b == null) {
                return null;
            }
            try {
                return IOUtils.getObjectFromSerializedForm(b);
            } catch (ClassNotFoundException e) {
                //Log.bug(e);
                return null;
            }
        }
        return null;

    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        TypeMarshaller wrapper = getMarshallManager().getTypeMarshaller(object.getClass());
        if (wrapper != null && wrapper.getClass() != getClass()) {
            return wrapper.toSQLLiteral(object);
        }
        throw new RuntimeException("literal not supported for Objects (" + object + " as " + object.getClass() + ")");
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
//            	preparedStatement.setNull(i, Types.VARCHAR);
            preparedStatement.setBytes(i, null);
        } else {
//            	byte[] d=Utils.getSerializedFormOf(object);
            //InputStream dis=new ByteArrayInputStream(d);
            //preparedStatement.setBinaryStream(i, dis,d.length);
            preparedStatement.setBytes(i, IOUtils.getSerializedFormOf(object));
        }
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
//            	preparedStatement.setNull(i, Types.VARCHAR);
            updatableResultSet.updateBytes(i, null);
        } else {
//            	byte[] d=Utils.getSerializedFormOf(object);
            //InputStream dis=new ByteArrayInputStream(d);
            //preparedStatement.setBinaryStream(i, dis,d.length);
            updatableResultSet.updateBytes(i, IOUtils.getSerializedFormOf(object));
        }
    }

    public boolean isLiteralSupported() {
        return false;
    }
}
