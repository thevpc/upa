package net.vpc.upa.impl.navigator;


import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.upql.util.UPQLUtils;

public class LongKeyEntityNavigator extends DefaultEntityNavigator {

    public LongKeyEntityNavigator(Entity entity) {
        super(entity);
    }

    public long getNewValue(Field field) throws UPAException {
        Entity entity = field.getEntity();
        Select s = new Select().from(entity.getName(), UPQLUtils.THIS);
        s.field(new Plus(
                        new Coalesce(
                                new Max(new Var(new Var(UPQLUtils.THIS), field.getName())),
                                new Literal(0L)
                        ),
                        new Literal(1L)),
                "nextValue");
        Document next = field.getPersistenceUnit().createQuery(s).getDocument();
        if (next != null) {
            return next.getLong("nextValue");
        } else {
            return 0;
        }
    }

    public Object getNewKey() throws UPAException {
        return entity.createId(getNewValue(entity.getIdFields().get(0)));
    }
}
