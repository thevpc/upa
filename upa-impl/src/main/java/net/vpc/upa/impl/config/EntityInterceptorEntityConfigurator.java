/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.Entity;
import net.vpc.upa.callbacks.EntityInterceptor;
import net.vpc.upa.callbacks.Trigger;
import net.vpc.upa.impl.config.annotationparser.AnnotationParserUtils;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityInterceptorEntityConfigurator implements EntityConfigurator {

    private EntityInterceptor dataInterceptor;
    private String callbackName;
    private List<Trigger> addedTriggers = new ArrayList<Trigger>();

    public EntityInterceptorEntityConfigurator(EntityInterceptor dataInterceptor, String callbackName) {
        this.dataInterceptor = dataInterceptor;
        this.callbackName = callbackName;
    }

    public void install(Entity e) {
        String cname = callbackName;
        if (AnnotationParserUtils.isEmptyString(cname)) {
            cname = dataInterceptor.getClass().getSimpleName();
        }
        addedTriggers.add(e.addTrigger(cname, dataInterceptor));
    }

    public void uninstall(Entity e) {
        for (Trigger t : new ArrayList<Trigger>(addedTriggers)) {
            for (Trigger t2 : new ArrayList<Trigger>(e.getTriggers())) {
                if (t.equals(t2)) {
                    e.removeTrigger(t.getName());
                    addedTriggers.remove(t);
                    break;
                }
            }
        }
    }

}
