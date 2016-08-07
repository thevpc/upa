package net.vpc.upa.impl.persistence;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Logger;
import net.vpc.upa.*;
import net.vpc.upa.persistence.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.extensions.UnionEntityExtensionDefinition;
import net.vpc.upa.extensions.ViewEntityExtensionDefinition;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.persistence.PersistenceName;
import net.vpc.upa.persistence.PersistenceNameStrategy;
import net.vpc.upa.persistence.PersistenceNameConfig;
import net.vpc.upa.persistence.PersistenceStore;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/17/12 3:15 PM
 */
public class DefaultPersistenceNameStrategy implements PersistenceNameStrategy {

    protected static Logger log = Logger.getLogger(DefaultPersistenceNameStrategy.class.getName());

    private String escapedNamePattern;
    private PersistenceStore persistenceStore;
    private PersistenceUnit persistenceUnit;
    private PersistenceNameConfig model;
    private Map<String, String> modelMap = new HashMap<String, String>();
//    private Map<String, String> modelMapPatterns = new HashMap<String, String>();

    public void init(PersistenceStore persistenceStore, PersistenceNameConfig model) {
        this.model = model;
        this.persistenceStore = persistenceStore;
//        modelMapPatterns.put("GLOBAL_PERSISTENCE_NAME", "{OBJECT_NAME}");
//        modelMapPatterns.put("LOCAL_PERSISTENCE_NAME", "{OBJECT_NAME}");
//        modelMapPatterns.put("PERSISTENCE_NAME_ESCAPE", null);
//        modelMapPatterns.put(PersistenceNameType.FK_CONSTRAINT.name(), "");

        if (model != null) {
            modelMap.put("GLOBAL_PERSISTENCE_NAME", model.getGlobalPersistenceName());
            modelMap.put("LOCAL_PERSISTENCE_NAME", model.getLocalPersistenceName());
            modelMap.put("PERSISTENCE_NAME_ESCAPE", model.getPersistenceNameEscape());
            if (model.getNames() != null) {
                for (PersistenceName persistenceName : model.getNames()) {
                    if (StringUtils.isNullOrEmpty(persistenceName.getObject())) {
                        modelMap.put(persistenceName.getPersistenceNameType().name(), persistenceName.getValue());
                    } else {
                        modelMap.put(persistenceName.getPersistenceNameType().name() + ":" + persistenceName.getObject(), persistenceName.getValue());
                    }
                }
            }
        }
    }

    public void close() {
    }

    public String getPersistenceName(Object source, PersistenceNameType spec) throws UPAException {
        List<PersistenceNameType> types = new ArrayList<PersistenceNameType>();
        UPAObjectAndSpec upaObjectAndSpec = new UPAObjectAndSpec(source, spec);
        if (source instanceof Entity) {
            Entity v = (Entity) source;
            if (spec == null) {
                String p = v.getPersistenceName();
                if (p == null) {
                    p = v.getName();
                }
                for (EntityExtensionDefinition extension : v.getExtensionDefinitions()) {
                    if (extension instanceof ViewEntityExtensionDefinition) {
                        types.add(PersistenceNameType.VIEW);
                    }
                    if (extension instanceof UnionEntityExtensionDefinition) {
                        types.add(PersistenceNameType.UNION_TABLE);
                    }
                }
                types.add(PersistenceNameType.TABLE);
                return validatePersistenceName(p, PersistenceNameType.TABLE, v.getName(), upaObjectAndSpec, types);
            }
            if (PersistenceNameType.PK_CONSTRAINT.equals(spec)) {
                String p = v.getShortName();
                if (p == null) {
                    p = v.getPersistenceName();
                }
                if (p == null) {
                    p = v.getName();
                }
                types.add(PersistenceNameType.PK_CONSTRAINT);
                return validatePersistenceName("PK_" + p, PersistenceNameType.PK_CONSTRAINT, v.getName(), upaObjectAndSpec, types);
            }
            if (PersistenceNameType.IMPLICIT_VIEW.equals(spec)) {
                String p = v.getPersistenceName();
                if (p == null) {
                    p = v.getName();
                }
                types.add(PersistenceNameType.IMPLICIT_VIEW);
                types.add(PersistenceNameType.TABLE);
                return validatePersistenceName(p + "_IV", PersistenceNameType.IMPLICIT_VIEW, v.getName(), upaObjectAndSpec, types);
            }
        }
        if (source instanceof Index) {
            Index v = (Index) source;
            String p = v.getPersistenceName();
            if (p == null) {
                p = v.getName();
            }
            if (p == null) {

                String sn = v.getEntity().getShortName();
                if (sn == null) {
                    sn = v.getEntity().getName();
                }
                StringBuilder sb = new StringBuilder("IX_").append(sn);
                for (String field : v.getFieldNames()) {
                    sb.append("_").append(field);
                }
                p = sb.toString();
            }
            types.add(PersistenceNameType.INDEX);
            return validatePersistenceName(p, PersistenceNameType.INDEX, v.getName(), upaObjectAndSpec, types);
        }
        if (source instanceof Relationship) {
            Relationship v = (Relationship) source;
            String p = v.getPersistenceName();
            if (p == null) {
                p = v.getName();
            }
            types.add(PersistenceNameType.FK_CONSTRAINT);
            return validatePersistenceName(p, PersistenceNameType.FK_CONSTRAINT, v.getName(), upaObjectAndSpec, types);
        }
        if (source instanceof PrimitiveField) {
            Field v = (Field) source;
            String p = v.getPersistenceName();
            if (p == null) {
                p = v.getName();
            }
            types.add(PersistenceNameType.COLUMN);
            return validatePersistenceName(p, PersistenceNameType.COLUMN, v.getEntity().getName() + "." + v.getName(), upaObjectAndSpec, types);
        }
        if (source instanceof String) {
            if (PersistenceNameType.ALIAS.equals(spec)) {
                return validatePersistenceName((String) source, PersistenceNameType.ALIAS, "aliasName", upaObjectAndSpec, types);
            } else {
                return validatePersistenceName((String) source, PersistenceNameType.ALIAS, null, upaObjectAndSpec, types);
            }
        }
        throw new IllegalArgumentException("No Supported");
    }

    private String getParamValue(String confPrefix, PersistenceNameType type, String name, Properties parameters) {
        String v = getParamValue(confPrefix, type.name() + ":" + name, parameters);
        if (v == null) {
            v = getParamValue(confPrefix, type.name(), parameters);
        }
        return v;
    }

    private String getParamValue(String confPrefix, String name, Properties parameters) {
        String v = modelMap.get(name);
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
        Properties parameters = getPersistenceUnit().getProperties();
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
        if (defaultType.isGlobal()) {
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
                    throw new IllegalArgumentException("Unsupported format. User one of objectName,ObjectName,objectname,OBJECTNAME,object_name,OBJECT_NAME");
                }
            }
        } else {
            throw new IllegalArgumentException("Unsupported format. User one of *,{},{objectName},{ObjectName},{objectname},{OBJECTNAME},{object_name},{OBJECT_NAME} patterns");
        }
        return objectName;
    }

    public PersistenceStore getPersistenceStore() {
        return persistenceStore;
    }

    public void setPersistenceStore(PersistenceStore persistenceStore) {
        this.persistenceStore = persistenceStore;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

}
