/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 28 fevr. 03
 * Time: 15:13:10
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.thevpc.upa.impl;


import net.thevpc.upa.RemoveTrace;
import net.thevpc.upa.DeletionTraceElement;
import net.thevpc.upa.Entity;
import net.thevpc.upa.RelationshipType;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class DefaultRemoveTrace implements RemoveTrace {

    private Map<RelationshipType, Map<String, Long>> infos;
    private List<String> stackTrace;

    public DefaultRemoveTrace() {
        infos = new HashMap<RelationshipType, Map<String, Long>>(1);
        stackTrace = new ArrayList<String>(1);
    }


    public void addTrace(String trace) {
        stackTrace.add(trace);
    }

    public void add(RelationshipType type, Entity entity, long count) {
        add(type, entity.getName(), count);
    }

    private void add(RelationshipType type, String table, long count) {
        Map<String, Long> tabInfos = infos.get(type);
        if (tabInfos == null) {
            tabInfos = new HashMap<String, Long>();
            infos.put(type, tabInfos);
        }
        Long l = tabInfos.get(table);
        if (l == null) {
            tabInfos.put(table, count);
        }
        else {
            tabInfos.put(table, l + count);
        }
    }

    public void add(RemoveTrace other) {
        for (DeletionTraceElement dependencyElement : other.getTrace()) {
            add(dependencyElement.getRelationshipType(),dependencyElement.getEntityName(), dependencyElement.getCount());
        }
    }

    public DeletionTraceElement[] getTrace(RelationshipType type) {
        Map<String, Long> m = infos.get(type);
        ArrayList<DeletionTraceElement> elements = new ArrayList<DeletionTraceElement>();
        if(m!=null){
            for (Map.Entry<String, Long> e2 : m.entrySet()) {
                String tabName = e2.getKey();
                long tabCount = e2.getValue().longValue();
                if (tabCount > 0) {
                    elements.add(new DefaultDeletionTraceElement(type, tabName, tabCount));
                }
            }
        }
        return elements.toArray(new DeletionTraceElement[elements.size()]);
    }

    public DeletionTraceElement[] getTrace() {
        List<DeletionTraceElement> elements = new ArrayList<DeletionTraceElement>();
        for (Map.Entry<RelationshipType, Map<String, Long>> e : infos.entrySet()) {
            RelationshipType type = e.getKey();
            for (Map.Entry<String, Long> e2 : e.getValue().entrySet()) {
                String tabName = e2.getKey();
                long tabCount = e2.getValue().longValue();
                if (tabCount > 0) {
                    elements.add(new DefaultDeletionTraceElement(type, tabName, tabCount));
                }
            }
        }
        return elements.toArray(new DeletionTraceElement[elements.size()]);
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        boolean first = true;
        sb.append("DeleteInfo : ");
        for (Map.Entry<RelationshipType, Map<String, Long>> e : infos.entrySet()) {
            RelationshipType k = (RelationshipType) e.getKey();
            String typeName = k.name();
            sb.append("[").append(typeName).append("]=").append("{");
            for (Map.Entry<String, Long> e2 : e.getValue().entrySet()) {
                String tabName = e2.getKey();
                long tabCount = e2.getValue().longValue();
                if (tabCount > 0) {
                    if (first) {
                        first = false;
                    } else {
                        sb.append(" ; ");
                    }
                    sb.append(tabCount).append(" ").append(tabName);
                }
            }
        }


        sb.append("\n");
        sb.append("\tStackTrace={");
        sb.append("\n");
        for (String aStackTrace : stackTrace) {
            sb.append("\t\t");
            sb.append(aStackTrace);
            sb.append("\n");
        }
        sb.append("\t}");
        sb.append("\n");
        return sb.toString();
    }

    public long getRemoveCount() {
        long count = 0;
        for (Map.Entry<RelationshipType, Map<String, Long>> e : infos.entrySet()) {
            for (Map.Entry<String, Long> e2 : e.getValue().entrySet()) {
                long tabCount = e2.getValue().longValue();
                count += tabCount;
            }

        }

        return count;
    }

    public long getRemoveCount(RelationshipType type) {
        long count = 0;
        for (Map.Entry<RelationshipType, Map<String, Long>> e : infos.entrySet()) {
            RelationshipType k = e.getKey();
            if (k == type) {
                for (Map.Entry<String, Long> e2 : e.getValue().entrySet()) {
                    long tabCount = e2.getValue().longValue();
                    count += tabCount;
                }
            }
        }

        return count;
    }

}
