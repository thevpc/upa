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



namespace Net.Vpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author vpc
     */
    public class DefaultDecorationFilter : Net.Vpc.Upa.Impl.Config.Decorations.DecorationFilter {

        private System.Collections.Generic.ISet<string> typeAnnotations = new System.Collections.Generic.HashSet<string>();

        private System.Collections.Generic.ISet<string> methodsAnnotations = new System.Collections.Generic.HashSet<string>();

        private System.Collections.Generic.ISet<string> fieldsAnnotations = new System.Collections.Generic.HashSet<string>();

        public virtual bool AcceptTypeDecoration(string name, string targetType, object @value) {
            return typeAnnotations.Contains(name);
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.Config.DecorationTarget> GetDecorationTargets() {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.Config.DecorationTarget> i = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.Config.DecorationTarget>();
            if ((typeAnnotations).Count > 0) {
                i.Add(Net.Vpc.Upa.Config.DecorationTarget.TYPE);
            }
            if ((methodsAnnotations).Count > 0) {
                i.Add(Net.Vpc.Upa.Config.DecorationTarget.METHOD);
            }
            if ((fieldsAnnotations).Count > 0) {
                i.Add(Net.Vpc.Upa.Config.DecorationTarget.FIELD);
            }
            //        i += HIERARCHICAL;
            return i;
        }

        public virtual bool AcceptMethodDecoration(string name, string targetMethod, string targetType, object @value) {
            return methodsAnnotations.Contains(name);
        }

        public virtual bool AcceptFieldDecoration(string name, string targetField, string targetType, object @value) {
            return fieldsAnnotations.Contains(name);
        }

        public virtual Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter AddDecorations(params System.Type [] all) {
            foreach (System.Type c in all) {
                Java.Lang.Annotation.Target t = (Java.Lang.Annotation.Target) (Java.Lang.Annotation.Target)Net.Vpc.Upa.Impl.FwkConvertUtils.GetTypeCustomAttribute(c, typeof(Java.Lang.Annotation.Target));
                if (t == null) {
                    throw new System.ArgumentException (c + " seems not to be an annotation");
                }
                foreach (Java.Lang.Annotation.ElementType et in t.Value) {
                    switch(et) {
                        case Java.Lang.Annotation.ElementType.TYPE:
                            {
                                typeAnnotations.Add((c).FullName);
                                break;
                            }
                        case Java.Lang.Annotation.ElementType.FIELD:
                            {
                                fieldsAnnotations.Add((c).FullName);
                                break;
                            }
                        case Java.Lang.Annotation.ElementType.METHOD:
                            {
                                fieldsAnnotations.Add((c).FullName);
                                break;
                            }
                    }
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationFilter AddTypeDecorations(params string [] all) {
            foreach (string a in all) {
                typeAnnotations.Add(a);
            }
            return this;
        }
    }
}
