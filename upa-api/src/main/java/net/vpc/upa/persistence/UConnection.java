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

import net.vpc.upa.CloseListener;
import net.vpc.upa.expressions.QueryScript;
import net.vpc.upa.types.DataTypeTransform;

import java.util.List;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 2/3/13 7:17 PM
 */
public interface UConnection {

    QueryResult executeQuery(String query, DataTypeTransform[] types, List<Parameter> queryParameters, boolean updatable) ;

    int executeNonQuery(String currentQuery, List<Parameter> queryParameters, List<Parameter> generatedKeys) ;

    int executeScript(QueryScript script, boolean exitOnError) ;

    void close() ;

    void addCloseListener(CloseListener closeListener);

    void removeCloseListener(CloseListener closeListener);

    Object getMetadataAccessibleConnection() ;

    Object getPlatformConnection() ;

    Object getProperty(String name) ;

    Map<String, Object> getProperties() ;

    void setProperty(String name, Object value) ;

    void beginTransaction();

    void commitTransaction();

    void rollbackTransaction();
}
