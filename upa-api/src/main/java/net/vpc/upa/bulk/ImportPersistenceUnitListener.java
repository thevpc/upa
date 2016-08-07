/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.bulk;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface ImportPersistenceUnitListener {

    void objectPersisted(String entityName, Object source, Object target);

    void objectMerged(String entityName, Object source, Object target);

    void objectPersistFailed(String entityName, Object source, Object target, Exception error) throws Exception;

    void objectMergeFailed(String entityName, Object source, Object target, Exception error) throws Exception;
}
