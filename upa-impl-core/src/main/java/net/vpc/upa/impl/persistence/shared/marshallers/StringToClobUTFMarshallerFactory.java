package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;
import net.vpc.upa.impl.persistence.TypeMarshallerNames;
import net.vpc.upa.types.DataType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class StringToClobUTFMarshallerFactory implements TypeMarshallerFactory {

    private TypeMarshaller str;
    private TypeMarshaller blob;
    private int maxString;
    private MarshallManager marshallManager;

    public StringToClobUTFMarshallerFactory(MarshallManager marshallManager,int maxString) {
        setMarshallManager(marshallManager);
        this.maxString=maxString;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        int length = type.getScale();
        if (length <= maxString) {
            return marshallManager.getTypeMarshaller(String.class);
        } else {
            return blob;
        }
    }

    @Override
    public void setMarshallManager(MarshallManager marshallManager) {
        this.marshallManager=marshallManager;
        str= marshallManager.getTypeMarshaller(TypeMarshallerNames.STRING);
        blob=marshallManager.getTypeMarshaller(TypeMarshallerNames.STRING_TO_CLOB);
    }
}
