/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.persistence;

import net.vpc.upa.*;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.EntityStatement;

import java.util.Set;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 1:24 AM To change
 * this template use File | Settings | File Templates.
 */
public interface PersistenceStore {

    //    static final String CURRENT_ENTITY_ALIAS = "this";
//    static String DB_CON_LOG = "DB_CONNECT";
//    static String DB_QUERY_LOG = "DB_QUERY";
//    static String DB_UPDATE_LOG = "DB_UPDATE";
//    static String DB_EXEC_LOG = "DB_EXEC";
//    static String DB_ERROR_LOG = "DB_ERROR";
//    //    static final String DB_NATIVE_LOG = "DB_NATIVE";
//    static String DB_PRE_NATIVE_UPDATE_LOG = "DB_PRE_NATIVE_UPDATE_LOG";
//    static String DB_PRE_NATIVE_QUERY_LOG = "DB_PRE_NATIVE_QUERY_LOG";
//    static String DB_NATIVE_QUERY_LOG = "DB_NATIVE_QUERY";
//    static String DB_NATIVE_UPDATE_LOG = "DB_NATIVE_UPDATE";
    void setProperties(Properties parameters);

    boolean isAccessible(ConnectionProfile connectionProfile);

    String getValidIdentifier(String s);

    void checkAccessible(ConnectionProfile connectionProfile);

    Set<String> getSupportedDrivers();

    boolean isCreatedStorage() ;

    FieldPersister createPersistSequenceGenerator(Field field) ;

    FieldPersister createUpdateSequenceGenerator(Field field) ;

    void createStorage(EntityExecutionContext context) ;

    void dropStorage(EntityExecutionContext context) ;

    Properties getProperties();

    Properties getStoreParameters();

    ConnectionProfile getConnectionProfile() ;

    void close() ;

    void setReadOnly(boolean value);

    boolean isReadOnly();

    //    String getSqlTypeName(DataType datatype);
//    TypeMarshaller getTypeMarshaller(Class someClass);
//
//    TypeMarshaller getTypeMarshaller(DataType p);
//
//    TypeMarshallerFactory getTypeMarshallerFactory(Class someClass);
//
//    String formatSqlValue(Object value);
    Query createQuery(Entity e, EntityStatement query, EntityExecutionContext qlContext) ;

    Query createQuery(EntityStatement query, EntityExecutionContext qlContext) ;

    void createStructure(EntityExecutionContext executionContext) ;

//    int executeNonQuery(NonQueryStatement query, EntityExecutionContext qlContext) ;

    boolean isReservedKeyword(String name);

    void setNativeConstraintsEnabled(boolean enable) ;

    boolean isComplexSelectSupported();

    boolean isFromClauseInUpdateStatementSupported();

    boolean isFromClauseInDeleteStatementSupported();

    boolean isReferencingSupported();

    boolean isViewSupported();

    boolean isTopSupported();

    String getPersistenceName(UPAObject persistentObject) ;

    String getPersistenceName(UPAObject persistentObject, PersistenceNameType spec) ;

    String getPersistenceName(String name, PersistenceNameType spec) ;

    PersistenceState getPersistenceState(UPAObject object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext) ;

    boolean isView(Entity entity);

    void alterPersistenceUnitAddObject(UPAObject object) ;

    void alterPersistenceUnitRemoveObject(UPAObject object) ;

    void alterPersistenceUnitUpdateObject(UPAObject oldObject, UPAObject newObject, Set<String> updates) ;

    boolean commitStorage() ;

    void revalidateModel() ;

    /**
     * create connection
     *
     * @return
     * @
     */
    UConnection createConnection() ;

    void setIdentityConstraintsEnabled(Entity entity, boolean enable, EntityExecutionContext context);
}
