package net.vpc.upa.impl.persistence.shared;

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

    public NumberDataMarshallerFactory() {
    }

    private MarshallManager pm;

    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.pm = pm;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        NumberType n = (NumberType) type;
        Class c = n.getPlatformType();
        TypeMarshaller m = pm.getTypeMarshaller(c);
        if (m == null) {
            m = pm.getTypeMarshaller(Object.class);
        }
        return m;

    }
}
