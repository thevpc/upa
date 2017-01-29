package net.vpc.upa.impl.util.classpath;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.util.PlatformUtils;

import java.net.URL;
import java.util.Iterator;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:00 PM
 */
@PortabilityHint(target = "C#", name = "partial")
public class URLClassIterable implements Iterable<Class> {

    protected static final Logger log = Logger.getLogger(URLClassIterable.class.getName());
    public URL[] urls;
    public ClassPathFilter configFilter;
    public ClassFilter classFilter;
//    private Map<Class, Set<Class>> entityClasses = new LinkedHashMap<Class, Set<Class>>();
//        Map<Class, Class> entityToPrimary = new LinkedHashMap<Class, Class>();
//    public Map<String, List<AnnotatedClass>> annotatedClassMap = new HashMap<String, List<AnnotatedClass>>();

//    public Set<Class> classAnnotations = new HashSet<Class>();
//    PersistenceNameStrategyConfig nameStrategyModel = null;
    public int nameStrategyModelConfigOrder = Integer.MIN_VALUE;
    public ClassLoader contextClassLoader;

    public URLClassIterable(URL[] urls, ClassPathFilter configFilter, ClassFilter classFilter) {
        this.urls = urls;
        this.configFilter = configFilter;
        this.classFilter = classFilter;
        this.contextClassLoader = PlatformUtils.getContextClassLoader();
    }

//    private void configureFolder(File rootFolder, File folder, ClassPathFilter typeFilter) throws MalformedURLException, ClassNotFoundException {
//        File[] files = folder.listFiles();
//        URL src = rootFolder.toURI().toURL();
//        if (files != null) {
//            for (File file : files) {
//                if (file.isDirectory()) {
//                    configureFolder(rootFolder, file, typeFilter);
//                } else if (file.isFile()) {
//                    String path = file.getPath().substring(rootFolder.getPath().length());
//                    configureClassURL(src, path);
//                }
//            }
//        }
//    }
//    protected String getMethodSig(Method method) {
//        StringBuilder types = new StringBuilder();
//        for (Class<?> parameterType : method.getParameterTypes()) {
//            if (types.length() > 0) {
//                types.append(",");
//            }
//            types.append(parameterType.getName());
//        }
//        return method.getName() + "(" + types + ")";
//    }
//    public void parse() throws IOException, ClassNotFoundException, URISyntaxException {
//        for (URL jarURL : urls) {
//            if (configFilter.acceptLibrary(jarURL)) {
//                log.log(Level.FINE, "configuration from  url : {0}", jarURL);
//                ClassPathRoot r = new ClassPathRoot(jarURL);
//                for (ClassPathResource cr : r) {
//                    configureClassURL(jarURL, cr.getPath());
//                }
//            } else {
//                log.log(Level.FINE, "ignoring  configuration from url : {0}", jarURL);
//            }
//        }
//    }
    public Iterator<Class> iterator() {
        return new URLClassIterableIterator(this);
    }

    Class configureClassURL(URL src, String path) throws ClassNotFoundException {
        if (path.startsWith("/")) {
            path = path.substring(1);
        }
//        URL url = contextClassLoader.getResource(path);
        if (path.endsWith(".class")) {
            String cls = path.substring(0, path.length() - ".class".length()).replace('/', '.');
            String pck = null;
            int endIndex = cls.lastIndexOf('.');
            if (endIndex > 0) {
                pck = cls.substring(0, endIndex);
            }
            int dollar = cls.indexOf('$');
            boolean anonymousClass = false;
            boolean innerClass = false;
            if (dollar >= 0) {
                innerClass = true;
                //special class
                if (dollar + 1 < cls.length()) {
                    String subName = cls.substring(dollar + 1);
                    if (subName != null && subName.length() > 0 && Character.isDigit(subName.charAt(0))) {
                        anonymousClass = true;
                    }
                }
            }
            if (!anonymousClass) {
                if (configFilter.acceptClassName(src, cls)) {
                    Class<?> aClass = null;
                    try {
                        aClass = PlatformUtils.forName(cls, false, contextClassLoader);
                    } catch (Throwable e) {
                        log.log(Level.FINE, "Unable to load class {0} for UPA configuration. Ignored", cls);
                    }
                    if (aClass != null) {
                        if (configFilter.acceptClass(src, cls, aClass)) {
                            if (classFilter == null || classFilter.accept(aClass)) {
                                return (aClass);
                            }
                        }
                    }
                } else {
//                      System.out.println(path);
//                      System.out.println("\tSOURCE  " + src);
//                      System.out.println("\tSYS URL " + sysURL);
//                      System.out.println("\tAPP URL " + url);
//                      System.out.println("\tPKG   " + (pck==null?"":Package.getPackage(pck)));
//                      System.out.println("\tCLASS " + Class.forName(cls,false,contextClassLoader));
                }
            }
        }
        return null;
    }

}
