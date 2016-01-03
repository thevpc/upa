/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * Simple MethodFilter that accepts method having the given Annotation defined.
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/31/12 3:27 AM
     */
    public class AnnotationMethodFilter : Net.Vpc.Upa.MethodFilter {

        private System.Type annotationType;

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        /**
             * simple constructor
             *
             * @param annotationType annotation to look for
             */
        public AnnotationMethodFilter(System.Type annotationType, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository) {
            this.annotationType = annotationType;
            this.decorationRepository = decorationRepository;
        }

        /**
             * {@inheritDoc}
             */

        public virtual bool Accept(System.Reflection.MethodInfo method) {
            return decorationRepository.GetMethodDecoration(method, annotationType) != null;
        }
    }
}
