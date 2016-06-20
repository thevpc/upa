package net.vpc.upa.impl.util;

import net.vpc.upa.BeanType;
import net.vpc.upa.Entity;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.ObjectFilter;
import net.vpc.upa.impl.DefaultRecord;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class CustomRecordBeanType extends RecordBeanType{

    private BeanType customType;

    public CustomRecordBeanType(Entity entity,Class customType) {
        super(entity);
        this.customType=PlatformBeanTypeRepository.getInstance().getBeanType(customType);
    }

    @Override
    public Class getPlatformType() {
        return customType.getPlatformType();
    }

    public Object newInstance() {
        return customType.newInstance();
    }



}
