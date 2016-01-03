package net.vpc.upa.impl;

import net.vpc.upa.PrimitiveField;

public class DefaultPrimitiveField extends AbstractField implements PrimitiveField {

    public static final DefaultPrimitiveField[] EMPTY_ARRAY = new DefaultPrimitiveField[0];

    public DefaultPrimitiveField() {
        super();
    }

    public static String getFieldAlias(String name) {
        int index;
        if ((index = name.indexOf('.')) < 0) {
            return null;
        } else {
            return name.substring(0, index);
        }
    }

//    public DefaultPrimitiveField(Entity entity, String name, String title) {
//        this(entity, name, title, null, false);
//    }

//    public DefaultPrimitiveField(Entity entity, String name, String title, Formula formula, boolean isAbsolute) {
//        this.isAbsolute = false;
//        this.entity = null;
//        this.name = null;
////        index = 0;
//        modifiers = 0;
//        title = null;
//        defaultValue = null;
//        relation = null;
//        dataType = null;
//        this.entity = entity;
//        if (entity != null) {
//            entityName = entity.getName();
//        }
//        this.name = name;
//        this.isAbsolute = isAbsolute;
//        this.formula = formula;
//        modifiers = 0;
//
//        String rsrcRootKey = null;
//        String rsrcRootKeyGen = null;
//        if (entity != null) {
//            rsrcRootKey = entity.getPersistenceUnit().getI18NStringStrategy().getFieldString(this);
//        } else {
//            rsrcRootKey = entity.getPersistenceUnit().getI18NStringStrategy().getFieldString(null, this);
//        }
//        rsrcRootKeyGen = entity.getPersistenceUnit().getI18NStringStrategy().getFieldString(null, this);
//        String rsrcDescKey = rsrcRootKey + ".desc";
//        String rsrcDescKeyGen = rsrcRootKeyGen + ".desc";
//        if (title == null) {
//            this.title = entity == null ? null : (entity.getResources().get(
//                    new String[]{
//                        rsrcRootKey,
//                        rsrcRootKeyGen
//                    }));
//        } else {
//            this.title = (title);
//        }
//        this.description = entity == null ? null : (entity.getResources().get(
//                new String[]{
//                    rsrcDescKey, rsrcDescKeyGen}, false));
//
//        if (name == null) {
//            throw new IllegalArgumentException("Null Table.Field");
//        } else {
//            hash = toString().hashCode();
//        }
//    }


//    private static Table getEntity(String name) {
//        PersistenceUnitFilter db = PersistenceUnitFilter.getPersistenceUnit();
//        if (db == null)
//            return null;
//        else
//            return db.getEntity(name, false);
//    }
//    public boolean isAbsolute() {
//        return isAbsolute;
//    }

//    public PrimitiveField getAbsolute(String[] tableNames) {
//        if (isAbsolute()) {
//            return this;
//        }
//        if (entity == null) {
//            //TODO
////            if (tableNames == PersistenceUnitFilter.ALL_TABLES) {
////                Table[] tables = PersistenceUnitFilter.getPersistenceUnit().getTables();
////                for (int i = 0; i < tables.length; i++) {
////                    Field f = tables[i].getField(name);
////                    if (f != null)
////                        return f;
////                }
////
////            } else {
////                for (int i = 0; i < tableNames.length; i++) {
////                    Field f = PersistenceUnitFilter.getPersistenceUnit().getEntity(tableNames[i]).getField(name);
////                    if (f != null)
////                        return f;
////                }
////
////            }
//            return null;
//        } else {
//            return entity.getPrimitiveField(name);
//        }
//    }

//    public DefaultPrimitiveField getAbsolute() {
//        if (isAbsolute) {
//            return this;
//        }
//        if (entity == null) {
//            return null;
//        } else {
//            return entity.getPrimitiveField(name);
//        }
//    }
//
//
//
//    public String toString(String tableAlias) {
//        return tableAlias != null ? (tableAlias + "." + name) : name;
//    }

//    public String getAbsoluteName() {
//        return toString();
//    }

//    public long getModifiers() {
////        Field f = getAbsolute();
////        return f != null ? f.modifiers : modifiers;
//        return modifiers;
//    }





    //    public boolean isTopForeignField() {
//        Relationship r = getRelations();
//        if (r == null)
//            return false;
//        else
//            return equals(r.getDetailField(0));
//    }
//
//    public boolean isTopPrimaryField() {
//            return equals(entity.getPrimaryFields()[0]);
//    }


//    public String toString() {
//        return getEntity().getName() + '.' + getName();
//    }


//    public Param toParam(int index) {
//        return new Param(index, dataType);
//    }
//
//    public Var toVar() {
//        return toVar(null, null);
//    }
//
//    public Var toVar(String tableVarName, HashMap context) {
//        return new Var(toSQL(tableVarName, context), dataType);
//    }
//
//    public String toSQL(String tableVarName, HashMap context) {
//        return isQueryField()
//                ? (getEntity().getPersistenceUnit().getPersistenceManager().getProperties().get("isComplexSelectSupported", false)
//                ? getAlias(tableVarName, context)
//                : "0")
//                : (tableVarName != null
//                ? tableVarName + '.' + name
//                : name);
//    }

//    public String getAlias(String tableVarName, HashMap context) {
//        String s = formula.getExpression().toSQL(getPersistenceUnit());
//        String t = tableVarName != null ? tableVarName : getEntity().getPersistenceName();
//        return DBUtils.simplifyExpression(s, t);
//    }

//    public int getPass() {
//        return formula.getPass();
//    }
//
//

//    public static String[] toStringArray(DefaultPrimitiveField[] fields, boolean absolute) {
//        String[] s = new String[fields.length];
//        if (absolute) {
//            for (int i = 0; i < s.length; i++) {
//                s[i] = fields[i].getAbsoluteName();
//            }
//
//        } else {
//            for (int i = 0; i < s.length; i++) {
//                s[i] = fields[i].getName();
//            }
//
//        }
//        return s;
//    }

//    public int hashCode() {
//        return hash;
//    }


//    public TypeMarshaller getDataWrapper() {
//        return getEntity().getPersistenceUnit().getPersistenceManager().getTypeMarshaller(dataType);
//    }
//


}
