package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.TemporalType;
import net.thevpc.upa.types.*;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.TypeMarshaller;
import net.thevpc.upa.impl.persistence.TypeMarshallerFactory;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:50 AM
*/
public class TemporalDataMarshallerFactory implements TypeMarshallerFactory {

    private MarshallManager pm;
    public TemporalDataMarshallerFactory(MarshallManager pm) {
        this.pm=pm;
    }


    @Override
    public void setMarshallManager(MarshallManager pm) {
        this.pm = pm;
    }

    public TypeMarshaller createTypeMarshaller(DataType type) {
        TemporalType n = (TemporalType) type;
        Class primitiveType = type.getPlatformType();
        return pm.getTypeMarshaller(primitiveType);// getWrapper(net.thevpc.util.Time.class);
//        if(java.sql.Time.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Time.class);// getWrapper(net.thevpc.util.Time.class);
//
//        }else if(java.sql.Timestamp.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(Timestamp.class);
//
//        }else if(java.sql.Date.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(java.sql.Date.class);
//
//        }else if(net.thevpc.upa.types.Time.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(net.thevpc.upa.types.Time.class);// getWrapper(net.thevpc.util.Time.class);
//
//        }else if(net.thevpc.upa.types.DateTime.class.isAssignableFrom(primitiveType)){
//            return pm.getTypeMarshaller(DateTime.class);
//        }else if(net.thevpc.upa.types.Timestamp.class.isAssignableFrom(primitiveType)){
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
