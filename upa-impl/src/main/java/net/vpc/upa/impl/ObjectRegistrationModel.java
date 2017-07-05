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

    boolean containsPackage(Package item, Package parent) throws UPAException;

    boolean containsEntity(Entity item, Package parent) throws UPAException;

    boolean containsField(Field item) throws UPAException;

    boolean containsIndex(Index item, Entity parent) throws UPAException;

    boolean containsRelationship(Relationship item) throws UPAException;

    boolean containsSection(Section item) throws UPAException;

    void registerPackage(Package item, Package parent) throws UPAException;

    void registerEntity(Entity item, Package parent) throws UPAException;

    void registerSection(Section item) throws UPAException;

    void registerField(Field item) throws UPAException;

    void registerIndex(Index item, Entity parent) throws UPAException;

    void registerRelationship(Relationship item) throws UPAException;

    void unregisterPackage(Package item) throws UPAException;

    void unregisterEntity(Entity item) throws UPAException;

    void unregisterSection(Section item) throws UPAException;

    void unregisterField(Field item) throws UPAException;

    void unregisterIndex(Index item) throws UPAException;

    void unregisterRelation(Relationship item) throws UPAException;

    Index getIndex(String name) throws UPAException;

    Entity getEntity(String name) throws UPAException;

    Relationship getRelationship(String name) throws UPAException;

    Relationship findRelationship(String name) throws UPAException;

    Entity findEntity(String name) throws UPAException;

    Entity findEntity(Class name) throws UPAException;

    List<Entity> findEntities(Class entityType) throws UPAException;

    List<Entity> getEntities() throws UPAException;

    List<Field> getFields() throws UPAException;

    List<Index> getIndexes() throws UPAException;

    List<Package> getPackages() throws UPAException;

    List<Relationship> getRelationships() throws UPAException;

    Entity getEntity(Class entityType) throws UPAException;

    Entity getEntityByIdType(Class idType) throws UPAException;

    boolean containsEntity(String entityName) throws UPAException;

    boolean containsEntity(Class entityType) throws UPAException;

    List<Index> getIndexes(String entityName) throws UPAException;
}
