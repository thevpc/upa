package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class ClassDelegateMarshaller
        extends SimpleTypeMarshaller {

    private TypeMarshaller delegate;
    private Class delegateType;

    public ClassDelegateMarshaller(MarshallManager marshallManager, Class delegateType) {
        super(marshallManager);
        this.delegateType = delegateType;
    }

    public TypeMarshaller getDelegate() {
        return delegate = getMarshallManager().getTypeMarshaller(delegateType);
    }

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        return getDelegate().read(index, resultSet);
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet)  {
        getDelegate().write(object,i,updatableResultSet);
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return getDelegate().toSQLLiteral(object);
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
            {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        getDelegate().write(object, i, preparedStatement);
    }

    public boolean isLiteralSupported() {
        return getDelegate().isLiteralSupported();
    }
}
