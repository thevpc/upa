package net.thevpc.upa.impl.persistence.shared.marshallers;

import java.util.HashMap;
import java.util.Map;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.TypeMarshaller;
import net.thevpc.upa.impl.persistence.TypeMarshallerFactory;
import net.thevpc.upa.types.EnumType;
import net.thevpc.upa.types.DataType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class EnumMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager marshallManager;
    private static Map<Class,EnumAsIntMarshaller> byType=new HashMap<Class,EnumAsIntMarshaller>();

    public EnumMarshallerFactory(MarshallManager marshallManager) {
        this.marshallManager=marshallManager;
    }

    public static TypeMarshaller getSharedTypeMarshaller(Class platformType,MarshallManager marshallManager) {
        EnumAsIntMarshaller found = byType.get(platformType);
        if(found==null){
            found=new EnumAsIntMarshaller(marshallManager,platformType);
            byType.put(platformType,found);
        }
        //TODO should get more info about marshalling info
        return found;
    }
    
    public TypeMarshaller createTypeMarshaller(DataType type) {
        EnumType n = (EnumType) type;
        return getSharedTypeMarshaller(n.getPlatformType(),marshallManager);
    }


    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.marshallManager = marshallManager;
    }
}
