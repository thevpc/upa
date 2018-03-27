/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.android;

import android.app.Application;

/**
 *
 * @author vpc
 */
public class AndroidContext {

    public static Application getApplication() {
        try {
            return (Application) Class.forName("android.app.ActivityThread")
                    .getMethod("currentApplication").invoke(null, (Object[]) null);
        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }
}
