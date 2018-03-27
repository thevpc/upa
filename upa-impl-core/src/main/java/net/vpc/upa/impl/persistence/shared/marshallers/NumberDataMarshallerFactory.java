package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.NumberType;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:49 AM
 */
public class NumberDataMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager marshallManager;
    public NumberDataMarshallerFactory(MarshallManager marshallManager) {
        this.marshallManager=marshallManager;
    }


    @Override
    public void setMarshallManager(MarshallManager marshallManager) {
        this.marshallManager = marshallManager;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        NumberType n = (NumberType) type;
        Class c = n.getPlatformType();
        TypeMarshaller m = marshallManager.getTypeMarshaller(c);
        if (m == null) {
            m = marshallManager.getTypeMarshaller(Object.class);
        }
        return m;

    }
}
