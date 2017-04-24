package net.vpc.upa.impl.uql.compiledexpression;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.impl.uql.DecObjectType;

public class CompiledInsertSelection extends DefaultCompiledEntityStatement
        implements CompiledUpdateStatement, Cloneable {

    private static final long serialVersionUID = 1L;
    private CompiledQueryStatement selection;
    private ArrayList<CompiledVar> fields;
    private CompiledEntityName entity;
    private String tableAlias;

    public CompiledInsertSelection() {
        selection = null;
        fields = new ArrayList<CompiledVar>(1);
    }

    public CompiledInsertSelection(CompiledInsertSelection other) {
        this();
        addQuery(other);
    }

    private CompiledInsertSelection into(String entity, String alias) {
        this.entity = new CompiledEntityName(entity);
        tableAlias = alias;
        prepareChildren(this.entity);
        exportDeclaration(alias, DecObjectType.ENTITY, entity, alias);
        return this;
    }

    public CompiledInsertSelection into(String entity) {
        return into(entity, null);
    }

    public CompiledEntityName getEntity() {
        return entity;
    }

    public String getTableAlias() {
        return tableAlias;
    }

    public int size() {
        return 3;
    }

    public CompiledInsertSelection addQuery(CompiledInsertSelection other) {
        if (other == null) {
            return this;
        }
        if (other.entity != null) {
            entity = other.entity;
            if (other.tableAlias != null) {
                tableAlias = other.tableAlias;
            }
            prepareChildren(this.entity);
            exportDeclaration(tableAlias, DecObjectType.ENTITY, other.entity.getName(), null);
        }
        for (int i = 0; i < other.fields.size(); i++) {
            field(other.getField(i).getName());
        }

        if (other.selection != null) {
            selection = (CompiledQueryStatement) other.selection.copy();
        }
        return this;
    }

    public DefaultCompiledExpression copy() {
        CompiledInsertSelection o = new CompiledInsertSelection();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.addQuery(this);
        return o;
    }

    public CompiledInsertSelection field(String key) {
        fields.add(new CompiledVar(key));
        return this;
    }

    public CompiledInsertSelection field(String[] keys) {
        for (String key : keys) {
            field(key);
        }

        return this;
    }

    public CompiledInsertSelection from(CompiledQueryStatement selection) {
        this.selection = selection;
        return this;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        if (query == null) {
//            StringBuffer sb = new StringBuffer("Insert Into " + entity);
//            if (tableAlias != null)
//                sb.append(" ").append(tableAlias);
//            sb.append("(");
//            boolean isFirst = true;
//            for (int i = 0; i < fields.size(); i++) {
//                if (isFirst)
//                    isFirst = false;
//                else
//                    sb.append(", ");
//                sb.append(fields.get(i));
//            }
//
//            query = sb.append(") ").append(selection.toSQL(database)).toString();
//        }
//        return query;
//    }
    public int countFields() {
        return fields.size();
    }

    public CompiledVar getField(int i) {
        return fields.get(i);
    }

    public CompiledQueryStatement getSelection() {
        return selection;
    }

    @Override
    public boolean isValid() {
        return entity != null && fields.size() > 0 && selection.isValid();
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        ArrayList<DefaultCompiledExpression> all = new ArrayList<DefaultCompiledExpression>();
        if (entity != null) {
            all.add(entity);
        }
        /**
         * this will not work because in C# all and fields have different types
         */
        //all.addAll(fields);
        for (CompiledVar field : fields) {
            all.add(field);
        }
        all.add(selection);
        return all.toArray(new DefaultCompiledExpression[all.size()]);
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if (index == 0) {
            entity = (CompiledEntityName) expression;
        } else if (index - 1 < fields.size()) {
            fields.set(index - 1, (CompiledVar) expression);
        } else {
            selection = (CompiledSelect) expression;
        }
    }

    protected List<CompiledNamedExpression> findEntityDefinitions() {
        ArrayList<CompiledNamedExpression> list = new ArrayList<CompiledNamedExpression>();
        list.add(new CompiledNamedExpression(null, getEntity()));
        return list;
    }
}
