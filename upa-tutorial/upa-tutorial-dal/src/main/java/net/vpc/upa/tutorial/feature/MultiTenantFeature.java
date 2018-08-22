/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.tutorial.feature;

import net.vpc.upa.DefaultFieldBuilder;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.Entity;
import net.vpc.upa.config.Callback;
import net.vpc.upa.config.OnCreate;
import net.vpc.upa.types.DataTypeFactory;

/**
 * This class adds multi tenant support to the application. All Entities will
 * include a new field "tenantId". This field is treated as formula (read only)
 * and is populated according to a thread local var "currentTenant". Besides,
 * any tenant partitioning is forced using ObjectFilter concept : any tenant can
 * see only objects of the same tenant.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Callback
public class MultiTenantFeature {
    public final static ThreadLocal<Integer> currentTenant = new ThreadLocal<Integer>();

    static {
        currentTenant.set(15);
    }

    @OnCreate
    public void entityAdded(EntityEvent event) {
        Entity entity = event.getEntity();

        entity.addField(new DefaultFieldBuilder().setName("tenantId").setPath("MultiTenant").setDataType(DataTypeFactory.INT)
        .setPersistFormula("CurrentTenant()"));

        // filter entities by tenantId
        entity.addFilter("MultiTenant", "tenantId=CurrentTenant()");
    }

    /**
     * simple implementation of multi tenancy using a thread local field. set
     * the initial value of the tenant. Callback function called when the
     * persistenceUnit is created. Creates a new Function usable in UPQL
     * (Unstructured Query Language) context. Actually this is needed to call
     * the thread local var from within the tenantId formula
     *
     */
    @net.vpc.upa.config.Function
    public Integer CurrentTenant() {
        return currentTenant.get();
    }
}
