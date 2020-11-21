/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.test;

import java.math.BigDecimal;
import java.math.BigInteger;
import junit.framework.Assert;
import net.thevpc.upa.impl.util.PlatformUtils;
import org.junit.Test;

/**
 *
 * @author vpc
 */
public class TestPlatformUtils {

    @Test
    public void test_getPlatformType() {
        test_getPlatformType(Boolean.class, PlatformUtils.TYPE_MAJOR_BOOLEAN | PlatformUtils.TYPE_FLAGS_NULLABLE | PlatformUtils.TYPE_SIZE_1);
        test_getPlatformType(Boolean.TYPE, PlatformUtils.TYPE_MAJOR_BOOLEAN | PlatformUtils.TYPE_SIZE_1);
        test_getPlatformType(Byte.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_8 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Byte.TYPE, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_8);
        test_getPlatformType(Short.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_16 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Short.TYPE, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_16);
        test_getPlatformType(Integer.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_32 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Integer.TYPE, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_32);
        test_getPlatformType(Long.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_64 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Long.TYPE, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_64);
        test_getPlatformType(BigInteger.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_BIG | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Float.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_FLOAT | PlatformUtils.TYPE_SIZE_32 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Float.TYPE, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_FLOAT | PlatformUtils.TYPE_SIZE_32);
        test_getPlatformType(Double.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_FLOAT | PlatformUtils.TYPE_SIZE_64 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Double.TYPE, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_FLOAT | PlatformUtils.TYPE_SIZE_64);
        test_getPlatformType(BigDecimal.class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_DECIMAL | PlatformUtils.TYPE_SIZE_BIG| PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(String.class, PlatformUtils.TYPE_MAJOR_STRING | PlatformUtils.TYPE_MINOR_CHARS | PlatformUtils.TYPE_SIZE_BIG | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Character.class, PlatformUtils.TYPE_MAJOR_STRING | PlatformUtils.TYPE_MINOR_CHAR | PlatformUtils.TYPE_SIZE_16 | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Character.TYPE, PlatformUtils.TYPE_MAJOR_STRING | PlatformUtils.TYPE_MINOR_CHAR | PlatformUtils.TYPE_SIZE_16);
        test_getPlatformType(char[].class, PlatformUtils.TYPE_MAJOR_STRING | PlatformUtils.TYPE_MINOR_CHAR | PlatformUtils.TYPE_SIZE_16 | PlatformUtils.TYPE_FLAGS_NULLABLE| PlatformUtils.TYPE_FLAGS_ARRAY);
        test_getPlatformType(Character[].class, PlatformUtils.TYPE_MAJOR_STRING | PlatformUtils.TYPE_MINOR_CHAR | PlatformUtils.TYPE_SIZE_16 | PlatformUtils.TYPE_FLAGS_NULLABLE| PlatformUtils.TYPE_FLAGS_ARRAY);
        test_getPlatformType(byte[].class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_8 | PlatformUtils.TYPE_FLAGS_ARRAY | PlatformUtils.TYPE_FLAGS_NULLABLE);
        test_getPlatformType(Byte[].class, PlatformUtils.TYPE_MAJOR_NUMBER | PlatformUtils.TYPE_MINOR_INT | PlatformUtils.TYPE_SIZE_8 | PlatformUtils.TYPE_FLAGS_ARRAY | PlatformUtils.TYPE_FLAGS_NULLABLE);
    }

    private void test_getPlatformType(Class cls, int expected) {
        int platformType = PlatformUtils.getPlatformType(cls);
        System.out.println(cls + " :: " );
        System.out.println("\t found    : " + platformType + "=" + PlatformUtils.getPlatformTypeName(platformType));
        System.out.println("\t expected : " + expected + "=" + PlatformUtils.getPlatformTypeName(expected));
        Assert.assertEquals(PlatformUtils.getPlatformTypeName(expected), PlatformUtils.getPlatformTypeName(platformType));
    }

}
