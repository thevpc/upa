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



namespace Net.Vpc.Upa.Impl.Util.Classpath
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 1:00 PM
     */

    public partial class DecorationParser {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.Classpath.DecorationParser)).FullName);

        public System.Collections.Generic.IEnumerable<System.Type> urls;

        public int nameStrategyModelConfigOrder = System.Int32.MinValue;



        public string persistenceUnitName;

        public string persistenceGroupName;

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository newDecorationRepository = new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository("New", false);

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationFilter decorationFilter;

        public DecorationParser(System.Collections.Generic.IEnumerable<System.Type> urls, Net.Vpc.Upa.Impl.Config.Decorations.DecorationFilter decorationFilter, string persistenceGroupName, string persistenceUnitName, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository) {
            this.urls = urls;
            this.persistenceGroupName = persistenceGroupName;
            this.persistenceUnitName = persistenceUnitName;
            this.decorationFilter = decorationFilter;
            this.decorationRepository = decorationRepository;
        }

        public virtual Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository GetNewDecorationRepository() {
            return newDecorationRepository;
        }

        public virtual void Visit(System.Type type, Net.Vpc.Upa.Impl.Config.Decorations.DecorationFilter decorationFilter) {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.Config.DecorationTarget> kind = decorationFilter.GetDecorationTargets();
            bool types = kind.Contains(Net.Vpc.Upa.Config.DecorationTarget.TYPE);
            bool methods = kind.Contains(Net.Vpc.Upa.Config.DecorationTarget.METHOD);
            bool fields = kind.Contains(Net.Vpc.Upa.Config.DecorationTarget.FIELD);
            //        boolean tree = (kind & DecorationFilter.HIERARCHICAL) != 0;
            //        boolean someType = false;
            if (types) {
                System.Attribute[] annotations = null;
                try {
                    annotations = type.GetAnnotations();
                } catch (System.Exception e) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Ignored type {0} : {1}",null,new object[] { (type).FullName, e.ToString() }));
                }
                //ignore
                if (annotations != null) {
                    int pos = 0;
                    foreach (System.Attribute a in annotations) {
                        if (decorationFilter.AcceptTypeDecoration((a.GetType()).FullName, (type).FullName, type)) {
                            decorationRepository.Visit(new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration(a, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Config.DecorationTarget.TYPE, (type).FullName, null, pos));
                            newDecorationRepository.Visit(new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration(a, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Config.DecorationTarget.TYPE, (type).FullName, null, pos));
                        }
                        //                    someType = true;
                        pos++;
                    }
                }
            }
            if (methods) {
                System.Reflection.MethodInfo[] declaredMethods = null;
                try {
                    declaredMethods = type.GetMethods(System.Reflection.BindingFlags.Default);
                } catch (System.Exception e) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Ignored type {0} : {1}",null,new object[] { (type).FullName, e.ToString() }));
                }
                //ignore
                if (declaredMethods != null) {
                    foreach (System.Reflection.MethodInfo method in declaredMethods) {
                        int pos = 0;
                        foreach (System.Attribute a in method.GetAnnotations()) {
                            string methodSig = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetMethodSignature(method);
                            if (decorationFilter.AcceptMethodDecoration((a.GetType()).FullName, methodSig, (type).FullName, method)) {
                                decorationRepository.Visit(new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration(a, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Config.DecorationTarget.METHOD, ((method).DeclaringType).FullName, methodSig, pos));
                                newDecorationRepository.Visit(new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration(a, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Config.DecorationTarget.METHOD, ((method).DeclaringType).FullName, methodSig, pos));
                            }
                            pos++;
                        }
                    }
                }
            }
            if (fields) {
                System.Reflection.FieldInfo[] declaredFields = null;
                try {
                    declaredFields = type.GetFields(System.Reflection.BindingFlags.Default);
                } catch (System.Exception e) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Ignored type {0} : {1}",null,new object[] { (type).FullName, e.ToString() }));
                }
                //ignore
                if (declaredFields != null) {
                    foreach (System.Reflection.FieldInfo field in declaredFields) {
                        int pos = 0;
                        foreach (System.Attribute a in field.GetAnnotations()) {
                            if (decorationFilter.AcceptFieldDecoration((a.GetType()).FullName, (field).Name, (type).FullName, field)) {
                                decorationRepository.Visit(new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration(a, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Config.DecorationTarget.FIELD, ((field).DeclaringType).FullName, (field).Name, pos));
                                newDecorationRepository.Visit(new Net.Vpc.Upa.Impl.Config.Decorations.AnnotationDecoration(a, Net.Vpc.Upa.Config.DecorationSourceType.TYPE, Net.Vpc.Upa.Config.DecorationTarget.FIELD, ((field).DeclaringType).FullName, (field).Name, pos));
                            }
                            pos++;
                        }
                    }
                }
            }
        }

        public virtual Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository GetDecorationRepository() {
            return decorationRepository;
        }

        public virtual void Parse() /* throws System.IO.IOException, System.Exception, System.Exception */  {
            foreach (System.Type type in urls) {
                Visit(type, decorationFilter);
            }
        }
    }
}
