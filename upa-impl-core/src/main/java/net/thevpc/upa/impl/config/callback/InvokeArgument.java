package net.thevpc.upa.impl.config.callback;

/**
 * Created by vpc on 7/25/15.
 */
public interface InvokeArgument {
    String getName();

    Class getPlatformType();

    Object getValue(Object[] arguments);

    boolean isAcceptSubClasses();
}
