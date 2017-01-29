package net.vpc.upa.impl.util.classpath;

import net.vpc.upa.PortabilityHint;

import java.io.IOException;
import java.lang.annotation.Annotation;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.net.URISyntaxException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.FlagSet;
import net.vpc.upa.impl.config.decorations.AnnotationDecoration;
import net.vpc.upa.impl.config.decorations.DecorationFilter;
import net.vpc.upa.config.DecorationSourceType;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.config.DecorationTarget;
import net.vpc.upa.impl.config.decorations.DefaultDecorationRepository;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:00 PM
 */
@PortabilityHint(target = "C#", name = "partial")
public class DecorationParser {

    private static final Logger log = Logger.getLogger(DecorationParser.class.getName());
    public Iterable<Class> urls;
    public int nameStrategyModelConfigOrder = Integer.MIN_VALUE;
    public String persistenceUnitName;
    public String persistenceGroupName;
    private DecorationRepository decorationRepository;
    private DecorationRepository newDecorationRepository = new DefaultDecorationRepository("New", false);
    private DecorationFilter decorationFilter;

    public DecorationParser(Iterable<Class> urls, DecorationFilter decorationFilter, String persistenceGroupName, String persistenceUnitName, DecorationRepository decorationRepository) {
        this.urls = urls;
        this.persistenceGroupName = persistenceGroupName;
        this.persistenceUnitName = persistenceUnitName;
        this.decorationFilter = decorationFilter;
        this.decorationRepository = decorationRepository;
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
    public DecorationRepository getNewDecorationRepository() {
        return newDecorationRepository;
    }

    public void visit(Class type, DecorationFilter decorationFilter) {
        FlagSet<DecorationTarget> kind = decorationFilter.getDecorationTargets();
        boolean types = kind.contains(DecorationTarget.TYPE);
        boolean methods = kind.contains(DecorationTarget.METHOD);
        boolean fields = kind.contains(DecorationTarget.FIELD);
//        boolean tree = (kind & DecorationFilter.HIERARCHICAL) != 0;
//        boolean someType = false;
        if (types) {
            Annotation[] annotations = null;
            try {
                annotations = type.getAnnotations();
            } catch (Throwable e) {
                log.log(Level.FINE, "Ignored type {0} : {1}", new Object[]{type.getName(), e.toString()});
                //ignore
            }
            if (annotations != null) {
                int pos = 0;
                for (Annotation a : annotations) {
                    if (decorationFilter.acceptTypeDecoration(a.annotationType().getName(), type.getName(), type)) {
                        decorationRepository.visit(new AnnotationDecoration(a, DecorationSourceType.TYPE, DecorationTarget.TYPE, type.getName(), null, pos));
                        newDecorationRepository.visit(new AnnotationDecoration(a, DecorationSourceType.TYPE, DecorationTarget.TYPE, type.getName(), null, pos));
//                    someType = true;
                    }
                    pos++;
                }
            }
        }
        if (methods /*&& (!tree || someType)*/) {
            Method[] declaredMethods = null;
            try {
                declaredMethods = type.getDeclaredMethods();
            } catch (Throwable e) {
                log.log(Level.FINE, "Ignored type {0} : {1}", new Object[]{type.getName(), e.toString()});
                //ignore
            }
            if (declaredMethods != null) {
                for (Method method : declaredMethods) {
                    int pos = 0;
                    for (Annotation a : method.getAnnotations()) {
                        String methodSig = PlatformUtils.getMethodSignature(method);
                        if (decorationFilter.acceptMethodDecoration(a.annotationType().getName(), methodSig, type.getName(), method)) {
                            decorationRepository.visit(new AnnotationDecoration(a, DecorationSourceType.TYPE, DecorationTarget.METHOD, method.getDeclaringClass().getName(), methodSig, pos));
                            newDecorationRepository.visit(new AnnotationDecoration(a, DecorationSourceType.TYPE, DecorationTarget.METHOD, method.getDeclaringClass().getName(), methodSig, pos));
                        }
                        pos++;
                    }
                }
            }
        }
        if (fields /*&& (!tree || someType)*/) {
            Field[] declaredFields = null;
            try {
                declaredFields = type.getDeclaredFields();
            } catch (Throwable e) {
                log.log(Level.FINE, "Ignored type {0} : {1}", new Object[]{type.getName(), e.toString()});
                //ignore
            }
            if (declaredFields != null) {
                for (Field field : declaredFields) {
                    int pos = 0;
                    for (Annotation a : field.getAnnotations()) {
                        if (decorationFilter.acceptFieldDecoration(a.annotationType().getName(), field.getName(), type.getName(), field)) {
                            decorationRepository.visit(new AnnotationDecoration(a, DecorationSourceType.TYPE, DecorationTarget.FIELD, field.getDeclaringClass().getName(), field.getName(), pos));
                            newDecorationRepository.visit(new AnnotationDecoration(a, DecorationSourceType.TYPE, DecorationTarget.FIELD, field.getDeclaringClass().getName(), field.getName(), pos));
                        }
                        pos++;
                    }
                }
            }
        }
    }

    public DecorationRepository getDecorationRepository() {
        return decorationRepository;
    }

//    public Decoration getDecoration(Class type, Class annotationClass) {
//        return UPAReflector.getDecoration(type, annotationClass, persistenceGroupName, persistenceUnitName, decorationRepository);
//    }
    public void parse() throws IOException, ClassNotFoundException, URISyntaxException {
        for (Class type : urls) {
            visit(type, decorationFilter);
        }
    }

}
