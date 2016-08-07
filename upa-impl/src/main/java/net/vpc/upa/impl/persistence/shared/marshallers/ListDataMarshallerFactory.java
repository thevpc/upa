package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.ListType;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class ListDataMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager pm;

    public ListDataMarshallerFactory() {
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        ListType n = (ListType) type;
        return pm.getTypeMarshaller(n.getElementType());
    }


    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.pm = pm;
    }
}
