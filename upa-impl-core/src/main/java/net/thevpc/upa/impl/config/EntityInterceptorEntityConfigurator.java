/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import java.util.ArrayList;
import java.util.List;

import net.thevpc.upa.impl.config.annotationparser.AnnotationParserUtils;
import net.thevpc.upa.Entity;
import net.thevpc.upa.events.EntityInterceptor;
import net.thevpc.upa.events.Trigger;

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
