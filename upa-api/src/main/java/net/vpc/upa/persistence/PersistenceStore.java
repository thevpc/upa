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
    boolean isAccessible(ConnectionProfile connectionProfile);

    String getValidIdentifier(String s);

    void checkAccessible(ConnectionProfile connectionProfile);

    void init(PersistenceUnit persistenceUnit, boolean readOnly, ConnectionProfile connection, PersistenceNameConfig nameConfig) throws UPAException;

    Set<String> getSupportedDrivers();

    boolean isCreatedStorage() throws UPAException;

    FieldPersister createPersistSequenceGenerator(Field field) throws UPAException;

    FieldPersister createUpdateSequenceGenerator(Field field) throws UPAException;

    void createStorage(EntityExecutionContext context) throws UPAException;

    void dropStorage(EntityExecutionContext context) throws UPAException;

    Properties getProperties();

    ConnectionProfile getConnectionProfile() throws UPAException;

    void close() throws UPAException;

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
    Query createQuery(Entity e, EntityStatement query, EntityExecutionContext qlContext) throws UPAException;

    Query createQuery(EntityStatement query, EntityExecutionContext qlContext) throws UPAException;

    void createStructure(PersistenceUnit persistenceUnit, EntityExecutionContext executionContext) throws UPAException;

//    int executeNonQuery(NonQueryStatement query, EntityExecutionContext qlContext) throws UPAException;

    boolean isReservedKeyword(String name);

    void setNativeConstraintsEnabled(PersistenceUnit persistenceUnit, boolean enable) throws UPAException;

    boolean isComplexSelectSupported();

    boolean isFromClauseInUpdateStatementSupported();

    boolean isFromClauseInDeleteStatementSupported();

    boolean isReferencingSupported();

    boolean isViewSupported();

    boolean isTopSupported();

    PersistenceNameStrategy getPersistenceNameStrategy();

    void setPersistenceNameStrategy(PersistenceNameStrategy persistenceNameStrategy);

    String getPersistenceName(UPAObject persistentObject) throws UPAException;

    String getPersistenceName(UPAObject persistentObject, PersistenceNameType spec) throws UPAException;

    String getPersistenceName(String name, PersistenceNameType spec) throws UPAException;

    PersistenceState getPersistenceState(UPAObject object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext) throws UPAException;

    boolean isView(Entity entity);

    void alterPersistenceUnitAddObject(UPAObject object) throws UPAException;

    void alterPersistenceUnitRemoveObject(UPAObject object) throws UPAException;

    void alterPersistenceUnitUpdateObject(UPAObject oldObject, UPAObject newObject, Set<String> updates) throws UPAException;

    boolean commitStorage() throws UPAException;

    void revalidateModel() throws UPAException;

    /**
     * create connection
     *
     * @return
     * @throws UPAException
     */
    UConnection createConnection() throws UPAException;

    void setIdentityConstraintsEnabled(Entity entity, boolean enable, EntityExecutionContext context);
}
