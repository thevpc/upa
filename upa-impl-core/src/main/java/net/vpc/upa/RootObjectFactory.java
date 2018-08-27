package net.vpc.upa;

import net.vpc.upa.impl.util.ClassMap;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:21 PM
 */
public class RootObjectFactory extends AbstractObjectFactory {

    public static final Logger log = Logger.getLogger(RootObjectFactory.class.getName());
    private ObjectFactory parentFactory;
    private ClassMap<Class> map = new ClassMap<Class>();
    private PlatformObjectFactory platformObjectFactory;

    public RootObjectFactory() {
        register(PlatformObjectFactory.class, net.vpc.upa.impl.DefaultPlatformObjectFactory.class);
        register(UPAContext.class, net.vpc.upa.impl.config.DefaultUPAContext.class);
        register(UPAContextProvider.class, net.vpc.upa.impl.context.DefaultUPAContextProvider.class);
        register(ObjectFactory.class, net.vpc.upa.impl.DefaultTypedFactory.class);
        register(PersistenceUnitProvider.class, net.vpc.upa.impl.context.DefaultPersistenceUnitProvider.class);
        register(PersistenceGroupProvider.class, net.vpc.upa.impl.context.DefaultPersistenceGroupProvider.class);
        register(PersistenceGroup.class, net.vpc.upa.impl.DefaultPersistenceGroup.class);
        register(PersistenceUnit.class, net.vpc.upa.impl.DefaultPersistenceUnit.class);
        register(I18NStringStrategy.class, net.vpc.upa.impl.DefaultI18NStringStrategy.class);
        register(Key.class, net.vpc.upa.impl.DefaultKey.class);
        register(Document.class, net.vpc.upa.impl.DefaultDocument.class);
        register(SessionContextProvider.class, net.vpc.upa.impl.context.DefaultSessionContextProvider.class);
        register(EntityShield.class, net.vpc.upa.impl.DefaultEntityShield.class);
        register(DataTypeTransformFactory.class, net.vpc.upa.impl.transform.DefaultDataTypeTransformFactory.class);
        register(Index.class, net.vpc.upa.impl.DefaultIndex.class);
        register(Entity.class, net.vpc.upa.impl.DefaultEntity.class);
        register(Package.class, net.vpc.upa.impl.DefaultPackage.class);
        register(Section.class, net.vpc.upa.impl.DefaultSection.class);
        register(UPASecurityManager.class, net.vpc.upa.impl.security.DefaultSecurityManager.class);
        register(TransactionManager.class, net.vpc.upa.impl.persistence.DefaultTransactionManager.class);
        register(Session.class, net.vpc.upa.impl.context.DefaultSession.class);
        register(HierarchyExtension.class, net.vpc.upa.impl.extension.HierarchicalRelationshipSupport.class);
        register(UnionEntityExtension.class, net.vpc.upa.impl.extension.DefaultUnionEntityExtension.class);
        register(SingletonExtension.class, net.vpc.upa.impl.extension.DefaultSingletonExtension.class);
        register(ViewEntityExtension.class, net.vpc.upa.impl.extension.DefaultViewEntityExtension.class);
        register(FilterEntityExtension.class, net.vpc.upa.impl.extension.DefaultFilterEntityExtension.class);
        register(QLExpressionParser.class, net.vpc.upa.impl.upql.DefaultQLExpressionParser.class);
        register(BeanAdapterFactory.class, net.vpc.upa.impl.DefaultBeanAdapterFactory.class);
        register(QLEvaluator.class, net.vpc.upa.impl.eval.DefaultQLEvaluator.class);
        register(Properties.class, net.vpc.upa.impl.DefaultProperties.class);
        register(net.vpc.upa.config.UPAContextConfigAnnotationParser.class, net.vpc.upa.impl.config.DefaultUPAContextConfigAnnotationParser.class);
        register(net.vpc.upa.persistence.PersistenceStoreFactory.class, net.vpc.upa.impl.persistence.DefaultPersistenceStoreFactory.class);
        register(net.vpc.upa.persistence.EntityExecutionContext.class, net.vpc.upa.impl.persistence.DefaultExecutionContext.class);
        register(net.vpc.upa.persistence.EntityOperationManager.class, net.vpc.upa.impl.persistence.DefaultEntityOperationManager.class);
        register(net.vpc.upa.persistence.TransactionManagerFactory.class, net.vpc.upa.impl.persistence.DefaultTransactionManagerFactory.class);
        register(net.vpc.upa.persistence.PersistenceNameStrategy.class, net.vpc.upa.impl.persistence.DefaultPersistenceNameStrategy.class);


        addAlternative(net.vpc.upa.persistence.PersistenceStore.class, net.vpc.upa.impl.persistence.specific.mssqlserver.MSSQLServerPersistenceStore.class);

        /**
         * @PortabilityHint(target = "C#", name = "todo")
         */
        addAlternative(net.vpc.upa.persistence.PersistenceStore.class, net.vpc.upa.impl.persistence.specific.oracle.OraclePersistenceStore.class);
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         */
        addAlternative(net.vpc.upa.persistence.PersistenceStore.class, net.vpc.upa.impl.persistence.specific.mysql.MySQLPersistenceStore.class);

        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        addAlternative(net.vpc.upa.persistence.PersistenceStore.class, net.vpc.upa.impl.persistence.specific.derby.DerbyPersistenceStore.class);
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        addAlternative(net.vpc.upa.persistence.PersistenceStore.class, net.vpc.upa.impl.persistence.specific.mckoi.McKoiPersistenceStore.class);
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        addAlternative(net.vpc.upa.persistence.PersistenceStore.class, net.vpc.upa.impl.persistence.specific.interbase.InterBasePersistenceStore.class);

        
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        {
            register(net.vpc.upa.bulk.TextFixedWidthParser.class, net.vpc.upa.impl.bulk.text.DefaultTextFixedWidthParser.class);
            register(net.vpc.upa.bulk.TextCSVParser.class, net.vpc.upa.impl.bulk.text.DefaultTextCSVParser.class);
            register(net.vpc.upa.bulk.XmlParser.class, net.vpc.upa.impl.bulk.xml.DefaultXmlParser.class);
            register(net.vpc.upa.bulk.TextCSVFormatter.class, net.vpc.upa.impl.bulk.text.DefaultTextCSVFormatter.class);
            register(net.vpc.upa.bulk.TextFixedWidthFormatter.class, net.vpc.upa.impl.bulk.text.DefaultTextFixedWidthFormatter.class);
            register(net.vpc.upa.bulk.XmlFormatter.class, net.vpc.upa.impl.bulk.xml.DefaultXmlFormatter.class);
            register(net.vpc.upa.bulk.ImportDataManager.class, net.vpc.upa.impl.bulk.DefaultImportDataManager.class);
            register(net.vpc.upa.bulk.ParseFormatManager.class, net.vpc.upa.impl.bulk.DefaultParseFormatManager.class);
            register(net.vpc.upa.bulk.ImportExportManager.class, net.vpc.upa.impl.bulk.DefaultImportExportManager.class);
            register(net.vpc.upa.bulk.ImportEntityFinder.class, net.vpc.upa.impl.bulk.DefaultImportEntityFinder.class);
            register(net.vpc.upa.bulk.ImportEntityMapper.class, net.vpc.upa.impl.bulk.DefaultImportEntityFinder.class);
        }


        register(net.vpc.upa.impl.DefaultEntityExtensionManager.class, net.vpc.upa.impl.DefaultEntityExtensionManager.class);
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        register(net.vpc.upa.impl.XmlFactory.class, net.vpc.upa.impl.DefaultXmlFactory.class);
        
    }

    public final void register(Class contract, Class impl) {
        map.put(contract, impl);
    }

    @Override
    public void setParentFactory(ObjectFactory factory) {
        this.parentFactory = factory;
    }

    @Override
    public <T> T createObject(Class<T> type, String name) {
        return createObject(type, name, null);
    }

    protected <T> T createObject(Class<T> type, String name, PlatformObjectFactory platformObjectFactory) {
        T s = (T) singletons.get(type.getName());
        if (s != null) {
            return s;
        }
        Class best = map.get(type);
        if (best == null || !type.isAssignableFrom(best)) {
            if (parentFactory != null) {
                return parentFactory.createObject(type, name);
            }
            if (net.vpc.upa.impl.util.PlatformUtils.isAbstract(type) || net.vpc.upa.impl.util.PlatformUtils.isInterface(type)) {
                throw new net.vpc.upa.exceptions.NoSuchUPAElementException("NoSuchObject", type.getSimpleName());
            }
            best = type;
        }
        if (platformObjectFactory != null) {
            return (T) platformObjectFactory.createObject(best, name);
        }
        try {
            return (T) createPlatformInstance(best, name);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public <T> T createObject(String typeName, String name) {
        Class<T> c;
        try {
            c = net.vpc.upa.impl.util.PlatformUtils.forName(typeName);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(typeName);
        }
        return (T) createObject(c, name);
    }

    @Override
    public int getContextSupportLevel() {
        return 0;
    }

    @Override
    public <T> T createObject(Class<T> type) {
        return createObject(type, null);
    }

    @Override
    public <T> T createObject(String typeName) {
        try {
            Class<T> c = (Class<T>) net.vpc.upa.impl.util.PlatformUtils.forName(typeName);
            return (T) createObject(c);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    protected Object createPlatformInstance(Class cls, String name) {
        if (platformObjectFactory == null) {
            if (cls.equals(PlatformObjectFactory.class) || cls.equals(net.vpc.upa.impl.DefaultPlatformObjectFactory.class)) {
                platformObjectFactory = net.vpc.upa.impl.DefaultPlatformObjectFactory.INSTANCE;
            } else {
                platformObjectFactory = createObject(PlatformObjectFactory.class, null, net.vpc.upa.impl.DefaultPlatformObjectFactory.INSTANCE);
            }
        }
        return platformObjectFactory.createObject(cls, name);
    }

}
