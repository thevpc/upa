/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import java.lang.reflect.Method;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.*;
import net.vpc.upa.Callback;
import net.vpc.upa.Function;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.callbacks.*;
import net.vpc.upa.config.*;
import net.vpc.upa.config.OnInit;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.EqualsStringFilter;
import net.vpc.upa.impl.util.SimpleEntityFilter;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeFactory;

/**
 * @author taha.bensalah@gmail.com
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
                if (StringUtils.isNullOrEmpty(_name)) {
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
            DataType dt = DataTypeFactory.forPlatformType(d.getType("returnType"));
            String n = d.getString("name");
            if (StringUtils.isNullOrEmpty(n)) {
                n = d.getLocationType();
            }
            persistenceUnit.getExpressionManager().addFunction(n, dt, f);
        } else if (Callback.class.equals(event.getContract())) {
            Callback callbackType = (Callback) persistenceUnit.getFactory().createObject(event.getVisitedType());
            persistenceUnit.addCallback(callbackType);
        } else if (EntitySecurityManager.class.equals(event.getContract())) {
            Decoration d = (Decoration) event.getUserObject();
            EntitySecurityManager secu = (EntitySecurityManager) persistenceUnit.getFactory().createObject(event.getVisitedType());
            EntityConfiguratorProcessor.configureOneShot(persistenceUnit, new SimpleEntityFilter(
                    new EqualsStringFilter(d.getString("entity"), false, false),
                    true
            ), new SecurityManagerEntityConfigurator(secu));
        } else if (PersistenceNameRule.class.equals(event.getContract())) {
            PersistenceNameRule rule = (PersistenceNameRule) event.getUserObject();
            persistenceUnit.getPersistenceNameStrategy().addPersistenceNameRule(rule);
        } else if (event.getUserObject() instanceof DecoratedMethodScan) {
            DecoratedMethodScan dms = (DecoratedMethodScan) event.getUserObject();
            Decoration callbackDecoration = dms.getDecoration();
            configureMethodCallback(type, dms.getMethod(), callbackDecoration, persistenceUnit);
        }
    }

    public static void configureMethodCallback(Class type, Method method, Decoration methodDecoration, PersistenceUnit persistenceUnit) {
        CallbackType callbackType = PlatformUtils.getUndefinedValue(CallbackType.class);
        EventPhase callbackPhase = PlatformUtils.getUndefinedValue(EventPhase.class);
        List<ObjectType> objectTypes = new ArrayList<>();
        Map<String, Object> conf = new HashMap<String, Object>();
        if (methodDecoration.isName(OnPreAlter.class)) {
            callbackType = CallbackType.ON_ALTER;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.addAll(Arrays.asList(methodDecoration.getPrimitiveArray("types", ObjectType.class)));
        } else if (methodDecoration.isName(OnAlter.class)) {
            callbackType = CallbackType.ON_ALTER;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.addAll(Arrays.asList(methodDecoration.getPrimitiveArray("types", ObjectType.class)));
        } else if (methodDecoration.isName(OnPreCreate.class)) {
            callbackType = CallbackType.ON_CREATE;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.addAll(Arrays.asList(methodDecoration.getPrimitiveArray("types", ObjectType.class)));
        } else if (methodDecoration.isName(OnCreate.class)) {
            callbackType = CallbackType.ON_CREATE;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.addAll(Arrays.asList(methodDecoration.getPrimitiveArray("types", ObjectType.class)));
        } else if (methodDecoration.isName(OnPreDrop.class)) {
            callbackType = CallbackType.ON_DROP;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.addAll(Arrays.asList(methodDecoration.getPrimitiveArray("types", ObjectType.class)));
        } else if (methodDecoration.isName(OnDrop.class)) {
            callbackType = CallbackType.ON_DROP;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.addAll(Arrays.asList(methodDecoration.getPrimitiveArray("types", ObjectType.class)));


        } else if (methodDecoration.isName(OnPrePersist.class)) {
            callbackType = CallbackType.ON_PERSIST;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPersist.class)) {
            callbackType = CallbackType.ON_PERSIST;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPreUpdate.class)) {
            callbackType = CallbackType.ON_UPDATE;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnUpdate.class)) {
            callbackType = CallbackType.ON_UPDATE;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPreRemove.class)) {
            callbackType = CallbackType.ON_REMOVE;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnRemove.class)) {
            callbackType = CallbackType.ON_REMOVE;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPreReset.class)) {
            callbackType = CallbackType.ON_RESET;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnReset.class)) {
            callbackType = CallbackType.ON_RESET;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPreInit.class)) {
            callbackType = CallbackType.ON_INIT;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnInit.class)) {
            callbackType = CallbackType.ON_INIT;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPrePrepare.class)) {
            callbackType = CallbackType.ON_PREPARE;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPrepare.class)) {
            callbackType = CallbackType.ON_PREPARE;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            objectTypes.add(ObjectType.ENTITY);
        } else if (methodDecoration.isName(OnPreUpdateFormula.class)) {
            callbackType = CallbackType.ON_UPDATE_FORMULAS;
            callbackPhase = EventPhase.BEFORE;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            if (method.getParameterTypes().length > 0) {
                Class<?> p = method.getParameterTypes()[0];
                if (p.equals(PersistenceUnitEvent.class)) {
                    objectTypes.add(ObjectType.PERSISTENCE_UNIT);
                } else if (EntityEvent.class.isAssignableFrom(p)) {
                    objectTypes.add(ObjectType.ENTITY);
                } else {
                    objectTypes.add(ObjectType.PERSISTENCE_UNIT);
                }
            } else {
                objectTypes.add(ObjectType.PERSISTENCE_UNIT);
            }
        } else if (methodDecoration.isName(OnUpdateFormula.class)) {
            callbackType = CallbackType.ON_UPDATE_FORMULAS;
            callbackPhase = EventPhase.AFTER;
            conf.put("trackSystemObjects", methodDecoration.getBoolean("trackSystemObjects"));
            conf.put("nameFilter", methodDecoration.getString("name"));
            if (method.getParameterTypes().length > 0) {
                Class<?> p = method.getParameterTypes()[0];
                if (p.equals(PersistenceUnitEvent.class)) {
                    objectTypes.add(ObjectType.PERSISTENCE_UNIT);
                } else if (EntityEvent.class.isAssignableFrom(p)) {
                    objectTypes.add(ObjectType.ENTITY);
                } else {
                    objectTypes.add(ObjectType.PERSISTENCE_UNIT);
                }
            } else {
                objectTypes.add(ObjectType.PERSISTENCE_UNIT);
            }
        } else if (methodDecoration.isName(net.vpc.upa.config.Function.class)) {
            objectTypes.add(ObjectType.FUNCTION);
            callbackType = CallbackType.ON_EVAL_FUNCTION;
            callbackPhase = EventPhase.AFTER;
            String functionName = methodDecoration.getString("name");
            Class returnType = methodDecoration.getType("returnType");
            if (!StringUtils.isNullOrEmpty(functionName)) {
                conf.put("functionName", functionName);
            }
            if (returnType != null && !PlatformUtils.isVoid(returnType)) {
                conf.put("returnType", returnType);
            }
        } else if (methodDecoration.isName(net.vpc.upa.config.NamedFormula.class)) {
            objectTypes.add(ObjectType.FORMULA);
            callbackType = CallbackType.ON_EVAL_FORMULA;
            callbackPhase = EventPhase.AFTER;
            String formulaName = methodDecoration.getString("name");
            if (!StringUtils.isNullOrEmpty(formulaName)) {
                conf.put("formulaName", formulaName);
            }
        }
        if (callbackType != null) {
            if (objectTypes.isEmpty()) {
                objectTypes.add(null);
            }
            Object instance = null;
            if (!PlatformUtils.isStatic(method)) {
                instance = persistenceUnit.getFactory().getSingleton(type);
            }
            for (ObjectType o : objectTypes) {
                persistenceUnit.addCallback(new MethodCallback(instance,
                        method,
                        o,
                        callbackType,
                        callbackPhase,
                        conf));
            }
        }
    }

}
