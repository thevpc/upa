/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.util.List;
import net.vpc.upa.Package;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Index;
import net.vpc.upa.Relationship;
import net.vpc.upa.Section;
import net.vpc.upa.exceptions.UPAException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface ObjectRegistrationModel {

    public boolean containsPackage(Package item, Package parent) throws UPAException;

    public boolean containsEntity(Entity item, Package parent) throws UPAException;

    public boolean containsField(Field item) throws UPAException;

    public boolean containsIndex(Index item, Entity parent) throws UPAException;

    public boolean containsRelationship(Relationship item) throws UPAException;

    public boolean containsSection(Section item) throws UPAException;

    public void registerPackage(Package item, Package parent) throws UPAException;

    public void registerEntity(Entity item, Package parent) throws UPAException;

    public void registerSection(Section item) throws UPAException;

    public void registerField(Field item) throws UPAException;

    public void registerIndex(Index item, Entity parent) throws UPAException;

    public void registerRelationship(Relationship item) throws UPAException;

    public void unregisterPackage(Package item) throws UPAException;

    public void unregisterEntity(Entity item) throws UPAException;

    public void unregisterSection(Section item) throws UPAException;

    public void unregisterField(Field item) throws UPAException;

    public void unregisterIndex(Index item) throws UPAException;

    public void unregisterRelation(Relationship item) throws UPAException;

    public Index getIndex(String name) throws UPAException;

    public Entity getEntity(String name) throws UPAException;

    public Relationship getRelationship(String name) throws UPAException;

    public Relationship findRelationship(String name) throws UPAException;

    public Entity findEntity(String name) throws UPAException;

    public Entity findEntity(Class name) throws UPAException;

    public List<Entity> findEntities(Class entityType) throws UPAException;

    public List<Entity> getEntities() throws UPAException;

    public List<Field> getFields() throws UPAException;

    public List<Index> getIndexes() throws UPAException;

    public List<Package> getPackages() throws UPAException;

    public List<Relationship> getRelationships() throws UPAException;

    public Entity getEntity(Class entityType) throws UPAException;

    public Entity getEntityByIdType(Class idType) throws UPAException;

    public boolean containsEntity(String entityName) throws UPAException;

    public boolean containsEntity(Class entityType) throws UPAException;

    public List<Index> getIndexes(String entityName) throws UPAException;
}
