/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.persistence;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/22/12 6:48 PM
 */
public final class ConnectionOption {
    public static final String DATABASE_PRODUCT = "databaseProduct";
    public static final String CONNECTION_DRIVER = "connectionDriver";
    public static final String DATABASE_PRODUCT_VERSION = "databaseProductVersion";
    public static final String CONNECTION_DRIVER_VERSION = "connectionDriverVersion";
    public static final String URL = "url";
    public static final String DRIVER = "driver";
    public static final String PASSWORD = "password";
    public static final String USER_NAME = "userName";
    public static final String TRUSTED = "trusted";

    public static final String DATABASE_NAME = "databaseName";
    public static final String DATABASE_PATH = "databasePath";
    public static final String SERVER_ADDRESS = "serverAddress";
    public static final String SERVER_PORT = "port";
    public static final String PROFILE_NAME = "profileName";
    public static final String DATASOURCE = "datasource";
    public static final String STRUCTURE = "structure";

    private ConnectionOption() {
    }
}
