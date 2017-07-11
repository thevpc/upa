package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.types.*;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:50 AM
*/
public class TemporalDataMarshallerFactory implements TypeMarshallerFactory {

    public TemporalDataMarshallerFactory() {
    }

    private MarshallManager pm;

    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.pm = pm;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        TemporalType n = (TemporalType) type;
        Class primitiveType = type.getPlatformType();
        return pm.getTypeMarshaller(primitiveType);// getWrapper(net.vpc.util.Time.class);
//        if(java.sql.Time.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Time.class);// getWrapper(net.vpc.util.Time.class);
//
//        }else if(java.sql.Timestamp.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Timestamp.class);
//
//        }else if(java.sql.Date.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(java.sql.Date.class);
//
//        }else if(net.vpc.upa.types.Time.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(net.vpc.upa.types.Time.class);// getWrapper(net.vpc.util.Time.class);
//
//        }else if(net.vpc.upa.types.DateTime.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(DateTime.class);
//        }else if(net.vpc.upa.types.Timestamp.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(DateTime.class);
//
//        }else if(Month.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Month.class);
//
//        }else if(Year.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Year.class);
//
//        }else if(Date.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Date.class);
//
//        }else if(java.util.Date.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(java.util.Date.class);
//        }else{
//            throw new UPAIllegalArgumentException();
//        }
    }
}
