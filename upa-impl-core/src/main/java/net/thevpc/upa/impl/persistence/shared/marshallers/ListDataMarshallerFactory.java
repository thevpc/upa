package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.ListType;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.TypeMarshaller;
import net.thevpc.upa.impl.persistence.TypeMarshallerFactory;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class ListDataMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager marshallManager;

    public ListDataMarshallerFactory(MarshallManager marshallManager) {
        this.marshallManager=marshallManager;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        ListType n = (ListType) type;
        return marshallManager.getTypeMarshaller(n.getElementType());
    }


    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.marshallManager= pm;
    }
}
