package net.vpc.upa.impl.navigator;


import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.uql.util.UQLUtils;

public class IntegerKeyEntityNavigator extends DefaultEntityNavigator {

    public IntegerKeyEntityNavigator(Entity entity) {
        super(entity);
    }

    public int getNewValue(Field field) throws UPAException {
        Entity entity = field.getEntity();
        Select s = new Select().from(entity.getName(), UQLUtils.THIS);
        s.field(new Plus(
                        new Coalesce(
                                new Max(new Var(new Var(UQLUtils.THIS), field.getName())),
                                new Literal(0)
                        ),
                        new Literal(1))
                , "nextValue");
        Document next = field.getPersistenceUnit().createQuery(s).getDocument();
        if (next != null) {
            return next.getInt("nextValue");
        } else {
            return 0;
        }
    }

    public Object getNewKey() throws UPAException {
        return entity.createId(getNewValue(entity.getIdFields().get(0)));
    }
}
