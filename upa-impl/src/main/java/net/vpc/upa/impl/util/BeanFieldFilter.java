/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.lang.reflect.Field;

/**
 *
 * @author vpc
 */
public class BeanFieldFilter implements ObjectFilter<Field> {
    public static final BeanFieldFilter INSTANCE=new BeanFieldFilter();
    public boolean accept(Field s) {
        return !PlatformUtils.isStatic(s);
    }

}
