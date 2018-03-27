package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.Clob;

import java.io.Reader;
import java.sql.SQLException;

public class DefaultClob implements Clob {
    private java.sql.Clob data;

    public DefaultClob(java.sql.Clob data) {
        this.data = data;
    }

    public java.sql.Clob getData() {
        return data;
    }

    @Override
    public Reader getCharacterStream() {
        try {
            return data.getCharacterStream();
        } catch (SQLException e) {
            throw new UPAException(e);
        }
    }
}
