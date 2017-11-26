package net.vpc.upa;

import java.util.Map;

public class UPAObjectInfo {
    private Map<String, Object> simpleProperties;
    private String name;
    private String type;
    private String title;

    public UPAObjectInfo(String type) {
        this.type = type;
    }

    public Map<String, Object> getSimpleProperties() {
        return simpleProperties;
    }

    public void setSimpleProperties(Map<String, Object> simpleProperties) {
        this.simpleProperties = simpleProperties;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setType(String type) {
        //
    }

    public String getType() {
        return type;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

}
