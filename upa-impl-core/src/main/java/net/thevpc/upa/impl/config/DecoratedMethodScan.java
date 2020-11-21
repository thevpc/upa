/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import java.lang.reflect.Method;

import net.thevpc.upa.config.Decoration;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DecoratedMethodScan {

    private Decoration decoration;
    private Method method;

    public DecoratedMethodScan(Decoration decoration, Method method) {
        this.decoration = decoration;
        this.method = method;
    }

    public Decoration getDecoration() {
        return decoration;
    }

    public Method getMethod() {
        return method;
    }

}
