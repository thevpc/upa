package net.thevpc.upa.impl.util.classpath;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:05 PM
 */
public class AcceptAllClassFilter implements ClassFilter{
    public static final AcceptAllClassFilter INSTANCE=new AcceptAllClassFilter();
    public boolean accept(Class cls) {
        return true;
    }
}
