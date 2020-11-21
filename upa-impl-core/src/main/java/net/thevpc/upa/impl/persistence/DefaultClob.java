package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.types.Clob;

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
