package net.thevpc.upa.impl.config;

import net.thevpc.upa.*;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.config.*;
import net.thevpc.upa.config.Converter;
import net.thevpc.upa.config.Entity;
import net.thevpc.upa.config.Field;
import net.thevpc.upa.config.Formula;
import net.thevpc.upa.config.Function;
import net.thevpc.upa.config.Index;
import net.thevpc.upa.config.NamedFormula;
import net.thevpc.upa.config.PersistenceNameStrategy;
import net.thevpc.upa.config.Properties;
import net.thevpc.upa.config.Property;
import net.thevpc.upa.config.Sequence;
import net.thevpc.upa.impl.util.*;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.events.EntityInterceptor;
import net.thevpc.upa.events.PersistenceGroupDefinitionListener;
import net.thevpc.upa.events.SectionDefinitionListener;
import net.thevpc.upa.events.RelationshipDefinitionListener;
import net.thevpc.upa.events.IndexDefinitionListener;
import net.thevpc.upa.events.PackageDefinitionListener;
import net.thevpc.upa.events.TriggerDefinitionListener;
import net.thevpc.upa.events.PersistenceUnitDefinitionListener;
import net.thevpc.upa.events.EntityDefinitionListener;
import net.thevpc.upa.events.PersistenceUnitListener;
import net.thevpc.upa.events.FieldDefinitionListener;
import net.thevpc.upa.persistence.ConnectionConfig;
import net.thevpc.upa.persistence.PersistenceGroupConfig;
import net.thevpc.upa.persistence.PersistenceNameFormat;
import net.thevpc.upa.persistence.PersistenceUnitConfig;

import net.thevpc.upa.config.Callback;
import net.thevpc.upa.config.*;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;
import net.thevpc.upa.impl.config.decorations.DefaultDecorationFilter;
import net.thevpc.upa.impl.jpa.JPAAnnotationsAdapter;
import net.thevpc.upa.impl.util.*;
import net.thevpc.upa.impl.util.classpath.DecorationParser;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.types.I18NString;

import java.lang.reflect.Method;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 12:28 AM
 */
public class URLAnnotationStrategySupport {

    private static final Logger log = Logger.getLogger(URLAnnotationStrategySupport.class.getName());
    private static final Class[] persistenceUnitItemDefinitionListenerTypes = new Class[]{
        PackageDefinitionListener.class, SectionDefinitionListener.class, EntityDefinitionListener.class, FieldDefinitionListener.class, IndexDefinitionListener.class, TriggerDefinitionListener.class //            , PersistenceUnitTriggerDefinitionListener.class
        ,
         RelationshipDefinitionListener.class
    };
    /**
     * @PortabilityHint(target = "C#", name = "replace") private String[]
     * EXTRA_ANNOTATIONS={};
     */
    private String[] EXTRA_ANNOTATIONS = JPAAnnotationsAdapter.JPA_ANNOTATIONS;

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

    public void scan(ScanSource source, UPAContextConfig config, ScanListener listener, UPAContext context, DecorationRepository decorationRepository) throws UPAException {
        try {
//            UPAContextConfig bootstrapContextConfig = context.getBootstrapContextConfig();
            DecorationParser parser = new DecorationParser(UPAUtils.toBaseScanSource(source).toIterable(context),
                    new DefaultDecorationFilter()
                            .addDecorations(
                                    Callback.class,
                                    OnAlter.class,
                                    OnPreAlter.class,
                                    OnPreCreate.class,
                                    OnCreate.class,
                                    OnPreDrop.class,
                                    OnDrop.class,
                                    OnPreRemove.class,
                                    OnRemove.class,
                                    OnPrePersist.class,
                                    OnPersist.class,
                                    OnPreRemove.class,
                                    OnRemove.class,
                                    OnPreUpdate.class,
                                    OnPreUpdate.class,
                                    OnUpdate.class,
                                    OnPreUpdateFormula.class,
                                    OnUpdateFormula.class,
                                    OnPreInit.class,
                                    OnInit.class,
                                    OnPrePrepare.class,
                                    OnPrepare.class,
                                    OnPreReset.class,
                                    OnReset.class,
                                    SecurityContext.class,
                                    net.thevpc.upa.config.PersistenceUnit.class,
                                    PersistenceNameStrategy.class,
                                    Properties.class,
                                    Property.class)
                            .addTypeDecorations(
                                    EXTRA_ANNOTATIONS
                            ), null, null, decorationRepository);
            parser.parse();
            //repository that contains just the scanned classes
            //older classes
            DecorationRepository newDecorationRepository = parser.getNewDecorationRepository();
            /**
             * @PortabilityHint(target = "C#", name = "suppress")
             */
            JPAAnnotationsAdapter.processJAVAXAnnotations(decorationRepository, newDecorationRepository, source.isNoIgnore());
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
            for (PersistenceGroupConfig persistenceGroupConfig : config.getPersistenceGroups()) {
                for (PersistenceUnitConfig persistenceUnitConfig : persistenceGroupConfig.getPersistenceUnits()) {
                    persistenceUnitConfigs.add(new OrderedIem<PersistenceUnitConfig>(Integer.MAX_VALUE, persistenceUnitConfig));
                }
            }

            for (Decoration configPersistenceUnit : newDecorationRepository.getDeclaredDecorations(net.thevpc.upa.config.PersistenceUnit.class.getName())) {
                Decoration ignored = source.isNoIgnore() ? null : newDecorationRepository.getTypeDecoration(configPersistenceUnit.getLocationType(), Ignore.class.getName());
                if (ignored == null) {

                    PersistenceUnitConfig c = new PersistenceUnitConfig();
                    c.setName(StringUtils.trim(configPersistenceUnit.getString("name")));
                    c.setPersistenceGroup(StringUtils.trim(configPersistenceUnit.getString("persistenceGroup")));
                    for (Object configPropertyObj : configPersistenceUnit.getArray("properties")) {
                        Decoration configProperty = (Decoration) configPropertyObj;
                        Object v = UPAUtils.createValue(UPAUtils.createProperty(configProperty));
                        c.getProperties().put(configProperty.getString("name"), v);
                    }
                    persistenceUnitConfigs.add(new OrderedIem<PersistenceUnitConfig>(configPersistenceUnit.getInt("order"), c));
                }
            }

            Map<String, PersistenceUnitConfig> partialPersistenceUnitConfig = new HashMap<String, PersistenceUnitConfig>();
            for (Decoration a : newDecorationRepository.getDeclaredDecorations(PersistenceNameStrategy.class.getName())) {
                Decoration ignored = newDecorationRepository.getTypeDecoration(a.getLocationType(), Ignore.class.getName());
                if (ignored == null) {

                    Decoration config2 = a.getDecoration("config");
                    int configOrder = config2.getInt("order");
                    String key = StringUtils.trim(config2.getString("persistenceGroup")) + "/" + StringUtils.trim(config2.getString("persistenceUnit")) + "/" + configOrder;
                    PersistenceUnitConfig puc = partialPersistenceUnitConfig.get(key);
                    if (puc == null) {
                        puc = new PersistenceUnitConfig();
                        partialPersistenceUnitConfig.put(key, puc);
                        persistenceUnitConfigs.add(new OrderedIem<PersistenceUnitConfig>(configOrder, puc));
                    }
                    merge(a, puc);
                }
            }

            //persistence groups
            List<PersistenceGroup> createdPersistenceGroups = new ArrayList<PersistenceGroup>();

            List<PersistenceUnitConfig> buildPersistenceUnitConfigs = buildPersistenceUnitConfigs(persistenceUnitConfigs);
            for (PersistenceUnitConfig c : buildPersistenceUnitConfigs) {
                if (!StringUtils.isSimpleExpression(c.getPersistenceGroup())) {
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
                for (PersistenceGroupConfig pgc : config.getPersistenceGroups()) {
                    if (StringUtils.matchesSimpleExpression(g.getName(), pgc.getName(), PatternType.DOT_PATH)) {
                        if (pgc.getAutoScan() != null) {
                            g.setAutoScan(pgc.getAutoScan());
                        }
                        if (pgc.getInheritScanFilters() != null) {
                            g.setInheritScanFilters(pgc.getInheritScanFilters());
                        }
                        for (ScanFilter a : pgc.getScanFilters()) {
                            g.addScanFilter(a);
                        }
                        for (Map.Entry<String, Object> stringObjectEntry : pgc.getProperties().entrySet()) {
                            g.getProperties().setObject(stringObjectEntry.getKey(), stringObjectEntry.getValue());
                        }
                    }
                }
                if (listener != null) {
                    listener.contextItemScanned(new ScanEvent(context, null, null, PersistenceGroup.class, null, g));
                }
                g.scan(source, listener, false);
            }

            //persistence units
            List<PersistenceUnit> createdPersistenceUnits = new ArrayList<>();
            for (PersistenceUnitConfig puc : buildPersistenceUnitConfigs) {
                if (!StringUtils.isSimpleExpression(puc.getName())) {
                    for (PersistenceGroup persistenceGroup : context.getPersistenceGroups()) {
                        if (StringUtils.matchesSimpleExpression(persistenceGroup.getName(), puc.getPersistenceGroup(), PatternType.DOT_PATH)) {
                            if (!persistenceGroup.containsPersistenceUnit(puc.getName())) {
                                PersistenceUnit pu = persistenceGroup.addPersistenceUnit(puc.getName());
                                if ((puc.getAutoScan() != null)) {
                                    pu.setAutoScan(puc.getAutoScan());
                                }
                                if ((puc.getInheritScanFilters() != null)) {
                                    pu.setInheritScanFilters(puc.getInheritScanFilters());
                                }
                                pu.setAutoStart(puc.getAutoStart() == null ? Boolean.TRUE : puc.getAutoStart().booleanValue());
                                for (ScanFilter a : puc.getFilters()) {
                                    pu.addScanFilter(a);
                                }
                                for (ConnectionConfig connectionConfig : puc.getConnections()) {
                                    pu.addConnectionConfig(connectionConfig);
                                }
                                for (ConnectionConfig connectionConfig : puc.getRootConnections()) {
                                    pu.addRootConnectionConfig(connectionConfig);
                                }
                                for (Map.Entry<String, Object> stringObjectEntry : puc.getProperties().entrySet()) {
                                    pu.getProperties().setObject(stringObjectEntry.getKey(), stringObjectEntry.getValue());
                                }
                                net.thevpc.upa.persistence.PersistenceNameStrategy ns = pu.getPersistenceNameStrategy();
                                ns.setGlobalPersistenceNameFormat(puc.getGlobalPersistenceNameFormat());
                                ns.setLocalPersistenceNameFormat(puc.getLocalPersistenceNameFormat());
                                ns.setPersistenceNameEscape(puc.getPersistenceNameEscape());
                                for (PersistenceNameFormat persistenceNameFormat : puc.getNameFormats()) {
                                    ns.addNameFormat(persistenceNameFormat);
                                }
                                if (listener != null) {
                                    listener.contextItemScanned(new ScanEvent(context, null, null, PersistenceUnit.class, null, pu));
                                }
                                if (pu.isAutoScan()) {
                                    pu.scan(source, listener, false);
                                }
                            }
                        }
                    }
                }
            }

        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("URLAnnotationStrategySupportConfigureException"));
        }
    }

    public void scan(ScanSource source, ScanListener listener, PersistenceGroup persistenceGroup, DecorationRepository decorationRepository) throws UPAException {
        try {
            DecorationParser parser = new DecorationParser(UPAUtils.toBaseScanSource(source).toIterable(persistenceGroup),
                    new DefaultDecorationFilter()
                            .addDecorations(
                                    Callback.class,
                                    OnPreAlter.class,
                                    OnAlter.class,
                                    OnPreCreate.class,
                                    OnCreate.class,
                                    OnPreDrop.class,
                                    OnDrop.class,
                                    OnPreRemove.class,
                                    OnRemove.class,
                                    OnPrePersist.class,
                                    OnPersist.class,
                                    OnPreRemove.class,
                                    OnRemove.class,
                                    OnPreUpdate.class,
                                    OnUpdate.class,
                                    OnPreUpdateFormula.class,
                                    OnUpdateFormula.class,
                                    OnPreInit.class,
                                    OnInit.class,
                                    OnPrePrepare.class,
                                    OnPrepare.class,
                                    OnPreReset.class,
                                    OnReset.class
                            )
                            .addDecorations(SecurityContext.class)
                            .addTypeDecorations(
                                    EXTRA_ANNOTATIONS
                            ), persistenceGroup.getName(), null, decorationRepository);
            parser.parse();
            DecorationRepository repo = parser.getDecorationRepository();
            DecorationRepository newrepo = parser.getNewDecorationRepository();
            /**
             * @PortabilityHint(target = "C#", name = "suppress")
             */
            JPAAnnotationsAdapter.processJAVAXAnnotations(repo, newrepo, source.isNoIgnore());
            for (Decoration at : newrepo.getDeclaredDecorations(Callback.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = source.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
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
                Decoration ignored = source.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
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

    public void scan(ScanSource scanSource, ScanListener listener, PersistenceUnit persistenceUnit, DecorationRepository decorationRepository) throws UPAException {
        try {
            DecorationParser parser = new DecorationParser(
                    UPAUtils.toBaseScanSource(scanSource).toIterable(persistenceUnit),
                    new DefaultDecorationFilter()
                            .addDecorations(
                                    SecurityContext.class,
                                    ItemConfig.class,
                                    Field.class,
                                    Main.class,
                                    Summary.class,
                                    Unique.class,
                                    FilterEntity.class,
                                    Formula.class,
                                    NamedFormula.class,
                                    Formulas.class,
                                    Id.class,
                                    Ignore.class,
                                    Index.class,
                                    Indexes.class,
                                    Init.class,
                                    ManyToOne.class,
                                    OneToOne.class,
                                    Password.class,
                                    ToString.class,
                                    ToByteArray.class,
                                    Converter.class,
                                    Path.class,
                                    net.thevpc.upa.config.PersistenceUnit.class,
                                    Properties.class,
                                    Property.class,
                                    Function.class,
                                    Search.class,
                                    Secret.class,
                                    Sequence.class,
                                    Singleton.class,
                                    Temporal.class,
                                    Transactional.class,
                                    Hierarchy.class,
                                    Callback.class,
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
                                    OnPreInit.class,
                                    OnInit.class,
                                    OnPrePrepare.class,
                                    OnPrepare.class,
                                    OnPreReset.class,
                                    OnReset.class,
                                    UnionEntity.class,
                                    UnionEntityEntry.class,
                                    View.class,
                                    Entity.class,
                                    Table.class,
                                    Tables.class,
                                    Column.class,
                                    Columns.class,
                                    net.thevpc.upa.config.PersistenceNameFormat.class,
                                    PersistenceNameStrategy.class
                            )
                            .addTypeDecorations(EXTRA_ANNOTATIONS),
                    persistenceUnit.getPersistenceGroup().getName(), persistenceUnit.getName(), decorationRepository);
            parser.parse();
            DecorationRepository repo = parser.getDecorationRepository();
            DecorationRepository newrepo = parser.getNewDecorationRepository();
            JPAAnnotationsAdapter.processJAVAXAnnotations(repo, newrepo, scanSource.isNoIgnore());
            for (Decoration at : newrepo.getDeclaredDecorations(Callback.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = scanSource.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
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
            Set<Class> classWithEntityAnnotations = new HashSet<>();
            for (Decoration at : newrepo.getDeclaredDecorations(Entity.class.getName())) {
                classWithEntityAnnotations.add(PlatformUtils.forName(at.getLocationType()));
            }
            for (Decoration at : newrepo.getDeclaredDecorations(View.class.getName())) {
                classWithEntityAnnotations.add(PlatformUtils.forName(at.getLocationType()));
            }
            for (Decoration at : newrepo.getDeclaredDecorations(UnionEntity.class.getName())) {
                classWithEntityAnnotations.add(PlatformUtils.forName(at.getLocationType()));
            }
            for (Decoration at : newrepo.getDeclaredDecorations(Singleton.class.getName())) {
                classWithEntityAnnotations.add(PlatformUtils.forName(at.getLocationType()));
            }

            for (Class tt : classWithEntityAnnotations.toArray(new Class[classWithEntityAnnotations.size()])) {
                Decoration ignored = scanSource.isNoIgnore() ? null : newrepo.getTypeDecoration(tt, Ignore.class);
                if (ignored != null) {
                    log.log(Level.FINE, "\t Ignored Entity Class {0}", tt);
                    classWithEntityAnnotations.remove(tt);
                    continue;
                }
                if (listener != null) {
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, Entity.class, tt,
                            null
                    ));
                }
            }
            Map<String, String> typeToEntityNameMap = new HashMap<>();
            if (listener != null) {
                EntityDescriptorResolver r = new EntityDescriptorResolver(persistenceUnit, newrepo);
                for (EntityDescriptor resolved : r.resolveAll(classWithEntityAnnotations.toArray())) {
                    Object source = resolved.getSource();
                    if (source instanceof Class[]) {
                        for (Class aClass : ((Class[]) source)) {
                            typeToEntityNameMap.put(aClass.getName(), resolved.getName());
                        }
                    }
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, EntityDescriptor.class, EntityDescriptor.class,
                            resolved
                    ));
                }
//                for (Set<Class> ee : entityClassesByName.values()) {
//                    EntityDescriptor resolved = r.resolve(ee.toArray(new Class[ee.size()]));
//                    for (Class aClass : ee) {
//                        typeToEntityNameMap.put(aClass.getName(), resolved.getName());
//                    }
//                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, EntityDescriptor.class, EntityDescriptor.class,
//                            resolved
//                    ));
//                }
            }

            for (Decoration d : newrepo.getDeclaredRepeatableDecorations(
                    Table.class.getName(),
                    Tables.class.getName()
            )) {
                String entityName = null;
                switch (d.getTarget()) {
                    case DEFAULT:
                    case TYPE: {
                        entityName = d.getString("entityName");
                        if (StringUtils.isNullOrEmpty(entityName)) {
                            //check Entity by current class name
                            entityName = typeToEntityNameMap.get(d.getLocationType());
                        }
                        break;
                    }
                    default: {
                        break;
                    }
                }
                if (StringUtils.isNullOrEmpty(entityName)) {
                    //check Entity by current class name
                    log.log(Level.SEVERE, "You should use entityName on Entity Type " + d + ". Unable to resolve that entity for " + d);
                } else {
                    PersistenceNameRule rule = new TablePersistenceNameRule()
                            .setEntityName(entityName)
                            .setPersistenceName(d.getString("value"))
                            .setCatalog(d.getString("catalog"))
                            .setSchema(d.getString("schema"))
                            .setPkPersistenceName(d.getString("pkPersistenceName"))
                            .setViewPersistenceName(d.getString("viewPersistenceName"))
                            .setShortPersistenceNamePrefix(d.getString("shortPersistenceNamePrefix"))
                            .setDatabaseProduct(d.getDecoration("condition").getEnum("databaseProduct", DatabaseProduct.class))
                            .setDatabaseVersion(d.getDecoration("condition").getString("databaseVersion"))
                            .setStrategyName(d.getDecoration("condition").getString("strategyName"));
                    if (listener != null) {
                        listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(),
                                persistenceUnit.getPersistenceGroup(), persistenceUnit, PersistenceNameRule.class, PersistenceNameRule.class,
                                rule
                        ));
                    }
                }
            }
            for (Decoration d : newrepo.getDeclaredRepeatableDecorations(
                    Column.class.getName(),
                    Columns.class.getName()
            )) {
                String entityName = null;
                String fieldName = null;
                boolean ignore = false;
                switch (d.getTarget()) {
                    case TYPE: {
                        entityName = d.getString("entityName");
                        if (StringUtils.isNullOrEmpty(entityName)) {
                            //check Entity by current class name
                            entityName = typeToEntityNameMap.get(d.getLocationType());
                        }
                        fieldName = d.getString("fieldName");
//                        if (StringUtils.isNullOrEmpty(entityName)) {
//                            //check Entity by current class name
//                            fieldName = typeToEntityNameMap.get(d.getLocation());
//                        }
                        break;
                    }
                    case DEFAULT:
                    case METHOD:
                    case FIELD: {
                        ignore = true;
                        //will not process, this should has bean already processed!
//                        entityName = d.getString("entityName");
//                        if(StringUtils.isNullOrEmpty(entityName)){
//                          //check Entity by current class name
//                            entityName = typeToEntityNameMap.get(d.getLocationType());
//                        }
                        break;
                    }
                    default: {
                        ignore = true;
                        break;
                    }
                }
                if (!ignore) {
                    if (StringUtils.isNullOrEmpty(entityName)) {
                        //check Entity by current class name
                        log.log(Level.SEVERE, "You should use entityName on Entity Type " + d + ". Unable to resolve that entity for " + d);
                    } else {
                        ColumnPersistenceNameRule rule = new ColumnPersistenceNameRule()
                                .setEntityName(entityName)
                                .setFieldName(fieldName)
                                .setPersistenceName(d.getString("value"))
                                .setTableName(d.getString("tableName"))
                                .setDatabaseProduct(d.getDecoration("condition").getEnum("databaseProduct", DatabaseProduct.class))
                                .setDatabaseVersion(d.getDecoration("condition").getString("databaseVersion"))
                                .setStrategyName(d.getDecoration("condition").getString("strategyName"));
                        if (listener != null) {
                            listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(),
                                    persistenceUnit.getPersistenceGroup(), persistenceUnit, PersistenceNameRule.class, PersistenceNameRule.class,
                                    rule
                            ));
                        }
                    }
                }
            }

            for (Decoration d : newrepo.getDeclaredDecorations(Function.class.getName())) {
                final Class tt = PlatformUtils.forName(d.getLocationType());
                Decoration ignored = scanSource.isNoIgnore() ? null : newrepo.getTypeDecoration(tt, Ignore.class);
                if (ignored != null) {
                    log.log(Level.FINE, "\t Ignored QLFunction {0}", tt);
                    continue;
                }
                log.log(Level.FINE, "\t Detect Function {0}", tt);
                if (listener != null) {
                    listener.persistenceUnitItemScanned(new ScanEvent(persistenceUnit.getPersistenceGroup().getContext(), persistenceUnit.getPersistenceGroup(), persistenceUnit, net.thevpc.upa.Function.class, tt, null));
                }
            }
            for (Decoration at : newrepo.getDeclaredDecorations(SecurityContext.class.getName())) {
                Class t = PlatformUtils.forName(at.getLocationType());
                Decoration ignored = scanSource.isNoIgnore() ? null : newrepo.getTypeDecoration(t, Ignore.class);
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
            if (!StringUtils.isNullOrEmpty(source.getConnectionString())) {
                target.setConnectionString(StringUtils.trim(source.getConnectionString()));
            }
            if (!StringUtils.isNullOrEmpty(source.getUserName())) {
                target.setUserName(StringUtils.trim(source.getUserName()));
            }
            if (!StringUtils.isNullOrEmpty(source.getPassword())) {
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
                    if (StringUtils.isNullOrEmpty(entry.getValue())) {
                        target.getProperties().put(StringUtils.trim(entry.getKey()), StringUtils.trim(entry.getValue()));
                    }
                }
            }
        }
    }

    private void merge(Decoration persistenceNameStrategy, PersistenceUnitConfig target) {
        if (persistenceNameStrategy != null) {
            if (!StringUtils.isUndefined(persistenceNameStrategy.getString("escape"))) {
                target.setPersistenceNameEscape(persistenceNameStrategy.getString("escape"));
            }
            if (!StringUtils.isUndefined(persistenceNameStrategy.getString("globalPersistenceNameFormat"))) {
                target.setGlobalPersistenceNameFormat(StringUtils.trim(persistenceNameStrategy.getString("globalPersistenceNameFormat")));
            }
            if (!StringUtils.isUndefined(persistenceNameStrategy.getString("localPersistenceNameFormat"))) {
                target.setLocalPersistenceNameFormat(StringUtils.trim(persistenceNameStrategy.getString("localPersistenceNameFormat")));
            }
            if (!StringUtils.isUndefined(persistenceNameStrategy.getString("persistenceName"))) {
                target.setGlobalPersistenceNameFormat(persistenceNameStrategy.getString("persistenceName"));
            }
            for (Object persistenceNameObj : persistenceNameStrategy.getArray("persistenceNameFormats")) {
                Decoration persistenceName = (Decoration) persistenceNameObj;

                PersistenceNameType type2 = null;
                switch (PersistenceNameType.valueOf(persistenceName.getString("persistenceNameType"))) {
                    case CUSTOM: {
                        if (StringUtils.isUndefined(persistenceNameStrategy.getString("customTypeName"))) {
                            throw new UPAException("MissingCustomPersistenceNameType");
                        }
                        type2 = PersistenceNameType.valueOf(persistenceName.getString("customType"));
                        break;
                    }
                    default: {
                        type2 = PersistenceNameType.valueOf(persistenceName.getString("persistenceNameType"));
                        break;
                    }
                }
                target.getNameFormats().add(new PersistenceNameFormat(
                        StringUtils.trim(persistenceName.getString("object")),
                        type2, StringUtils.trim(persistenceName.getString("value")), persistenceName.getConfig().getOrder()));
            }
        }
    }

    public List<PersistenceUnitConfig> buildPersistenceUnitConfigs(List<OrderedIem<PersistenceUnitConfig>> persistenceUnitConfigs) {
        LinkedHashMap<String, PersistenceUnitConfig> t = new LinkedHashMap<String, PersistenceUnitConfig>();
        Collections.sort(persistenceUnitConfigs);
        for (OrderedIem<PersistenceUnitConfig> orderedIem : persistenceUnitConfigs) {
            PersistenceUnitConfig c = orderedIem.value;
            String puname = StringUtils.trim(c.getName());
            String pgname = StringUtils.trim(c.getPersistenceGroup());
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
            if (c.getInheritScanFilters() != null) {
                old.setInheritScanFilters(c.getInheritScanFilters());
            }
            if (!StringUtils.isNullOrEmpty(c.getPersistenceNameEscape())) {
                old.setPersistenceNameEscape(c.getPersistenceNameEscape());
            }
            if (!StringUtils.isNullOrEmpty(c.getGlobalPersistenceNameFormat())) {
                old.setGlobalPersistenceNameFormat(c.getGlobalPersistenceNameFormat());
            }
//            if (c.getGlobalPersistenceNameFormat() != null) {
//                old.setGlobalPersistenceNameFormat(c.getGlobalPersistenceNameFormat());
//            }
            if (!StringUtils.isNullOrEmpty(c.getLocalPersistenceNameFormat())) {
                old.setLocalPersistenceNameFormat(c.getLocalPersistenceNameFormat());
            }
            for (PersistenceNameFormat v : c.getNameFormats()) {
                old.getNameFormats().add(new PersistenceNameFormat(v.getObject(), v.getPersistenceNameType(), v.getValue(), v.getConfigOrder()));
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
            ScanFilter[] filters = c.getFilters();
            for (ScanFilter scanFilter : filters) {
                old.addFilter(scanFilter);
            }
        }
        return new ArrayList<PersistenceUnitConfig>(t.values());
    }

}
