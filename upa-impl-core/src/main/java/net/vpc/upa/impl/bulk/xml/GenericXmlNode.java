package net.vpc.upa.impl.bulk.xml;

import java.util.LinkedHashMap;
import java.util.List;
import net.vpc.upa.PortabilityHint;

/**
* Created by vpc on 1/4/14.
*/
@PortabilityHint(target = "C#",name = "suppress")
public class GenericXmlNode {

    String name;
    LinkedHashMap<String, String> properties;
    List<String> content;
    Object userObject;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public LinkedHashMap<String, String> getProperties() {
        return properties;
    }

    public void setProperties(LinkedHashMap<String, String> properties) {
        this.properties = properties;
    }

    public List<String> getContent() {
        return content;
    }

    public void setContent(List<String> content) {
        this.content = content;
    }

    public Object getUserObject() {
        return userObject;
    }

    public void setUserObject(Object userObject) {
        this.userObject = userObject;
    }

    @Override
    public String toString() {
        return "GenericXmlNode{" + "name=" + name + ", properties=" + properties + ", content=" + content + '}';
    }
}
