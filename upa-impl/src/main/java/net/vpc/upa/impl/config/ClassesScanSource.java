package net.vpc.upa.impl.config;

import java.util.Arrays;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/24/12 3:01 AM
 */
public class ClassesScanSource extends BaseScanSource {

    private final Class[] classes;
    private boolean noIgnore;

    public ClassesScanSource(Class[] classes, boolean noIgnore) {
        this.classes = classes;
        this.noIgnore = noIgnore;
    }

    public boolean isNoIgnore() {
        return noIgnore;
    }

    public Class[] getClasses() {
        return classes;
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "{" + Arrays.toString(classes) + "}";
    }

    @Override
    public Iterable<Class> toIterable(Object context) {
        return Arrays.asList(classes);
    }

}
