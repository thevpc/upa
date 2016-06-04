/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.util.HashMap;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class ExpansionVisitTracker {

    private HashMap<String, Integer> map = new HashMap<String, Integer>();
    private int maxEntityDepth = 2;
//    private int maxGlobalDepth = 10;
    private int navigationDepth = 2;

    public ExpansionVisitTracker() {
    }

    public ExpansionVisitTracker(int navigationDepth) {
        this.navigationDepth = navigationDepth<0?2:navigationDepth;
    }

    public boolean nextVisit(String entity) {
        int i = getVisited(entity);
        if (i > 0) {
            decVisited(entity);
            return true;
        }
        return false;
    }

    public int getVisited(String entity) {
        Integer i = map.get(entity);
        return i == null ? maxEntityDepth : i;
    }

    public void decNavigationDepth() {
        navigationDepth--;
    }

    public void decVisited(String entity) {
        map.put(entity, getVisited(entity) - 1);
    }

    public ExpansionVisitTracker dive() {
        if (navigationDepth > 0) {
            ExpansionVisitTracker cc = copy();
            cc.navigationDepth--;
            return cc;
        }
        return null;
    }

    public ExpansionVisitTracker copy() {
        ExpansionVisitTracker r = new ExpansionVisitTracker();
        r.map.putAll(map);
        r.maxEntityDepth = maxEntityDepth;
//        r.maxGlobalDepth = maxGlobalDepth;
        r.navigationDepth = navigationDepth;
        return r;
    }

    @Override
    public String toString() {
        return "ExpansionVisitTracker{maxEntityDepth=" + maxEntityDepth + ", navigationDepth=" + navigationDepth+ ", map=" + map + '}';
    }
    
}
