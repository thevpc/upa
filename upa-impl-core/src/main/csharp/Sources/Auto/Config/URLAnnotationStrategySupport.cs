/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/30/12 12:28 AM
     */
    public class URLAnnotationStrategySupport {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Config.URLAnnotationStrategySupport)).FullName);

        private static readonly System.Type[] persistenceUnitItemDefinitionListenerTypes = new System.Type[] { typeof(Net.TheVpc.Upa.Callbacks.PackageDefinitionListener), typeof(Net.TheVpc.Upa.Callbacks.SectionDefinitionListener), typeof(Net.TheVpc.Upa.Callbacks.EntityDefinitionListener), typeof(Net.TheVpc.Upa.Callbacks.FieldDefinitionListener), typeof(Net.TheVpc.Upa.Callbacks.IndexDefinitionListener), typeof(Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener), typeof(Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener) };

        public static bool IsPersistenceUnitItemDefinitionListener(System.Type c) {
            foreach (System.Type p in persistenceUnitItemDefinitionListenerTypes) {
                if (p.IsAssignableFrom(c)) {
                    return true;
                }
            }
            return false;
        }

        public static System.Type[] GetPersistenceUnitItemDefinitionListener(System.Type c) {
            System.Collections.Generic.List<System.Type> all = new System.Collections.Generic.List<System.Type>();
            foreach (System.Type p in persistenceUnitItemDefinitionListenerTypes) {
                if (p.IsAssignableFrom(c)) {
                    all.Add(p);
                }
            }
            return all.ToArray();
        }

        public virtual void Scan(Net.TheVpc.Upa.UPAContext context, Net.TheVpc.Upa.Config.ScanSource source, Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.TheVpc.Upa.ScanListener listener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                Net.TheVpc.Upa.Impl.Util.Classpath.DecorationParser parser = new Net.TheVpc.Upa.Impl.Util.Classpath.DecorationParser(Net.TheVpc.Upa.Impl.Util.UPAUtils.ToConfigurationStrategy(source).ToIterable(context), new Net.TheVpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter().AddDecorations(typeof(Net.TheVpc.Upa.Config.Callback), typeof(Net.TheVpc.Upa.Config.OnAlter), typeof(Net.TheVpc.Upa.Config.OnCreate), typeof(Net.TheVpc.Upa.Config.OnDrop), typeof(Net.TheVpc.Upa.Config.OnRemove), typeof(Net.TheVpc.Upa.Config.OnPersist), typeof(Net.TheVpc.Upa.Config.OnRemove), typeof(Net.TheVpc.Upa.Config.OnUpdate), typeof(Net.TheVpc.Upa.Config.OnUpdateFormula), typeof(Net.TheVpc.Upa.Config.OnInitialize), typeof(Net.TheVpc.Upa.Config.OnReset), typeof(Net.TheVpc.Upa.Config.SecurityContext), typeof(Net.TheVpc.Upa.Config.PersistenceUnit), typeof(Net.TheVpc.Upa.Config.PersistenceNameStrategy), typeof(Net.TheVpc.Upa.Config.Properties), typeof(Net.TheVpc.Upa.Config.Property)).AddTypeDecorations("javax.annotation.PostConstruct"), null, null, decorationRepository);
                parser.Parse();
                //repository that contains just the scanned classes
                //older classes
                Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository newDecorationRepository = parser.GetNewDecorationRepository();
                ProcessJAVAXAnnotations(decorationRepository, newDecorationRepository, source.IsNoIgnore());
                //            Map<Class, Object> instances = new HashMap<Class, Object>();
                //            for (PersistenceGroupDefinitionListener old : context.getPersistenceGroupDefinitionListeners()) {
                //                if(!instances.containsKey(old.getClass())){
                //                    instances.put(old.getClass(), old);
                //                }
                //            }
                foreach (Net.TheVpc.Upa.Config.Decoration dec in newDecorationRepository.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.Callback)).FullName)) {
                    System.Type tt = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(dec.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = source.IsNoIgnore() ? null : newDecorationRepository.GetTypeDecoration(dec.GetLocationType(), (typeof(Net.TheVpc.Upa.Config.Ignore)).FullName);
                    if (ignored == null) {
                        if (typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener).IsAssignableFrom(tt)) {
                            if (listener != null) {
                                listener.ContextItemScanned(new Net.TheVpc.Upa.ScanEvent(context, null, null, typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener), tt, null, null, dec, null));
                            }
                        }
                    }
                }
                System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>> persistenceUnitConfigs = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>>();
                foreach (Net.TheVpc.Upa.Persistence.PersistenceGroupConfig persistenceGroupConfig in context.GetBootstrapContextConfig().GetPersistenceGroups()) {
                    foreach (Net.TheVpc.Upa.Persistence.PersistenceUnitConfig persistenceUnitConfig in persistenceGroupConfig.GetPersistenceUnits()) {
                        persistenceUnitConfigs.Add(new Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>(System.Int32.MaxValue, persistenceUnitConfig));
                    }
                }
                foreach (Net.TheVpc.Upa.Config.Decoration configPersistenceUnit in newDecorationRepository.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.PersistenceUnit)).FullName)) {
                    Net.TheVpc.Upa.Config.Decoration ignored = source.IsNoIgnore() ? null : newDecorationRepository.GetTypeDecoration(configPersistenceUnit.GetLocationType(), (typeof(Net.TheVpc.Upa.Config.Ignore)).FullName);
                    if (ignored == null) {
                        Net.TheVpc.Upa.Persistence.PersistenceUnitConfig c = new Net.TheVpc.Upa.Persistence.PersistenceUnitConfig();
                        c.SetName(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(configPersistenceUnit.GetString("name")));
                        c.SetPersistenceGroup(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(configPersistenceUnit.GetString("persistenceGroup")));
                        foreach (object configPropertyObj in configPersistenceUnit.GetArray("properties")) {
                            Net.TheVpc.Upa.Config.Decoration configProperty = (Net.TheVpc.Upa.Config.Decoration) configPropertyObj;
                            object v = Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(new Net.TheVpc.Upa.Property(configProperty.GetString("name"), configProperty.GetString("value"), configProperty.GetString("type"), configProperty.GetString("format")));
                            c.GetProperties()[configProperty.GetString("name")]=v;
                        }
                        persistenceUnitConfigs.Add(new Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>(configPersistenceUnit.GetInt("order"), c));
                    }
                }
                System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Persistence.PersistenceUnitConfig> partialPersistenceUnitConfig = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>();
                foreach (Net.TheVpc.Upa.Config.Decoration a in newDecorationRepository.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.PersistenceNameStrategy)).FullName)) {
                    Net.TheVpc.Upa.Config.Decoration ignored = newDecorationRepository.GetTypeDecoration(a.GetLocationType(), (typeof(Net.TheVpc.Upa.Config.Ignore)).FullName);
                    if (ignored == null) {
                        Net.TheVpc.Upa.Config.Decoration config = a.GetDecoration("config");
                        int configOrder = config.GetInt("order");
                        string key = Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(config.GetString("persistenceGroup")) + "/" + Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(config.GetString("persistenceUnit")) + "/" + configOrder;
                        Net.TheVpc.Upa.Persistence.PersistenceUnitConfig puc = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>(partialPersistenceUnitConfig,key);
                        if (puc == null) {
                            puc = new Net.TheVpc.Upa.Persistence.PersistenceUnitConfig();
                            partialPersistenceUnitConfig[key]=puc;
                            persistenceUnitConfigs.Add(new Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>(configOrder, puc));
                        }
                        Net.TheVpc.Upa.Persistence.PersistenceNameConfig target = puc.GetModel();
                        if (target == null) {
                            target = new Net.TheVpc.Upa.Persistence.PersistenceNameConfig(Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER);
                            puc.SetModel(target);
                        }
                        Merge(a, target);
                    }
                }
                //persistence groups
                System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroup> createdPersistenceGroups = new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceGroup>();
                System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig> buildPersistenceUnitConfigs = BuildPersistenceUnitConfigs(persistenceUnitConfigs);
                foreach (Net.TheVpc.Upa.Persistence.PersistenceUnitConfig c in buildPersistenceUnitConfigs) {
                    if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsSimpleExpression(c.GetPersistenceGroup())) {
                        if (listener != null) {
                            listener.ContextItemScanned(new Net.TheVpc.Upa.ScanEvent(context, null, null, typeof(Net.TheVpc.Upa.Persistence.PersistenceUnitConfig), null, c));
                        }
                        if (!context.ContainsPersistenceGroup(c.GetPersistenceGroup())) {
                            Net.TheVpc.Upa.PersistenceGroup pg = context.AddPersistenceGroup(c.GetPersistenceGroup());
                            createdPersistenceGroups.Add(pg);
                        }
                    }
                }
                if ((context.GetPersistenceGroups().Count==0)) {
                    createdPersistenceGroups.Add(context.AddPersistenceGroup(null));
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("No PersistenceGroup found, create default one",null));
                }
                foreach (Net.TheVpc.Upa.PersistenceGroup g in createdPersistenceGroups) {
                    //                int count = 0;
                    foreach (Net.TheVpc.Upa.Persistence.PersistenceGroupConfig pgc in context.GetBootstrapContextConfig().GetPersistenceGroups()) {
                        if (Net.TheVpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(g.GetName(), pgc.GetName(), Net.TheVpc.Upa.Impl.Util.PatternType.DOT_PATH)) {
                            if (pgc.GetAutoScan() != null) {
                                g.SetAutoScan((pgc.GetAutoScan()).Value);
                            }
                            foreach (Net.TheVpc.Upa.Config.ScanFilter a in pgc.GetContextAnnotationStrategyFilters()) {
                                g.AddContextAnnotationStrategyFilter(a);
                            }
                        }
                    }
                    if (listener != null) {
                        listener.ContextItemScanned(new Net.TheVpc.Upa.ScanEvent(context, null, null, typeof(Net.TheVpc.Upa.PersistenceGroup), null, g));
                    }
                    g.Scan(source, listener, false);
                }
                //persistence units
                System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnit> createdPersistenceUnits = new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceUnit>();
                foreach (Net.TheVpc.Upa.Persistence.PersistenceUnitConfig c in buildPersistenceUnitConfigs) {
                    if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsSimpleExpression(c.GetName())) {
                        foreach (Net.TheVpc.Upa.PersistenceGroup persistenceGroup in context.GetPersistenceGroups()) {
                            if (Net.TheVpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(persistenceGroup.GetName(), c.GetPersistenceGroup(), Net.TheVpc.Upa.Impl.Util.PatternType.DOT_PATH)) {
                                if (!persistenceGroup.ContainsPersistenceUnit(c.GetName())) {
                                    Net.TheVpc.Upa.PersistenceUnit pu = persistenceGroup.AddPersistenceUnit(c.GetName());
                                    createdPersistenceUnits.Add(pu);
                                }
                            }
                        }
                    }
                }
                foreach (Net.TheVpc.Upa.PersistenceUnit pu in createdPersistenceUnits) {
                    bool autoScan = false;
                    foreach (Net.TheVpc.Upa.Persistence.PersistenceUnitConfig puc in buildPersistenceUnitConfigs) {
                        if (Net.TheVpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(pu.GetPersistenceGroup().GetName(), puc.GetPersistenceGroup(), Net.TheVpc.Upa.Impl.Util.PatternType.DOT_PATH) && Net.TheVpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(pu.GetName(), puc.GetName(), Net.TheVpc.Upa.Impl.Util.PatternType.DOT_PATH)) {
                            if ((puc.GetAutoScan() != null)) {
                                pu.SetAutoScan(autoScan);
                            }
                            pu.SetAutoStart(puc.GetAutoStart() == null ? ((bool)((new System.Nullable<bool>(true)).Value)) : (puc.GetAutoStart()).Value);
                            Net.TheVpc.Upa.Persistence.PersistenceNameConfig oldPersistenceNameConfig = pu.GetPersistenceNameConfig();
                            Merge(puc.GetModel(), oldPersistenceNameConfig);
                            pu.SetPersistenceNameConfig(oldPersistenceNameConfig);
                            foreach (Net.TheVpc.Upa.Config.ScanFilter a in puc.GetFilters()) {
                                puc.AddContextAnnotationStrategyFilter(a);
                            }
                            foreach (Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig in puc.GetConnections()) {
                                pu.AddConnectionConfig(connectionConfig);
                            }
                            foreach (Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig in puc.GetRootConnections()) {
                                pu.AddRootConnectionConfig(connectionConfig);
                            }
                        }
                    }
                    if (listener != null) {
                        listener.ContextItemScanned(new Net.TheVpc.Upa.ScanEvent(context, null, null, typeof(Net.TheVpc.Upa.PersistenceUnit), null, pu));
                    }
                    pu.Scan(source, listener, false);
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("URLAnnotationStrategySupportConfigureException"));
            }
        }

        public virtual void Scan(Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.Config.ScanSource strategy, Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.TheVpc.Upa.ScanListener listener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                Net.TheVpc.Upa.Impl.Util.Classpath.DecorationParser parser = new Net.TheVpc.Upa.Impl.Util.Classpath.DecorationParser(Net.TheVpc.Upa.Impl.Util.UPAUtils.ToConfigurationStrategy(strategy).ToIterable(persistenceGroup), new Net.TheVpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter().AddDecorations(typeof(Net.TheVpc.Upa.Config.Callback), typeof(Net.TheVpc.Upa.Config.OnAlter), typeof(Net.TheVpc.Upa.Config.OnCreate), typeof(Net.TheVpc.Upa.Config.OnDrop), typeof(Net.TheVpc.Upa.Config.OnRemove), typeof(Net.TheVpc.Upa.Config.OnPersist), typeof(Net.TheVpc.Upa.Config.OnRemove), typeof(Net.TheVpc.Upa.Config.OnUpdate), typeof(Net.TheVpc.Upa.Config.OnUpdateFormula), typeof(Net.TheVpc.Upa.Config.OnInitialize), typeof(Net.TheVpc.Upa.Config.OnReset)).AddDecorations(typeof(Net.TheVpc.Upa.Config.SecurityContext)).AddTypeDecorations("javax.annotation.PostConstruct"), persistenceGroup.GetName(), null, decorationRepository);
                parser.Parse();
                Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo = parser.GetDecorationRepository();
                Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository newrepo = parser.GetNewDecorationRepository();
                ProcessJAVAXAnnotations(repo, newrepo, strategy.IsNoIgnore());
                foreach (Net.TheVpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.Callback)).FullName)) {
                    System.Type t = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.TheVpc.Upa.Config.Ignore));
                    if (ignored == null) {
                        if (typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener).IsAssignableFrom(t)) {
                            if (listener != null) {
                                listener.PersistenceGroupItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceGroup.GetContext(), persistenceGroup, null, typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener), t, null));
                            }
                        }
                    }
                }
                foreach (Net.TheVpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.SecurityContext)).FullName)) {
                    System.Type t = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.TheVpc.Upa.Config.Ignore));
                    if (ignored == null) {
                        bool ok = false;
                        if (typeof(Net.TheVpc.Upa.PersistenceGroupSecurityManager).IsAssignableFrom(t)) {
                            ok = true;
                            if (listener != null) {
                                listener.PersistenceGroupItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceGroup.GetContext(), persistenceGroup, null, typeof(Net.TheVpc.Upa.PersistenceGroupSecurityManager), t, null));
                            }
                        }
                        if (typeof(Net.TheVpc.Upa.UPASecurityManager).IsAssignableFrom(t)) {
                            ok = true;
                            if (listener != null) {
                                listener.PersistenceGroupItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceGroup.GetContext(), persistenceGroup, null, typeof(Net.TheVpc.Upa.UPASecurityManager), t, null));
                            }
                        }
                        if (typeof(Net.TheVpc.Upa.EntitySecurityManager).IsAssignableFrom(t)) {
                            ok = true;
                        }
                        //will be processed as persistence unit listener
                        if (!ok) {
                            log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("@SecurityContext ignored as annotating any of PersistenceGroupSecurityManager, UPASecurityManager",null));
                        }
                    }
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("URLAnnotationStrategySupportConfigureException"));
            }
        }

        public virtual void Scan(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Config.ScanSource strategy, Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.TheVpc.Upa.ScanListener listener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                Net.TheVpc.Upa.Impl.Config.EntityDescriptorResolver r = new Net.TheVpc.Upa.Impl.Config.EntityDescriptorResolver(persistenceUnit, decorationRepository);
                Net.TheVpc.Upa.Impl.Util.Classpath.DecorationParser parser = new Net.TheVpc.Upa.Impl.Util.Classpath.DecorationParser(Net.TheVpc.Upa.Impl.Util.UPAUtils.ToConfigurationStrategy(strategy).ToIterable(persistenceUnit), new Net.TheVpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter().AddDecorations(typeof(Net.TheVpc.Upa.Config.SecurityContext), typeof(Net.TheVpc.Upa.Config.Config), typeof(Net.TheVpc.Upa.Config.Field), typeof(Net.TheVpc.Upa.Config.Main), typeof(Net.TheVpc.Upa.Config.Summary), typeof(Net.TheVpc.Upa.Config.Unique), typeof(Net.TheVpc.Upa.Config.FilterEntity), typeof(Net.TheVpc.Upa.Config.Formula), typeof(Net.TheVpc.Upa.Config.Formulas), typeof(Net.TheVpc.Upa.Config.Id), typeof(Net.TheVpc.Upa.Config.Ignore), typeof(Net.TheVpc.Upa.Config.Index), typeof(Net.TheVpc.Upa.Config.Indexes), typeof(Net.TheVpc.Upa.Config.Init), typeof(Net.TheVpc.Upa.Config.ManyToOne), typeof(Net.TheVpc.Upa.Config.Partial), typeof(Net.TheVpc.Upa.Config.Password), typeof(Net.TheVpc.Upa.Config.ToString), typeof(Net.TheVpc.Upa.Config.ToByteArray), typeof(Net.TheVpc.Upa.Config.Converter), typeof(Net.TheVpc.Upa.Config.Path), typeof(Net.TheVpc.Upa.Config.PersistenceName), typeof(Net.TheVpc.Upa.Config.PersistenceNameStrategy), typeof(Net.TheVpc.Upa.Config.PersistenceUnit), typeof(Net.TheVpc.Upa.Config.Properties), typeof(Net.TheVpc.Upa.Config.Property), typeof(Net.TheVpc.Upa.Config.Function), typeof(Net.TheVpc.Upa.Config.Search), typeof(Net.TheVpc.Upa.Config.Secret), typeof(Net.TheVpc.Upa.Config.Sequence), typeof(Net.TheVpc.Upa.Config.Singleton), typeof(Net.TheVpc.Upa.Config.Temporal), typeof(Net.TheVpc.Upa.Config.Transactional), typeof(Net.TheVpc.Upa.Config.Hierarchy), typeof(Net.TheVpc.Upa.Config.Callback), typeof(Net.TheVpc.Upa.Config.OnPreAlter), typeof(Net.TheVpc.Upa.Config.OnAlter), typeof(Net.TheVpc.Upa.Config.OnPreCreate), typeof(Net.TheVpc.Upa.Config.OnCreate), typeof(Net.TheVpc.Upa.Config.OnPreDrop), typeof(Net.TheVpc.Upa.Config.OnDrop), typeof(Net.TheVpc.Upa.Config.OnPreRemove), typeof(Net.TheVpc.Upa.Config.OnRemove), typeof(Net.TheVpc.Upa.Config.OnPrePersist), typeof(Net.TheVpc.Upa.Config.OnPrePersist), typeof(Net.TheVpc.Upa.Config.OnPersist), typeof(Net.TheVpc.Upa.Config.OnPreUpdate), typeof(Net.TheVpc.Upa.Config.OnUpdate), typeof(Net.TheVpc.Upa.Config.OnPreUpdateFormula), typeof(Net.TheVpc.Upa.Config.OnUpdateFormula), typeof(Net.TheVpc.Upa.Config.OnPreInitialize), typeof(Net.TheVpc.Upa.Config.OnInitialize), typeof(Net.TheVpc.Upa.Config.OnPreReset), typeof(Net.TheVpc.Upa.Config.OnReset), typeof(Net.TheVpc.Upa.Config.UnionEntity), typeof(Net.TheVpc.Upa.Config.UnionEntityEntry), typeof(Net.TheVpc.Upa.Config.View), typeof(Net.TheVpc.Upa.Config.Entity), typeof(Net.TheVpc.Upa.Config.Partial)).AddTypeDecorations("javax.persistence.Entity", "javax.persistence.Id", "javax.persistence.ManyToOne", "javax.annotation.PostConstruct"), persistenceUnit.GetPersistenceGroup().GetName(), persistenceUnit.GetName(), decorationRepository);
                parser.Parse();
                Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo = parser.GetDecorationRepository();
                Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository newrepo = parser.GetNewDecorationRepository();
                ProcessJAVAXAnnotations(repo, newrepo, strategy.IsNoIgnore());
                foreach (Net.TheVpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.Callback)).FullName)) {
                    System.Type t = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.TheVpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        continue;
                    }
                    foreach (System.Reflection.MethodInfo m in Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetAllConcreteMethods(t)) {
                        Net.TheVpc.Upa.Config.Decoration[] mdecos = newrepo.GetMethodDecorations(m);
                        foreach (Net.TheVpc.Upa.Config.Decoration mdeco in mdecos) {
                            if (listener != null) {
                                listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(object), t, new Net.TheVpc.Upa.Impl.Config.DecoratedMethodScan(mdeco, m)));
                            }
                        }
                    }
                    if (IsPersistenceUnitItemDefinitionListener(t)) {
                        if (listener != null) {
                            foreach (System.Type tt in GetPersistenceUnitItemDefinitionListener(t)) {
                                listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, tt, t, at));
                            }
                        }
                    }
                    if (typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitListener).IsAssignableFrom(t)) {
                        if (listener != null) {
                            listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitListener), t, null));
                        }
                    }
                    if (typeof(Net.TheVpc.Upa.Callbacks.EntityInterceptor).IsAssignableFrom(t)) {
                        if (listener != null) {
                            listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.Callbacks.EntityInterceptor), t, at));
                        }
                    }
                }
                System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.ISet<System.Type>> entityClasses = new System.Collections.Generic.Dictionary<System.Type , System.Collections.Generic.ISet<System.Type>>();
                System.Collections.Generic.IDictionary<System.Type , System.Type> partialEntities = new System.Collections.Generic.Dictionary<System.Type , System.Type>();
                foreach (Net.TheVpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.Entity)).FullName)) {
                    System.Type tt = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(tt, typeof(Net.TheVpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored Entity {0}",null,tt));
                        continue;
                    }
                    System.Type entityType = at.GetType("entityType");
                    if (entityType != null && (typeof(void).Equals(entityType) || typeof(void).Equals(entityType))) {
                        entityType = tt;
                    }
                    System.Collections.Generic.ISet<System.Type> s = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.ISet<System.Type>>(entityClasses,entityType);
                    if (s == null) {
                        s = new System.Collections.Generic.HashSet<System.Type>();
                        entityClasses[entityType]=s;
                    }
                    if (tt.Equals(entityType)) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,40,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Entity {0}",null,tt));
                    } else {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,40,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Entity {0} as {1}",null,entityType));
                    }
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.Config.Entity), tt, null));
                    }
                    s.Add(tt);
                }
                foreach (Net.TheVpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.Partial)).FullName)) {
                    System.Type tt = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = newrepo.GetTypeDecoration(tt, typeof(Net.TheVpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored Entity {0}",null,tt));
                        continue;
                    }
                    Net.TheVpc.Upa.Config.Decoration entityAnnotation = newrepo.GetTypeDecoration(tt, typeof(Net.TheVpc.Upa.Config.Entity));
                    if (entityAnnotation == null) {
                        throw new System.ArgumentException ("Missing @Entity along with @Partial for " + tt);
                    }
                    partialEntities[tt]=at.GetType("value");
                    entityClasses.Remove(tt);
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Partial Entity {0} as {1}",null,new object[] { at.GetType("value"), tt }));
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.Config.Partial), tt, null));
                    }
                }
                foreach (System.Collections.Generic.KeyValuePair<System.Type , System.Type> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<System.Type,System.Type>>(partialEntities)) {
                    System.Type rootEntity = GetRootEntity((entry).Key, entityClasses, partialEntities);
                    if (rootEntity == null) {
                        //                    rootEntity = getRootEntity(entry.getKey(), entityClasses, partialEntities);
                        throw new System.ArgumentException ("Partial Entity " + (entry).Key + " references invalid Entity or Partial (" + (entry).Value + ")");
                    }
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.ISet<System.Type>>(entityClasses,rootEntity).Add((entry).Key);
                }
                foreach (System.Collections.Generic.ISet<System.Type> ee in (entityClasses).Values) {
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.EntityDescriptor), typeof(Net.TheVpc.Upa.EntityDescriptor), r.Resolve(ee.ToArray())));
                    }
                }
                foreach (Net.TheVpc.Upa.Config.Decoration d in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.Function)).FullName)) {
                    System.Type tt = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(d.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(tt, typeof(Net.TheVpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored QLFunction {0}",null,tt));
                        continue;
                    }
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Function {0}",null,tt));
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.Function), tt, null));
                    }
                }
                foreach (Net.TheVpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.TheVpc.Upa.Config.SecurityContext)).FullName)) {
                    System.Type t = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.TheVpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.TheVpc.Upa.Config.Ignore));
                    bool ok = false;
                    if (ignored == null) {
                        if (typeof(Net.TheVpc.Upa.EntitySecurityManager).IsAssignableFrom(t)) {
                            ok = true;
                            if (listener != null) {
                                listener.PersistenceUnitItemScanned(new Net.TheVpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.TheVpc.Upa.EntitySecurityManager), t, at));
                                ok = true;
                            }
                        }
                        if (typeof(Net.TheVpc.Upa.PersistenceGroupSecurityManager).IsAssignableFrom(t) || typeof(Net.TheVpc.Upa.UPASecurityManager).IsAssignableFrom(t)) {
                            ok = true;
                        }
                        if (!ok) {
                            log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("@SecurityContext ignored as annotating any of PersistenceGroupSecurityManager, UPASecurityManager, EntitySecurityManager",null));
                        }
                    }
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("URLAnnotationStrategySupportConfigureException"));
            }
        }

        /**
             * transform supported JPA Annotations to UPA Decorations
             */
        private void ProcessJAVAXAnnotations(Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository readFrom, Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository writeTo, bool noIgnore) {
            int pos = 0;
            foreach (Net.TheVpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.persistence.Entity")) {
                Net.TheVpc.Upa.Config.Decoration ignored = noIgnore ? null : readFrom.GetTypeDecoration(at.GetLocationType(), (typeof(Net.TheVpc.Upa.Config.Ignore)).FullName);
                if (ignored != null) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored javax.persistence.Entity {0}",null,at));
                    continue;
                }
                System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
                Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.TheVpc.Upa.Config.Entity)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
            pos = 0;
            foreach (Net.TheVpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.persistence.Id")) {
                //            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
                //            if (ignored != null) {
                //                log.log(Level.FINE, "\t Ignored javax.persistence.Id {0}", at);
                //                continue;
                //            }
                System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
                Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.TheVpc.Upa.Config.Id)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
            pos = 0;
            foreach (Net.TheVpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.persistence.ManyToOne")) {
                //            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
                //            if (ignored != null) {
                //                log.log(Level.FINE, "\t Ignored javax.persistence.Id javax.persistence.ManyToOne", at);
                //                continue;
                //            }
                System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
                Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.TheVpc.Upa.Config.ManyToOne)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
            pos = 0;
            foreach (Net.TheVpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.annotation.PostConstruct")) {
                System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Config.DecorationValue>();
                Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.TheVpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.TheVpc.Upa.Config.Init)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
        }

        private System.Type GetRootEntity(System.Type c, System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.ISet<System.Type>> entityClasses, System.Collections.Generic.IDictionary<System.Type , System.Type> partialEntities) {
            if (entityClasses.ContainsKey(c)) {
                return c;
            }
            System.Type r = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Type>(partialEntities,c);
            if (r == null) {
                return null;
            }
            return GetRootEntity(r, entityClasses, partialEntities);
        }

        private void Merge(Net.TheVpc.Upa.Persistence.ConnectionConfig source, Net.TheVpc.Upa.Persistence.ConnectionConfig target) {
            if (source != null) {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(source.GetConnectionString())) {
                    target.SetConnectionString(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(source.GetConnectionString()));
                }
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(source.GetUserName())) {
                    target.SetUserName(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(source.GetUserName()));
                }
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(source.GetPassword())) {
                    target.SetPassword(source.GetPassword());
                }
                if (source.GetStructureStrategy() != default(Net.TheVpc.Upa.Persistence.StructureStrategy)) {
                    target.SetStructureStrategy(source.GetStructureStrategy());
                }
                if (source.IsEnabled() != null) {
                    target.SetEnabled(source.IsEnabled());
                }
                if (source.GetProperties() != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string , string> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,string>>(source.GetProperties())) {
                        if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty((entry).Value)) {
                            target.GetProperties()[Net.TheVpc.Upa.Impl.Util.StringUtils.Trim((entry).Key)]=Net.TheVpc.Upa.Impl.Util.StringUtils.Trim((entry).Value);
                        }
                    }
                }
            }
        }

        private void Merge(Net.TheVpc.Upa.Config.Decoration persistenceNameStrategy, Net.TheVpc.Upa.Persistence.PersistenceNameConfig target) {
            if (persistenceNameStrategy != null) {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsUndefined(persistenceNameStrategy.GetString("escape"))) {
                    target.SetPersistenceNameEscape(persistenceNameStrategy.GetString("escape"));
                }
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsUndefined(persistenceNameStrategy.GetString("globalPersistenceNameFormat"))) {
                    target.SetGlobalPersistenceName(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(persistenceNameStrategy.GetString("globalPersistenceNameFormat")));
                }
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsUndefined(persistenceNameStrategy.GetString("localPersistenceNameFormat"))) {
                    target.SetLocalPersistenceName(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(persistenceNameStrategy.GetString("localPersistenceNameFormat")));
                }
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsUndefined(persistenceNameStrategy.GetString("persistenceNameFormat"))) {
                    target.SetGlobalPersistenceName(persistenceNameStrategy.GetString("persistenceNameFormat"));
                }
                foreach (object persistenceNameObj in persistenceNameStrategy.GetArray("names")) {
                    Net.TheVpc.Upa.Config.Decoration persistenceNameFormat = (Net.TheVpc.Upa.Config.Decoration) persistenceNameObj;
                    Net.TheVpc.Upa.Persistence.PersistenceNameType type2 = null;
                    switch((Net.TheVpc.Upa.Config.PersistenceNameType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Config.PersistenceNameType),persistenceNameFormat.GetString("type")))) {
                        case Net.TheVpc.Upa.Config.PersistenceNameType.CUSTOM:
                            {
                                if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsUndefined(persistenceNameStrategy.GetString("custom"))) {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingCustomPersistenceNameType");
                                }
                                type2 = Net.TheVpc.Upa.Persistence.PersistenceNameType.ValueOf(persistenceNameFormat.GetString("customType"));
                                break;
                            }
                        default:
                            {
                                type2 = Net.TheVpc.Upa.Persistence.PersistenceNameType.ValueOf(persistenceNameFormat.GetString("type"));
                                break;
                            }
                    }
                    target.GetNames().Add(new Net.TheVpc.Upa.Persistence.PersistenceName(Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(persistenceNameFormat.GetString("object")), type2, Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(persistenceNameFormat.GetString("value")), persistenceNameFormat.GetConfig().GetOrder()));
                }
            }
        }

        private void Merge(Net.TheVpc.Upa.Persistence.PersistenceNameConfig source, Net.TheVpc.Upa.Persistence.PersistenceNameConfig target) {
            if (source != null) {
                if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(source.GetPersistenceNameEscape())) {
                    target.SetPersistenceNameEscape(source.GetPersistenceNameEscape());
                }
                if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(source.GetGlobalPersistenceName())) {
                    target.SetGlobalPersistenceName(source.GetGlobalPersistenceName());
                }
                if (source.GetGlobalPersistenceName() != null) {
                    target.SetGlobalPersistenceName(source.GetGlobalPersistenceName());
                }
                if (source.GetLocalPersistenceName() != null) {
                    target.SetLocalPersistenceName(source.GetLocalPersistenceName());
                }
                foreach (Net.TheVpc.Upa.Persistence.PersistenceName v in source.GetNames()) {
                    target.GetNames().Add(new Net.TheVpc.Upa.Persistence.PersistenceName(v.GetObject(), v.GetPersistenceNameType(), v.GetValue(), v.GetConfigOrder()));
                }
            }
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig> BuildPersistenceUnitConfigs(System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>> persistenceUnitConfigs) {
            System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.PersistenceUnitConfig> t = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(persistenceUnitConfigs, null);
            foreach (Net.TheVpc.Upa.Impl.Util.OrderedIem<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig> orderedIem in persistenceUnitConfigs) {
                Net.TheVpc.Upa.Persistence.PersistenceUnitConfig c = orderedIem.@value;
                string puname = Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(c.GetName());
                string pgname = Net.TheVpc.Upa.Impl.Util.StringUtils.Trim(c.GetPersistenceGroup());
                string id = pgname + "/" + puname;
                Net.TheVpc.Upa.Persistence.PersistenceUnitConfig old = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>(t,id);
                if (old == null) {
                    old = new Net.TheVpc.Upa.Persistence.PersistenceUnitConfig();
                    old.SetName(puname);
                    old.SetPersistenceGroup(pgname);
                    t[id]=old;
                }
                if (c.GetAutoStart() != null) {
                    old.SetAutoStart(c.GetAutoStart());
                }
                if (c.GetModel() != null) {
                    Net.TheVpc.Upa.Persistence.PersistenceNameConfig m0 = c.GetModel();
                    Net.TheVpc.Upa.Persistence.PersistenceNameConfig m = old.GetModel();
                    if (m == null) {
                        m = new Net.TheVpc.Upa.Persistence.PersistenceNameConfig(orderedIem.order);
                        old.SetModel(m);
                    }
                    if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(m0.GetPersistenceNameEscape())) {
                        m.SetPersistenceNameEscape(m0.GetPersistenceNameEscape());
                    }
                    if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(m0.GetGlobalPersistenceName())) {
                        m.SetGlobalPersistenceName(m0.GetGlobalPersistenceName());
                    }
                    if (m0.GetGlobalPersistenceName() != null) {
                        m.SetGlobalPersistenceName(m0.GetGlobalPersistenceName());
                    }
                    if (m0.GetLocalPersistenceName() != null) {
                        m.SetLocalPersistenceName(m0.GetLocalPersistenceName());
                    }
                    foreach (Net.TheVpc.Upa.Persistence.PersistenceName v in m0.GetNames()) {
                        m.GetNames().Add(new Net.TheVpc.Upa.Persistence.PersistenceName(v.GetObject(), v.GetPersistenceNameType(), v.GetValue(), v.GetConfigOrder()));
                    }
                }
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(c.GetProperties())) {
                    if (System.Collections.Generic.EqualityComparer<object>.Default.Equals((entry).Value,null)) {
                        old.GetProperties().Remove((entry).Key);
                    } else {
                        old.GetProperties()[(entry).Key]=(entry).Value;
                    }
                }
                foreach (Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig in c.GetConnections()) {
                    string s = connectionConfig.GetConnectionString();
                    Net.TheVpc.Upa.Persistence.ConnectionConfig oldConnectionConfig = null;
                    foreach (Net.TheVpc.Upa.Persistence.ConnectionConfig c0 in old.GetConnections()) {
                        if (Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(s, c0.GetConnectionString())) {
                            oldConnectionConfig = c0;
                            break;
                        }
                    }
                    if (oldConnectionConfig == null) {
                        old.GetConnections().Add(connectionConfig);
                    } else {
                        Merge(connectionConfig, oldConnectionConfig);
                    }
                }
                foreach (Net.TheVpc.Upa.Persistence.ConnectionConfig connectionConfig in c.GetRootConnections()) {
                    string s = connectionConfig.GetConnectionString();
                    Net.TheVpc.Upa.Persistence.ConnectionConfig oldConnectionConfig = null;
                    foreach (Net.TheVpc.Upa.Persistence.ConnectionConfig c0 in old.GetRootConnections()) {
                        if (Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(s, c0.GetConnectionString())) {
                            oldConnectionConfig = c0;
                            break;
                        }
                    }
                    if (oldConnectionConfig == null) {
                        old.GetRootConnections().Add(connectionConfig);
                    } else {
                        Merge(connectionConfig, oldConnectionConfig);
                    }
                }
            }
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.PersistenceUnitConfig>((t).Values);
        }
    }
}
