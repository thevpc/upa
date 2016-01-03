package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.impl.util.Converter;

/**
 * Created by vpc on 8/7/15.
 */
public class SequencePatternEvaluator implements Converter<String, String> {
    private Field field;
    private Object replacement;
    private Record record;

    public SequencePatternEvaluator(Field field, Object replacement, Record record) {
        this.field = field;
        this.replacement = replacement;
        this.record = record;
    }

    @Override
    public String convert(String v) {
        if (v.equals("#")) {
            return String.valueOf(replacement);
        }
        if (record != null && record.isSet(v)) {
            return String.valueOf(record.getObject(v));
        }
        Select s = new Select();
        s.field(new UserExpression(v), "customValue");
        return String.valueOf(field.getEntity().getPersistenceUnit().createQuery(s).getSingleValue());
    }
}
