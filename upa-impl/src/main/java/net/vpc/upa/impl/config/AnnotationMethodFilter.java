package net.vpc.upa.impl.config;

import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import net.vpc.upa.MethodFilter;
import net.vpc.upa.impl.config.decorations.DecorationRepository;

/**
 * Simple MethodFilter that accepts method having the given Annotation defined.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/31/12 3:27 AM
 */
public class AnnotationMethodFilter implements MethodFilter {

    private Class<Annotation> annotationType;
    private DecorationRepository decorationRepository;

    /**
     * simple constructor
     *
     * @param annotationType annotation to look for
     */
    public AnnotationMethodFilter(Class<Annotation> annotationType, DecorationRepository decorationRepository) {
        this.annotationType = annotationType;
        this.decorationRepository = decorationRepository;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean accept(Method method) {
        return decorationRepository.getMethodDecoration(method, annotationType) != null;
    }
}
