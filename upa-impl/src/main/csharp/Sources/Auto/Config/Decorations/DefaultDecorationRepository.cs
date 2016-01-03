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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author vpc
     */
    public class DefaultDecorationRepository : Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository {

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo> decorationsByType = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.ISet<string>> typesByDecoration = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.ISet<string>>();

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository)).FullName);

        private string name;

        private bool enableLog;

        public DefaultDecorationRepository(string name, bool enableLog) {
            this.name = name;
            this.enableLog = enableLog;
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(System.Reflection.MethodInfo method) {
            return GetMethodDecorations(((method).DeclaringType).FullName, Net.Vpc.Upa.Impl.Util.PlatformUtils.GetMethodSignature(method));
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetFieldDecorations(System.Reflection.FieldInfo field) {
            return GetFieldDecorations(((field).DeclaringType).FullName, (field).Name);
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(System.Type type) {
            return GetTypeDecorations((type).FullName);
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetTypeDecoration(System.Type type, string annType) {
            return GetTypeDecoration((type).FullName, annType);
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetTypeDecoration(System.Type type, System.Type annType) {
            return GetTypeDecoration((type).FullName, (annType).FullName);
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(System.Type type, string annType) {
            return GetTypeDecorations((type).FullName, annType);
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(string type, string annType) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> found = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            foreach (Net.Vpc.Upa.Config.Decoration decoration in GetTypeDecorations(type)) {
                if (decoration.GetName().Equals(annType)) {
                    found.Add(decoration);
                }
            }
            return found.ToArray();
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetTypeDecoration(string type, string annType) {
            Net.Vpc.Upa.Config.Decoration[] found = GetTypeDecorations(type, annType);
            return found.Length == 0 ? null : found[0];
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(System.Reflection.MethodInfo method, string annType) {
            return GetMethodDecorations(((method).DeclaringType).FullName, Net.Vpc.Upa.Impl.Util.PlatformUtils.GetMethodSignature(method), annType);
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(string type, string method, string annType) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> found = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            foreach (Net.Vpc.Upa.Config.Decoration decoration in GetMethodDecorations(type, method)) {
                if (decoration.GetName().Equals(annType)) {
                    found.Add(decoration);
                }
            }
            return found.ToArray();
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetMethodDecoration(string type, string method, string annType) {
            Net.Vpc.Upa.Config.Decoration[] found = GetMethodDecorations(type, method, annType);
            return found.Length == 0 ? null : found[0];
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetMethodDecoration(System.Reflection.MethodInfo method, System.Type annType) {
            return GetMethodDecoration(method, (annType).FullName);
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetMethodDecoration(System.Reflection.MethodInfo method, string annType) {
            foreach (Net.Vpc.Upa.Config.Decoration decoration in GetMethodDecorations(method)) {
                if (decoration.GetName().Equals(annType)) {
                    return decoration;
                }
            }
            return null;
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetFieldDecoration(string type, string field, System.Type annType) {
            return GetFieldDecoration(type, field, (annType).FullName);
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetFieldDecoration(string type, string field, string annType) {
            foreach (Net.Vpc.Upa.Config.Decoration decoration in GetFieldDecorations(type, field)) {
                if (decoration.GetName().Equals(annType)) {
                    return decoration;
                }
            }
            return null;
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetFieldDecoration(System.Reflection.FieldInfo field, System.Type annType) {
            return GetFieldDecoration(field, (annType).FullName);
        }

        public virtual Net.Vpc.Upa.Config.Decoration GetFieldDecoration(System.Reflection.FieldInfo field, string annType) {
            foreach (Net.Vpc.Upa.Config.Decoration decoration in GetFieldDecorations(field)) {
                if (decoration.GetName().Equals(annType)) {
                    return decoration;
                }
            }
            return null;
        }

        public virtual void Visit(Net.Vpc.Upa.Config.Decoration d) {
            string typeName = d.GetLocationType();
            try {
                if (enableLog && typeName.ToLower().Contains("upalock")) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t[{0}] unexpected registration of {1}",null,new object[] { name, typeName }));
                }
            } catch (System.Exception e) {
                System.Console.WriteLine(e);
            }
            string methodOrFieldName = d.GetLocation();
            Net.Vpc.Upa.Config.DecorationTarget targetType = d.GetTarget();
            if (enableLog && /*IsLoggable=*/true) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("\t[{0}] register Decoration {1}",null,new object[] { name, d }));
            }
            Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo typeInfo = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo>(decorationsByType,typeName);
            if (typeInfo == null) {
                typeInfo = new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo();
                typeInfo.typeName = typeName;
                decorationsByType[typeName]=typeInfo;
            }
            if (targetType != null) {
                switch(targetType) {
                    case Net.Vpc.Upa.Config.DecorationTarget.TYPE:
                        {
                            if (typeInfo.decorations == null) {
                                typeInfo.decorations = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>(3);
                            }
                            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> m = typeInfo.decorations;
                            int found = -1;
                            for (int i = 0; i < (m).Count; i++) {
                                Net.Vpc.Upa.Config.Decoration m1 = m[i];
                                if (m1.GetName().Equals(d.GetName()) && m1.GetPosition() == d.GetPosition()) {
                                    found = i;
                                    break;
                                }
                            }
                            if (found < 0) {
                                m.Add(d);
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Config.DecorationTarget.METHOD:
                        {
                            if (typeInfo.methods == null) {
                                typeInfo.methods = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration>>();
                                System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> m = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
                                typeInfo.methods[methodOrFieldName]=m;
                                m.Add(d);
                            } else {
                                System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> m = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration>>(typeInfo.methods,methodOrFieldName);
                                if (m == null) {
                                    m = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
                                    typeInfo.methods[methodOrFieldName]=m;
                                }
                                int found = -1;
                                for (int i = 0; i < (m).Count; i++) {
                                    Net.Vpc.Upa.Config.Decoration m1 = m[i];
                                    if (m1.GetName().Equals(d.GetName()) && m1.GetPosition() == d.GetPosition()) {
                                        found = i;
                                        break;
                                    }
                                }
                                if (found < 0) {
                                    m.Add(d);
                                }
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Config.DecorationTarget.FIELD:
                        {
                            if (typeInfo.fields == null) {
                                typeInfo.fields = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration>>();
                                System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> m = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
                                typeInfo.fields[methodOrFieldName]=m;
                                m.Add(d);
                            } else {
                                System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> m = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration>>(typeInfo.fields,methodOrFieldName);
                                if (m == null) {
                                    m = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
                                    typeInfo.fields[methodOrFieldName]=m;
                                }
                                int found = -1;
                                for (int i = 0; i < (m).Count; i++) {
                                    Net.Vpc.Upa.Config.Decoration m1 = m[i];
                                    if (m1.GetName().Equals(d.GetName()) && m1.GetPosition() == d.GetPosition()) {
                                        found = i;
                                        break;
                                    }
                                }
                                if (found < 0) {
                                    m.Add(d);
                                }
                            }
                            break;
                        }
                }
            }
            System.Collections.Generic.ISet<string> tt = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.ISet<string>>(typesByDecoration,d.GetName());
            if (tt == null) {
                tt = new System.Collections.Generic.HashSet<string>();
                typesByDecoration[d.GetName()]=tt;
            }
            tt.Add(typeName);
        }

        public virtual string[] GetTypesForDecoration(string decorationName) {
            System.Collections.Generic.ISet<string> found = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.ISet<string>>(typesByDecoration,decorationName);
            return found == null ? ((string[])(new string[0])) : found.ToArray();
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetDeclaredDecorations(string decorationName) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> all = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Decoration>();
            System.Collections.Generic.ISet<string> found = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.ISet<string>>(typesByDecoration,decorationName);
            if (found != null) {
                foreach (string t in found) {
                    Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo dd = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo>(decorationsByType,t);
                    if (dd != null) {
                        foreach (Net.Vpc.Upa.Config.Decoration d in dd.decorations) {
                            if (d.GetName().Equals(decorationName)) {
                                all.Add(d);
                            }
                        }
                    }
                }
            }
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(all, null);
            return all.ToArray();
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetTypeDecorations(string type) {
            Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo typeInf = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo>(decorationsByType,type);
            if (typeInf != null && typeInf.decorations != null) {
                return typeInf.decorations.ToArray();
            }
            return new Net.Vpc.Upa.Config.Decoration[0];
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetMethodDecorations(string type, string method) {
            Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo typeInf = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo>(decorationsByType,type);
            if (typeInf != null && typeInf.methods != null) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> _deco = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration>>(typeInf.methods,method);
                if (_deco != null) {
                    return _deco.ToArray();
                }
            }
            return new Net.Vpc.Upa.Config.Decoration[0];
        }

        public virtual Net.Vpc.Upa.Config.Decoration[] GetFieldDecorations(string type, string field) {
            Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo typeInf = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepositoryTypeInfo>(decorationsByType,type);
            if (typeInf != null && typeInf.fields != null) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration> _deco = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Config.Decoration>>(typeInf.fields,field);
                if (_deco != null) {
                    return _deco.ToArray();
                }
            }
            return new Net.Vpc.Upa.Config.Decoration[0];
        }
    }
}
