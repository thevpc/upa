package net.vpc.upa.impl.persistence.shared.marshallers;

import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;
import net.vpc.upa.types.EnumType;
import net.vpc.upa.types.DataType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class EnumMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager pm;
    private static Map<Class,EnumAsIntMarshaller> byType=new HashMap<Class,EnumAsIntMarshaller>();

    public EnumMarshallerFactory() {
    }

    public static TypeMarshaller getSharedTypeMarshaller(Class platformType) {
        EnumAsIntMarshaller found = byType.get(platformType);
        if(found==null){
            found=new EnumAsIntMarshaller(platformType);
            byType.put(platformType,found);
        }
        //TODO should get more info about marshalling info
        return found;
    }
    
    public TypeMarshaller createTypeMarshaller(DataType type) {
        EnumType n = (EnumType) type;
        return getSharedTypeMarshaller(n.getPlatformType());
    }


    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.pm = pm;
    }
}
