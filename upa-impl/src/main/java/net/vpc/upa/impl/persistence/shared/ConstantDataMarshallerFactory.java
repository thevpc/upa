package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;
import net.vpc.upa.types.DataType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class ConstantDataMarshallerFactory implements TypeMarshallerFactory {

    private TypeMarshaller w;

    public ConstantDataMarshallerFactory(TypeMarshaller w) {
        this.w = w;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        return w;
    }

    @Override
    public void setMarshallManager(MarshallManager pm) {
    }
}
