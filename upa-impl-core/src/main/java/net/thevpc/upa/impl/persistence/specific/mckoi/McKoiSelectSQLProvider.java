package net.thevpc.upa.impl.persistence.specific.mckoi;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.shared.sql.SelectSQLProvider;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class McKoiSelectSQLProvider extends SelectSQLProvider {

    public McKoiSelectSQLProvider() {
    }

    @Override
    public String getFromNullString(){
        return null;
    }
}
