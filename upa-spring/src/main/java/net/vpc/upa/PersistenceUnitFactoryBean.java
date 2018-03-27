package net.vpc.upa;

import net.vpc.upa.persistence.ConnectionConfig;
import org.springframework.beans.factory.DisposableBean;
import org.springframework.beans.factory.FactoryBean;
import org.springframework.beans.factory.InitializingBean;

public class PersistenceUnitFactoryBean implements FactoryBean<PersistenceUnit> , InitializingBean, DisposableBean{
    private String persistenceGroupName;
    private String persistenceUnitName;
    private ConnectionConfig connectionConfig;
    private PersistenceUnitProvider persistenceUnitProvider;
    private PersistenceGroupProvider persistenceGroupProvider;

    public String getPersistenceUnitName() {
        return persistenceUnitName;
    }

    public void setPersistenceUnitName(String persistenceUnitName) {
        this.persistenceUnitName = persistenceUnitName;
    }

    public ConnectionConfig getConnectionConfig() {
        return connectionConfig;
    }

    public void setConnectionConfig(ConnectionConfig connectionConfig) {
        this.connectionConfig = connectionConfig;
    }

    public String getPersistenceGroupName() {
        return persistenceGroupName;
    }

    public void setPersistenceGroupName(String persistenceGroupName) {
        this.persistenceGroupName = persistenceGroupName;
    }

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
        return UPA.getPersistenceGroup(getPersistenceGroupName()).getPersistenceUnit(getPersistenceUnitName());
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
        PersistenceUnit pu=null;
        PersistenceGroup pg =null;
        if(!UPA.getContext().containsPersistenceGroup(getPersistenceGroupName())){
            pg = UPA.getContext().addPersistenceGroup(getPersistenceGroupName());
        }else{
            pg = UPA.getContext().getPersistenceGroup(getPersistenceGroupName());
        }

        if(pg.containsPersistenceUnit(getPersistenceUnitName())) {
            pu = pg.getPersistenceUnit(getPersistenceUnitName());
        }else{
            pu = pg.addPersistenceUnit(getPersistenceUnitName());
            pu.addConnectionConfig(getConnectionConfig());
            pu.start();
        }
    }

    @Override
    public void destroy() throws Exception {
        UPA.getContext().close();
    }
}
