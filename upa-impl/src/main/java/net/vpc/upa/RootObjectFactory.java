package net.vpc.upa;

import java.util.HashMap;
import net.vpc.upa.extensions.HierarchyExtension;

import net.vpc.upa.bulk.*;
import net.vpc.upa.impl.*;
import net.vpc.upa.impl.bulk.sheet.DefaultSheetFormatter;
import net.vpc.upa.impl.bulk.sheet.DefaultSheetParser;
import net.vpc.upa.impl.bulk.text.DefaultTextFixedWidthFormatter;
import net.vpc.upa.impl.bulk.text.DefaultTextFixedWidthParser;
import net.vpc.upa.impl.bulk.xml.DefaultXmlFormatter;
import net.vpc.upa.impl.config.DefaultUPAContext;
import net.vpc.upa.impl.context.*;
import net.vpc.upa.impl.extension.*;
import net.vpc.upa.impl.persistence.DefaultEntityOperationManager;
import net.vpc.upa.impl.persistence.DefaultExecutionContext;
import net.vpc.upa.impl.persistence.DefaultPersistenceStoreFactory;
import net.vpc.upa.impl.persistence.DefaultPersistenceNameStrategy;
import net.vpc.upa.impl.security.DefaultSecurityManager;
import net.vpc.upa.impl.transaction.DefaultTransactionManager;
import net.vpc.upa.impl.transaction.DefaultTransactionManagerFactory;
import net.vpc.upa.impl.util.ClassMap;
import net.vpc.upa.persistence.*;

import java.util.NoSuchElementException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.bulk.SheetParser;
import net.vpc.upa.impl.bulk.DefaultImportEntityFinder;
import net.vpc.upa.impl.bulk.DefaultImportDataManager;
import net.vpc.upa.impl.bulk.DefaultImportExportManager;
import net.vpc.upa.impl.bulk.DefaultParseFormatManager;
import net.vpc.upa.impl.bulk.text.DefaultTextCSVFormatter;
import net.vpc.upa.impl.bulk.text.DefaultTextCSVParser;
import net.vpc.upa.impl.bulk.xml.DefaultXmlParser;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.transform.DefaultDataTypeTransformFactory;
import net.vpc.upa.impl.eval.DefaultQLEvaluator;
import net.vpc.upa.impl.uql.DefaultQLExpressionParser;
import net.vpc.upa.impl.util.DefaultBeanAdapterFactory;
import net.vpc.upa.types.DataTypeTransformFactory;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/11/12 9:21 PM
 */
public class RootObjectFactory implements ObjectFactory {

    final Logger log = Logger.getLogger(RootObjectFactory.class.getName());
    private ObjectFactory parentFactory;
    private ClassMap<Class> map = new ClassMap<Class>();
    private final HashMap<String, Object> singletons = new HashMap<String, Object>();

    public RootObjectFactory() {
        register(UPAContext.class, DefaultUPAContext.class);
        register(UPAContextProvider.class, DefaultUPAContextProvider.class);
        register(ObjectFactory.class, DefaultTypedFactory.class);
        register(PersistenceUnitProvider.class, DefaultPersistenceUnitProvider.class);
        register(PersistenceGroupProvider.class, DefaultPersistenceGroupProvider.class);
        register(PersistenceGroup.class, DefaultPersistenceGroup.class);
        register(PersistenceUnit.class, DefaultPersistenceUnit.class);
        register(I18NStringStrategy.class, DefaultI18NStringStrategy.class);
        register(Key.class, DefaultKey.class);
        register(Document.class, DefaultDocument.class);
        register(PersistenceStoreFactory.class, DefaultPersistenceStoreFactory.class);
        register(SessionContextProvider.class, DefaultSessionContextProvider.class);
//        register(PropertiesConnectionProfileManager.class,DefaultPropertiesConnectionProfileManager.class);
        register(EntityExecutionContext.class, DefaultExecutionContext.class);
        register(EntityShield.class, DefaultEntityShield.class);
        register(DefaultEntityExtensionManager.class, DefaultEntityExtensionManager.class);
        register(EntityOperationManager.class, DefaultEntityOperationManager.class);
        register(DataTypeTransformFactory.class, DefaultDataTypeTransformFactory.class);
        register(Index.class, DefaultIndex.class);
        register(Entity.class, DefaultEntity.class);
        register(Package.class, DefaultPackage.class);
        register(Relationship.class, DefaultRelationship.class);
        register(Section.class, DefaultSection.class);
        register(UPASecurityManager.class, DefaultSecurityManager.class);
        register(TransactionManagerFactory.class, DefaultTransactionManagerFactory.class);
        register(TransactionManager.class, DefaultTransactionManager.class);
        register(Session.class, DefaultSession.class);
//        register(Modifiers.class, DefaultModifiers.class);
        register(PersistenceNameStrategy.class, DefaultPersistenceNameStrategy.class);
        register(HierarchyExtension.class, HierarchicalRelationshipSupport.class);
        register(UnionEntityExtension.class, DefaultUnionEntityExtension.class);
        register(SingletonExtension.class, DefaultSingletonExtension.class);
        register(ViewEntityExtension.class, DefaultViewEntityExtension.class);
        register(FilterEntityExtension.class, DefaultFilterEntityExtension.class);
        register(QLExpressionParser.class, DefaultQLExpressionParser.class);
        register(BeanAdapterFactory.class, DefaultBeanAdapterFactory.class);
        register(QLEvaluator.class, DefaultQLEvaluator.class);
        register(Properties.class, DefaultProperties.class);

        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        {
            register(TextFixedWidthParser.class, DefaultTextFixedWidthParser.class);
            register(TextCSVParser.class, DefaultTextCSVParser.class);
            register(SheetParser.class, DefaultSheetParser.class);
            register(XmlParser.class, DefaultXmlParser.class);
            register(TextCSVFormatter.class, DefaultTextCSVFormatter.class);
            register(TextFixedWidthFormatter.class, DefaultTextFixedWidthFormatter.class);
            register(SheetFormatter.class, DefaultSheetFormatter.class);
            register(XmlFormatter.class, DefaultXmlFormatter.class);
            register(ImportDataManager.class, DefaultImportDataManager.class);
            register(ParseFormatManager.class, DefaultParseFormatManager.class);
            register(ImportExportManager.class, DefaultImportExportManager.class);
            register(ImportEntityFinder.class, DefaultImportEntityFinder.class);
            register(ImportEntityMapper.class, DefaultImportEntityFinder.class);
        }
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
        Class best = map.get(type);
        if (best == null || !type.isAssignableFrom(best)) {
            if (parentFactory != null) {
                return parentFactory.createObject(type, name);
            }
            if (PlatformUtils.isAbstract(type) || PlatformUtils.isInterface(type)) {
                throw new NoSuchElementException(type.getSimpleName());
            }
            best = type;
        }
        try {
            return (T) best.newInstance();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public <T> T createObject(String typeName, String name) {
        Class<T> c;
        try {
            c = PlatformUtils.forName(typeName);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(typeName);
        }
        return (T) createObject(c, name);
    }

    public int getContextSupportLevel() {
        return 0;
    }

    public <T> T createObject(Class<T> type) {
        return createObject(type, null);
    }

    public <T> T createObject(String typeName) {
        try {
            Class<T> c = (Class<T>) PlatformUtils.forName(typeName);
            return (T) createObject(c);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    @Override
    public <T> T getSingleton(Class<T> type) {
        String typeName = type.getName();
        if (singletons.containsKey(typeName)) {
            return (T) singletons.get(typeName);
        }
        synchronized (singletons) {
            if (singletons.containsKey(typeName)) {
                return (T) singletons.get(typeName);
            }
            T o = createObject(type);
            singletons.put(typeName, o);
            return o;
        }
    }

    @Override
    public <T> T getSingleton(String typeName) {
        if (singletons.containsKey(typeName)) {
            return (T) singletons.get(typeName);
        }
        synchronized (singletons) {
            if (singletons.containsKey(typeName)) {
                return (T) singletons.get(typeName);
            }
            T o = createObject(typeName);
            singletons.put(typeName, o);
            return o;
        }
    }
}
