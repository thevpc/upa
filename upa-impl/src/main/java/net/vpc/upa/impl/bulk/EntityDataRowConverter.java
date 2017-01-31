package net.vpc.upa.impl.bulk;

import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataRowConverter;
import net.vpc.upa.filters.FieldFilter;

import java.util.List;

/**
 * @author taha.bensalah@gmail.com on 7/10/16.
 */
@PortabilityHint(target = "C#",name = "todo")
class EntityDataRowConverter implements DataRowConverter {
    private DataColumn[] columns;
    private List<Field> fields;
    private Entity entity;

    public EntityDataRowConverter(Entity entity, FieldFilter filter) {
        this.entity = entity;
        fields = entity.getFields(filter);
        columns = new DataColumn[fields.size()];
        for (int i = 0; i < columns.length; i++) {
            Field field = fields.get(i);
            DataColumn cc = new DataColumn(i, field.getName());
            cc.setDataType(field.getDataType());
            //should call i18n
            cc.setTitle(field.getName());
            cc.setTitle(field.getName());
            columns[i] = cc;

        }
    }

    @Override
    public DataColumn[] getColumns() {
        return columns;
    }

    @Override
    public Object[] objectToRow(Object o) {
        Document document = entity.getBuilder().objectToDocument(o, false);
        Object[] vals = new Object[columns.length];
        for (int i = 0; i < vals.length; i++) {
            vals[i] = document.getObject(fields.get(i).getName());
        }
        return vals;
    }
}
