package net.vpc.upa.impl.util;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.Entity;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 12:16 AM
 */
public class CustomDocumentPlatformBeanType extends DocumentPlatformBeanType {

    private PlatformBeanType customType;

    public CustomDocumentPlatformBeanType(Entity entity, Class customType) {
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
