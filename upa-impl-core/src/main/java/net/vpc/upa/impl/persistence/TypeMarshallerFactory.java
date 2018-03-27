package net.vpc.upa.impl.persistence;

import net.vpc.upa.types.DataType;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 18 juin 2006 Time: 22:09:35 To
 * change this template use File | Settings | File Templates.
 */
public interface TypeMarshallerFactory {

    void setMarshallManager(MarshallManager marshallManager);

    TypeMarshaller createTypeMarshaller(DataType type);
}
