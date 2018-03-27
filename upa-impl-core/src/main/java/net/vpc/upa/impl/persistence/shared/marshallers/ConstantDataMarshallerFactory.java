package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;
import net.vpc.upa.types.DataType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class ConstantDataMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager marshallManager;
    private TypeMarshaller w;

    public ConstantDataMarshallerFactory(MarshallManager marshallManager,String name) {
        this(marshallManager,marshallManager.getTypeMarshaller(name));
    }

    public ConstantDataMarshallerFactory(MarshallManager marshallManager,TypeMarshaller w) {
        this.w = w;
        this.marshallManager = marshallManager;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        return w;
    }

    @Override
    public void setMarshallManager(MarshallManager marshallManager) {
        this.marshallManager=marshallManager;
    }
}
