package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;
import net.vpc.upa.impl.persistence.TypeMarshallerUtils;
import net.vpc.upa.types.DataType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class StringToBlobDataMarshallerFactory implements TypeMarshallerFactory {

    private TypeMarshaller str= TypeMarshallerUtils.STRING;
    private TypeMarshaller blob=TypeMarshallerUtils.STRING_BLOB;
    private int maxString;

    public StringToBlobDataMarshallerFactory(int maxString) {
        this.maxString=maxString;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        int length = type.getScale();
        if (length <= maxString) {
            return str;
        } else {
            return blob;
        }
    }

    @Override
    public void setMarshallManager(MarshallManager pm) {
    }
}
