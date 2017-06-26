package net.vpc.upa;

import net.vpc.upa.callbacks.UPAEvent;

/**
 * Created by vpc on 7/25/15.
 */
public interface PreparedCallback extends Callback {
    void prepare(UPAEvent event);

}
