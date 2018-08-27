package net.vpc.upa.impl.persistence;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Logger;

import net.vpc.upa.*;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.persistence.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.EntityExtensionDefinition;
import net.vpc.upa.UnionEntityExtensionDefinition;
import net.vpc.upa.ViewEntityExtensionDefinition;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.PersistenceNameFormat;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/17/12 3:15 PM
 */
public class DefaultPersistenceNameStrategy implements PersistenceNameStrategy {

    protected static Logger log = Logger.getLogger(DefaultPersistenceNameStrategy.class.getName());

    private String escapedNamePattern;
    private PersistenceStore persistenceStore;
    private Properties properties;
    private Map<String, String> namesFormatMap = new HashMap<String, String>();
    private PersistenceNameRuleSet persistenceNameRuleSet = new PersistenceNameRuleSet();
    private List<PersistenceNameFormat> nameFormats = new ArrayList<PersistenceNameFormat>(2);
    private String globalPersistenceNameFormat;
    private String localPersistenceNameFormat;

    private String persistenceNameEscape;
    private PersistenceNameTransformer persistenceNameTransformer;

    public void init(PersistenceStore persistenceStore, Properties properties) {
        this.persistenceStore = persistenceStore;
        this.properties = properties;
    }

    private void invalidateModelMap() {
        namesFormatMap = null;
    }

    private Map<String, String> getNamesFormatMap() {
        if (namesFormatMap == null) {
            namesFormatMap = new HashMap<>();
            namesFormatMap.put("GLOBAL_PERSISTENCE_NAME", getGlobalPersistenceNameFormat());
            namesFormatMap.put("LOCAL_PERSISTENCE_NAME", getLocalPersistenceNameFormat());
            namesFormatMap.put("PERSISTENCE_NAME_ESCAPE", getPersistenceNameEscape());
            if (getNameFormats() != null) {
                for (PersistenceNameFormat persistenceNameFormat : getNameFormats()) {
                    if (StringUtils.isNullOrEmpty(persistenceNameFormat.getObject())) {
                        namesFormatMap.put(persistenceNameFormat.getPersistenceNameType().name(), persistenceNameFormat.getValue());
                    } else {
                        namesFormatMap.put(persistenceNameFormat.getPersistenceNameType().name() + ":" + persistenceNameFormat.getObject(), persistenceNameFormat.getValue());
                    }
                }
            }
        }
        return namesFormatMap;
    }

    public void close() {
    }

    private String getBestName(String preferred, String actual) {
        if (!StringUtils.isNullOrEmpty(preferred)) {
            return preferred;
        }
        return actual;
    }

    public String getTablePKPersistencePreferredName(Entity entity, PersistenceNameStrategyCondition condition) {
        String tablePersistenceName = getTablePersistenceName0(entity, PersistenceNameType.TABLE, condition);
        TablePersistenceNameRule tableRule = persistenceNameRuleSet.getTableRule(entity.getName(), condition);
        String preferredPersistenceName = tableRule == null ? null : tableRule.getPkPersistenceName();
        if (preferredPersistenceName == null) {
            String prefix = tableRule == null ? null : tableRule.getShortPersistenceNamePrefix();
            if (prefix != null) {
                preferredPersistenceName = "PK_" + prefix;
            } else {
                preferredPersistenceName = "PK_" + tablePersistenceName;
            }
        }
        return preferredPersistenceName;
    }

    @Override
    public String getTablePKPersistenceName(Entity source, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        String tableName = getTablePersistenceName0(source, PersistenceNameType.TABLE, condition);
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(source, PersistenceNameType.PRIMARY_KEY_CONSTRAINT);
        String p = getBestName(getTablePKPersistencePreferredName(source, condition), "PK_" + tableName);
        types.add(PersistenceNameType.PRIMARY_KEY_CONSTRAINT);
        return validatePersistenceName(p, PersistenceNameType.PRIMARY_KEY_CONSTRAINT, source.getName(), upaObjectAndSpec, types);
    }

    @Override
    public String getImplicitViewPersistenceName(Entity entity, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        String tableName = getTablePersistenceName0(entity, spec, condition);
        TablePersistenceNameRule tableRule = persistenceNameRuleSet.getTableRule(entity.getName(), condition);
        String preferredPersistenceName = tableRule == null ? null : tableRule.getViewPersistenceName();
        if (preferredPersistenceName == null) {
            String prefix = tableRule == null ? null : tableRule.getShortPersistenceNamePrefix();
            if (prefix != null) {
                preferredPersistenceName = prefix + "_IV";
            } else {
                preferredPersistenceName = tableName + "_IV";
            }
        }

        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(entity, PersistenceNameType.IMPLICIT_VIEW);
        String p = getBestName(preferredPersistenceName, tableName + "_IV");
        types.add(PersistenceNameType.IMPLICIT_VIEW);
        types.add(PersistenceNameType.TABLE);
        return validatePersistenceName(p, PersistenceNameType.IMPLICIT_VIEW, entity.getName(), upaObjectAndSpec, types);
    }

    public String getTablePersistenceName0(Entity entity, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        TablePersistenceNameRule tableRule = persistenceNameRuleSet.getTableRule(entity.getName(), condition);
        String preferredPersistenceName = tableRule == null ? null : tableRule.getPersistenceName();
        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        if (entity.isView()) {
            types.add(PersistenceNameType.VIEW);
        }
        if (entity.isUnion()) {
            types.add(PersistenceNameType.UNION_TABLE);
        }
        types.add(PersistenceNameType.TABLE);
        return getBestName(preferredPersistenceName, entity.getName());
    }

    @Override
    public String getTablePersistenceName(Entity entity, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        TablePersistenceNameRule tableRule = persistenceNameRuleSet.getTableRule(entity.getName(), condition);
        String preferredPersistenceName = tableRule == null ? null : tableRule.getPersistenceName();
        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(entity, spec);
        if (entity.isView()) {
            types.add(PersistenceNameType.VIEW);
        }
        if (entity.isUnion()) {
            types.add(PersistenceNameType.UNION_TABLE);
        }
        types.add(PersistenceNameType.TABLE);
        return validatePersistenceName(getBestName(preferredPersistenceName, entity.getName()), PersistenceNameType.TABLE, entity.getName(), upaObjectAndSpec, types);
    }

    @Override
    public String getIndexPersistenceName(Index index, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        IndexPersistenceNameRule tableRule = persistenceNameRuleSet.getIndexRule(index.getEntity().getName(), index.getName(), condition);
        String preferredPersistenceName = null;
        if (tableRule != null) {
            preferredPersistenceName = tableRule.getPersistenceName();
        }
        String tableName = getTablePersistenceName(index.getEntity(), PersistenceNameType.TABLE, condition);

        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(index, spec);
        String p = preferredPersistenceName;
        if (p == null) {
            p = index.getName();
        }
        if (StringUtils.isNullOrEmpty(p)) {
            StringBuilder sb = new StringBuilder("IX_").append(tableName);
            for (String field : index.getFieldNames()) {
                sb.append("_").append(field);
            }
            p = sb.toString();
        }
        types.add(PersistenceNameType.INDEX);
        return validatePersistenceName(p, PersistenceNameType.INDEX, index.getName(), upaObjectAndSpec, types);
    }

    @Override
    public String getRelationshipPersistenceName(Relationship relationship, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        RelationshipPersistenceNameRule tableRule = persistenceNameRuleSet.getRelationshipRule(relationship.getName(), condition);
        String preferredPersistenceName = null;
        if (tableRule != null) {
            preferredPersistenceName = tableRule.getPersistenceName();
        }

        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(relationship, spec);

        String p = preferredPersistenceName;
        if (p == null) {
            p = relationship.getName();
        }
        types.add(PersistenceNameType.FOREIGN_KEY_CONSTRAINT);
        return validatePersistenceName(p, PersistenceNameType.FOREIGN_KEY_CONSTRAINT, relationship.getName(), upaObjectAndSpec, types);
    }

    @Override
    public String getIdentifierPersistenceName(String identifier, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(identifier, spec);
        if (PersistenceNameType.ALIAS.equals(spec)) {
            return validatePersistenceName(identifier, PersistenceNameType.ALIAS, "aliasName", upaObjectAndSpec, types);
        } else {
            return validatePersistenceName(identifier, PersistenceNameType.ALIAS, null, upaObjectAndSpec, types);
        }
    }

    @Override
    public String getFieldPersistenceName(Field field, PersistenceNameType spec, PersistenceNameStrategyCondition condition) throws UPAException {
        ColumnPersistenceNameRule tableRule = persistenceNameRuleSet.getColumnRule(field.getEntity().getName(), field.getName(), condition);
        String preferredPersistenceName = null;
        if (tableRule != null) {
            preferredPersistenceName = tableRule.getPersistenceName();
        }

        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(field, spec);
        Field v = (Field) field;
        String p = preferredPersistenceName;
        if (p == null) {
            p = v.getName();
        }
        types.add(PersistenceNameType.COLUMN);
        return validatePersistenceName(p, PersistenceNameType.COLUMN, v.getEntity().getName() + "." + v.getName(), upaObjectAndSpec, types);
    }

    public void setProperties(Properties properties) {
        this.properties = properties;
    }

    private String getParamValue(String confPrefix, PersistenceNameType type, String name, Properties parameters) {
        String v = getParamValue(confPrefix, type.name() + ":" + name, parameters);
        if (v == null) {
            v = getParamValue(confPrefix, type.name(), parameters);
        }
        return v;
    }

    private String getParamValue(String confPrefix, String name, Properties parameters) {
        String v = getNamesFormatMap().get(name);
        if (StringUtils.isNullOrEmpty(v)) {
            v = parameters.getString(confPrefix + name);
        }
        if (!StringUtils.isNullOrEmpty(v)) {
            return v;
        }
        return null;
    }

    protected String validatePersistenceName(String persistenceName, PersistenceNameType defaultType, String absoluteName, UPAObjectAndSpec e, List<PersistenceNameType> types) throws UPAException {
//        String varName = "*";
        String confPrefix = "";//UPA.CONNECTION_STRING+".";
        String persistenceNamePattern = null;
        Properties parameters = getProperties();
        if (absoluteName != null) {
            persistenceNamePattern = getParamValue(confPrefix, defaultType, absoluteName, parameters);
        }
        if (persistenceNamePattern == null) {
            for (PersistenceNameType t : types) {
                persistenceNamePattern = getParamValue(confPrefix, t, absoluteName, parameters);
                if (persistenceNamePattern != null) {
                    break;
                }
            }
        }
        boolean noPatternDefined = true;
        if (persistenceNamePattern == null) {
            persistenceNamePattern = getParamValue(confPrefix, "PERSISTENCE_NAME", parameters);
        }
        if (persistenceNamePattern != null) {
            persistenceNamePattern = persistenceNamePattern.trim();
            if (persistenceNamePattern.length() > 0) {
                noPatternDefined = false;
                persistenceName = replacePersistenceName(persistenceNamePattern, persistenceName);
            }
        }
        if (isGlobal(defaultType)) {
            persistenceNamePattern = getParamValue(confPrefix, "GLOBAL_PERSISTENCE_NAME", parameters);
        } else {
            persistenceNamePattern = getParamValue(confPrefix, "LOCAL_PERSISTENCE_NAME", parameters);
        }

        if (persistenceNamePattern != null) {
            persistenceNamePattern = persistenceNamePattern.trim();
            if (persistenceNamePattern.length() > 0) {
                noPatternDefined = false;
                persistenceName = replacePersistenceName(persistenceNamePattern, persistenceName);
            }
        }
        if (noPatternDefined) {
            //use default pattern...
            persistenceName = replacePersistenceName("*", persistenceName);
        }

        persistenceName = convertName(persistenceName, e);

        if (getPersistenceStore().isReservedKeyword(persistenceName)) {
            if (escapedNamePattern == null) {
                escapedNamePattern = getParamValue(confPrefix, "PERSISTENCE_NAME_ESCAPE", parameters);
                if (escapedNamePattern == null) {
                    escapedNamePattern = "";
                }
                escapedNamePattern = escapedNamePattern.trim();
                if (escapedNamePattern.length() > 0) {
                    if (!escapedNamePattern.contains("*")) {
                        escapedNamePattern = escapedNamePattern + "*";
                    }
                }
            }
            if (escapedNamePattern.length() > 0) {
                persistenceName = replacePersistenceName(escapedNamePattern, persistenceName);
            }
        }
        return persistenceName;
    }

    protected String convertName(String persistenceName, UPAObjectAndSpec e) {
        PersistenceNameTransformer o = getPersistenceNameTransformer();
        if (o == null) {
            return persistenceName;
        }
        return o.transformName(persistenceName, e.getObject(), e.getSpec());
    }

    protected static String replacePersistenceName(String pattern, String objectName) {
        int i = pattern.indexOf('*');
        if (i >= 0) {
            pattern = pattern.replace("*", "{OBJECT_NAME}");
        }
        i = pattern.indexOf('{');
        if (i >= 0) {
            int j = pattern.indexOf('}', i + 1);
            if (j > 0) {
                String t = pattern.substring(i + 1, j);
                if ("".equals(t)) {
                    return pattern.replace("{}", objectName);
                } else if ("OBJECTNAME".equals(t)) {
                    return pattern.replace("{OBJECTNAME}", objectName.toUpperCase());
                } else if ("objectname".equals(t)) {
                    return pattern.replace("{objectname}", objectName.toLowerCase());
                } else if ("objectName".equals(t)) {
                    StringBuilder s = new StringBuilder();
                    boolean wasSpace = false;
                    char[] chars = objectName.toCharArray();
                    boolean someLow = false;
                    boolean someUp = false;
                    for (char c : chars) {
                        if (Character.isLetter(c)) {
                            if (Character.isLowerCase(c)) {
                                someLow = true;
                            }
                            if (Character.isUpperCase(c)) {
                                someUp = true;
                            }
                        }
                    }
                    if (someLow && someUp) {
                        for (char c : chars) {
                            if (s.length() == 0) {
                                //first
                                s.append(Character.toLowerCase(c));
                            } else {
                                s.append(c);
                            }
                        }
                    } else {
                        for (char c : chars) {
                            if (s.length() == 0) {
                                //first
                                s.append(Character.toLowerCase(c));
                            } else if (wasSpace) {
                                if (c == '_') {
                                    wasSpace = true;
                                    s.append('_');
                                } else {
                                    wasSpace = false;
                                    s.append(Character.toUpperCase(c));
                                }
                            } else {
                                s.append(Character.toLowerCase(c));
                            }
                        }
                    }
                    return pattern.replace("{objectName}", s.toString());
                } else if ("ObjectName".equals(t)) {
                    StringBuilder s = new StringBuilder();
                    boolean wasSpace = false;
                    char[] chars = objectName.toCharArray();
                    boolean someLow = false;
                    boolean someUp = false;
                    for (char c : chars) {
                        if (Character.isLetter(c)) {
                            if (Character.isLowerCase(c)) {
                                someLow = true;
                            }
                            if (Character.isUpperCase(c)) {
                                someUp = true;
                            }
                        }
                    }
                    if (someLow && someUp) {
                        for (char c : chars) {
                            if (s.length() == 0) {
                                //first
                                s.append(Character.toUpperCase(c));
                            } else {
                                s.append(c);
                            }
                        }
                    } else {
                        for (char c : chars) {
                            if (s.length() == 0) {
                                //first
                                s.append(Character.toUpperCase(c));
                            } else if (wasSpace) {
                                if (c == '_') {
                                    wasSpace = true;
                                    s.append('_');
                                } else {
                                    wasSpace = false;
                                    s.append(Character.toUpperCase(c));
                                }
                            } else {
                                s.append(Character.toLowerCase(c));
                            }
                        }
                    }
                    return pattern.replace("{ObjectName}", s.toString());
                } else if ("object_name".equals(t)) {
                    StringBuilder s = new StringBuilder();
                    char[] chars = objectName.toCharArray();
                    boolean someLow = false;
                    boolean someUp = false;
                    for (char c : chars) {
                        if (Character.isLetter(c)) {
                            if (Character.isLowerCase(c)) {
                                someLow = true;
                            }
                            if (Character.isUpperCase(c)) {
                                someUp = true;
                            }
                        }
                    }
                    if (!someLow || !someUp) {
                        for (char c : chars) {
                            s.append(Character.toLowerCase(c));
                        }
                    } else {
                        boolean wasUpper = false;
                        for (char c : chars) {
                            if (s.length() == 0) {
                                //first
                                s.append(Character.toLowerCase(c));
                            } else if (!wasUpper && Character.isUpperCase(c)) {
                                s.append('_');
                                s.append(Character.toLowerCase(c));
                            } else {
                                s.append(Character.toLowerCase(c));
                            }
                            wasUpper = Character.isLetter(c) && Character.isUpperCase(c);
                        }
                    }
                    return pattern.replace("{object_name}", s.toString());
                } else if ("OBJECT_NAME".equals(t)) {
                    StringBuilder s = new StringBuilder();
                    char[] chars = objectName.toCharArray();
                    boolean someLow = false;
                    boolean someUp = false;
                    for (char c : chars) {
                        if (Character.isLetter(c)) {
                            if (Character.isLowerCase(c)) {
                                someLow = true;
                            }
                            if (Character.isUpperCase(c)) {
                                someUp = true;
                            }
                        }
                    }
                    if (!someLow || !someUp) {
                        for (char c : chars) {
                            s.append(Character.toUpperCase(c));
                        }
                    } else {
                        boolean wasLower = false;
                        for (char c : chars) {
                            if (s.length() == 0) {
                                //first
                                s.append(Character.toUpperCase(c));
                            } else if (wasLower && Character.isUpperCase(c)) {
                                s.append('_');
                                s.append(Character.toUpperCase(c));
                            } else {
                                s.append(Character.toUpperCase(c));
                            }
                            wasLower = Character.isLetter(c) && Character.isLowerCase(c);
                        }
                    }
                    return pattern.replace("{OBJECT_NAME}", s.toString());
                } else {
                    throw new IllegalUPAArgumentException("Unsupported format. User one of objectName,ObjectName,objectname,OBJECTNAME,object_name,OBJECT_NAME");
                }
            }
        } else {
            throw new IllegalUPAArgumentException("Unsupported format. User one of *,{},{objectName},{ObjectName},{objectname},{OBJECTNAME},{object_name},{OBJECT_NAME} patterns");
        }
        return objectName;
    }

    public PersistenceStore getPersistenceStore() {
        return persistenceStore;
    }

    public void setPersistenceStore(PersistenceStore persistenceStore) {
        this.persistenceStore = persistenceStore;
    }

    public Properties getProperties() {
        return properties;
    }

    public boolean isGlobal(net.vpc.upa.config.PersistenceNameType type) {
        switch (type) {
            case COLUMN:
            case ALIAS: {
                return false;
            }
        }
        return true;
    }

    public PersistenceNameRule[] getPersistenceNameRules() {
        return persistenceNameRuleSet.getRules();
    }

    public void addPersistenceNameRule(PersistenceNameRule rule) {
        persistenceNameRuleSet.addRule(rule);
    }

    public void removePersistenceNameRule(PersistenceNameRule rule) {
        persistenceNameRuleSet.removeRule(rule);
    }

    public PersistenceNameRuleSet getPersistenceNameRuleSet() {
        return persistenceNameRuleSet;
    }

    @Override
    public String getGlobalPersistenceNameFormat() {
        return globalPersistenceNameFormat;
    }

    @Override
    public void setGlobalPersistenceNameFormat(String globalPersistenceNameFormat) {
        this.globalPersistenceNameFormat = globalPersistenceNameFormat;
        invalidateModelMap();
    }

    @Override
    public String getPersistenceNameEscape() {
        return persistenceNameEscape;
    }

    @Override
    public void setPersistenceNameEscape(String persistenceNameEscape) {
        this.persistenceNameEscape = persistenceNameEscape;
        invalidateModelMap();
    }

    @Override
    public void addNameFormat(PersistenceNameFormat nameFormat) {
        nameFormats.add(nameFormat);
        invalidateModelMap();
    }

    @Override
    public void removeNameFormat(PersistenceNameFormat nameFormat) {
        nameFormats.remove(nameFormat);
        invalidateModelMap();
    }

    @Override
    public PersistenceNameFormat[] getNameFormats() {
        return nameFormats.toArray(new PersistenceNameFormat[nameFormats.size()]);
    }

    @Override
    public String getLocalPersistenceNameFormat() {
        return localPersistenceNameFormat;
    }

    @Override
    public void setLocalPersistenceNameFormat(String localPersistenceNameFormat) {
        this.localPersistenceNameFormat = localPersistenceNameFormat;
    }

    @Override
    public PersistenceNameTransformer getPersistenceNameTransformer() {
        return persistenceNameTransformer;
    }

    @Override
    public void setPersistenceNameTransformer(PersistenceNameTransformer persistenceNameTransformer) {
        if (this.persistenceNameTransformer != null) {
            this.persistenceNameTransformer.close();
        }
        this.persistenceNameTransformer = persistenceNameTransformer;
        if (this.persistenceNameTransformer != null) {
            this.persistenceNameTransformer.start(persistenceStore);
        }
    }
}
