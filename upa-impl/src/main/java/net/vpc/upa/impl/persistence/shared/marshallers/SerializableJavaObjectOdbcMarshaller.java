package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.util.IOUtils;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/ //    public  DataWrapper wdouble() {
//        return getWrapper(Double.class);
//    }
//
//    public DataWrapper wboolean() {
//        return getWrapper(Boolean.class);
//    }
//
//    public DataWrapper wdateonly() {
//        return getWrapper(Date.class);
//    }
//
//    public DataWrapper wtime() {
//        return getWrapper(Time.class);
//    }
//
//    public DataWrapper wdatetime() {
//        return getWrapper(net.vpc.util.DateTime.class);
//    }
//
//    public DataWrapper wtimestamp() {
//        return getWrapper(Timestamp.class);
//    }
//
//    public DataWrapper wyear() {
//        return getWrapper(Year.class);
//    }
//
//    public DataWrapper wbyte() {
//        return getWrapper(Byte.class);
//    }
//
//    public DataWrapper wshort() {
//        return getWrapper(Short.class);
//    }
//
//    public DataWrapper wbigdecimal() {
//        return getWrapper(BigDecimal.class);
//    }
//
//    public DataWrapper wbiginteger() {
//        return getWrapper(BigInteger.class);
//    }
//
//    public DataWrapper wmonthyear() {
//        return getWrapper(Month.class);
//    }
//
//    public DataWrapper winteger() {
//        return getWrapper(Integer.class);
//    }
//
//    public DataWrapper wstring() {
//        return getWrapper(String.class);
//    }
//
//    public DataWrapper wlong() {
//        return getWrapper(Long.class);
//    }
//
//    public DataWrapper wfloat() {
//        return getWrapper(Float.class);
//    }
//
//    public DataWrapper wobject() {
//        return getWrapper(Object.class);
//    }
public class SerializableJavaObjectOdbcMarshaller
        extends SimpleTypeMarshaller {

    public SerializableJavaObjectOdbcMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
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
        throw new RuntimeException("litteral not supported for Objects (" + object + " as " + object.getClass() + ")");
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.VARCHAR);
            //preparedStatement.setBytes(i, null);
        } else {
            preparedStatement.setBytes(i, IOUtils.getSerializedFormOf(object));
        }
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
            updatableResultSet.updateNull(i);
            //preparedStatement.setBytes(i, null);
        } else {
            updatableResultSet.updateBytes(i, IOUtils.getSerializedFormOf(object));
        }
    }

    public boolean isLiteralSupported() {
        return false;
    }
}
