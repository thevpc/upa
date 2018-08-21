/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import java.io.InputStream;
import java.io.Reader;
import java.io.StringReader;
import java.math.BigDecimal;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Time;
import java.sql.Timestamp;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
 *
 * @author vpc
 */
public class PreparedSQLUPQLStatement implements NativeStatement {

    private PreparedStatement s;

    public PreparedSQLUPQLStatement(PreparedStatement s) {
        this.s = s;
    }

    @Override
    public void setNull(int parameterIndex, int sqlType) {
        try {
            s.setNull(parameterIndex, sqlType);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setBoolean(int parameterIndex, boolean x) {
        try {
            s.setBoolean(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setByte(int parameterIndex, byte x) {
        try {
            s.setByte(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setShort(int parameterIndex, short x) {
        try {
            s.setShort(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setInt(int parameterIndex, int x) {
        try {
            s.setInt(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setLong(int parameterIndex, long x) {
        try {
            s.setLong(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setFloat(int parameterIndex, float x) {
        try {
            s.setFloat(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setDouble(int parameterIndex, double x) {
        try {
            s.setDouble(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setBigDecimal(int parameterIndex, BigDecimal x) {
        try {
            s.setBigDecimal(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setString(int parameterIndex, String x) {
        try {
            s.setString(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setBytes(int parameterIndex, byte[] x) {
        try {
            s.setBytes(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setDate(int parameterIndex, Date x) {
        try {
            s.setDate(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setTime(int parameterIndex, Time x) {
        try {
            s.setTime(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setTimestamp(int parameterIndex, Timestamp x) {
        try {
            s.setTimestamp(parameterIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public int executeUpdate() {
        try {
            return s.executeUpdate();
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public NativeResult executeQuery() {
        try {
            return new JdbcNativeResult(s.executeQuery());
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public NativeResult getGeneratedKeys() {
        try {
            return new JdbcNativeResult(s.getGeneratedKeys());
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setObject(int i, Object object) {
        try {
            s.setObject(i, object);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setBlob(int i, net.vpc.upa.types.Blob blob) {
        try {
            s.setBlob(i, blob==null?null:(((DefaultBlob)blob).getData()));
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setBlob(int i, InputStream stream) {
        try {
            s.setBlob(i, stream);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setClob(int i, Reader reader) {
        try {
            s.setClob(i, reader);
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setClob(int i, net.vpc.upa.types.Clob clob) {
        try {
            s.setClob(i, clob==null?null:((DefaultClob)clob).getData());
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }

    @Override
    public void setClob(int index, String string) {
        try {
            s.setClob(index, string==null?null:new StringReader(string));
        } catch (SQLException ex) {
            throw new UPAException(ex.getMessage(), ex);
        }
    }
    

}
