package net.vpc.upa.impl.util;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 11:18 PM
*/
abstract class AbstractBeanAdapterAttribute implements BeanAdapterAttribute {

    protected String name;
    protected Class fieldType;

    AbstractBeanAdapterAttribute(String name, Class fieldType) {
        this.name = name;
        this.fieldType = fieldType;
    }

    @Override
    public String getName() {
        return name;
    }

    public Class getFieldType() {
        return fieldType;
    }


    @Override
    public boolean isDefaultValue(Object o) {
        Object fieldValue = getValue(o);
        Object fieldDefaultValue = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(getFieldType());
        if (fieldDefaultValue == null) {
            return fieldValue == null;
        } else {
            return fieldDefaultValue.equals(fieldValue);
        }
    }

    @Override
    public Object getDefaultValue() {
        return PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(getFieldType());
    }

    //        @Override
//        public R getDefaultValue() throws UPAException{
//            if (entity == null) {
//                return (R) DEFAULT_VALUES_BY_TYPE.get(fieldType);
//            } else {
//                final net.vpc.upa.Field field = entity.getField(name);
//                final Object fuv = field.getUnspecifiedValue();
//                if (UnspecifiedValue.DEFAULT.equals(fuv)) {
//                    return (R) DEFAULT_VALUES_BY_TYPE.get(fieldType);
//                } else {
//                    return (R)fuv;
//                }
//            }
//        }
//
//        public boolean isDefaultValue(Object o) throws UPAException{
//            R fieldValue = getValue(o);
//            if (entity == null) {
//                R fieldDefaultValue =(R) DEFAULT_VALUES_BY_TYPE.get(fieldType);
//                if (fieldDefaultValue == null) {
//                    return fieldValue == null;
//                } else {
//                    return fieldDefaultValue.equals(fieldValue);
//                }
//            } else {
//                final net.vpc.upa.Field field = entity.getField(name);
//                final Object fuv = field.getUnspecifiedValue();
//                if (UnspecifiedValue.DEFAULT.equals(fuv)) {
//                    return AnyBeanAdapter.isTypeDefaultValue(fieldType, fieldValue);
//                } else {
//                    return !(fuv == o || (fuv != null && fuv.equals(fieldValue)));
//                }
//            }
//        }
}
