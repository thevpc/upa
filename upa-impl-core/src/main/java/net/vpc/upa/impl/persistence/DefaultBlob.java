package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.Blob;

import java.io.InputStream;
import java.sql.SQLException;

public class DefaultBlob implements Blob {
    private java.sql.Blob data;

    public DefaultBlob(java.sql.Blob data) {
        this.data = data;
    }

    public java.sql.Blob getData() {
        return data;
    }

    @Override
    public InputStream getBinaryStream() {
        try {
            return data.getBinaryStream();
        } catch (SQLException e) {
            throw new UPAException(e);
        }
    }
}
