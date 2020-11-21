package net.thevpc.upa.impl.navigator;


import net.thevpc.upa.Document;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.impl.upql.util.UPQLUtils;

public class IntegerKeyEntityNavigator extends DefaultEntityNavigator {

    public IntegerKeyEntityNavigator(Entity entity) {
        super(entity);
    }

    public int getNewValue(Field field) throws UPAException {
        Entity entity = field.getEntity();
        Select s = new Select().from(entity.getName(), UPQLUtils.THIS);
        s.field(new Plus(
                        new Coalesce(
                                new Max(new Var(new Var(UPQLUtils.THIS), field.getName())),
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
