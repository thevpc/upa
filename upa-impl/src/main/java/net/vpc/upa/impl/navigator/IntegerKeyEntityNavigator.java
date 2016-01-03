package net.vpc.upa.impl.navigator;


import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;

public class IntegerKeyEntityNavigator extends DefaultEntityNavigator {

    public IntegerKeyEntityNavigator(Entity entity) {
        super(entity);
    }

    public int getNewValue(Field field) throws UPAException {
        Entity entity=field.getEntity();
        Select s=new Select().from(entity.getName());
        s.field(new Plus(
                new Coalesce(new Max(new Var(field.getName())),new Literal(0)),
                new Literal(1))
                ,"nextValue");
        Record next = field.getPersistenceUnit().createQuery(s).getRecord();
        if(next!=null){
            return next.getInt("nextValue");
        }else{
            return 0;
        }
    }

    public Object getNewKey() throws UPAException {
        return entity.createId(getNewValue(entity.getPrimaryFields().get(0)));
    }
}
