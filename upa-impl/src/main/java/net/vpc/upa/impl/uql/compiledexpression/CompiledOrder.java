/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 6 janv. 03
 * Time: 23:11:47
 * To change template for new class use 
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.io.Serializable;
import java.util.ArrayList;

public class CompiledOrder implements Serializable, Cloneable {

    private ArrayList<CompiledOrderItem> items = new ArrayList<CompiledOrderItem>(1);

    public CompiledOrder() {
    }

    public CompiledOrder ascendant(CompiledExpressionExt field) {
        return addOrder(field, true);
    }

    public CompiledOrder descendant(CompiledExpressionExt field) {
        return addOrder(field, false);
    }

    public CompiledOrder addOrder(CompiledOrder order) {
        for (CompiledOrderItem field : order.items) {
            items.add(new CompiledOrderItem(field.getExpression(), field.isAsc()));
        }
        return this;
    }

    public CompiledOrder addOrder(CompiledExpressionExt field, boolean is_asc) {
        items.add(new CompiledOrderItem(field, is_asc));
        return this;
    }

    public int indexOf(CompiledExpressionExt field) {
        for (int i = 0; i < items.size(); i++) {
            if (items.get(i).getExpression().equals(field)) {
                return i;
            }
        }
        return -1;
    }

    public CompiledOrder removeOrder(CompiledExpressionExt field) {

        int i = indexOf(field);
        if (i >= 0) {
            items.remove(i);
        }
        return this;
    }

    public CompiledOrder removeOrder(int index) {
        items.remove(index);
        return this;
    }

    public CompiledOrder insertOrder(int index, CompiledExpressionExt field, boolean is_asc) {
        items.add(index, new CompiledOrderItem(field, is_asc));
        return this;
    }

    public void setOrderAt(int index, CompiledExpressionExt expression) {
        items.get(index).setExpression(expression);
    }

    public CompiledExpressionExt getOrderAt(int index) {
        return items.get(index).getExpression();
    }

    public boolean isAscendentAt(int index) {
        return items.get(index).isAsc();
    }

    public ArrayList<CompiledOrderItem> getItems() {
        return items;
    }

    public int size() {
        return items.size();
    }

    public CompiledOrder clear() {
        items.clear();
        return this;
    }

    public CompiledOrder noOrder() {
        items.clear();
        return this;
    }

    public CompiledOrder copy() {
        CompiledOrder o = new CompiledOrder();
        for (CompiledOrderItem i : items) {
            o.items.add(new CompiledOrderItem(i.getExpression().copy(), i.isAsc()));
        }
        return o;
    }
//    public String toSQL(PersistenceUnitFilter database){
//        int max=fields.size();
//        if(max==0) return "";
//        StringBuffer sb=new StringBuffer("ORDER BY ");
//        for (int i = 0; i < max; i++) {
//            if (i > 0)
//                sb.append(", ");
//            sb.append(((Expression) fields.get(i)).toSQL(database));
//            if(((Boolean) asc.get(i))==Boolean.TRUE){
//                sb.append(" ASC ");
//            }else{
//                sb.append(" DESC ");
//            }
//        }
//        return sb.toString();
//    }
}
