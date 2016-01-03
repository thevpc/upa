/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Callback;
import net.vpc.upa.CallbackType;
import net.vpc.upa.EntityDescriptor;
import net.vpc.upa.EntitySecurityManager;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Function;
import net.vpc.upa.ScanEvent;
import net.vpc.upa.ScanListener;
import net.vpc.upa.UPAContext;
import net.vpc.upa.PersistenceGroupSecurityManager;
import net.vpc.upa.callbacks.EntityInterceptor;
import net.vpc.upa.callbacks.DefinitionListener;
import net.vpc.upa.callbacks.PersistenceGroupDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitListener;
import net.vpc.upa.config.OnAlter;
import net.vpc.upa.config.OnCreate;
import net.vpc.upa.config.OnDrop;
import net.vpc.upa.config.OnInitialize;
import net.vpc.upa.config.OnPersist;
import net.vpc.upa.config.OnRemove;
import net.vpc.upa.config.OnReset;
import net.vpc.upa.config.OnUpdate;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.EqualsStringFilter;
import net.vpc.upa.impl.util.SimpleEntityFilter;
import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TypesFactory;

/**
 *
 * @author vpc
 */
public class ConfigureScanListener implements ScanListener {

    private static final Logger log = Logger.getLogger(ConfigureScanListener.class.getName());
    private ScanListener listener;
    private Map<Class, Object> instances = new HashMap<Class, Object>();
    List<PersistenceGroup> createdPersistenceGroups = new ArrayList<PersistenceGroup>();

    public ConfigureScanListener(ScanListener listener) {
        this.listener = listener;
    }

    public void contextItemScanned(ScanEvent event) {
        if (listener != null) {
            listener.contextItemScanned(event);
        }
        final UPAContext context = event.getContext();
        final Class tt = event.getVisitedType();
        if (event.getContract().equals(PersistenceGroupDefinitionListener.class)) {
            Object i = instances.get(tt);
            if (i == null) {
                i = context.getFactory().createObject(tt);
                instances.put(tt, i);
            }
            context.addPersistenceGroupDefinitionListener((PersistenceGroupDefinitionListener) i);
        }
    }

    public void persistenceGroupItemScanned(ScanEvent event) {
        if (listener != null) {
            listener.persistenceGroupItemScanned(event);
        }
        final PersistenceGroup persistenceGroup = event.getPersistenceGroup();
        Class t = event.getVisitedType();
        if (event.getContract().equals(PersistenceUnitDefinitionListener.class)) {
            Object i = instances.get(t);
            if (i == null) {
                i = persistenceGroup.getFactory().getSingleton(t);
                instances.put(t, i);
            }
            persistenceGroup.addPersistenceUnitDefinitionListener((PersistenceUnitDefinitionListener) i);
        }
        if (event.getContract().equals(PersistenceGroupSecurityManager.class)) {
            Object i = instances.get(t);
            if (i == null) {
                i = persistenceGroup.getFactory().getSingleton(t);
                instances.put(t, i);
            }
            persistenceGroup.setPersistenceGroupSecurityManager((PersistenceGroupSecurityManager) i);
        }
    }

    public void persistenceUnitItemScanned(ScanEvent event) {
        if (listener != null) {
            listener.persistenceUnitItemScanned(event);
        }
        final PersistenceUnit persistenceUnit = event.getPersistenceUnit();
        final Class contract = event.getContract();
        final Class type = event.getVisitedType();
        if (URLAnnotationStrategySupport.isPersistenceUnitItemDefinitionListener(contract)) {
            Object i = instances.get(type);
            if (i == null) {
                i = persistenceUnit.getFactory().createObject(type);
                instances.put(type, i);
            }
            Decoration at = (Decoration) event.getUserObject();
            String _filter = at.getString("filter");
            boolean _trackSystemObjects = at.getBoolean("trackSystemObjects");
//                    Callback cb = (Callback) at.getAnnotation();
            if (_filter.length() == 0) {
                persistenceUnit.addDefinitionListener((DefinitionListener) i, _trackSystemObjects);
            } else {
                persistenceUnit.addDefinitionListener(_filter, (DefinitionListener) i, _trackSystemObjects);
            }
        } else if (PersistenceUnitListener.class.equals(contract)) {
            Object i = instances.get(type);
            if (i == null) {
                i = persistenceUnit.getFactory().createObject(type);
                instances.put(type, i);
            }
            persistenceUnit.addPersistenceUnitListener((PersistenceUnitListener) i);
        } else if (EntityInterceptor.class.equals(contract)) {
            EntityInterceptor i = (EntityInterceptor) instances.get(type);
            if (i == null) {
                try {
                    i = (EntityInterceptor) persistenceUnit.getFactory().createObject(type);
                } catch (Exception ex) {
                    log.log(Level.SEVERE, null, ex);
                }
                if (i != null) {
                    instances.put(type, i);
                }
            }
            if (i != null) {
                Decoration at = (Decoration) event.getUserObject();
                String _filter = at.getString("filter");
                String _name = at.getString("name");
                if (Strings.isNullOrEmpty(_name)) {
                    _name = i.getClass().getSimpleName();
                }
                boolean _trackSystemObjects = at.getBoolean("trackSystemObjects");
//                    Callback cb = (Callback) at.getAnnotation();
                persistenceUnit.addTrigger(_name, i, _filter, _trackSystemObjects);
            }
        } else if (EntityDescriptor.class.equals(event.getContract())) {
            EntityDescriptor desc = (EntityDescriptor) event.getUserObject();
            persistenceUnit.addEntity(desc);
        } else if (Function.class.equals(event.getContract())) {
            Function f = (Function) persistenceUnit.getFactory().createObject(event.getVisitedType());
            Decoration d = (Decoration) event.getUserObject();
//                net.vpc.upa.config.FunctionDefinition d = type.getAnnotation();
            DataType dt = TypesFactory.forPlatformType(d.getType("returnType"));
            String n = d.getString("name");
            if (Strings.isNullOrEmpty(n)) {
                n = d.getLocationType();
            }
            persistenceUnit.getExpressionManager().addFunction(n, dt, f);
        } else if (Callback.class.equals(event.getContract())) {
            DecoratedMethodScan dms = (DecoratedMethodScan) event.getUserObject();
            Decoration at = dms.getDecoration();
//                net.vpc.upa.config.FunctionDefinition d = type.getAnnotation();
            CallbackType callbackType = PlatformUtils.getUndefinedValue(CallbackType.class);
            Map<String, Object> conf = new HashMap<String, Object>();
            if (at.isName(OnAlter.class)) {
                callbackType = CallbackType.ON_UPDATE;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnCreate.class)) {
                callbackType = CallbackType.ON_CREATE;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnDrop.class)) {
                callbackType = CallbackType.ON_DROP;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnPersist.class)) {
                callbackType = CallbackType.ON_PERSIST;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnUpdate.class)) {
                callbackType = CallbackType.ON_UPDATE;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnRemove.class)) {
                callbackType = CallbackType.ON_REMOVE;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnReset.class)) {
                callbackType = CallbackType.ON_RESET;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(OnInitialize.class)) {
                callbackType = CallbackType.ON_INITIALIZE;
                conf.put("before", at.getBoolean("before"));
                conf.put("after", at.getBoolean("after"));
                conf.put("trackSystemObjects", at.getBoolean("trackSystemObjects"));
            } else if (at.isName(net.vpc.upa.config.Function.class)) {
                callbackType = CallbackType.ON_EVAL;
                String functionName = at.getString("name");
                Class returnType = at.getType("returnType");
                if (!Strings.isNullOrEmpty(functionName)) {
                    conf.put("functionName", functionName);
                }
                if (returnType != null && !PlatformUtils.isVoid(returnType)) {
                    conf.put("returnType", returnType);
                }
            }
            if (callbackType != null) {
                Object instance = null;
                if (!PlatformUtils.isStatic(dms.getMethod())) {
                    instance = persistenceUnit.getFactory().getSingleton(event.getVisitedType());
                }
                net.vpc.upa.Callback cb = persistenceUnit.getPersistenceGroup().getContext().createCallback(
                        instance,
                        dms.getMethod(),
                        callbackType,
                        conf
                );
                persistenceUnit.addCallback(cb);
            }

        } else if (EntitySecurityManager.class.equals(event.getContract())) {
            Decoration d = (Decoration) event.getUserObject();
            EntitySecurityManager secu = (EntitySecurityManager) persistenceUnit.getFactory().createObject(event.getVisitedType());
            EntityConfiguratorProcessor.configureOneShot(persistenceUnit, new SimpleEntityFilter(
                    new EqualsStringFilter(d.getString("entity"), false, false),
                    true
            ), new SecurityManagerEntityConfigurator(secu));
        }
    }

}
