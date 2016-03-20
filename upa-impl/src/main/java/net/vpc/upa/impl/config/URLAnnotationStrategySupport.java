package net.vpc.upa.impl.config;

import net.vpc.upa.callbacks.TriggerDefinitionListener;
import net.vpc.upa.callbacks.IndexDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitDefinitionListener;
import net.vpc.upa.callbacks.EntityInterceptor;
import net.vpc.upa.callbacks.SectionDefinitionListener;
import net.vpc.upa.callbacks.RelationshipDefinitionListener;
import net.vpc.upa.callbacks.FieldDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitListener;
import net.vpc.upa.callbacks.EntityDefinitionListener;
import net.vpc.upa.callbacks.PackageDefinitionListener;
import net.vpc.upa.callbacks.PersistenceGroupDefinitionListener;
import net.vpc.upa.config.ConfigInfo;
import java.lang.reflect.Method;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.config.decorations.DefaultDecorationFilter;
import net.vpc.upa.impl.util.classpath.DecorationParser;
import net.vpc.upa.persistence.PersistenceUnitConfig;
import java.util.ArrayList;
import java.util.Collections;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPAContext;
import net.vpc.upa.config.Callback;
import net.vpc.upa.exceptions.UPAException;

import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.CallbackType;
import net.vpc.upa.EntityDescriptor;
import net.vpc.upa.EntitySecurityManager;
import net.vpc.upa.Function;
import net.vpc.upa.ScanEvent;
import net.vpc.upa.ScanListener;
import net.vpc.upa.PersistenceGroupSecurityManager;
import net.vpc.upa.UPASecurityManager;
import net.vpc.upa.config.Partial;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.ScanSource;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.config.OnAlter;
import net.vpc.upa.config.OnCreate;
import net.vpc.upa.config.OnDrop;
import net.vpc.upa.config.OnInitialize;
import net.vpc.upa.config.OnPersist;
import net.vpc.upa.config.OnRemove;
import net.vpc.upa.config.OnReset;
import net.vpc.upa.config.OnUpdate;
import net.vpc.upa.config.OnUpdateFormula;
import net.vpc.upa.config.SecurityContext;
import net.vpc.upa.config.DecorationValue;
import net.vpc.upa.config.OnPreAlter;
import net.vpc.upa.config.OnPreCreate;
import net.vpc.upa.config.OnPreDrop;
import net.vpc.upa.config.OnPreInitialize;
import net.vpc.upa.config.OnPrePersist;
import net.vpc.upa.config.OnPreRemove;
import net.vpc.upa.config.OnPreReset;
import net.vpc.upa.config.OnPreUpdate;
import net.vpc.upa.config.OnPreUpdateFormula;
import net.vpc.upa.impl.config.decorations.SimpleDecoration;
import net.vpc.upa.impl.util.OrderedIem;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.PersistenceGroupConfig;
import net.vpc.upa.persistence.PersistenceNameConfig;
import net.vpc.upa.persistence.PersistenceNameType;
import net.vpc.upa.persistence.UPAContextConfig;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 12:28 AM
 */
public class URLAnnotationStrategySupport {

    private static final Logger log = Logger.getLogger(URLAnnotationStrategySupport.class.getName());
    private static final Class[] persistenceUnitItemDefinitionListenerTypes = new Class[]{
        PackageDefinitionListener.class, SectionDefinitionListener.class, EntityDefinitionListener.class, FieldDefinitionListener.class, IndexDefinitionListener.class, TriggerDefinitionListener.class //            , PersistenceUnitTriggerDefinitionListener.class
        , RelationshipDefinitionListener.class
    };

    public static boolean isPersistenceUnitItemDefinitionListener(Class c) {
        for (Class p : persistenceUnitItemDefinitionListenerTypes) {
            if (p.isAssignableFrom(c)) {
                return true;
            }
        }
        return false;
    }

    public static Class[] getPersistenceUnitItemDefinitionListener(Class c) {
        ArrayList<Class> all = new ArrayList<Class>();
        for (Class p : persistenceUnitItemDefinitionListenerTypes) {
            if (p.isAssignableFrom(c)) {
                all.add(p);
            }
        }
        return all.toArray(new Class[all.size()]);
    }

    public void scan(UPAContext context, ScanSource source, DecorationRepository decorationRepository, ScanListener listener) throws UPAException {
        try {
            DecorationParser parser = new DecorationParser(UPAUtils.toConfigurationStrategy(source).toIterable(context),
                    new DefaultDecorationFilter()
                    .addDecorations(
                            Callback.class,
                            OnAlter.class,
                            OnCreate.class,
                            OnDrop.class,
                            OnRemove.class,
                            OnPersist.class,
                            OnRemove.class,
                            OnUpdate.class,
                            OnUpdateFormula.class,
                            OnInitialize.class,
                            OnReset.class,
                            SecurityContext.class,
                            net.vpc.upa.config.PersistenceUnit.class,
                            net.vpc.upa.config.PersistenceNameStrategy.class,
                            net.vpc.upa.config.Properties.class,
                            net.vpc.upa.config.Property.class)
                    .addTypeDecorations(
                            "javax.annotation.PostConstruct"
                    ), null, null, decorationRepository);
            parser.parse();
            //repository that contains just the scanned classes
            //older classes
            DecorationRepository newDecorationRepository = parser.getNewDecorationRepository();
            processJAVAXAnnotations(decorationRepository, newDecorationRepository, source.isNoIgnore());
//            Map<Class, Object> instances = new HashMap<Class, Object>();
//            for (PersistenceGroupDefinitionListener old : context.getPersistenceGroupDefinitionListeners()) {
//                if(!instances.containsKey(old.getClass())){
//                    instances.put(old.getClass(), old);
//                }
//            }

            for (Decoration dec : newDecorationRepository.getDeclaredDecorations(Callback.class.getName())) {
                Class tt = PlatformUtils.forName(dec.getLocationType());
                Decoration ignored = source.isNoIgnore() ? null : newDecorationRepository.getTypeDecoration(dec.getLocationType(), Ignore.class.getName());
                if (ignored == null) {
                    if (PersistenceGroupDefinitionListener.class.isAssignableFrom(tt)) {
                        if (listener != null) {
                            listener.contextItemScanned(new ScanEvent(context, null, null, PersistenceGroupDefinitionListener.class, tt, null, null, dec, null));
                        }
                    }
                }
            }
            List<OrderedIem<PersistenceUnitConfig>> persistenceUnitConfigs = new ArrayList<OrderedIem<PersistenceUnitConfig>>();
            for (PersistenceGroupConfig persistenceGroupConfig : context.getBootstrapContextConfig().getPersistenceGroups()) {
                for (PersistenceUnitConfig persistenceUnitConfig : persistenceGroupConfig.getPersistenceUnits()) {
                    persistenceUnitConfigs.add(new OrderedIem<PersistenceUnitConfig>(Integer.MAX_VALUE, persistenceUnitConfig));
                }
            }

            for (Decoration configPersistenceUnit : newDecorationRepository.getDeclaredDecorations(net.vpc.upa.config.PersistenceUnit.class.getName())) {
                Decoration ignored = source.isNoIgnore() ? null : newDecorationRepository.getTypeDecoration(configPersistenceUnit.getLocationType(), Ignore.class.getName());
                if (ignored == null) {

                    PersistenceUnitConfig c = new PersistenceUnitConfig();
                    c.setName(Strings.trim(configPersistenceUnit.getString("name")));
                    c.setPersistenceGroup(Strings.trim(configPersistenceUnit.getString("persistenceGroup")));
                    for (Object configPropertyObj : configPersistenceUnit.getArray("properties")) {
                        Decoration configProperty = (Decoration) configPropertyObj;
                        Object v = UPAUtils.createValue(new net.vpc.upa.Property(configProperty.getString("name"),
                                configProperty.getString("value"),
                                configProperty.getString("type"),
                                configProperty.getString("format")
                        ));
                        c.getProperties().put(configProperty.getString("name"), v);
                    }
                    persistenceUnitConfigs.add(new OrderedIem<PersistenceUnitConfig>(configPersistenceUnit.getInt("order"), c));
                }
            }

            Map<String, PersistenceUnitConfig> partialPersistenceUnitConfig = new HashMap<String, PersistenceUnitConfig>();
            for (Decoration a : newDecorationRepository.getDeclaredDecorations(net.vpc.upa.config.PersistenceNameStrategy.class.getName())) {
                Decoration ignored = newDecorationRepository.getTypeDecoration(a.getLocationType(), Ignore.class.getName());
                if (ignored == null) {

                    Decoration config = a.getDecoration("config");
                    int configOrder = config.getInt("order");
                    String key = Strings.trim(config.getString("persistenceGroup")) + "/" + Strings.trim(config.getString("persistenceUnit")) + "/" + configOrder;
                    PersistenceUnitConfig puc = partialPersistenceUnitConfig.get(key);
                    if (puc == null) {
                        puc = new PersistenceUnitConfig();
                        partialPersistenceUnitConfig.put(key, puc);
                        persistenceUnitConfigs.add(new OrderedIem<PersistenceUnitConfig>(configOrder, puc));
                    }
                    PersistenceNameConfig target = puc.getModel();
                    if (target == null) {
                        target = new PersistenceNameConfig(UPAContextConfig.XML_ORDER);
                        puc.setModel(target);
                    }
                    merge(a, target);
                }
            }

            //persistence groups
            List<PersistenceGroup> createdPersistenceGroups = new ArrayList<PersistenceGroup>();

            List<PersistenceUnitConfig> buildPersistenceUnitConfigs = buildPersistenceUnitConfigs(persistenceUnitConfigs);
            for (PersistenceUnitConfig c : buildPersistenceUnitConfigs) {
                if (!Strings.isSimpleExpression(c.getPersistenceGroup())) {
                    if (listener != null) {
                        listener.contextItemScanned(new ScanEvent(context, null, null, PersistenceUnitConfig.class, null, c));
                    }
                    if (!context.containsPersistenceGroup(c.getPersistenceGroup())) {
                        PersistenceGroup pg = context.addPersistenceGroup(c.getPersistenceGroup());
                        createdPersistenceGroups.add(pg);
                    }
                }
            }

            if (context.getPersistenceGroups().isEmpty()) {
                createdPersistenceGroups.add(context.addPersistenceGroup(null));
                log.log(Level.FINE, "No PersistenceGroup found, create default one");
            }
            for (PersistenceGroup g : createdPersistenceGroups) {
//                int count = 0;
                for (PersistenceGroupConfig pgc : context.getBootstrapContextConfig().getPersistenceGroups()) {
                    if (Strings.matchesSimpleExpression(g.getName(), pgc.getName())) {
                        if (pgc.getAutoScan() != null) {
                            g.setAutoScan(pgc.getAutoScan());
                        }
                        for (ScanFilter a : pgc.getContextAnnotationStrategyFilters()) {
                            g.addContextAnnotationStrategyFilter(a);
                        }
                    }
                }
                if (listener != null) {
                    listener.contextItemScanned(new ScanEvent(context, null, null, PersistenceGroup.class, null, g));
                }
                g.scan(source, listener, false);
            }

            //persistence units
            List<PersistenceUnit> createdPersistenceUnits = new ArrayList<PersistenceUnit>();
            for (PersistenceUnitConfig c : buildPersistenceUnitConfigs) {
                if (!Strings.isSimpleExpression(c.getName())) {
                    for (PersistenceGroup persistenceGroup : context.getPersistenceGroups()) {
                        if (Strings.matchesSimpleExpression(persistenceGroup.getName(), c.getPersistenceGroup())) {
                            if (!persistenceGroup.containsPersistenceUnit(c.getName())) {
                                PersistenceUnit pu = persistenceGroup.addPersistenceUnit(c.getName());
                                createdPersistenceUnits.add(pu);
                            }
                        }
                    }
                }
            }
            for (PersistenceUnit pu : createdPersistenceUnits) {
                boolean autoScan = false;
                for (PersistenceUnitConfig puc : buildPersistenceUnitConfigs) {
                    if (Strings.matchesSimpleExpression(pu.getPersistenceGroup().getName(), puc.getPersistenceGroup())
                            && Strings.matchesSimpleExpression(pu.getName(), puc.getName())) {
                        if ((puc.getAutoScan() != null)) {
                            pu.setAutoScan(autoScan);
                        }
                        pu.setAutoStart(puc.getAutoStart() == null ? Boolean.TRUE : puc.getAutoStart().booleanValue());
                        PersistenceNameConfig oldPersistenceNameConfig = pu.getPersistenceNameConfig();
                        merge(puc.getModel(), oldPersistenceNameConfig);
                        pu.setPersistenceNameConfig(oldPersistenceNameConfig);
                        for (ScanFilter a : puc.getFilters()) {
                            puc.addContextAnnotationStrategyFilter(a);
                        }
                        for (ConnectionConfig connectionConfig : puc.getConnections()) {
                            pu.addConnectionConfig(connectionConfig);
                        }
                        for (ConnectionConfig connectionConfig : puc.getRootConnections()) {
                            pu.addRootConnectionConfig(connectionConfig);
                        }
                    }
                }
                if (listener != null) {
                    listener.contextItemScanned(new ScanEvent(context, null, null, PersistenceUnit.class, null, pu));
                }
                pu.scan(source, listener, false);
            }

        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("URLAnnotationStrategySupportConfigureException"));
        }
    }

    public void scan(PersistenceGroup persistenceGroup, ScanSource strategy, DecorationRepository decorationRepository, ScanListener listener) throws UPAException {
        try {
            DecorationParser parser = new DecorationParser(UPAUtils.toConfigurationStrategy(strategy).toIterable(persistenceGroup),
                    new DefaultDecorationFilter()
                    .addDecorations(
                            Callback.class,
                            OnAlter.class,
                            OnCreate.class,
                            OnDrop.class,
                            OnRemove.class,
                            OnPersist.class,
                            OnRemove.class,
                            OnUpdate.class,
                            OnUpdateFormula.class,
                            OnInitialize.class,
                            OnReset.class
                    )
                    .addDecorations(SecurityContext.class)
                    .addTypeDecorations(
                            "javax.annotation.PostConstruct"
                    ), persistenceGroup.getName(), null, decorationRepository);
            parser.parse();
            DecorationRepository repo = parser.getDecorationRepository();
            DecorationRepository newrepo = parser.getNewDecorationRepository();
            processJAVAXAnnotations(repo, newrepo, strategy.isNoIgnore());
            for (Decoration at : newrepo.getDeclaredDecorations(Callback.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = strategy.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
                if (ignored == null) {
                    if (PersistenceUnitDefinitionListener.class.isAssignableFrom(t)) {
                        if (listener != null) {
                            listener.persistenceGroupItemScanned(new ScanEvent(persistenceGroup.getContext(), persistenceGroup, null, PersistenceUnitDefinitionListener.class, t, null));
                        }
                    }
                }
            }
            for (Decoration at : newrepo.getDeclaredDecorations(SecurityContext.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = strategy.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
                if (ignored == null) {
                    boolean ok = false;
                    if (PersistenceGroupSecurityManager.class.isAssignableFrom(t)) {
                        ok = true;
                        if (listener != null) {
                            listener.persistenceGroupItemScanned(new ScanEvent(persistenceGroup.getContext(), persistenceGroup, null, PersistenceGroupSecurityManager.class, t, null));
                        }
                    }
                    if (UPASecurityManager.class.isAssignableFrom(t)) {
                        ok = true;
                        if (listener != null) {
                            listener.persistenceGroupItemScanned(new ScanEvent(persistenceGroup.getContext(), persistenceGroup, null, UPASecurityManager.class, t, null));
                        }
                    }
                    if (EntitySecurityManager.class.isAssignableFrom(t)) {
                        ok = true;
                        //will be processed as persistence unit listener
                    }
                    if (!ok) {
                        log.log(Level.WARNING, "@SecurityContext ignored as annotating any of PersistenceGroupSecurityManager, UPASecurityManager");
                    }
                }
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("URLAnnotationStrategySupportConfigureException"));
        }
    }

    public void scan(PersistenceUnit persistenceUnit, ScanSource strategy, DecorationRepository decorationRepository, ScanListener listener) throws UPAException {
        try {
            EntityDescriptorResolver r = new EntityDescriptorResolver(persistenceUnit, decorationRepository);
            DecorationParser parser = new DecorationParser(
                    UPAUtils.toConfigurationStrategy(strategy).toIterable(persistenceUnit),
                    new DefaultDecorationFilter()
                    .addDecorations(
                            net.vpc.upa.config.SecurityContext.class,
                            net.vpc.upa.config.Config.class,
                            net.vpc.upa.config.Field.class,
                            net.vpc.upa.config.FilterEntity.class,
                            net.vpc.upa.config.Formula.class,
                            net.vpc.upa.config.Formulas.class,
                            net.vpc.upa.config.Id.class,
                            net.vpc.upa.config.Ignore.class,
                            net.vpc.upa.config.Index.class,
                            net.vpc.upa.config.Indexes.class,
                            net.vpc.upa.config.Init.class,
                            net.vpc.upa.config.ManyToOne.class,
                            net.vpc.upa.config.Partial.class,
                            net.vpc.upa.config.Password.class,
                            net.vpc.upa.config.ToString.class,
                            net.vpc.upa.config.ToByteArray.class,
                            net.vpc.upa.config.Converter.class,
                            net.vpc.upa.config.Path.class,
                            net.vpc.upa.config.PersistenceName.class,
                            net.vpc.upa.config.PersistenceNameStrategy.class,
                            net.vpc.upa.config.PersistenceUnit.class,
                            net.vpc.upa.config.Properties.class,
                            net.vpc.upa.config.Property.class,
                            net.vpc.upa.config.Function.class,
                            net.vpc.upa.config.Search.class,
                            net.vpc.upa.config.Secret.class,
                            net.vpc.upa.config.Sequence.class,
                            net.vpc.upa.config.Singleton.class,
                            net.vpc.upa.config.Temporal.class,
                            net.vpc.upa.config.Transactional.class,
                            net.vpc.upa.config.Hierarchy.class,
                            net.vpc.upa.config.Callback.class,
                            OnPreAlter.class,
                            OnAlter.class,
                            OnPreCreate.class,
                            OnCreate.class,
                            OnPreDrop.class,
                            OnDrop.class,
                            OnPreRemove.class,
                            OnRemove.class,
                            OnPrePersist.class,
                            OnPrePersist.class,
                            OnPersist.class,
                            OnPreUpdate.class,
                            OnUpdate.class,
                            OnPreUpdateFormula.class,
                            OnUpdateFormula.class,
                            OnPreInitialize.class,
                            OnInitialize.class,
                            OnPreReset.class,
                            OnReset.class,
                            net.vpc.upa.config.UnionEntity.class,
                            net.vpc.upa.config.UnionEntityEntry.class,
                            net.vpc.upa.config.View.class,
                            net.vpc.upa.config.Entity.class,
                            net.vpc.upa.config.Partial.class
                    )
                    .addTypeDecorations(
                            "javax.persistence.Entity", "javax.persistence.Id", "javax.persistence.ManyToOne", "javax.annotation.PostConstruct"
                    ),
                    persistenceUnit.getPersistenceGroup().getName(), persistenceUnit.getName(), decorationRepository);
            parser.parse();
            DecorationRepository repo = parser.getDecorationRepository();
            DecorationRepository newrepo = parser.getNewDecorationRepository();
            processJAVAXAnnotations(repo, newrepo, strategy.isNoIgnore());
            for (Decoration at : newrepo.getDeclaredDecorations(Callback.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = strategy.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
                if (ignored != null) {
                    continue;
                }
                for (Method m : PlatformUtils.getAllConcreteMethods(t)) {
                    Decoration[] mdecos = newrepo.getMethodDecorations(m);
                    for (Decoration mdeco : mdecos) {
                        if (listener != null) {
                            listener.persistenceUnitItemScanned(new ScanEvent(
                                    persistenceUnit.getPersistenceGroup().getContext(),
                                    persistenceUnit.getPersistenceGroup(), persistenceUnit, Object.class, t,
                                    new DecoratedMethodScan(mdeco, m)));
                        }
                    }
                }
                if (isPersistenceUnitItemDefinitionListener(t)) {
                    if (listener != null) {
                        for (Class tt : getPersistenceUnitItemDefinitionListener(t)) {
                            listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(),
                                    persistenceUnit.getPersistenceGroup(), persistenceUnit, tt, t, at));
                        }
                    }

                }
                if (PersistenceUnitListener.class.isAssignableFrom(t)) {
                    if (listener != null) {
                        listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, PersistenceUnitListener.class, t, null));
                    }
                }
                if (EntityInterceptor.class.isAssignableFrom(t)) {
                    if (listener != null) {
                        listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, EntityInterceptor.class, t, at));
                    }
                }
            }
            Map<Class, Set<Class>> entityClasses = new LinkedHashMap<Class, Set<Class>>();
            Map<Class, Class> partialEntities = new LinkedHashMap<Class, Class>();

            for (Decoration at : newrepo.getDeclaredDecorations(net.vpc.upa.config.Entity.class.getName())) {
                Class tt = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = strategy.isNoIgnore() ? null : newrepo.getTypeDecoration(tt, Ignore.class);
                if (ignored != null) {
                    log.log(Level.FINE, "\t Ignored Entity {0}", tt);
                    continue;
                }
                Class entityType = at.getType("entityType");
                if (entityType != null && (Void.TYPE.equals(entityType) || Void.class.equals(entityType))) {
                    entityType = tt;
                }
                Set<Class> s = entityClasses.get(entityType);
                if (s == null) {
                    s = new LinkedHashSet<Class>();
                    entityClasses.put(entityType, s);
                }
                if (tt.equals(entityType)) {
                    log.log(Level.FINEST, "\t Detect Entity {0}", tt);
                } else {
                    log.log(Level.FINEST, "\t Detect Entity {0} as {1}", entityType);
                }
                if (listener != null) {
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, net.vpc.upa.config.Entity.class, tt,
                            null
                    ));
                }
                s.add(tt);
            }

            for (Decoration at : newrepo.getDeclaredDecorations(Partial.class.getName())) {
                Class tt = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = newrepo.getTypeDecoration(tt, Ignore.class);
                if (ignored != null) {
                    log.log(Level.FINE, "\t Ignored Entity {0}", tt);
                    continue;
                }
                Decoration entityAnnotation = newrepo.getTypeDecoration(tt, net.vpc.upa.config.Entity.class);
                if (entityAnnotation == null) {
                    throw new IllegalArgumentException("Missing @Entity along with @Partial for " + tt);
                }
                partialEntities.put(tt, at.getType("value"));
                entityClasses.remove(tt);
                log.log(Level.FINE, "\t Detect Partial Entity {0} as {1}", new Object[]{at.getType("value"), tt});
                if (listener != null) {
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, Partial.class, tt,
                            null
                    ));
                }
            }

            for (Map.Entry<Class, Class> entry : partialEntities.entrySet()) {
                Class rootEntity = getRootEntity(entry.getKey(), entityClasses, partialEntities);
                if (rootEntity == null) {
//                    rootEntity = getRootEntity(entry.getKey(), entityClasses, partialEntities);
                    throw new IllegalArgumentException("Partial Entity " + entry.getKey() + " references invalid Entity or Partial (" + entry.getValue() + ")");
                }
                entityClasses.get(rootEntity).add(entry.getKey());
            }
            for (Set<Class> ee : entityClasses.values()) {
                if (listener != null) {
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, EntityDescriptor.class, EntityDescriptor.class,
                            r.resolve(ee.toArray(new Class[ee.size()]))
                    ));
                }
            }

            for (Decoration d : newrepo.getDeclaredDecorations(net.vpc.upa.config.Function.class.getName())) {
                final Class tt = PlatformUtils.forName(d.getLocationType());
                Decoration ignored = strategy.isNoIgnore() ? null : newrepo.getTypeDecoration(tt, Ignore.class);
                if (ignored != null) {
                    log.log(Level.FINE, "\t Ignored QLFunction {0}", tt);
                    continue;
                }
                log.log(Level.FINE, "\t Detect Function {0}", tt);
                if (listener != null) {
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, Function.class, tt, null));
                }
            }
            for (Decoration at : newrepo.getDeclaredDecorations(SecurityContext.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = strategy.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
                boolean ok = false;
                if (ignored == null) {
                    if (EntitySecurityManager.class.isAssignableFrom(t)) {
                        ok = true;
                        if (listener != null) {
                            listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, EntitySecurityManager.class, t, at));
                            ok = true;
                        }
                    }
                    if (PersistenceGroupSecurityManager.class.isAssignableFrom(t) || UPASecurityManager.class.isAssignableFrom(t)) {
                        ok = true;
                    }
                    if (!ok) {
                        log.log(Level.WARNING, "@SecurityContext ignored as annotating any of PersistenceGroupSecurityManager, UPASecurityManager, EntitySecurityManager");
                    }
                }
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("URLAnnotationStrategySupportConfigureException"));
        }
    }

    /**
     * transform supported JPA Annotations to UPA Decorations
     */
    private void processJAVAXAnnotations(DecorationRepository readFrom, DecorationRepository writeTo, boolean noIgnore) {
        int pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.Entity")) {
            Decoration ignored = noIgnore ? null : readFrom.getTypeDecoration(at.getLocationType(), Ignore.class.getName());
            if (ignored != null) {
                log.log(Level.FINE, "\t Ignored javax.persistence.Entity {0}", at);
                continue;
            }

            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.Entity.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.Id")) {
//            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
//            if (ignored != null) {
//                log.log(Level.FINE, "\t Ignored javax.persistence.Id {0}", at);
//                continue;
//            }
            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.Id.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.ManyToOne")) {
//            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
//            if (ignored != null) {
//                log.log(Level.FINE, "\t Ignored javax.persistence.Id javax.persistence.ManyToOne", at);
//                continue;
//            }
            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.ManyToOne.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }

        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.PostConstruct")) {
            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.Init.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }
    }

    private Class getRootEntity(Class c, Map<Class, Set<Class>> entityClasses, Map<Class, Class> partialEntities) {
        if (entityClasses.containsKey(c)) {
            return c;
        }
        Class r = partialEntities.get(c);
        if (r == null) {
            return null;
        }
        return getRootEntity(r, entityClasses, partialEntities);
    }

    private void merge(ConnectionConfig source, ConnectionConfig target) {
        if (source != null) {
            if (!Strings.isNullOrEmpty(source.getConnectionString())) {
                target.setConnectionString(Strings.trim(source.getConnectionString()));
            }
            if (!Strings.isNullOrEmpty(source.getUserName())) {
                target.setUserName(Strings.trim(source.getUserName()));
            }
            if (!Strings.isNullOrEmpty(source.getPassword())) {
                target.setPassword(source.getPassword());
            }
            if (source.getStructureStrategy() != null) {
                target.setStructureStrategy(source.getStructureStrategy());
            }
            if (source.isEnabled() != null) {
                target.setEnabled(source.isEnabled());
            }
            if (source.getProperties() != null) {
                for (Map.Entry<String, String> entry : source.getProperties().entrySet()) {
                    if (Strings.isNullOrEmpty(entry.getValue())) {
                        target.getProperties().put(Strings.trim(entry.getKey()), Strings.trim(entry.getValue()));
                    }
                }
            }
        }
    }

    private void merge(Decoration persistenceNameStrategy, PersistenceNameConfig target) {
        if (persistenceNameStrategy != null) {
            if (!Strings.isUndefined(persistenceNameStrategy.getString("escape"))) {
                target.setPersistenceNameEscape(persistenceNameStrategy.getString("escape"));
            }
            if (!Strings.isUndefined(persistenceNameStrategy.getString("globalPersistenceName"))) {
                target.setGlobalPersistenceName(Strings.trim(persistenceNameStrategy.getString("globalPersistenceName")));
            }
            if (!Strings.isUndefined(persistenceNameStrategy.getString("localPersistenceName"))) {
                target.setLocalPersistenceName(Strings.trim(persistenceNameStrategy.getString("localPersistenceName")));
            }
            if (!Strings.isUndefined(persistenceNameStrategy.getString("persistenceName"))) {
                target.setGlobalPersistenceName(persistenceNameStrategy.getString("persistenceName"));
            }
            for (Object persistenceNameObj : persistenceNameStrategy.getArray("names")) {
                Decoration persistenceName = (Decoration) persistenceNameObj;

                PersistenceNameType type2 = null;
                switch (net.vpc.upa.config.PersistenceNameType.valueOf(persistenceName.getString("type"))) {
                    case CUSTOM: {
                        if (Strings.isUndefined(persistenceNameStrategy.getString("custom"))) {
                            throw new UPAException("MissingCustomPersistenceNameType");
                        }
                        type2 = PersistenceNameType.valueOf(persistenceName.getString("customType"));
                        break;
                    }
                    default: {
                        type2 = PersistenceNameType.valueOf(persistenceName.getString("type"));
                        break;
                    }
                }
                target.getNames().add(new net.vpc.upa.persistence.PersistenceName(Strings.trim(persistenceName.getString("object")), type2, Strings.trim(persistenceName.getString("value")), persistenceName.getConfig().getOrder()));
            }
        }
    }

    private void merge(PersistenceNameConfig source, PersistenceNameConfig target) {
        if (source != null) {
            if (Strings.isNullOrEmpty(source.getPersistenceNameEscape())) {
                target.setPersistenceNameEscape(source.getPersistenceNameEscape());
            }
            if (Strings.isNullOrEmpty(source.getGlobalPersistenceName())) {
                target.setGlobalPersistenceName(source.getGlobalPersistenceName());
            }
            if (source.getGlobalPersistenceName() != null) {
                target.setGlobalPersistenceName(source.getGlobalPersistenceName());
            }
            if (source.getLocalPersistenceName() != null) {
                target.setLocalPersistenceName(source.getLocalPersistenceName());
            }
            for (net.vpc.upa.persistence.PersistenceName v : source.getNames()) {
                target.getNames().add(new net.vpc.upa.persistence.PersistenceName(v.getObject(), v.getPersistenceNameType(), v.getValue(), v.getConfigOrder()));
            }
        }
    }

    public List<PersistenceUnitConfig> buildPersistenceUnitConfigs(List<OrderedIem<PersistenceUnitConfig>> persistenceUnitConfigs) {
        LinkedHashMap<String, PersistenceUnitConfig> t = new LinkedHashMap<String, PersistenceUnitConfig>();
        Collections.sort(persistenceUnitConfigs);
        for (OrderedIem<PersistenceUnitConfig> orderedIem : persistenceUnitConfigs) {
            PersistenceUnitConfig c = orderedIem.value;
            String puname = Strings.trim(c.getName());
            String pgname = Strings.trim(c.getPersistenceGroup());
            String id = pgname + "/" + puname;
            PersistenceUnitConfig old = t.get(id);
            if (old == null) {
                old = new PersistenceUnitConfig();
                old.setName(puname);
                old.setPersistenceGroup(pgname);
                t.put(id, old);
            }
            if (c.getAutoStart() != null) {
                old.setAutoStart(c.getAutoStart());
            }
            if (c.getModel() != null) {
                PersistenceNameConfig m0 = c.getModel();
                PersistenceNameConfig m = old.getModel();
                if (m == null) {
                    m = new PersistenceNameConfig(orderedIem.order);
                    old.setModel(m);
                }
                if (Strings.isNullOrEmpty(m0.getPersistenceNameEscape())) {
                    m.setPersistenceNameEscape(m0.getPersistenceNameEscape());
                }
                if (Strings.isNullOrEmpty(m0.getGlobalPersistenceName())) {
                    m.setGlobalPersistenceName(m0.getGlobalPersistenceName());
                }
                if (m0.getGlobalPersistenceName() != null) {
                    m.setGlobalPersistenceName(m0.getGlobalPersistenceName());
                }
                if (m0.getLocalPersistenceName() != null) {
                    m.setLocalPersistenceName(m0.getLocalPersistenceName());
                }
                for (net.vpc.upa.persistence.PersistenceName v : m0.getNames()) {
                    m.getNames().add(new net.vpc.upa.persistence.PersistenceName(v.getObject(), v.getPersistenceNameType(), v.getValue(), v.getConfigOrder()));
                }
            }
            for (Map.Entry<String, Object> entry : c.getProperties().entrySet()) {
                if (entry.getValue() == null) {
                    old.getProperties().remove(entry.getKey());
                } else {
                    old.getProperties().put(entry.getKey(), entry.getValue());
                }
            }
            for (ConnectionConfig connectionConfig : c.getConnections()) {
                String s = connectionConfig.getConnectionString();
                ConnectionConfig oldConnectionConfig = null;
                for (ConnectionConfig c0 : old.getConnections()) {
                    if (UPAUtils.equals(s, c0.getConnectionString())) {
                        oldConnectionConfig = c0;
                        break;
                    }
                }
                if (oldConnectionConfig == null) {
                    old.getConnections().add(connectionConfig);
                } else {
                    merge(connectionConfig, oldConnectionConfig);
                }
            }
            for (ConnectionConfig connectionConfig : c.getRootConnections()) {
                String s = connectionConfig.getConnectionString();
                ConnectionConfig oldConnectionConfig = null;
                for (ConnectionConfig c0 : old.getRootConnections()) {
                    if (UPAUtils.equals(s, c0.getConnectionString())) {
                        oldConnectionConfig = c0;
                        break;
                    }
                }
                if (oldConnectionConfig == null) {
                    old.getRootConnections().add(connectionConfig);
                } else {
                    merge(connectionConfig, oldConnectionConfig);
                }
            }
        }
        return new ArrayList<PersistenceUnitConfig>(t.values());
    }
}
