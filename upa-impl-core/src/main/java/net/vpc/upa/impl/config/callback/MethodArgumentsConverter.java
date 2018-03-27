package net.vpc.upa.impl.config.callback;

/**
 * Created by vpc on 7/25/15.
 * transform API Arguments to user Arguments
 */
public interface MethodArgumentsConverter {
    Object[] convert(Object[] apiArguments);
}
