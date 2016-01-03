package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.DBConfigModel;

/**
 * Created by IntelliJ IDEA. User: root Date: 9 mai 2003 Time: 11:38:44 To
 * change this template use Options | File Templates.
 */
public class DefaultDBConfigModel implements DBConfigModel {

    private String[] adapters;
    private String adapter;

    public DefaultDBConfigModel() {
    }

    public String[] getConnectionStringArray() {
        return adapters;
//        return Configuration.getConfiguration().getStringArray("used_adapters", new String[]{getAdapterString()});
    }

    public void setConnectionStringArray(String[] adapters) {
        this.adapters = adapters;
//        Configuration.getConfiguration().setStringArray("used_adapters", adapters, '\n');
    }

    public String getConnectionString() {
        return adapter;
//        return AppInfos.getInstance().getString(SimpleDBAppInfos.REG_PERSISTENCE_MANAGER, null);
    }

    public void setConnectionString(String adapter) {
//        AppInfos.getInstance().setString(SimpleDBAppInfos.REG_PERSISTENCE_MANAGER, adapter);
        this.adapter = adapter;
    }
}
