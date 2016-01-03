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
namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/30/12 12:28 AM
     */
    public class URLAnnotationStrategySupport {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport)).FullName);

        private static readonly System.Type[] persistenceUnitItemDefinitionListenerTypes = new System.Type[] { typeof(Net.Vpc.Upa.Callbacks.PackageDefinitionListener), typeof(Net.Vpc.Upa.Callbacks.SectionDefinitionListener), typeof(Net.Vpc.Upa.Callbacks.EntityDefinitionListener), typeof(Net.Vpc.Upa.Callbacks.FieldDefinitionListener), typeof(Net.Vpc.Upa.Callbacks.IndexDefinitionListener), typeof(Net.Vpc.Upa.Callbacks.TriggerDefinitionListener), typeof(Net.Vpc.Upa.Callbacks.RelationshipDefinitionListener) };

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

        public virtual void Scan(Net.Vpc.Upa.UPAContext context, Net.Vpc.Upa.Config.ScanSource source, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.Vpc.Upa.ScanListener listener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser parser = new Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser(Net.Vpc.Upa.Impl.Util.UPAUtils.ToConfigurationStrategy(source).ToIterable(context), new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter().AddDecorations(typeof(Net.Vpc.Upa.Config.Callback), typeof(Net.Vpc.Upa.Config.OnAlter), typeof(Net.Vpc.Upa.Config.OnCreate), typeof(Net.Vpc.Upa.Config.OnDrop), typeof(Net.Vpc.Upa.Config.OnRemove), typeof(Net.Vpc.Upa.Config.OnPersist), typeof(Net.Vpc.Upa.Config.OnRemove), typeof(Net.Vpc.Upa.Config.OnUpdate), typeof(Net.Vpc.Upa.Config.OnUpdateFormula), typeof(Net.Vpc.Upa.Config.OnInitialize), typeof(Net.Vpc.Upa.Config.OnReset), typeof(Net.Vpc.Upa.Config.SecurityContext), typeof(Net.Vpc.Upa.Config.PersistenceUnit), typeof(Net.Vpc.Upa.Config.PersistenceNameStrategy), typeof(Net.Vpc.Upa.Config.Properties), typeof(Net.Vpc.Upa.Config.Property)).AddTypeDecorations("javax.annotation.PostConstruct"), null, null, decorationRepository);
                parser.Parse();
                //repository that contains just the scanned classes
                //older classes
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository newDecorationRepository = parser.GetNewDecorationRepository();
                ProcessJAVAXAnnotations(decorationRepository, newDecorationRepository, source.IsNoIgnore());
                //            Map<Class, Object> instances = new HashMap<Class, Object>();
                //            for (PersistenceGroupDefinitionListener old : context.getPersistenceGroupDefinitionListeners()) {
                //                if(!instances.containsKey(old.getClass())){
                //                    instances.put(old.getClass(), old);
                //                }
                //            }
                foreach (Net.Vpc.Upa.Config.Decoration dec in newDecorationRepository.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.Callback)).FullName)) {
                    System.Type tt = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(dec.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = source.IsNoIgnore() ? null : newDecorationRepository.GetTypeDecoration(dec.GetLocationType(), (typeof(Net.Vpc.Upa.Config.Ignore)).FullName);
                    if (ignored == null) {
                        if (typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener).IsAssignableFrom(tt)) {
                            if (listener != null) {
                                listener.ContextItemScanned(new Net.Vpc.Upa.ScanEvent(context, null, null, typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener), tt, null, null, dec, null));
                            }
                        }
                    }
                }
                System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>> persistenceUnitConfigs = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>>();
                foreach (Net.Vpc.Upa.Persistence.PersistenceGroupConfig persistenceGroupConfig in context.GetBootstrapContextConfig().GetPersistenceGroups()) {
                    foreach (Net.Vpc.Upa.Persistence.PersistenceUnitConfig persistenceUnitConfig in persistenceGroupConfig.GetPersistenceUnits()) {
                        persistenceUnitConfigs.Add(new Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>(System.Int32.MaxValue, persistenceUnitConfig));
                    }
                }
                foreach (Net.Vpc.Upa.Config.Decoration configPersistenceUnit in newDecorationRepository.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.PersistenceUnit)).FullName)) {
                    Net.Vpc.Upa.Config.Decoration ignored = source.IsNoIgnore() ? null : newDecorationRepository.GetTypeDecoration(configPersistenceUnit.GetLocationType(), (typeof(Net.Vpc.Upa.Config.Ignore)).FullName);
                    if (ignored == null) {
                        Net.Vpc.Upa.Persistence.PersistenceUnitConfig c = new Net.Vpc.Upa.Persistence.PersistenceUnitConfig();
                        c.SetName(Net.Vpc.Upa.Impl.Util.Strings.Trim(configPersistenceUnit.GetString("name")));
                        c.SetPersistenceGroup(Net.Vpc.Upa.Impl.Util.Strings.Trim(configPersistenceUnit.GetString("persistenceGroup")));
                        foreach (object configPropertyObj in configPersistenceUnit.GetArray("properties")) {
                            Net.Vpc.Upa.Config.Decoration configProperty = (Net.Vpc.Upa.Config.Decoration) configPropertyObj;
                            object v = Net.Vpc.Upa.Impl.Util.UPAUtils.CreateValue(new Net.Vpc.Upa.Property(configProperty.GetString("name"), configProperty.GetString("value"), configProperty.GetString("type"), configProperty.GetString("format")));
                            c.GetProperties()[configProperty.GetString("name")]=v;
                        }
                        persistenceUnitConfigs.Add(new Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>(configPersistenceUnit.GetInt("order"), c));
                    }
                }
                System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Persistence.PersistenceUnitConfig> partialPersistenceUnitConfig = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Persistence.PersistenceUnitConfig>();
                foreach (Net.Vpc.Upa.Config.Decoration a in newDecorationRepository.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.PersistenceNameStrategy)).FullName)) {
                    Net.Vpc.Upa.Config.Decoration ignored = newDecorationRepository.GetTypeDecoration(a.GetLocationType(), (typeof(Net.Vpc.Upa.Config.Ignore)).FullName);
                    if (ignored == null) {
                        Net.Vpc.Upa.Config.Decoration config = a.GetDecoration("config");
                        int configOrder = config.GetInt("order");
                        string key = Net.Vpc.Upa.Impl.Util.Strings.Trim(config.GetString("persistenceGroup")) + "/" + Net.Vpc.Upa.Impl.Util.Strings.Trim(config.GetString("persistenceUnit")) + "/" + configOrder;
                        Net.Vpc.Upa.Persistence.PersistenceUnitConfig puc = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Persistence.PersistenceUnitConfig>(partialPersistenceUnitConfig,key);
                        if (puc == null) {
                            puc = new Net.Vpc.Upa.Persistence.PersistenceUnitConfig();
                            partialPersistenceUnitConfig[key]=puc;
                            persistenceUnitConfigs.Add(new Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>(configOrder, puc));
                        }
                        Net.Vpc.Upa.Persistence.PersistenceNameConfig target = puc.GetModel();
                        if (target == null) {
                            target = new Net.Vpc.Upa.Persistence.PersistenceNameConfig(Net.Vpc.Upa.Persistence.UPAContextConfig.XML_ORDER);
                            puc.SetModel(target);
                        }
                        Merge(a, target);
                    }
                }
                //persistence groups
                System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceGroup> createdPersistenceGroups = new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceGroup>();
                System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> buildPersistenceUnitConfigs = BuildPersistenceUnitConfigs(persistenceUnitConfigs);
                foreach (Net.Vpc.Upa.Persistence.PersistenceUnitConfig c in buildPersistenceUnitConfigs) {
                    if (!Net.Vpc.Upa.Impl.Util.Strings.IsSimpleExpression(c.GetPersistenceGroup())) {
                        if (listener != null) {
                            listener.ContextItemScanned(new Net.Vpc.Upa.ScanEvent(context, null, null, typeof(Net.Vpc.Upa.Persistence.PersistenceUnitConfig), null, c));
                        }
                        if (!context.ContainsPersistenceGroup(c.GetPersistenceGroup())) {
                            Net.Vpc.Upa.PersistenceGroup pg = context.AddPersistenceGroup(c.GetPersistenceGroup());
                            createdPersistenceGroups.Add(pg);
                        }
                    }
                }
                if ((context.GetPersistenceGroups().Count==0)) {
                    createdPersistenceGroups.Add(context.AddPersistenceGroup(null));
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("No PersistenceGroup found, create default one",null));
                }
                foreach (Net.Vpc.Upa.PersistenceGroup g in createdPersistenceGroups) {
                    //                int count = 0;
                    foreach (Net.Vpc.Upa.Persistence.PersistenceGroupConfig pgc in context.GetBootstrapContextConfig().GetPersistenceGroups()) {
                        if (Net.Vpc.Upa.Impl.Util.Strings.MatchesSimpleExpression(g.GetName(), pgc.GetName())) {
                            if (pgc.GetAutoScan() != null) {
                                g.SetAutoScan((pgc.GetAutoScan()).Value);
                            }
                            foreach (Net.Vpc.Upa.Config.ScanFilter a in pgc.GetContextAnnotationStrategyFilters()) {
                                g.AddContextAnnotationStrategyFilter(a);
                            }
                        }
                    }
                    if (listener != null) {
                        listener.ContextItemScanned(new Net.Vpc.Upa.ScanEvent(context, null, null, typeof(Net.Vpc.Upa.PersistenceGroup), null, g));
                    }
                    g.Scan(source, listener, false);
                }
                //persistence units
                System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnit> createdPersistenceUnits = new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceUnit>();
                foreach (Net.Vpc.Upa.Persistence.PersistenceUnitConfig c in buildPersistenceUnitConfigs) {
                    if (!Net.Vpc.Upa.Impl.Util.Strings.IsSimpleExpression(c.GetName())) {
                        foreach (Net.Vpc.Upa.PersistenceGroup persistenceGroup in context.GetPersistenceGroups()) {
                            if (Net.Vpc.Upa.Impl.Util.Strings.MatchesSimpleExpression(persistenceGroup.GetName(), c.GetPersistenceGroup())) {
                                if (!persistenceGroup.ContainsPersistenceUnit(c.GetName())) {
                                    Net.Vpc.Upa.PersistenceUnit pu = persistenceGroup.AddPersistenceUnit(c.GetName());
                                    createdPersistenceUnits.Add(pu);
                                }
                            }
                        }
                    }
                }
                foreach (Net.Vpc.Upa.PersistenceUnit pu in createdPersistenceUnits) {
                    bool autoScan = false;
                    foreach (Net.Vpc.Upa.Persistence.PersistenceUnitConfig puc in buildPersistenceUnitConfigs) {
                        if (Net.Vpc.Upa.Impl.Util.Strings.MatchesSimpleExpression(pu.GetPersistenceGroup().GetName(), puc.GetPersistenceGroup()) && Net.Vpc.Upa.Impl.Util.Strings.MatchesSimpleExpression(pu.GetName(), puc.GetName())) {
                            if ((puc.GetAutoScan() != null)) {
                                pu.SetAutoScan(autoScan);
                            }
                            pu.SetAutoStart(puc.GetAutoStart() == null ? ((bool)((true).Value)) : (puc.GetAutoStart()).Value);
                            Net.Vpc.Upa.Persistence.PersistenceNameConfig oldPersistenceNameConfig = pu.GetPersistenceNameConfig();
                            Merge(puc.GetModel(), oldPersistenceNameConfig);
                            pu.SetPersistenceNameConfig(oldPersistenceNameConfig);
                            foreach (Net.Vpc.Upa.Config.ScanFilter a in puc.GetFilters()) {
                                puc.AddContextAnnotationStrategyFilter(a);
                            }
                            foreach (Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig in puc.GetConnections()) {
                                pu.AddConnectionConfig(connectionConfig);
                            }
                            foreach (Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig in puc.GetRootConnections()) {
                                pu.AddRootConnectionConfig(connectionConfig);
                            }
                        }
                    }
                    if (listener != null) {
                        listener.ContextItemScanned(new Net.Vpc.Upa.ScanEvent(context, null, null, typeof(Net.Vpc.Upa.PersistenceUnit), null, pu));
                    }
                    pu.Scan(source, listener, false);
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("URLAnnotationStrategySupportConfigureException"));
            }
        }

        public virtual void Scan(Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.Config.ScanSource strategy, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.Vpc.Upa.ScanListener listener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser parser = new Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser(Net.Vpc.Upa.Impl.Util.UPAUtils.ToConfigurationStrategy(strategy).ToIterable(persistenceGroup), new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter().AddDecorations(typeof(Net.Vpc.Upa.Config.Callback), typeof(Net.Vpc.Upa.Config.OnAlter), typeof(Net.Vpc.Upa.Config.OnCreate), typeof(Net.Vpc.Upa.Config.OnDrop), typeof(Net.Vpc.Upa.Config.OnRemove), typeof(Net.Vpc.Upa.Config.OnPersist), typeof(Net.Vpc.Upa.Config.OnRemove), typeof(Net.Vpc.Upa.Config.OnUpdate), typeof(Net.Vpc.Upa.Config.OnUpdateFormula), typeof(Net.Vpc.Upa.Config.OnInitialize), typeof(Net.Vpc.Upa.Config.OnReset)).AddDecorations(typeof(Net.Vpc.Upa.Config.SecurityContext)).AddTypeDecorations("javax.annotation.PostConstruct"), persistenceGroup.GetName(), null, decorationRepository);
                parser.Parse();
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo = parser.GetDecorationRepository();
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository newrepo = parser.GetNewDecorationRepository();
                ProcessJAVAXAnnotations(repo, newrepo, strategy.IsNoIgnore());
                foreach (Net.Vpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.Callback)).FullName)) {
                    System.Type t = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.Vpc.Upa.Config.Ignore));
                    if (ignored == null) {
                        if (typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener).IsAssignableFrom(t)) {
                            if (listener != null) {
                                listener.PersistenceGroupItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceGroup.GetContext(), persistenceGroup, null, typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener), t, null));
                            }
                        }
                    }
                }
                foreach (Net.Vpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.SecurityContext)).FullName)) {
                    System.Type t = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.Vpc.Upa.Config.Ignore));
                    if (ignored == null) {
                        if (typeof(Net.Vpc.Upa.PersistenceGroupSecurityManager).IsAssignableFrom(t)) {
                            if (listener != null) {
                                listener.PersistenceGroupItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceGroup.GetContext(), persistenceGroup, null, typeof(Net.Vpc.Upa.PersistenceGroupSecurityManager), t, null));
                            }
                        }
                        if (typeof(Net.Vpc.Upa.UPASecurityManager).IsAssignableFrom(t)) {
                            if (listener != null) {
                                listener.PersistenceGroupItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceGroup.GetContext(), persistenceGroup, null, typeof(Net.Vpc.Upa.UPASecurityManager), t, null));
                            }
                        }
                    }
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("URLAnnotationStrategySupportConfigureException"));
            }
        }

        public virtual void Scan(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Config.ScanSource strategy, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository, Net.Vpc.Upa.ScanListener listener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Impl.Config.EntityDescriptorResolver r = new Net.Vpc.Upa.Impl.Config.EntityDescriptorResolver(persistenceUnit, decorationRepository);
                Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser parser = new Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser(Net.Vpc.Upa.Impl.Util.UPAUtils.ToConfigurationStrategy(strategy).ToIterable(persistenceUnit), new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter().AddDecorations(typeof(Net.Vpc.Upa.Config.SecurityContext), typeof(Net.Vpc.Upa.Config.Config), typeof(Net.Vpc.Upa.Config.Field), typeof(Net.Vpc.Upa.Config.FilterEntity), typeof(Net.Vpc.Upa.Config.Formula), typeof(Net.Vpc.Upa.Config.Formulas), typeof(Net.Vpc.Upa.Config.Id), typeof(Net.Vpc.Upa.Config.Ignore), typeof(Net.Vpc.Upa.Config.Index), typeof(Net.Vpc.Upa.Config.Indexes), typeof(Net.Vpc.Upa.Config.Init), typeof(Net.Vpc.Upa.Config.ManyToOne), typeof(Net.Vpc.Upa.Config.Partial), typeof(Net.Vpc.Upa.Config.Password), typeof(Net.Vpc.Upa.Config.ToString), typeof(Net.Vpc.Upa.Config.ToByteArray), typeof(Net.Vpc.Upa.Config.Converter), typeof(Net.Vpc.Upa.Config.Path), typeof(Net.Vpc.Upa.Config.PersistenceName), typeof(Net.Vpc.Upa.Config.PersistenceNameStrategy), typeof(Net.Vpc.Upa.Config.PersistenceUnit), typeof(Net.Vpc.Upa.Config.Properties), typeof(Net.Vpc.Upa.Config.Property), typeof(Net.Vpc.Upa.Config.Function), typeof(Net.Vpc.Upa.Config.Search), typeof(Net.Vpc.Upa.Config.Secret), typeof(Net.Vpc.Upa.Config.Sequence), typeof(Net.Vpc.Upa.Config.Singleton), typeof(Net.Vpc.Upa.Config.Temporal), typeof(Net.Vpc.Upa.Config.Transactional), typeof(Net.Vpc.Upa.Config.Hierarchy), typeof(Net.Vpc.Upa.Config.Callback), typeof(Net.Vpc.Upa.Config.OnAlter), typeof(Net.Vpc.Upa.Config.OnCreate), typeof(Net.Vpc.Upa.Config.OnDrop), typeof(Net.Vpc.Upa.Config.OnRemove), typeof(Net.Vpc.Upa.Config.OnPersist), typeof(Net.Vpc.Upa.Config.OnRemove), typeof(Net.Vpc.Upa.Config.OnUpdate), typeof(Net.Vpc.Upa.Config.OnUpdateFormula), typeof(Net.Vpc.Upa.Config.OnInitialize), typeof(Net.Vpc.Upa.Config.OnReset), typeof(Net.Vpc.Upa.Config.UnionEntity), typeof(Net.Vpc.Upa.Config.UnionEntityEntry), typeof(Net.Vpc.Upa.Config.View), typeof(Net.Vpc.Upa.Config.Entity), typeof(Net.Vpc.Upa.Config.Partial)).AddTypeDecorations("javax.persistence.Entity", "javax.persistence.Id", "javax.persistence.ManyToOne", "javax.annotation.PostConstruct"), persistenceUnit.GetPersistenceGroup().GetName(), persistenceUnit.GetName(), decorationRepository);
                parser.Parse();
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo = parser.GetDecorationRepository();
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository newrepo = parser.GetNewDecorationRepository();
                ProcessJAVAXAnnotations(repo, newrepo, strategy.IsNoIgnore());
                foreach (Net.Vpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.Callback)).FullName)) {
                    System.Type t = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(t, typeof(Net.Vpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        continue;
                    }
                    foreach (System.Reflection.MethodInfo m in Net.Vpc.Upa.Impl.Util.PlatformUtils.GetAllConcreteMethods(t)) {
                        Net.Vpc.Upa.Config.Decoration[] mdecos = newrepo.GetMethodDecorations(m);
                        foreach (Net.Vpc.Upa.Config.Decoration mdeco in mdecos) {
                            Net.Vpc.Upa.CallbackType type = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.CallbackType>(typeof(Net.Vpc.Upa.CallbackType));
                            System.Collections.Generic.IDictionary<string , object> conf = new System.Collections.Generic.Dictionary<string , object>();
                            if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnAlter))) {
                                type = Net.Vpc.Upa.CallbackType.ON_UPDATE;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnCreate))) {
                                type = Net.Vpc.Upa.CallbackType.ON_CREATE;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnDrop))) {
                                type = Net.Vpc.Upa.CallbackType.ON_DROP;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnPersist))) {
                                type = Net.Vpc.Upa.CallbackType.ON_PERSIST;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnUpdate))) {
                                type = Net.Vpc.Upa.CallbackType.ON_UPDATE;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnRemove))) {
                                type = Net.Vpc.Upa.CallbackType.ON_REMOVE;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnReset))) {
                                type = Net.Vpc.Upa.CallbackType.ON_RESET;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.OnInitialize))) {
                                type = Net.Vpc.Upa.CallbackType.ON_INITIALIZE;
                                conf["before"]=at.GetBoolean("before");
                                conf["after"]=at.GetBoolean("after");
                                conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                            } else if (mdeco.IsName(typeof(Net.Vpc.Upa.Config.Function))) {
                                type = Net.Vpc.Upa.CallbackType.ON_EVAL;
                                string functionName = at.GetString("name");
                                System.Type returnType = at.GetType("returnType");
                                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(functionName)) {
                                    conf["functionName"]=functionName;
                                }
                                if (returnType != null && !Net.Vpc.Upa.Impl.Util.PlatformUtils.IsVoid(returnType)) {
                                    conf["returnType"]=returnType;
                                }
                            }
                            if (type != null) {
                                object instance = null;
                                if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsStatic(m)) {
                                    instance = persistenceUnit.GetFactory().GetSingleton<object>(t);
                                }
                                Net.Vpc.Upa.Callback cb = persistenceUnit.GetPersistenceGroup().GetContext().CreateCallback(instance, m, type, conf);
                                persistenceUnit.AddCallback(cb);
                            }
                            listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.Config.Callback), t, at));
                        }
                    }
                    if (IsPersistenceUnitItemDefinitionListener(t)) {
                        if (listener != null) {
                            foreach (System.Type tt in GetPersistenceUnitItemDefinitionListener(t)) {
                                listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, tt, t, at));
                            }
                        }
                    }
                    if (typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitListener).IsAssignableFrom(t)) {
                        if (listener != null) {
                            listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitListener), t, null));
                        }
                    }
                    if (typeof(Net.Vpc.Upa.Callbacks.EntityInterceptor).IsAssignableFrom(t)) {
                        if (listener != null) {
                            listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.Callbacks.EntityInterceptor), t, at));
                        }
                    }
                    if (typeof(Net.Vpc.Upa.EntitySecurityManager).IsAssignableFrom(t)) {
                        if (listener != null) {
                            listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.EntitySecurityManager), t, at));
                        }
                    }
                }
                System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.ISet<System.Type>> entityClasses = new System.Collections.Generic.Dictionary<System.Type , System.Collections.Generic.ISet<System.Type>>();
                System.Collections.Generic.IDictionary<System.Type , System.Type> partialEntities = new System.Collections.Generic.Dictionary<System.Type , System.Type>();
                foreach (Net.Vpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.Entity)).FullName)) {
                    System.Type tt = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(tt, typeof(Net.Vpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored Entity {0}",null,tt));
                        continue;
                    }
                    System.Type entityType = at.GetType("entityType");
                    if (entityType != null && (typeof(void).Equals(entityType) || typeof(void).Equals(entityType))) {
                        entityType = tt;
                    }
                    System.Collections.Generic.ISet<System.Type> s = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.ISet<System.Type>>(entityClasses,entityType);
                    if (s == null) {
                        s = new System.Collections.Generic.HashSet<System.Type>();
                        entityClasses[entityType]=s;
                    }
                    if (tt.Equals(entityType)) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Entity {0}",null,tt));
                    } else {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Entity {0} as {1}",null,entityType));
                    }
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.Config.Entity), tt, null));
                    }
                    s.Add(tt);
                }
                foreach (Net.Vpc.Upa.Config.Decoration at in newrepo.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.Partial)).FullName)) {
                    System.Type tt = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(at.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = newrepo.GetTypeDecoration(tt, typeof(Net.Vpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored Entity {0}",null,tt));
                        continue;
                    }
                    Net.Vpc.Upa.Config.Decoration entityAnnotation = newrepo.GetTypeDecoration(tt, typeof(Net.Vpc.Upa.Config.Entity));
                    if (entityAnnotation == null) {
                        throw new System.ArgumentException ("Missing @Entity along with @Partial for " + tt);
                    }
                    partialEntities[tt]=at.GetType("value");
                    entityClasses.Remove(tt);
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Partial Entity {0} as {1}",null,new object[] { at.GetType("value"), tt }));
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.Config.Partial), tt, null));
                    }
                }
                foreach (System.Collections.Generic.KeyValuePair<System.Type , System.Type> entry in partialEntities) {
                    System.Type rootEntity = GetRootEntity((entry).Key, entityClasses, partialEntities);
                    if (rootEntity == null) {
                        //                    rootEntity = getRootEntity(entry.getKey(), entityClasses, partialEntities);
                        throw new System.ArgumentException ("Partial Entity " + (entry).Key + " references invalid Entity or Partial (" + (entry).Value + ")");
                    }
                    Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.ISet<System.Type>>(entityClasses,rootEntity).Add((entry).Key);
                }
                foreach (System.Collections.Generic.ISet<System.Type> ee in (entityClasses).Values) {
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.EntityDescriptor), typeof(Net.Vpc.Upa.EntityDescriptor), r.Resolve(ee.ToArray())));
                    }
                }
                foreach (Net.Vpc.Upa.Config.Decoration d in newrepo.GetDeclaredDecorations((typeof(Net.Vpc.Upa.Config.Function)).FullName)) {
                    System.Type tt = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(d.GetLocationType());
                    Net.Vpc.Upa.Config.Decoration ignored = strategy.IsNoIgnore() ? null : newrepo.GetTypeDecoration(tt, typeof(Net.Vpc.Upa.Config.Ignore));
                    if (ignored != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored QLFunction {0}",null,tt));
                        continue;
                    }
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Detect Function {0}",null,tt));
                    if (listener != null) {
                        listener.PersistenceUnitItemScanned(new Net.Vpc.Upa.ScanEvent(persistenceUnit.GetPersistenceGroup().GetContext(), persistenceUnit.GetPersistenceGroup(), persistenceUnit, typeof(Net.Vpc.Upa.Function), tt, null));
                    }
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("URLAnnotationStrategySupportConfigureException"));
            }
        }

        /**
             * transform supported JPA Annotations to UPA Decorations
             */
        private void ProcessJAVAXAnnotations(Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository readFrom, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository writeTo, bool noIgnore) {
            int pos = 0;
            foreach (Net.Vpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.persistence.Entity")) {
                Net.Vpc.Upa.Config.Decoration ignored = noIgnore ? null : readFrom.GetTypeDecoration(at.GetLocationType(), (typeof(Net.Vpc.Upa.Config.Ignore)).FullName);
                if (ignored != null) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t Ignored javax.persistence.Entity {0}",null,at));
                    continue;
                }
                System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
                Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.Vpc.Upa.Config.Entity)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.Vpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
            pos = 0;
            foreach (Net.Vpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.persistence.Id")) {
                //            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
                //            if (ignored != null) {
                //                log.log(Level.FINE, "\t Ignored javax.persistence.Id {0}", at);
                //                continue;
                //            }
                System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
                Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.Vpc.Upa.Config.Id)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.Vpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
            pos = 0;
            foreach (Net.Vpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.persistence.ManyToOne")) {
                //            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
                //            if (ignored != null) {
                //                log.log(Level.FINE, "\t Ignored javax.persistence.Id javax.persistence.ManyToOne", at);
                //                continue;
                //            }
                System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
                Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.Vpc.Upa.Config.ManyToOne)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.Vpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
            pos = 0;
            foreach (Net.Vpc.Upa.Config.Decoration at in readFrom.GetDeclaredDecorations("javax.annotation.PostConstruct")) {
                System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue> v = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Config.DecorationValue>();
                Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration s = new Net.Vpc.Upa.Impl.Config.Decorations.SimpleDecoration((typeof(Net.Vpc.Upa.Config.Init)).FullName, at.GetDecorationSourceType(), at.GetTarget(), at.GetLocationType(), at.GetLocation(), pos, Net.Vpc.Upa.Config.ConfigInfo.DEFAULT, v);
                //            readFrom.register(s);
                writeTo.Visit(s);
                pos++;
            }
        }

        private System.Type GetRootEntity(System.Type c, System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.ISet<System.Type>> entityClasses, System.Collections.Generic.IDictionary<System.Type , System.Type> partialEntities) {
            if (entityClasses.ContainsKey(c)) {
                return c;
            }
            System.Type r = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Type>(partialEntities,c);
            if (r == null) {
                return null;
            }
            return GetRootEntity(r, entityClasses, partialEntities);
        }

        private void Merge(Net.Vpc.Upa.Persistence.ConnectionConfig source, Net.Vpc.Upa.Persistence.ConnectionConfig target) {
            if (source != null) {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(source.GetConnectionString())) {
                    target.SetConnectionString(Net.Vpc.Upa.Impl.Util.Strings.Trim(source.GetConnectionString()));
                }
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(source.GetUserName())) {
                    target.SetUserName(Net.Vpc.Upa.Impl.Util.Strings.Trim(source.GetUserName()));
                }
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(source.GetPassword())) {
                    target.SetPassword(source.GetPassword());
                }
                if (source.GetStructureStrategy() != null) {
                    target.SetStructureStrategy(source.GetStructureStrategy());
                }
                if (source.IsEnabled() != null) {
                    target.SetEnabled(source.IsEnabled());
                }
                if (source.GetProperties() != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string , string> entry in source.GetProperties()) {
                        if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty((entry).Value)) {
                            target.GetProperties()[Net.Vpc.Upa.Impl.Util.Strings.Trim((entry).Key)]=Net.Vpc.Upa.Impl.Util.Strings.Trim((entry).Value);
                        }
                    }
                }
            }
        }

        private void Merge(Net.Vpc.Upa.Config.Decoration persistenceNameStrategy, Net.Vpc.Upa.Persistence.PersistenceNameConfig target) {
            if (persistenceNameStrategy != null) {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsUndefined(persistenceNameStrategy.GetString("escape"))) {
                    target.SetPersistenceNameEscape(persistenceNameStrategy.GetString("escape"));
                }
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsUndefined(persistenceNameStrategy.GetString("globalPersistenceName"))) {
                    target.SetGlobalPersistenceName(Net.Vpc.Upa.Impl.Util.Strings.Trim(persistenceNameStrategy.GetString("globalPersistenceName")));
                }
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsUndefined(persistenceNameStrategy.GetString("localPersistenceName"))) {
                    target.SetLocalPersistenceName(Net.Vpc.Upa.Impl.Util.Strings.Trim(persistenceNameStrategy.GetString("localPersistenceName")));
                }
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsUndefined(persistenceNameStrategy.GetString("persistenceName"))) {
                    target.SetGlobalPersistenceName(persistenceNameStrategy.GetString("persistenceName"));
                }
                foreach (object persistenceNameObj in persistenceNameStrategy.GetArray("names")) {
                    Net.Vpc.Upa.Config.Decoration persistenceName = (Net.Vpc.Upa.Config.Decoration) persistenceNameObj;
                    Net.Vpc.Upa.Persistence.PersistenceNameType type2 = null;
                    switch((Net.Vpc.Upa.Config.PersistenceNameType)(System.Enum.Parse(typeof(Net.Vpc.Upa.Config.PersistenceNameType),persistenceName.GetString("type")))) {
                        case Net.Vpc.Upa.Config.PersistenceNameType.CUSTOM:
                            {
                                if (Net.Vpc.Upa.Impl.Util.Strings.IsUndefined(persistenceNameStrategy.GetString("custom"))) {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingCustomPersistenceNameType");
                                }
                                type2 = Net.Vpc.Upa.Persistence.PersistenceNameType.ValueOf(persistenceName.GetString("customType"));
                                break;
                            }
                        default:
                            {
                                type2 = Net.Vpc.Upa.Persistence.PersistenceNameType.ValueOf(persistenceName.GetString("type"));
                                break;
                            }
                    }
                    target.GetNames().Add(new Net.Vpc.Upa.Persistence.PersistenceName(Net.Vpc.Upa.Impl.Util.Strings.Trim(persistenceName.GetString("object")), type2, Net.Vpc.Upa.Impl.Util.Strings.Trim(persistenceName.GetString("value")), persistenceName.GetConfig().GetOrder()));
                }
            }
        }

        private void Merge(Net.Vpc.Upa.Persistence.PersistenceNameConfig source, Net.Vpc.Upa.Persistence.PersistenceNameConfig target) {
            if (source != null) {
                if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(source.GetPersistenceNameEscape())) {
                    target.SetPersistenceNameEscape(source.GetPersistenceNameEscape());
                }
                if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(source.GetGlobalPersistenceName())) {
                    target.SetGlobalPersistenceName(source.GetGlobalPersistenceName());
                }
                if (source.GetGlobalPersistenceName() != null) {
                    target.SetGlobalPersistenceName(source.GetGlobalPersistenceName());
                }
                if (source.GetLocalPersistenceName() != null) {
                    target.SetLocalPersistenceName(source.GetLocalPersistenceName());
                }
                foreach (Net.Vpc.Upa.Persistence.PersistenceName v in source.GetNames()) {
                    target.GetNames().Add(new Net.Vpc.Upa.Persistence.PersistenceName(v.GetObject(), v.GetPersistenceNameType(), v.GetValue(), v.GetConfigOrder()));
                }
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> BuildPersistenceUnitConfigs(System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>> persistenceUnitConfigs) {
            System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Persistence.PersistenceUnitConfig> t = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Persistence.PersistenceUnitConfig>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(persistenceUnitConfigs, null);
            foreach (Net.Vpc.Upa.Impl.Util.OrderedIem<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> orderedIem in persistenceUnitConfigs) {
                Net.Vpc.Upa.Persistence.PersistenceUnitConfig c = orderedIem.@value;
                string puname = Net.Vpc.Upa.Impl.Util.Strings.Trim(c.GetName());
                string pgname = Net.Vpc.Upa.Impl.Util.Strings.Trim(c.GetPersistenceGroup());
                string id = pgname + "/" + puname;
                Net.Vpc.Upa.Persistence.PersistenceUnitConfig old = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Persistence.PersistenceUnitConfig>(t,id);
                if (old == null) {
                    old = new Net.Vpc.Upa.Persistence.PersistenceUnitConfig();
                    old.SetName(puname);
                    old.SetPersistenceGroup(pgname);
                    t[id]=old;
                }
                if (c.GetAutoStart() != null) {
                    old.SetAutoStart(c.GetAutoStart());
                }
                if (c.GetModel() != null) {
                    Net.Vpc.Upa.Persistence.PersistenceNameConfig m0 = c.GetModel();
                    Net.Vpc.Upa.Persistence.PersistenceNameConfig m = old.GetModel();
                    if (m == null) {
                        m = new Net.Vpc.Upa.Persistence.PersistenceNameConfig(orderedIem.order);
                        old.SetModel(m);
                    }
                    if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(m0.GetPersistenceNameEscape())) {
                        m.SetPersistenceNameEscape(m0.GetPersistenceNameEscape());
                    }
                    if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(m0.GetGlobalPersistenceName())) {
                        m.SetGlobalPersistenceName(m0.GetGlobalPersistenceName());
                    }
                    if (m0.GetGlobalPersistenceName() != null) {
                        m.SetGlobalPersistenceName(m0.GetGlobalPersistenceName());
                    }
                    if (m0.GetLocalPersistenceName() != null) {
                        m.SetLocalPersistenceName(m0.GetLocalPersistenceName());
                    }
                    foreach (Net.Vpc.Upa.Persistence.PersistenceName v in m0.GetNames()) {
                        m.GetNames().Add(new Net.Vpc.Upa.Persistence.PersistenceName(v.GetObject(), v.GetPersistenceNameType(), v.GetValue(), v.GetConfigOrder()));
                    }
                }
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in c.GetProperties()) {
                    if ((entry).Value == null) {
                        old.GetProperties().Remove((entry).Key);
                    } else {
                        old.GetProperties()[(entry).Key]=(entry).Value;
                    }
                }
                foreach (Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig in c.GetConnections()) {
                    string s = connectionConfig.GetConnectionString();
                    Net.Vpc.Upa.Persistence.ConnectionConfig oldConnectionConfig = null;
                    foreach (Net.Vpc.Upa.Persistence.ConnectionConfig c0 in old.GetConnections()) {
                        if (Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(s, c0.GetConnectionString())) {
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
                foreach (Net.Vpc.Upa.Persistence.ConnectionConfig connectionConfig in c.GetRootConnections()) {
                    string s = connectionConfig.GetConnectionString();
                    Net.Vpc.Upa.Persistence.ConnectionConfig oldConnectionConfig = null;
                    foreach (Net.Vpc.Upa.Persistence.ConnectionConfig c0 in old.GetRootConnections()) {
                        if (Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(s, c0.GetConnectionString())) {
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
            return new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>((t).Values);
        }
    }
}
