/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.tree;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author vpc
 */
public class NativeObjectPersistenceTree {

    private final List<NativeObjectPersistenceTable> tables = new ArrayList<>();
    private final List<NativeObjectPersistenceView> views = new ArrayList<>();

    public List<NativeObjectPersistenceTable> getTables() {
        return tables;
    }

    public List<NativeObjectPersistenceView> getViews() {
        return views;
    }

}
