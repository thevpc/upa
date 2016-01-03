package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.types.DataType;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;
import net.vpc.upa.types.EnumType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class EnumMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager pm;

    public EnumMarshallerFactory() {
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        EnumType n = (EnumType) type;
        //TODO should get more info about marshalling info
        return new EnumAsIntMarshaller(n.getPlatformType());
    }


    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.pm = pm;
    }
}
