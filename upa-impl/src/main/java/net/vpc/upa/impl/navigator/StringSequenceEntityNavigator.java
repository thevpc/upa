/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.navigator;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Equals;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.EntitySequenceManager;
import net.vpc.upa.impl.SequenceManager;
import net.vpc.upa.impl.PrivateSequence;
import net.vpc.upa.impl.persistence.SequencePatternEvaluator;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class StringSequenceEntityNavigator extends DefaultEntityNavigator {

    /**
     * {yy}{#}
     */
    private String format;
    private String group;
    private String name;
    private int initialValue;
    private int allocationSize;

    public StringSequenceEntityNavigator(Entity entity, String name, String format, String group, int initialValue, int allocationSize) {
        super(entity);
        this.format = format;
        this.group = group;
        this.name = name;
        this.initialValue = initialValue;
        this.allocationSize = allocationSize;
        if (this.format == null) {
            this.format = "{#}";
        }
        if (this.group == null) {
            this.group = format;
        }
    }

    @Override
    public Object getNewKey()
            throws UPAException {
        return entity.createId(getNewValue(entity.getPrimaryFields().get(0)));
    }

    private String getNewValue(Field field)
            throws UPAException {
        Entity entity = field.getEntity();
        String idName = field.getName();
        Entity seq = entity.getPersistenceUnit().getEntity(PrivateSequence.ENTITY_NAME);

        SequenceManager sm = new EntitySequenceManager(seq);
        final String sequenceGroup = eval(field, this.group, "{#}");
        while (true) {
            final String nextIdString = eval(field,this.format, sm.nextValue(name, sequenceGroup,this.initialValue,this.allocationSize));
            long count = entity.getEntityCount(new Equals(new Var(idName), nextIdString));
            if (count==0) {
                return nextIdString;
            }
        }
    }

    private String eval(final Field field,String pattern, final Object replacement) {
        return StringUtils.replaceNoDollarVars(pattern, new SequencePatternEvaluator(field, replacement,null));
    }

//    public String getNewValue(Field field)
//            throws UPAException {
//        Entity table = field.getEntity();
//        String idName = field.getName();
//        Entity<Key, PrivateSequence> seq = table.getPersistenceUnit().getEntity(sequenceTable);
//
//        SequenceManager sm = new EntitySequenceManager(seq);
//        final String sequenceName = getSequenceName();
//        sm.getOrCreateSequence(name, sequenceName, initialValue, allocationSize);
//        int i = sm.getCurrentValue(name, sequenceName);
//        while (true) {
//            final String nextIdString = getValue(i);
//            List<Document> list = table.createQueryBuilder().setExpression(new Equals(new Var(idName), nextIdString)).setFieldFilter(new FieldNameFilter(idName)).getDocumentList();
//            if (list.isEmpty()) {
//                return nextIdString;
//            }
//            i = sm.nextValue(name, sequenceName);
//        }
//    }
//
//    public String getValue(int v) {
//        Pattern p = Pattern.compile("\\{[^\\{\\}]*\\}");
//        final Matcher m = p.matcher(format);
//        StringBuffer sb = new StringBuffer();
//        boolean result;
//        while (result = m.find()) {
//            final String g = m.group();
//            if (g.equals("{#}")) {
//                m.appendReplacement(sb, String.valueOf(v));
//            } else {
//                SimpleDateFormat d = new SimpleDateFormat(g.substring(1, g.length() - 1));
//                m.appendReplacement(sb, d.format(new Date()));
//            }
//        }
//        return sb.toString();
//    }
//
//    public String getSequenceName() {
//        Pattern p = Pattern.compile("\\{[^\\{\\}]*\\}");
//        final Matcher m = p.matcher(format);
//        StringBuffer sb = new StringBuffer(name == null ? "" : name);
//        boolean result;
//        while (result = m.find()) {
//            final String g = m.group();
//            if (g.equals("{#}")) {
//                //m.appendReplacement(sb, g);
//            } else {
//                SimpleDateFormat d = new SimpleDateFormat(g.substring(1, g.length() - 1));
//                m.appendReplacement(sb, d.format(new Date()));
//            }
//        }
//        return sb.toString();
//    }

    protected void setPattern(String pattern) {
        this.format = pattern;
    }

    protected void setName(String name) {
        this.name = name;
    }

}
