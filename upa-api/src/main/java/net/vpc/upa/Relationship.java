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
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.types.DataType;

import java.util.Map;
import net.vpc.upa.extensions.HierarchyExtension;

//Comparable,
public interface Relationship extends UPAObject {

    public void commitModelChanged() throws UPAException;

    public void setRelationshipType(RelationshipType dataType) throws UPAException;

    public void setDataType(DataType dataType) throws UPAException;

    public void setNullable(boolean nullable) throws UPAException;

    //    public void setSourceEntity(Entity sourceEntity);
//
//    public void setMasterEntity(Entity masterEntity);
//
//    public void setSourceFields(Field[] sourceFields);
    public RelationshipType getRelationshipType() throws UPAException;

    public int size() throws UPAException;

    public DataType getDataType() throws UPAException;

    //    public Entity getSourceEntity();
//
//    public Entity getTargetRole().getEntity();
//
    public Map<String, String> getSourceToTargetFieldNamesMap(boolean absolute) throws UPAException;

    public Map<String, String> getTargetToSourceFieldNamesMap(boolean absolute) throws UPAException;

    public Map<String, String> getSourceToTargetFieldsMap() throws UPAException;

    public Map<String, String> getTargetToSourceFieldsMap() throws UPAException;

    public Expression getTargetCondition(Expression sourceCondition, String sourceAlias, String targetAlias) throws UPAException;

    public Expression getSourceCondition(Expression targetCondition, String sourceAlias, String targetAlias) throws UPAException;

    public Expression getFilter() throws UPAException;

    public void setFilter(Expression filter) throws UPAException;

    public boolean isTransient() throws UPAException;

    public Entity getTargetEntity() throws UPAException;

    public Entity getSourceEntity() throws UPAException;

    public RelationshipRole getTargetRole() throws UPAException;

    public RelationshipRole getSourceRole() throws UPAException;

    public boolean isFollowLinks();

    public boolean isAskForConfirm();

    public Key getKey(Record sourceRecord);

    public HierarchyExtension getHierarchyExtension();

    public void setHierarchyExtension(HierarchyExtension extension);
}
