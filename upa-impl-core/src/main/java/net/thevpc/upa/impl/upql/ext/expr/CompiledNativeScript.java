package net.thevpc.upa.impl.upql.ext.expr;

import java.util.ArrayList;

public class CompiledNativeScript {

    public CompiledNativeScript() {
        lines = new ArrayList<String>();
    }

    public void addStatement(String stmt) {
        if (stmt != null) {
            lines.add(stmt);
        }
    }

    public void addScript(CompiledNativeScript script) {
        if (script != null) {
            for (int i = 0; i < script.size(); i++) {
                addStatement(script.getStatement(i));
            }
        }
    }

    public String getStatement(int i) {
        return lines.get(i);
    }

    public int size() {
        return lines.size();
    }

    public String toSql() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < lines.size(); i++) {
            if (i > 0) {
                sb.append("\n");
            }
            String s = lines.get(i);
            if (s != null) {
                sb.append(s);
                if (!s.endsWith(";")) {
                    sb.append(" ;");
                }
            }
        }

        return sb.toString();
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < lines.size(); i++) {
            if (i > 0) {
                sb.append("\n");
            }
            sb.append(lines.get(i));
        }

        return sb.toString();
    }

    private ArrayList<String> lines;
}
