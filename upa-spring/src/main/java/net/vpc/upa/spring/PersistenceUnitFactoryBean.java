package net.vpc.upa.spring;

import net.vpc.upa.*;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.UPAContextConfig;
import org.springframework.beans.factory.DisposableBean;
import org.springframework.beans.factory.FactoryBean;
import org.springframework.beans.factory.InitializingBean;

public class PersistenceUnitFactoryBean implements FactoryBean<PersistenceUnit> , InitializingBean, DisposableBean{
    private PersistenceUnitProvider persistenceUnitProvider;
    private PersistenceGroupProvider persistenceGroupProvider;
    private UPAContextConfig config;

    public PersistenceUnitProvider getPersistenceUnitProvider() {
        return persistenceUnitProvider;
    }

    public void setPersistenceUnitProvider(PersistenceUnitProvider persistenceUnitProvider) {
        this.persistenceUnitProvider = persistenceUnitProvider;
    }

    public PersistenceGroupProvider getPersistenceGroupProvider() {
        return persistenceGroupProvider;
    }

    public void setPersistenceGroupProvider(PersistenceGroupProvider persistenceGroupProvider) {
        this.persistenceGroupProvider = persistenceGroupProvider;
    }

    @Override
    public PersistenceUnit getObject() {
        return UPA.getPersistenceGroup().getPersistenceUnit();
    }

    @Override
    public Class<?> getObjectType() {
        return PersistenceUnit.class;
    }

    @Override
    public boolean isSingleton() {
        return false;
    }

    @Override
    public void afterPropertiesSet() throws Exception {
        if(persistenceGroupProvider!=null) {
            UPA.getBootstrapFactory().register(PersistenceGroupProvider.class, persistenceGroupProvider);
        }
        if(persistenceUnitProvider!=null) {
            UPA.getBootstrapFactory().register(PersistenceUnitProvider.class, persistenceUnitProvider);
        }
        UPA.configure(config);
    }

    @Override
    public void destroy() throws Exception {
        UPA.getContext().close();
    }

    public UPAContextConfig getConfig() {
        return config;
    }

    public void setConfig(UPAContextConfig config) {
        this.config = config;
    }
}
